-- =============================================
-- Author:		Ronald Pérez
-- Create date: 30/01/2013
-- Description:	Permite consultar el acceso de un empleado a un terminal
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_EPK_EmpleadoAccesoConsultar]
 @IdEmpleado   BIGINT
AS
BEGIN
	SELECT *
  FROM  EPK_EmpleadoAcceso
  WHERE  IdEmpleado  = @IdEmpleado
       AND  
        FechaEliminacion IS  NULL
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_EPK_EmpleadoAccesoConsultar] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_EPK_EmpleadoAccesoConsultar] TO PUBLIC
    AS [dbo];

