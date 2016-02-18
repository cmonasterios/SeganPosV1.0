-- =============================================
-- Author:		Ronald Pérez	
-- Create date: 26/01/2013
-- Description:	Permite listar los modos de verificacion en el terminal
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_ConsultaModoVerificacion]
AS
BEGIN
SELECT [IdModoVerificacion]
      ,[Descripcion]
  FROM  [EPK_ModoVerificacion]END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_ConsultaModoVerificacion] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_ConsultaModoVerificacion] TO PUBLIC
    AS [dbo];

