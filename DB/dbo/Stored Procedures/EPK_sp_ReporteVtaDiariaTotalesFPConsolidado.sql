

-- =============================================
-- Author:		sderkoyorikian
-- Create date: 26/12/2013
-- Description:	Consulta las ventas diarias 
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteVtaDiariaTotalesFPConsolidado] 
	@Fecha			DATE,
	@IdFormaPago	INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT  FP.Descripcion FormaPago, SUM (CP.TotalDia) MontoSistema, SUM (CP.MontoCierre) MontoFisico, SUM (CP.TotalDia - CP.MontoCierre) Diferencia
		FROM EPK_CierreVentaEncabezado E
		INNER JOIN EPK_CierreVentaPOS CP
			ON E.IdCierreV = CP.IdCierreV 
		INNER JOIN EPK_FormaPago FP
			ON CP.IdFormaPago = FP.IdFormaPago  
	WHERE	E.Fecha = @Fecha 
	AND		(@IdFormaPago IS NULL OR CP.IdFormaPago = @IdFormaPago)
	GROUP BY FP.Descripcion 
	UNION ALL 
	SELECT 'Total General' FormaPago, SUM(MontoSistema) MontoSistema, SUM (MontoFisico) MontoFisico, SUM(Diferencia)Diferencia
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
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ReporteVtaDiariaTotalesFPConsolidado] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteVtaDiariaTotalesFPConsolidado] TO PUBLIC
    AS [dbo];

