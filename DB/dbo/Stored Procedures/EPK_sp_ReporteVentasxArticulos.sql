-- =============================================
-- Author:		Ronald Pérez
-- Create date: 19/09/2013
-- Description:	Permite consolidar las ventas de los artículos de una colección
--              de acuerdo a un rango de fechas 
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteVentasxArticulos] @IdColeccion INT, @FechaDesde DATE, @FechaHasta DATE
AS BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;

  DECLARE @Status TINYINT
  SET @Status = DBO.fn_ObtenerParametroEntero ('FACProcesada', GETDATE(), 1)

  SELECT FotoMediana FotoPeq, Fecha, FE.IdFactura, RTRIM(LTRIM(CodigoReferencia)) CodReferencia,
         RTRIM(LTRIM(CodigoArticulo)) CodArticulo, RTRIM(LTRIM(A.Descripcion)) Descrip,
         A.Activo Act, SUM( CASE WHEN CAMBIO =1 THEN Cantidad*-1 ELSE Cantidad END ) Ventas
    FROM EPK_FacturaDetalle FD
      INNER JOIN EPK_FacturaEncabezado FE ON FD.IdFactura = FE.IdFactura
      INNER JOIN EPK_Articulo A ON A.IdArticulo = FD.IdArticulo
      INNER JOIN EPK_Referencia R ON A.IdReferencia = R.IdReferencia
    WHERE FE.Fecha BETWEEN @FechaDesde AND @FechaHasta AND FE.IdEstatus = @Status AND
          (@IdColeccion = 0 OR R.IdColeccion  =  @IdColeccion)
    GROUP BY FotoMediana, Fecha, FE.IdFactura, CodigoReferencia, CodigoArticulo, A.Descripcion,
             A.Activo, Cambio
    ORDER BY Fecha, FE.IdFactura, CodigoArticulo
    -- HAVING SUM(CASE WHEN CAMBIO =1 THEN Cantidad*-1 ELSE Cantidad END) <> 0
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ReporteVentasxArticulos] TO PUBLIC
    AS [dbo];
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteVentasxArticulos] TO PUBLIC
    AS [dbo];
