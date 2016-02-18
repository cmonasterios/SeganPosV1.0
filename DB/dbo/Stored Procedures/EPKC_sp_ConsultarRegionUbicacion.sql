-- =============================================
-- Author:		Ronald Pérez
-- Create date: 26/01/2013
-- Description:	Permite consultar las regiones de ubicacion
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_ConsultarRegionUbicacion]
AS
BEGIN
SELECT [IdRegion]
      ,[Descripcion]
  FROM  [EPK_RegionUbicacion]

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_ConsultarRegionUbicacion] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_ConsultarRegionUbicacion] TO PUBLIC
    AS [dbo];

