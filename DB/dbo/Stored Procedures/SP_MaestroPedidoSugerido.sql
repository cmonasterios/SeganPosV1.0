-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_MaestroPedidoSugerido] 
 @CodigoColeccion VARCHAR(20)
,@Tienda       VARCHAR(4)
,@MenosDe      INT
,@PidoPMenosDe INT
,@Entre5y      INT
,@PidoEntre5y  INT
AS
BEGIN


SELECT  
       ITEMNMBR [Código Artículo]
      ,DescripcionArticulo
      ,[Existen] 
      ,CASE WHEN Existen <@MenosDe THEN @PidoPMenosDe WHEN Existen BETWEEN @MenosDe AND @Entre5y THEN @PidoEntre5y ELSE 0 END Pedir
 FROM  SIV_View_DetalleExitencia
 WHERE 
  COLECCION =@CodigoColeccion
 AND 
  LOCNCODE = @Tienda 

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[SP_MaestroPedidoSugerido] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[SP_MaestroPedidoSugerido] TO PUBLIC
    AS [dbo];

