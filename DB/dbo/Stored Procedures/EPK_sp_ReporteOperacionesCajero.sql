
CREATE PROCEDURE [dbo].[EPK_sp_ReporteOperacionesCajero]
    @FechaDesde date,
	@FechaHasta date,
	@IdCaja		int = NULL,
	@Cajero     varchar (50) = NULL
AS
    BEGIN
	    BEGIN TRY 
		    -- SET NOCOUNT ON added to prevent extra result sets from
		    -- interfering with SELECT statements.
		    SET NOCOUNT ON;
		
		    DECLARE @idE INT, @FormaPago VARCHAR(100)

		    SELECT @idE = dbo.fn_ObtenerParametroEntero ('ID_EFECTIVO', getdate(),1)
		
		    SELECT @FormaPago = Descripcion 
		    FROM EPK_FormaPago 
		    WHERE IdFormaPago = @idE 

		    SELECT	ae.IdApertura, C.Descripcion Caja, U.Identificacion Cajero, ae.Fecha, cast ((cast (datepart(hour,ae.Hora) as varchar(2))+':'+cast (datepart(minute,ae.Hora) as varchar)) as time) Hora, 
				    @FormaPago FormaPago, SUM (d.Denominacion * ad.Cantidad) MontoOperacion, 
				    SUM (d.Denominacion * ad.Cantidad)  Montofisico, 0 Diferencia,  '' Observacion,	'Apertura' Operacion
		    FROM EPK_AperturaCajeroEncabezado ae  
		    INNER JOIN EPK_AperturaCajeroDenominacion ad
			    ON ae.IdApertura = ad.IdApertura 
		    INNER JOIN EPK_Denominacion d
			    ON ad.IdDenominacion = d.IdDenominacion
			INNER JOIN EPK_Usuario U
				ON AE.IdCajero = U.IdUsuario 
			INNER JOIN EPK_Caja C 
				ON AE.IdCaja = C.IdCaja 
			WHERE AE.Fecha BETWEEN @FechaDesde AND @FechaHasta 
			AND (@Cajero IS NULL OR U.Identificacion LIKE '%'+ @Cajero  +'%')
			--AND (@IdCajero IS NULL OR AE.IdCajero = @IdCajero )
			AND (@IdCaja IS NULL OR AE.IdCaja = @IdCaja)
		    GROUP BY ae.IdApertura, C.Descripcion, u.Identificacion, ae.Fecha, ae.Fecha,  ae.Hora
		    UNION ALL
		    SELECT	ce.IdCierre, C.Descripcion Caja, U.Identificacion Cajero, CE.Fecha,  cast ((cast (datepart(hour,ce.Hora) as varchar(2))+':'+cast (datepart(minute,ce.Hora) as varchar)) as time) Hora, 
				    fp.Descripcion , MontoPagos, 
				    CASE	WHEN cp.IdFormaPago = @idE 
							THEN ISNULL((SELECT SUM(TotalAprobado) 
										FROM EPK_AlivioEfectivoEncabezado ae
										WHERE ae.FechaAlivio = ce.Fecha
										AND AE.HoraAlivio BETWEEN APE.Hora AND CE.Hora 
										AND AE.IdUsuarioCajero = ce.IdCajero ), 0) 					
							ELSE MontoCierre END MontoCierre , 
					MontoPagos - (CASE	WHEN cp.IdFormaPago = @idE 
								THEN ISNULL((SELECT SUM(TotalAprobado) 
											FROM EPK_AlivioEfectivoEncabezado ae
											WHERE ae.FechaAlivio = ce.Fecha
											AND AE.HoraAlivio BETWEEN APE.Hora AND CE.Hora 
											AND AE.IdUsuarioCajero = ce.IdCajero ), 0) 					
											ELSE MontoCierre END) Diefrencia, 
				    Observacion, 'Cierre' Operacion
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
			AND (@Cajero IS NULL OR U.Identificacion LIKE '%'+ @Cajero  +'%')
			--AND (@IdCajero  IS NULL OR CE.IdCajero = @IdCajero )
			AND (@IdCaja IS NULL OR CE.IdCaja = @IdCaja)
			UNION ALL
			SELECT  e.IdCierre, C.Descripcion Caja, U.Identificacion Cajero, E.Fecha,  cast ((cast (datepart(hour,e.Hora) as varchar(2))+':'+cast (datepart(minute,e.Hora) as varchar)) as time) Hora, 
				    fp.Descripcion , CP.MontoPago,  CP.MontoPOS MontoCierre , 
					CP.MontoPago - CP.MontoPOS Diferencia, 
				    Observacion, 'Cierre' Operacion
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
			AND     (@Cajero IS NULL OR U.Identificacion LIKE '%'+ @Cajero  +'%')
			--AND		(@IdCajero  IS NULL OR IdCajero =@IdCajero)
		    
            RETURN 1
	    END TRY 
	    BEGIN CATCH
		    EXEC EPK_sp_LogErroresGenerar @@SPID
		    SELECT 'Linea de error: '+ CAST(ERROR_LINE() as varchar(4)) +' - Nro error: '+ CAST (ERROR_NUMBER () as varchar(30))+' - Mensaje de error: '+ ERROR_MESSAGE () 
		    RETURN 0
	    END CATCH
    END

GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ReporteOperacionesCajero] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteOperacionesCajero] TO PUBLIC
    AS [dbo];

