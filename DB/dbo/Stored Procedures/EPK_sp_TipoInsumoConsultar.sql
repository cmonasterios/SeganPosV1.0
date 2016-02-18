-- =============================================
-- Author:		Ronald Pérez
-- Create date: 18/07/2013
-- Description:	SP que permite consultar los tipos de insumos 
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_TipoInsumoConsultar]
  @IdTipoInsumo  SMALLINT    = NULL
  ,@Nombre       VARCHAR(50) = NULL 
AS
BEGIN
   SELECT  
   IdTipoInsumo
  ,Nombre 
  FROM EPK_TipoInsumo
  WHERE 
    (@IdTipoInsumo IS NULL OR @IdTipoInsumo = IdTipoInsumo)
  AND 
    (@Nombre       IS NULL OR Nombre LIKE @Nombre ) 
    
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_TipoInsumoConsultar] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_TipoInsumoConsultar] TO PUBLIC
    AS [dbo];

