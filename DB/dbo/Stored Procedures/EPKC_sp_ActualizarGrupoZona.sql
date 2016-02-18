-- =============================================
-- Author:		Ronald Pérez	
-- Create date: 11/12/2012
-- Description:	Permite actualizar un registros de grupozona
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_ActualizarGrupoZona]
 @IdRegion         INT
,@IdGrupo          SMALLINT
,@Descripcion      VARCHAR(50)
,@TipoVerificacion SMALLINT 
,@FeriadosValidos  BIT
,@IdZona1          SMALLINT 
,@IdZona2          SMALLINT 
,@IdZona3          SMALLINT 
AS
BEGIN
UPDATE  [EPK_GrupoZona]
   SET 
       [Descripcion]      = @Descripcion
      ,[TipoVerificacion] = @TipoVerificacion
      ,[FeriadosValidos]  = @FeriadosValidos
      ,[IdZona1] = @IdZona1
      ,[IdZona2] = @IdZona2
      ,[IdZona3] = @IdZona3
 WHERE @IdGrupo  = [IdGrupo]
      AND
       @IdRegion = [IdRegion]
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_ActualizarGrupoZona] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_ActualizarGrupoZona] TO PUBLIC
    AS [dbo];

