
--=============================================
-- Author:		sderkoyorikian
-- Create date: 29/08/2013
-- Description:	Consulta facturas canceladas
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteFacturasCanceladas] 
	@FechaDesde		DATE,
	@FechaHasta		DATE,
	@IdCajero		INT = NULL,
	@IdAutorizador	INT = NULL,
	@IdMotivo		INT = NULL 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @Status			TINYINT

	SET  @Status  = DBO.fn_ObtenerParametroEntero ('FACCancelada', GETDATE(),1)
	--SET  @Status  = 1

	SELECT	E.Fecha,								E.Hora,							C.Descripcion Caja,		U.Identificacion Cajero, 
			EMP.Nombre +' '+EMP.Apellido Vendedor,	UA.Identificacion Autorizador,	TD.Sigla +'-'+ CLI.NumeroDocumento Cliente,	
			E.IdFactura,							E.TicketFiscal,					E.COO,
			A.CodigoArticulo,						A.Descripcion,					D.Cantidad,				D.Precio,
			D.PrecioNeto 
	 FROM EPK_FacturaEncabezado E
	INNER JOIN	EPK_FacturaDetalle D
		ON E.IdFactura = D.IdFactura 
	INNER JOIN	EPK_Articulo A
		ON D.IdArticulo = A.IdArticulo 
	INNER JOIN	EPK_CAJA C
		ON C.IdCaja = E.IdCaja 
	INNER JOIN EPK_Usuario U
		ON E.IdUsuarioCreacion = U.IdUsuario 
		
		--*** OJO TIENE UN LEFT EN LUGAR DE UN INNER JOIN, DE FORMA PROVISIONAL ***
	LEFT JOIN EPK_Empleados EMP
		ON E.IdVendedor = EMP.IdEmpleado 
	INNER JOIN EPK_Usuario UA
		ON E.IdUsuarioModificacion = UA.IdUsuario
	INNER JOIN EPK_Cliente CLI
		ON E.IdCliente = CLI.IdCliente 
	INNER JOIN EPK_TipoDocumento TD
		ON CLI.IdTipoDocumento = TD.IdTipoDocumento 
	WHERE E.Fecha BETWEEN @FechaDesde AND @FechaHasta 
	AND (@IdCajero IS NULL OR U.IdUsuario = @IdCajero )
	AND (@IdAutorizador IS NULL OR UA.IdUsuario = @IdAutorizador)

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ReporteFacturasCanceladas] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteFacturasCanceladas] TO PUBLIC
    AS [dbo];

