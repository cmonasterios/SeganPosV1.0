-- =============================================
-- Author:		Ronald Pérez
-- Create date: 30/01/2013
-- Description:	Permite consultar el acceso de un empleado a un terminal
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_ConsultarEmpleadoLocalidad]
 @IdEmpleado   BIGINT
AS
BEGIN
	SELECT [IdRegion]
      ,[IdLocalidad]
      ,[IdEmpleado]
      ,[FechaHoraRegistro]
      ,[FechaHoraEliminacion]
      ,[FechaHoraInactivo]
      ,[FechaHoraEnvio]
  FROM  [EPK_EmpleadoLocalidad]
  WHERE  IdEmpleado  = @IdEmpleado
       AND  
         [FechaHoraEliminacion] IS  NULL
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_ConsultarEmpleadoLocalidad] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_ConsultarEmpleadoLocalidad] TO PUBLIC
    AS [dbo];

