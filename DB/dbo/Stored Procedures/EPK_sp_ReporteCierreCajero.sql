--=============================================
-- Author:		sderkoyorikian
-- Create date: 29/08/2013
-- Description:	Consulta Cierre de ventas
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteCierreCajero] 
	@FechaDesde date,
	@FechaHasta date,
	@IdCaja		int = NULL,
	@Cajero		varchar(50) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @idE INT, @FormaPago VARCHAR(100)

	SELECT @idE = dbo.fn_ObtenerParametroEntero ('ID_EFECTIVO', getdate(),1)

	--DECLARE @FechaDesde DATE = '20130801',@FechaHasta DATE = '20130829'
	SELECT	Cajero, IdCierre, Fecha,  cast ((cast (datepart(hour,Hora) as varchar(2))+':'+cast (datepart(minute,Hora) as varchar)) as time) Hora, 
			Caja,	IdFormaPago, FormaPago, 
			Banco, POS, Lote, MontoPagos /*+ ISNULL((SELECT SUM(AD.Cantidad * D.Denominacion) 
																FROM EPK_AperturaCajeroEncabezado ae
																INNER JOIN EPK_AperturaCajeroDenominacion AD
																	ON AE.IdApertura = AD.IdApertura 
																INNER JOIN EPK_Denominacion D
																	ON AD.IdDenominacion = D.IdDenominacion 
																WHERE AE.IdCierre = T.IdCierre), 0)*/ MontoPagos,
			 MontoCierre /*- ISNULL((SELECT SUM(AD.Cantidad * D.Denominacion) 
						FROM EPK_AperturaCajeroEncabezado ae
						INNER JOIN EPK_AperturaCajeroDenominacion AD
							ON AE.IdApertura = AD.IdApertura 
						INNER JOIN EPK_Denominacion D
							ON AD.IdDenominacion = D.IdDenominacion 
						WHERE	Fecha BETWEEN @FechaDesde AND @FechaHasta
						AND		(@IdCaja	IS NULL OR IdCaja =@IdCaja)
						AND		(@IdCajero  IS NULL OR IdCajero =@IdCajero)
						), 0) */MontoCierre, 
			MontoPagos - MontoCierre/*(MontoCierre  - ISNULL((SELECT SUM(AD.Cantidad * D.Denominacion) 
						FROM EPK_AperturaCajeroEncabezado ae
						INNER JOIN EPK_AperturaCajeroDenominacion AD
							ON AE.IdApertura = AD.IdApertura 
						INNER JOIN EPK_Denominacion D
							ON AD.IdDenominacion = D.IdDenominacion 
						WHERE	AE.IdCierre = T.IdCierre), 0))*/ Diferencia 
	FROM 
		(
		SELECT	 U.Identificacion Cajero, ce.IdCierre, CE.Fecha,  ce.Hora, 
				 C.Descripcion Caja,	FP.IdFormaPago,	fp.Descripcion FormaPago,
				 NULL Banco,			NULL POS,		NULL Lote,				 MontoPagos, 
				    CASE	WHEN cp.IdFormaPago = @idE 
							THEN ISNULL((SELECT SUM(TotalAprobado) 
										FROM EPK_AlivioEfectivoEncabezado ae
										WHERE ae.FechaAlivio between @FechaDesde and @FechaHasta 
										AND AE.HoraAlivio BETWEEN APE.Hora AND CE.Hora 
										AND AE.IdUsuarioCajero = ce.IdCajero ), 0) 					
							ELSE MontoCierre END MontoCierre , 
					MontoPagos - (CASE	WHEN cp.IdFormaPago = @idE 
								THEN ISNULL((SELECT SUM(TotalAprobado) 
											FROM EPK_AlivioEfectivoEncabezado ae
											WHERE ae.FechaAlivio between @FechaDesde and @FechaHasta
											AND AE.HoraAlivio BETWEEN APE.Hora AND CE.Hora 
											AND AE.IdUsuarioCajero = ce.IdCajero ), 0) 					
											ELSE MontoCierre END) Diefrencia
		    FROM EPK_CierreCajeroEncabezado ce
		    INNER JOIN EPK_CierreCajeroPagos cp
			    ON ce.IdCierre = cp.IdCierre 
			INNER JOIN EPK_AperturaCajeroEncabezado APE
				ON APE.IdCierre = ce.IdCierre
		    INNER JOIN EPK_FormaPago fp
			    ON cp.IdFormaPago = fp.IdFormaPago 
			INNER JOIN EPK_Usuario U
				ON CE.IdCajero = U.IdUsuario
			INNER JOIN EPK_Caja C 
				ON CE.IdCaja = C.IdCaja  
            WHERE CE.Fecha BETWEEN @FechaDesde AND @FechaHasta 
			AND (@Cajero  IS NULL OR U.Identificacion  LIKE '%'+@Cajero+'%' )
			AND (@IdCaja IS NULL OR CE.IdCaja = @IdCaja)
		UNION ALL
		SELECT  U.Identificacion Cajero,
				E.IdCierre,				E.Fecha,		E.Hora, 			
				C.Descripcion Caja,		FP.IdFormaPago,	FP.Descripcion FormaPago, 
				ENT.Nombre Banco,	POS.Descripcion POS,	CP.LotePOS Lote, 
				CP.MontoPago ,		CP.MontoPOS MontoCierre,	CP.MontoPago - CP.MontoPOS Diferencia
		FROM EPK_CierreCajeroEncabezado E
		INNER JOIN EPK_CierreCajeroPOS CP
			ON E.IdCierre = CP.IdCierre 
		INNER JOIN EPK_FormaPago FP
			ON CP.IdFormaPago = FP.IdFormaPago  
		INNER JOIN EPK_POS POS
			ON POS.IdPOS = CP.IdPOS 
		INNER JOIN EPK_EntidadFinanciera ENT
			ON ENT.IdEntidad = POS.IdEntidad 
		INNER JOIN EPK_Caja C
			ON E.IdCaja = C.IdCaja
		INNER JOIN EPK_Usuario U
			ON E.IdCajero = U.IdUsuario 
		WHERE	Fecha BETWEEN @FechaDesde AND @FechaHasta
		AND		(@IdCaja	IS NULL OR e.IdCaja =@IdCaja)
		AND		(@Cajero  IS NULL OR U.Identificacion  LIKE '%'+@Cajero+'%' )) T
	ORDER BY t.IdCierre,  t.IdFormaPago 
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ReporteCierreCajero] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteCierreCajero] TO PUBLIC
    AS [dbo];

