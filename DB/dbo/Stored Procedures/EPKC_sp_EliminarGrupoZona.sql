-- =============================================
-- Author:		Ronald Pérez	
-- Create date: 11/12/2012
-- Description:	Permite eliminar un nuevo registros de grupozona
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_EliminarGrupoZona]
 @IdRegion         INT
,@IdGrupo          SMALLINT
AS
BEGIN
DELETE FROM  [EPK_GrupoZona]
WHERE @IdGrupo  = [IdGrupo]
      AND
       @IdRegion = [IdRegion]

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_EliminarGrupoZona] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_EliminarGrupoZona] TO PUBLIC
    AS [dbo];

