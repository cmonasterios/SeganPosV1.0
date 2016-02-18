-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_MaestroArticulos] 
@CodigoColeccion VARCHAR(20)
AS
BEGIN


 select ITEMNMBR Codigo
       ,ITEMDESC [Descripción]
       ,ITMSHNAM [Nombre Corto]
       ,USCATVLS_1 Referencia
       ,USCATVLS_2 [Colección]
       ,USCATVLS_3 Color
       ,USCATVLS_4 Talla
       ,USCATVLS_5 Grupo
       ,USCATVLS_6 Tema
       ,CREATDDT Fecha
       ,INACTIVE Activo
        from EPKDGP04.EPK.DBO.IV00101 AS MA 
 WHERE USCATVLS_2 =@CodigoColeccion
 ORDER BY ITEMNMBR

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[SP_MaestroArticulos] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[SP_MaestroArticulos] TO PUBLIC
    AS [dbo];

