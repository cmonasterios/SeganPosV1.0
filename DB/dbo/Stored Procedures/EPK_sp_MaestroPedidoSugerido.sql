-- =============================================
-- Author:		Ronald Pérez
-- Create date: 18/09/2013
-- Description:	Permite listar el pedido sugerido para una coleccion determinada
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_MaestroPedidoSugerido] 
 @IdColeccion  INT
,@MenosDe      INT
,@PidoPMenosDe INT
,@Entre5y      INT
,@PidoEntre5y  INT
AS
BEGIN


DECLARE @StockMinimo INT 

SET @StockMinimo =  DBO.fn_ObtenerParametroEntero ('StockMinimo',GETDATE(), 1)

SELECT 
  FotoPequena = FotoMediana
 ,LTRIM(RTRIM(CodigoReferencia)) AS Referencia
 ,LTRIM(RTRIM(CodigoArticulo))   AS Codigo
 ,LTRIM(RTRIM(CodigoTalla))   CodigoTalla
 ,LTRIM(RTRIM(CodigoColor))CodigoColor
 ,LTRIM(RTRIM(R.Descripcion))Descripcion
 ,LTRIM(RTRIM(G.Descripcion))DescripcionGenero 
 ,LTRIM(RTRIM(TP.Descripcion))TipoPrenda 
 ,Existencia        EnTienda 
 ,ExistenciaAlmacen EnAlmacen
 ,CASE WHEN  ExistenciaAlmacen > @StockMinimo THEN CASE WHEN Existencia < @MenosDe THEN @PidoPMenosDe WHEN Existencia BETWEEN @MenosDe AND @Entre5y THEN @PidoEntre5y ELSE 0 END ELSE 0 END Pedir
 ,CASE WHEN  ExistenciaAlmacen > @StockMinimo THEN 1 ELSE 0 END Disponible
 FROM EPK_Articulo A
INNER JOIN EPK_Referencia  R ON A.IdReferencia = R.IdReferencia
INNER JOIN EPK_Color  C      ON C.IdColor = A.IdColor
INNER JOIN EPK_Talla  T      ON T.IdTalla = A.IdTalla   
INNER JOIN EPK_Genero G      ON G.IdGenero = R.IdGenero
LEFT JOIN EPK_Grupo AS  Gr	 ON R.IdGrupo = Gr.IdGrupo 
LEFT JOIN EPK_TipoPrenda AS TP ON Gr.IdTipoPrenda = TP.IdTipoPrenda

WHERE 
   IdColeccion = @IdColeccion
   
   
 ORDER BY R.CodigoReferencia
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_MaestroPedidoSugerido] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_MaestroPedidoSugerido] TO PUBLIC
    AS [dbo];

