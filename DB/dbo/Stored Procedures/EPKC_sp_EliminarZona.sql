
-- =============================================
-- Author:		Ronald Pérez
-- Create date: 03/11/2012
-- Description: Permite Ingresar el grupo de acceso
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_EliminarZona]
   @IdRegion    INT
  ,@IdZona      SMALLINT
  AS
BEGIN

DELETE FROM  [EPK_Zonas]
  WHERE @IdRegion  = [IdRegion]  
      AND
       @IdZona    = [IdZona]

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_EliminarZona] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_EliminarZona] TO PUBLIC
    AS [dbo];

