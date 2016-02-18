-- =============================================
-- Author:		Ronald Pérez
-- Create date: 03/11/2012
-- Description:	Permite Consultar las zonas 
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_ConsultarZonas]
   @IdRegion    INT        = NULL
  ,@IdGrupo     INT        = NULL
  ,@IdZona      SMALLINT   = NULL
  ,@Intervalos  VARCHAR(50)= NULL
  ,@Descripcion VARCHAR(20)= NULL
AS
BEGIN
  SELECT 
  DISTINCT
      Z.IdRegion
     ,IdZona
     --,GZ.IdGrupo
     ,Z.Descripcion  
     ,Intervalos 
     ,RU.Descripcion AS DescripcionRegion
     ,SUBSTRING(Intervalos,1,2) +':'+ SUBSTRING(Intervalos,3,2) DomingoD
     ,SUBSTRING(Intervalos,5,2) +':'+ SUBSTRING(Intervalos,7,2) DomingoH
     ,SUBSTRING(Intervalos,9,2) +':'+ SUBSTRING(Intervalos,11,2) LunesD
     ,SUBSTRING(Intervalos,13,2)+':'+ SUBSTRING(Intervalos,15,2) LunesH
     ,SUBSTRING(Intervalos,17,2)+':'+  SUBSTRING(Intervalos,19,2) MartesD
     ,SUBSTRING(Intervalos,21,2)+':'+ SUBSTRING(Intervalos,23,2) MartesH
     ,SUBSTRING(Intervalos,25,2)+':'+ SUBSTRING(Intervalos,27,2) MiercolesD
     ,SUBSTRING(Intervalos,29,2)+':'+ SUBSTRING(Intervalos,31,2) MiercolesH
     ,SUBSTRING(Intervalos,33,2)+':'+ SUBSTRING(Intervalos,35,2) JuevesD
     ,SUBSTRING(Intervalos,37,2)+':'+ SUBSTRING(Intervalos,39,2) JuevesH
     ,SUBSTRING(Intervalos,41,2)+':'+ SUBSTRING(Intervalos,43,2) ViernesD
     ,SUBSTRING(Intervalos,45,2)+':'+ SUBSTRING(Intervalos,47,2) ViernesH
     ,SUBSTRING(Intervalos,49,2)+':'+ SUBSTRING(Intervalos,51,2) SabadoD
     ,SUBSTRING(Intervalos,53,2)+':'+ SUBSTRING(Intervalos,55,2) SabadoH
  FROM EPK_Zonas Z LEFT JOIN EPK_Region RU ON Z.IdRegion = RU.IdRegion
      -- LEFT JOIN  EPK_GrupoZona GZ ON (Z.IdRegion = GZ.IdRegion AND GZ.IdRegion = RU.IdRegion)
      -- --AND(Z.IdZona = GZ.IdZona1 OR Z.IdZona = GZ.IdZona2 OR Z.IdZona =GZ.IdZona3 )
      ---- AND Z.IdZona IN( GZ.IdZona1 ,  GZ.IdZona2 , GZ.IdZona3 )
  WHERE 
     (@IdZona      IS NULL OR  @IdZona   = IdZona)
    AND 
     (@Intervalos  IS NULL OR  @Intervalos = Intervalos)
    AND 
     (@Descripcion IS NULL OR Z.Descripcion LIKE @Descripcion)
    AND 
     (@IdRegion    IS NULL OR @IdRegion = Z.IdRegion)
    --AND 
    -- (@IdGrupo     IS NULL OR @IdGrupo  = GZ.IdGrupo)
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_ConsultarZonas] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_ConsultarZonas] TO PUBLIC
    AS [dbo];

