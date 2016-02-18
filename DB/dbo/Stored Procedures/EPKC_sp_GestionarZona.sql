
-- =============================================
-- Author:		Ronald Pérez
-- Create date: 03/11/2012
-- Description: Permite Ingresar el grupo de acceso
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_GestionarZona]
   @IdRegion    INT       
  ,@IdZona      SMALLINT    = NULL
  ,@Descripcion VARCHAR(20)
  ,@Intervalos  VARCHAR(56)
  AS
BEGIN
IF @IdZona IS NULL
BEGIN 
 SET @IdZona = (SELECT [dbo].[EPKC_F_ObtenerIdZona] (@IdRegion))
INSERT INTO  [EPK_Zonas]
           (
            [IdRegion] 
           ,[IdZona]
           ,[Descripcion]
           ,[Intervalos])
     VALUES
           (
            @IdRegion
           ,@IdZona
           ,@Descripcion
           ,@Intervalos)
END 
ELSE
BEGIN
UPDATE  [EPK_Zonas]
   SET 
       [Descripcion] = @Descripcion
      ,[Intervalos]  = @Intervalos
 WHERE @IdRegion  = [IdRegion]  
      AND
       @IdZona    = [IdZona]
END
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_GestionarZona] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_GestionarZona] TO PUBLIC
    AS [dbo];

