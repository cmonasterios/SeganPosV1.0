--=============================================
-- Author:		sderkoyorikian
-- Create date: 29/08/2013
-- Description:	Consulta Cierre de ventas
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteVentaDiaria] 
	@FechaDesde date,
	@FechaHasta date
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @idE INT, @FormaPago VARCHAR(100)

	SELECT @idE = dbo.fn_ObtenerParametroEntero ('ID_EFECTIVO', getdate(),1)
	
	SELECT	IdFormaPago, FormaPago, Banco, POS, 
			SUM(MontoPagos)		MontoPagos, 
			SUM(MontoCierre)	MontoCierre, 
			SUM(Diferencia)		Diferencia
	FROM 
		(
		SELECT  FP.IdFormaPago, FP.Descripcion FormaPago, NULL Banco, NULL POS, 
				CP.MontoPagos, 
				(SELECT SUM(TotalAprobado)
				FROM EPK_AlivioEfectivoEncabezado 
				WHERE FechaAlivio  =E.Fecha ) MontoCierre, 
				CP.MontoPagos - (SELECT SUM(TotalAprobado)
								FROM EPK_AlivioEfectivoEncabezado 
								WHERE FechaAlivio  = E.Fecha ) Diferencia
		FROM EPK_CierreVentaEncabezado E
		INNER JOIN EPK_CierreVentaPagos CP
			ON E.IdCierreV = CP.IdCierreV 
		INNER JOIN EPK_FormaPago FP
			ON CP.IdFormaPago = FP.IdFormaPago 
		WHERE fp.DatosPOS =0  AND Fecha BETWEEN @FechaDesde AND @FechaHasta AND FP.IdFormaPago =@idE 			 
		UNION ALL
		SELECT  FP.IdFormaPago, FP.Descripcion FormaPago, NULL Banco, NULL POS, 
				CP.MontoPagos, CP.MontoCierre, CP.MontoPagos - CP.MontoCierre Diferencia
		FROM EPK_CierreVentaEncabezado E
		INNER JOIN EPK_CierreVentaPagos CP
			ON E.IdCierreV = CP.IdCierreV 
		INNER JOIN EPK_FormaPago FP
			ON CP.IdFormaPago = FP.IdFormaPago 
		WHERE fp.DatosPOS =0  AND Fecha BETWEEN @FechaDesde AND @FechaHasta AND FP.IdFormaPago <>@idE 	
		UNION ALL
		SELECT  FP.IdFormaPago, FP.Descripcion FormaPago, ENT.Nombre Banco, POS.Descripcion POS, CP.TotalDia, CP.MontoCierre, CP.TotalDia - CP.MontoCierre Diferencia
		FROM EPK_CierreVentaEncabezado E
		INNER JOIN EPK_CierreVentaPOS CP
			ON E.IdCierreV = CP.IdCierreV 
		INNER JOIN EPK_FormaPago FP
			ON CP.IdFormaPago = FP.IdFormaPago  
		INNER JOIN EPK_POS POS
			ON POS.IdPOS = CP.IdPOS 
		INNER JOIN EPK_EntidadFinanciera ENT
			ON ENT.IdEntidad = POS.IdEntidad 
		WHERE Fecha BETWEEN @FechaDesde AND @FechaHasta ) t
	GROUP BY IdFormaPago, FormaPago, Banco, POS
	ORDER BY t.IdFormaPago 
	---- SET NOCOUNT ON added to prevent extra result sets from
	---- interfering with SELECT statements.
	--SET NOCOUNT ON;

	----DECLARE @FechaDesde DATE = '20130801',@FechaHasta DATE = '20130829'
	--select * 
	--from 
	--	(SELECT  FP.IdFormaPago, FP.Descripcion FormaPago, NULL Banco, NULL POS, CP.MontoPagos, CP.MontoCierre, CP.MontoPagos - CP.MontoCierre Diferencia
	--	FROM EPK_CierreVentaEncabezado E
	--	INNER JOIN EPK_CierreVentaPagos CP
	--		ON E.IdCierreV = CP.IdCierreV 
	--	INNER JOIN EPK_FormaPago FP
	--		ON CP.IdFormaPago = FP.IdFormaPago  
	--	UNION ALL
	--	SELECT  FP.IdFormaPago, FP.Descripcion FormaPago, ENT.Nombre Banco, POS.Descripcion POS, CP.TotalDia, CP.MontoCierre, CP.TotalDia - CP.MontoCierre Diferencia
	--	FROM EPK_CierreVentaEncabezado E
	--	INNER JOIN EPK_CierreVentaPOS CP
	--		ON E.IdCierreV = CP.IdCierreV 
	--	INNER JOIN EPK_FormaPago FP
	--		ON CP.IdFormaPago = FP.IdFormaPago  
	--	INNER JOIN EPK_POS POS
	--		ON POS.IdPOS = CP.IdPOS 
	--	INNER JOIN EPK_EntidadFinanciera ENT
	--		ON ENT.IdEntidad = POS.IdEntidad ) t
	--order by t.IdFormaPago 
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ReporteVentaDiaria] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteVentaDiaria] TO PUBLIC
    AS [dbo];

