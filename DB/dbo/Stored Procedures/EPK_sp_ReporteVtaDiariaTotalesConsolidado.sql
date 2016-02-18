
-- =============================================
-- Author:		sderkoyorikian
-- Create date: 26/12/2013
-- Description:	Consulta las ventas diarias 
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteVtaDiariaTotalesConsolidado] 
	@Fecha			DATE,
	@IdFormaPago	INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @TotalPagos	DECIMAL(18,2)
	DECLARE @Status			TINYINT

	SET  @Status  = DBO.fn_ObtenerParametroEntero ('FACProcesada', GETDATE(),1)	
	SELECT @TotalPagos = ISNULL(SUM (MontoFisico) ,0)
	FROM 
		(SELECT CP.MontoPagos MontoSistema, CP.MontoCierre MontoFisico, CP.MontoPagos - CP.MontoCierre Diferencia 
		FROM EPK_CierreVentaEncabezado E
		INNER JOIN EPK_CierreVentaPagos CP
			ON E.IdCierreV = CP.IdCierreV 
		INNER JOIN EPK_FormaPago FP
			ON CP.IdFormaPago = FP.IdFormaPago  
		WHERE	E.Fecha = @Fecha 
		AND		(@IdFormaPago IS NULL OR CP.IdFormaPago = @IdFormaPago)
		UNION ALL
		SELECT CP.TotalDia MontoSistema, CP.MontoCierre MontoFisico, CP.TotalDia - CP.MontoCierre Diferencia
		FROM EPK_CierreVentaEncabezado E
		INNER JOIN EPK_CierreVentaPOS CP
			ON E.IdCierreV = CP.IdCierreV 
		INNER JOIN EPK_FormaPago FP
			ON CP.IdFormaPago = FP.IdFormaPago  
		INNER JOIN EPK_POS POS
			ON POS.IdPOS = CP.IdPOS 
		INNER JOIN EPK_EntidadFinanciera ENT
			ON ENT.IdEntidad = POS.IdEntidad 
		WHERE	E.Fecha = @Fecha 
		AND		(@IdFormaPago IS NULL OR CP.IdFormaPago = @IdFormaPago)) t
		
	PRINT @TotalPagos

	SELECT 'Sistema'		Tipo,					ISNULL(SUM (MontoBase),0)		MontoBase, 
			ISNULL(SUM (MontoIVA),0)	MontoIVA,	ISNULL(SUM(MontoTotal),0)		MontoNeto,
			ISNULL(SUM(MontoTotal),0)	-@TotalPagos Diferencia
	FROM EPK_FacturaEncabezado 
	WHERE CAST (FechaCreacion AS DATE)= @Fecha
	AND IdEstatus = @Status
	UNION ALL
	SELECT 'Reporte Z'			Tipo,		ISNULL(SUM(BaseImponibleFact),0)	MontoBase, 
			ISNULL(SUM (ImpuestoFact),0)	MontoIVA,	ISNULL(SUM (MontoTotalFact),0)		MontoNeto,
			ISNULL(SUM (MontoTotalFact),0) -@TotalPagos Diferencia
	FROM EPK_CierreMaquinaFiscal 
	WHERE Fecha = @Fecha  
	UNION ALL
	SELECT  top 1 'Diferencia'	Tipo, t.MontoBase - t2.MontoBase			MontoBase,
			t.MontoIVA - t2.MontoIVA MontoIVA,	t.MontoNeto - t2.MontoNeto	MontoNeto,
			NULL  
	FROM 
		(SELECT 1 ID,	ISNULL(SUM (MontoBase),0)	MontoBase, 
						ISNULL(SUM (MontoIVA),0)	MontoIVA,	ISNULL(SUM(MontoTotal),0)	MontoNeto
		FROM EPK_FacturaEncabezado E
		WHERE CAST (FechaCreacion AS DATE)= @Fecha
		AND IdEstatus = @Status)T
	INNER JOIN 	
		(SELECT 1 ID, ISNULL(SUM(BaseImponibleFact),0)	MontoBase, 
				ISNULL(SUM (ImpuestoFact),0)	MontoIVA,	ISNULL(SUM (MontoTotalFact),0) 	MontoNeto
		FROM EPK_CierreMaquinaFiscal 
		WHERE Fecha = @Fecha) T2
	ON T.ID = T2.ID 
	
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ReporteVtaDiariaTotalesConsolidado] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteVtaDiariaTotalesConsolidado] TO PUBLIC
    AS [dbo];

