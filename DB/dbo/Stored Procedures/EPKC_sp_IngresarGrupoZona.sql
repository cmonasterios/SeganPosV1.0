-- =============================================
-- Author:		Ronald Pérez	
-- Create date: 11/12/2012
-- Description:	Permite agregar un nuevo registros de grupozona
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_IngresarGrupoZona]
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

INSERT INTO  [EPK_GrupoZona]
           (
            [IdRegion]
           ,[IdGrupo]
           ,[Descripcion]
           ,[TipoVerificacion]
           ,[FeriadosValidos]
           ,[IdZona1]
           ,[IdZona2]
           ,[IdZona3])
     VALUES
           (
            @IdRegion
           ,@IdGrupo
           ,@Descripcion
           ,@TipoVerificacion
           ,@FeriadosValidos
           ,@IdZona1
           ,@IdZona2
           ,@IdZona3
           )
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_IngresarGrupoZona] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_IngresarGrupoZona] TO PUBLIC
    AS [dbo];

