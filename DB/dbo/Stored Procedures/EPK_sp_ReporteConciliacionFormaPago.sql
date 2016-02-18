--=============================================
-- Author:		sderkoyorikian
-- Create date: 31/08/2013
-- Description:	Reporte para Conciliacion de 
--				Formas de Pagos General
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteConciliacionFormaPago] 
	@Fecha			DATE,
	@IdCaja			INT = NULL,
	--@IdCajero		INT = NULL,
	@IdFormaPago	TINYINT = NULL,
	@IdEntidad		INT = NULL,
	@IdPOS			INT = NULL,
	@MontoDesde		DECIMAL(18,2) = NULL,
	@MontoHasta		DECIMAL(18,2) = NULL,
	@IdMaquina		INT = NULL,
	@Cajero         VARCHAR(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @Status		TINYINT
    
	SET @Status  = DBO.fn_ObtenerParametroEntero ('FACProcesada', GETDATE(),1)

	SELECT	E.Fecha,				E.SerialMF,				FP.Descripcion FormaPago ,
			EF.Nombre Banco,		POS.Descripcion POS,	
			SUM(P.Monto-P.MontoVuelto) MontoPago,			SUM(P.MontoVuelto) MontoVuelto
	FROM EPK_FacturaEncabezado E
	INNER JOIN	EPK_FacturaPago P
		ON E.IdFactura = P.IdFactura
	INNER JOIN	EPK_FormaPago FP
		ON FP.IdFormaPago = P.IdFormaPago  
	LEFT JOIN	EPK_POS POS
		ON P.IdPOS = POS.IdPOS 
	LEFT JOIN	EPK_EntidadFinanciera EF
		ON POS.IdEntidad = EF.IdEntidad 
	INNER JOIN	EPK_CAJA C
		ON C.IdCaja = E.IdCaja 
	INNER JOIN EPK_Usuario U
		ON E.IdUsuarioCreacion = U.IdUsuario 
	INNER JOIN EPK_Cliente CLI
		ON E.IdCliente = CLI.IdCliente 
	INNER JOIN EPK_TipoDocumento TD
		ON CLI.IdTipoDocumento = TD.IdTipoDocumento  
	WHERE E.Fecha = @Fecha 
	AND E.IdEstatus = @Status
	AND (@Cajero IS NULL	OR U.Identificacion LIKE '%'+ @Cajero +'%')
	--AND (@IdCajero IS NULL	OR U.IdUsuario = @IdCajero)
	AND (@IdCaja IS NULL	OR C.IdCaja = @IdCaja)
	AND (@IdPOS IS NULL		OR POS.IdPOS  = @IdPOS)
	AND (@IdFormaPago IS NULL	OR P.IdFormaPago = @IdFormaPago)
	AND (@IdEntidad IS NULL		OR POS.IdEntidad  = @IdEntidad)
	AND (@IdMaquina IS NULL		OR E.SerialMF = (SELECT Serial 
												 FROM EPK_Dispositivo 
												 WHERE IdDispositivo = @IdMaquina))
	GROUP BY E.Fecha,				E.SerialMF,				FP.Descripcion,
			EF.Nombre,				POS.Descripcion
	HAVING 
		(@MontoDesde IS NULL	OR SUM(P.Monto - P.MontoVuelto) >= @MontoDesde)
	AND (@MontoHasta IS NULL	OR SUM(P.Monto - P.MontoVuelto) <= @MontoHasta)
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ReporteConciliacionFormaPago] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteConciliacionFormaPago] TO PUBLIC
    AS [dbo];

