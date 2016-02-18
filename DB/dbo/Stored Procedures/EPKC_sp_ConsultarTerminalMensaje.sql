-- =============================================
-- Author:		Ronald Pérez
-- Create date: 03/11/2012
-- Description:	Permite consultar los terminales asociados a una localidad
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_ConsultarTerminalMensaje]
  @IdRegion            INT = NULL
 ,@IdLocalidad         INT = NULL
 ,@IdTerminal          INT = NULL
AS
BEGIN
    SELECT 
       IdTerminal
      ,IdLocalidad
      ,IdTipoTerminal
    FROM EPK_Terminal 
    WHERE 
      (@IdLocalidad  IS NULL OR @IdLocalidad = IdLocalidad)
    AND 
      (@IdTerminal   IS NULL OR @IdTerminal  = IdTerminal)
    AND 
      (@IdRegion     IS NULL OR @IdRegion  =  IdRegion)
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_ConsultarTerminalMensaje] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_ConsultarTerminalMensaje] TO PUBLIC
    AS [dbo];

