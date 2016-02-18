
-- =============================================
-- Author:		Ronald Pérez
-- Create date: 03/11/2012
-- Description: Permite Ingresar el grupo de acceso
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_IngresarZona]
   @IdRegion    INT
  ,@IdZona      SMALLINT
  ,@Descripcion VARCHAR(20)
  ,@Intervalos  VARCHAR(56)
  AS
BEGIN
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
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_IngresarZona] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_IngresarZona] TO PUBLIC
    AS [dbo];

