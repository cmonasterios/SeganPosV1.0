-- =============================================
-- Author:		Ronald Pérez
-- Create date: 20/10/2012
-- Description:	Permite consultar las huellas de un empleado
-- =============================================
create PROCEDURE [dbo].[EPK_sp_HuellaEmpleadoConsultar]
     @IdEmpleado INT
    ,@IdFingerPrint INT =NULL
AS
BEGIN

	SELECT [IdEmpleado]
		  ,[IdFingerPrint]
		  ,[IdFlag]
		  ,[TemplateFinger]
	  FROM [EPK_HuellaEmpleado]
	  WHERE   @IdEmpleado     = [IdEmpleado]
	        AND 
	         (@IdFingerPrint IS NULL OR @IdFingerPrint  = [IdFingerPrint])
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_HuellaEmpleadoConsultar] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_HuellaEmpleadoConsultar] TO PUBLIC
    AS [dbo];

