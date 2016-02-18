-- =============================================
-- Author:		sderkoyorikian
-- Create date: 13/01/2014
-- Description:	Consulta las ventas diarias detalle
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteVtaDiariaFPDetallado] 
	@Fecha			DATE,
	@IdFormaPago	INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @IdEfectivo	INT
    DECLARE @IdCheque	INT
	DECLARE @Status		TINYINT
    
	SET @IdEfectivo = DBO.fn_ObtenerParametroEntero ('ID_EFECTIVO', GETDATE(),1)
	SET @IdCheque  = DBO.fn_ObtenerParametroEntero ('IDCHEQUE', GETDATE(),1)
	SET @Status  = DBO.fn_ObtenerParametroEntero ('FACProcesada', GETDATE(),1)

	SELECT	IdFormaPago, FormaPago, Banco, POS, LotePOS, NroControl,
			MontoSistema, MontoFisico, Diferencia, CASE WHEN RTRIM(LTRIM(Observacion)) ='' OR Observacion IS NULL 
                                                        THEN 'Sin observaciones' 
                                                        ELSE Observacion END Observacion
	FROM 
		(SELECT  DISTINCT	FP.IdFormaPago, FP.Descripcion FormaPago, NULL Banco, 
				null POS,	null LotePOS, cp.NroControl,
				CP.MontoPagos MontoSistema,
				CASE FP.IdFormaPago WHEN @IdEfectivo THEN ISNULL((SELECT SUM(MontoEfectivo) FROM EPK_DepositoEncabezado WHERE FechaVenta = @Fecha),0)
                                    WHEN @IdCheque	 THEN ISNULL((SELECT SUM(MontoCheque) FROM EPK_DepositoEncabezado WHERE FechaVenta = @Fecha),0)
                                    ELSE CP.MontoCierre END MontoFisico, 
                CP.MontoPagos - CASE FP.IdFormaPago WHEN @IdEfectivo THEN ISNULL((SELECT SUM(MontoEfectivo) FROM EPK_DepositoEncabezado WHERE FechaVenta = @Fecha),0)
													WHEN @IdCheque	 THEN ISNULL((SELECT SUM(MontoCheque) FROM EPK_DepositoEncabezado WHERE FechaVenta = @Fecha),0)
													ELSE CP.MontoCierre END Diferencia,
				 /*CASE WHEN CP.IdFormaPago <>@IdCheque THEN CP.MontoPagos ELSE FPD.Monto END MontoSistema,
				 CASE WHEN CP.IdFormaPago <>@IdCheque THEN CP.MontoCierre ELSE FPD.Monto END MontoFisico, 
				 CP.MontoPagos - CP.MontoCierre Diferencia, 
				 */cp.Observacion 
		FROM EPK_CierreVentaEncabezado E
		INNER JOIN EPK_CierreVentaPagos CP
			ON E.IdCierreV = CP.IdCierreV 
		INNER JOIN EPK_FormaPago FP
			ON CP.IdFormaPago = FP.IdFormaPago  
		/*LEFT JOIN EPK_FacturaEncabezado FE
			ON CAST (FE.FechaCreacion AS DATE) = E.Fecha 
			AND FE.IdEstatus = @Status 
		LEFT JOIN EPK_FacturaPago FPD
			ON	FE.IdFactura	= FPD.IdFactura 
			AND	cp.IdFormaPago = fpd.IdFormaPago 
			AND	FPD.IdFormaPago	= @IdCheque
		LEFT JOIN EPK_EntidadFinanciera B
			ON FPD.IdEntidad = B.IdEntidad 
		*/
		WHERE	E.Fecha = @Fecha 
		AND		(@IdFormaPago IS NULL OR CP.IdFormaPago = @IdFormaPago)
		UNION ALL
		SELECT  FP.IdFormaPago, FP.Descripcion FormaPago, ENT.Nombre Banco, 
				POS.Descripcion POS,  cp.LotePOS,	null NroControl,
				CP.TotalDia MontoSistema, CP.MontoCierre MontoFisico, CP.TotalDia - CP.MontoCierre Diferencia, cp.Observacion 
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
	WHERE MontoSistema IS NOT NULL 
	ORDER BY 1,2,3,4
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ReporteVtaDiariaFPDetallado] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteVtaDiariaFPDetallado] TO PUBLIC
    AS [dbo];

