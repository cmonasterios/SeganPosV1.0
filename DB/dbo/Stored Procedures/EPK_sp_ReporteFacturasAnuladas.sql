--exec EPK_sp_ReporteFacturasAnuladas '20130701', '20130829'
--=============================================
-- Author:		sderkoyorikian
-- Create date: 29/08/2013
-- Description:	Consulta facturas Anuladas
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteFacturasAnuladas] 
	@FechaDesde		DATE,
	@FechaHasta		DATE,
	@IdTipoDocumento	INT = NULL,
	@NumeroDocumento	VARCHAR (30) = null,
	@IdCajero			INT = NULL 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @Status			TINYINT

	SET  @Status  = DBO.fn_ObtenerParametroEntero ('FACAnulada', GETDATE(),1)
	--SET  @Status  = 1

	SELECT	E.Fecha,								E.Hora,							C.Descripcion Caja,		U.Identificacion Cajero, 
			E.IdFactura,							E.TicketFiscal,					E.COO,
			EMP.Nombre +' '+EMP.Apellido Vendedor,	UA.Identificacion Autorizador,	TD.Sigla +'-'+ CLI.NumeroDocumento Cliente,				
			CLI.Nombre+ ' '+ CLI.Apellido NombreCliente,
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
		
		--*** OJO SE DEBE CAMBIAR A INNER JOIN AL TERMINAR DE REALIZAR PRUEBAS ***
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
	AND (@IdTipoDocumento IS NULL OR CLI.IdTipoDocumento = @IdTipoDocumento)
	AND (@NumeroDocumento IS NULL OR CLI.NumeroDocumento = @NumeroDocumento)

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ReporteFacturasAnuladas] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteFacturasAnuladas] TO PUBLIC
    AS [dbo];

