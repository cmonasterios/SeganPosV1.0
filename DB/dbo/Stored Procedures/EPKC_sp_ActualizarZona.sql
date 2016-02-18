
-- =============================================
-- Author:		Ronald Pérez
-- Create date: 03/11/2012
-- Description: Permite Ingresar el grupo de acceso
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_ActualizarZona]
   @IdRegion    INT
  ,@IdZona      SMALLINT
  ,@Descripcion VARCHAR(20)
  ,@Intervalos  VARCHAR(56)
  AS
BEGIN
UPDATE  [EPK_Zonas]
   SET 
       [Descripcion] = @Descripcion
      ,[Intervalos]  = @Intervalos
 WHERE @IdRegion  = [IdRegion]  
      AND
       @IdZona    = [IdZona]
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_ActualizarZona] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_ActualizarZona] TO PUBLIC
    AS [dbo];

