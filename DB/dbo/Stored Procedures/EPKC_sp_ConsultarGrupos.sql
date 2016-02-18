-- =============================================
-- Author:		Ronald Pérez
-- Create date: 03/11/2012
-- Description:	Permite consultar los grupos disposibles 
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_ConsultarGrupos]
   @IdRegion         INT        = NULL 
  ,@IdGrupo          SMALLINT   = NULL
  ,@Descripcion      VARCHAR(15)= NULL
  ,@TipoVerificacion SMALLINT   = NULL
  ,@IdZona1          SMALLINT   = NULL
  ,@IdZona2          SMALLINT   = NULL
  ,@IdZona3          SMALLINT   = NULL
AS
BEGIN
   SELECT 
       [IdRegion]
      ,[IdGrupo]
      ,GZ.[Descripcion]
      ,[TipoVerificacion]
      ,[IdZona1]
      ,[IdZona2]
      ,[IdZona3]
      ,(SELECT DESCRIPCION FROM EPK_ModoVerificacion WHERE IdModoVerificacion = [TipoVerificacion]) AS ModoV
      ,(SELECT DESCRIPCION FROM EPK_ZONAS Z WHERE [IdZona]=[IdZona1] AND GZ.[IdRegion] = Z.[IdRegion] ) AS DESZ1
      ,(SELECT DESCRIPCION FROM EPK_ZONAS Z WHERE [IdZona]=[IdZona2]   AND GZ.[IdRegion] = Z.[IdRegion] ) AS DESZ2
      ,(SELECT DESCRIPCION FROM EPK_ZONAS Z WHERE [IdZona]=[IdZona3]  AND GZ.[IdRegion] = Z.[IdRegion]) AS DESZ3
  FROM  [EPK_GrupoZona] GZ

  WHERE  
       (@IdGrupo          IS NULL OR  @IdGrupo= [IdGrupo])
     AND
      (@Descripcion     IS NULL OR  GZ.[Descripcion] LIKE @Descripcion)
     AND
      (@TipoVerificacion IS NULL OR  @TipoVerificacion = [TipoVerificacion])
     AND
      (@IdZona1          IS NULL OR  @IdZona1          = [IdZona1]         )
     AND
      (@IdZona2          IS NULL OR  @IdZona2          = [IdZona2]         )
     AND
      (@IdZona3          IS NULL OR  @IdZona3          = [IdZona3]         )
      AND
      (@IdRegion         IS NULL OR  @IdRegion = [IdRegion])

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_ConsultarGrupos] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_ConsultarGrupos] TO PUBLIC
    AS [dbo];

