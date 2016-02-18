
-- =================================================
-- Author:		sderkoyorikian
-- Create date: 30/01/2014
-- Description:	Obtiene un parámetro de sistema 
--				de tipo numérico.
-- =================================================
CREATE FUNCTION [dbo].[fn_ObtenerParametroCadena] (
	@CodParametro	VARCHAR(50),
	@Fecha			DATE 
	)
RETURNS VARCHAR(MAX)
AS
BEGIN

	-- Declare the return variable here
	DECLARE @Res AS VARCHAR(MAX) = ''
	
	SET @CodParametro = UPPER (@CodParametro)
	
	IF (SELECT COUNT (1) 
		FROM EPK_ParametrosSistema
		WHERE UPPER (CodParametro)	= @CodParametro
		AND FechaInicio		<= @Fecha
		AND (FechaFin IS NULL OR  FechaFin  >= @Fecha)
		) >0 
		
		SELECT @Res = ValorCadena  
		FROM EPK_ParametrosSistema
		WHERE UPPER(CodParametro)	= @CodParametro
		AND FechaInicio		<= @Fecha
		AND (FechaFin IS NULL OR  FechaFin  >= @Fecha)
	
	RETURN @Res

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[fn_ObtenerParametroCadena] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[fn_ObtenerParametroCadena] TO PUBLIC
    AS [dbo];

