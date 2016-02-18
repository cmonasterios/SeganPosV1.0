
-- =================================================
-- Author:		sderkoyorikian
-- Create date: 25/04/2013
-- Description:	Obtiene un ID del terminal que 
--				corresponde al empleado según la 
--				localidades para la lectura virtual.
-- =================================================
CREATE FUNCTION [dbo].[fn_ObtenerTerminal] (
	@IdEmpleado		INT,
	@Entrada		BIT 
	)
RETURNS INT
AS
BEGIN

	-- Declare the return variable here
	DECLARE @Res AS INT = 0	
	
	IF @Entrada = 1 
		BEGIN 
			SELECT TOP 1 @Res = T.IdTerminal
			FROM         dbo.EPK_Empleados AS E INNER JOIN
								  dbo.EPK_EmpleadoLocalidad AS EL ON E.IdEmpleado = EL.IdEmpleado AND E.IdRegion = EL.IdRegion INNER JOIN
								  dbo.EPK_Terminal AS T ON EL.IdRegion = T.IdRegion AND EL.IdLocalidad = T.IdLocalidad
			WHERE     T.Principal = 1 AND T.IdTipoTerminal IN (1, 3)
			AND E.IdEmpleado = @IdEmpleado
		END
	ELSE 
		BEGIN
			SELECT TOP 1 @Res = T.IdTerminal
			FROM         dbo.EPK_Empleados AS E INNER JOIN
								  dbo.EPK_EmpleadoLocalidad AS EL ON E.IdEmpleado = EL.IdEmpleado AND E.IdRegion = EL.IdRegion INNER JOIN
								  dbo.EPK_Terminal AS T ON EL.IdRegion = T.IdRegion AND EL.IdLocalidad = T.IdLocalidad
			WHERE     T.Principal = 1 AND T.IdTipoTerminal IN (2, 3)
			AND E.IdEmpleado = @IdEmpleado
		END 
		
	RETURN @Res

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[fn_ObtenerTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[fn_ObtenerTerminal] TO PUBLIC
    AS [dbo];

