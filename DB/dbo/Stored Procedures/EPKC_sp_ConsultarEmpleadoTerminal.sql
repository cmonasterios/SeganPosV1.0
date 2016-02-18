-- =============================================
-- Author:		Ronald Pérez
-- Create date: 30/01/2013
-- Description:	Permite consultar el acceso de un empleado a un terminal
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_ConsultarEmpleadoTerminal]
 @IdEmpleado   BIGINT
AS
BEGIN
	SELECT 
       [IdRegion]
      ,[IdEmpleado]
      ,[IdTerminal]
      ,[FechaHoraRegistro]
      ,[FechaHoraEliminacion]
      ,[FechaHoraInactivo]
      ,[FechaHoraEnvio]
  FROM  [EPK_EmpleadoTerminal]
  WHERE  IdEmpleado  = @IdEmpleado
       AND  
         [FechaHoraEliminacion] IS NOT NULL
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_ConsultarEmpleadoTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_ConsultarEmpleadoTerminal] TO PUBLIC
    AS [dbo];

