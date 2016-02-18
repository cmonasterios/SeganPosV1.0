-- =============================================
-- Author:		Ronald Pérez
-- Create date: 30/01/2013
-- Description:	Ingresar la ubicacion del registro de empleado en una localidad
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_IngresarEmpleadoTerminal]
   @IdRegion       INT
  ,@IdEmpleado     BIGINT
  ,@IdTerminal     INT
AS
BEGIN
INSERT INTO  [EPK_EmpleadoTerminal]
           ([IdRegion]
           ,[IdEmpleado]
           ,[IdTerminal]
           ,[FechaHoraRegistro]
           ,[FechaHoraEliminacion]
           ,[FechaHoraInactivo]
           ,[FechaHoraEnvio])
     VALUES
           (@IdRegion
           ,@IdEmpleado
           ,@IdTerminal
           ,GETDATE()
           ,NULL
           ,NULL
           ,NULL)
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_IngresarEmpleadoTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_IngresarEmpleadoTerminal] TO PUBLIC
    AS [dbo];

