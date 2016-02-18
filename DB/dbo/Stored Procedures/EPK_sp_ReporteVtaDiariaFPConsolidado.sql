
-- =============================================
-- Author:		sderkoyorikian
-- Create date: 26/12/2013
-- Description:	Consulta las ventas diarias 
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteVtaDiariaFPConsolidado] 
	@Fecha			DATE,
	@IdFormaPago	INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    
    DECLARE @IdCheque	INT
    DECLARE @IdEfectivo	INT
	
	SET @IdCheque = DBO.fn_ObtenerParametroEntero ('IDCHEQUE', GETDATE(),1)
    SET @IdEfectivo = DBO.fn_ObtenerParametroEntero ('ID_EFECTIVO', GETDATE(),1)
    
	SELECT IdFormaPago, FormaPago, Banco, MontoSistema, MontoFisico, Diferencia, CASE WHEN RTRIM(LTRIM(Observacion)) ='' OR Observacion IS NULL 
                                                                                            THEN 'Sin observaciones' 
                                                                                            ELSE Observacion END Observacion
	FROM 
		(SELECT     FP.IdFormaPago, FP.Descripcion FormaPago, NULL Banco, CP.MontoPagos MontoSistema, 
                    CASE FP.IdFormaPago WHEN @IdEfectivo THEN ISNULL((SELECT SUM(MontoEfectivo) FROM EPK_DepositoEncabezado WHERE FechaVenta = @Fecha),0)
                                        WHEN  @IdCheque THEN  ISNULL((SELECT SUM(MontoCheque) FROM EPK_DepositoEncabezado WHERE FechaVenta = @Fecha),0)
                                        ELSE  CP.MontoCierre END MontoFisico, 
                    CP.MontoPagos - CASE FP.IdFormaPago WHEN @IdEfectivo THEN ISNULL((SELECT SUM(MontoEfectivo) FROM EPK_DepositoEncabezado WHERE FechaVenta = @Fecha),0)
														WHEN  @IdCheque THEN  ISNULL((SELECT SUM(MontoCheque) FROM EPK_DepositoEncabezado WHERE FechaVenta = @Fecha),0)
														ELSE  CP.MontoCierre END Diferencia, 
                    CP.Observacion 
		FROM EPK_CierreVentaEncabezado E
		INNER JOIN EPK_CierreVentaPagos CP
			ON E.IdCierreV = CP.IdCierreV 
		INNER JOIN EPK_FormaPago FP
			ON CP.IdFormaPago = FP.IdFormaPago  
		WHERE	E.Fecha = @Fecha 
		AND		(@IdFormaPago IS NULL OR CP.IdFormaPago = @IdFormaPago)
		UNION ALL
		SELECT  FP.IdFormaPago, FP.Descripcion FormaPago, ENT.Nombre Banco, 
				SUM(CP.TotalDia) MontoSistema, SUM(CP.MontoCierre) MontoFisico, 
				SUM(CP.TotalDia - CP.MontoCierre) Diferencia, cp.Observacion 
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
		AND		(@IdFormaPago IS NULL OR CP.IdFormaPago = @IdFormaPago)
		group by FP.IdFormaPago, FP.Descripcion, ENT.Nombre, cp.Observacion ) t
	ORDER BY t.IdFormaPago 
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ReporteVtaDiariaFPConsolidado] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteVtaDiariaFPConsolidado] TO PUBLIC
    AS [dbo];

