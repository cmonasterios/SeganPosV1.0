-- =============================================
-- Author:		Ronald Pérez
-- Create date: 26/01/2013
-- Description:	Permite consultar las Localidades
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_ConsultarLocalidad]
AS
BEGIN
SELECT  IdRegion
       ,IdLocalidad
       ,Descripcion 
FROM [EPK_Localidad] 
ORDER BY Descripcion 

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_ConsultarLocalidad] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_ConsultarLocalidad] TO PUBLIC
    AS [dbo];

