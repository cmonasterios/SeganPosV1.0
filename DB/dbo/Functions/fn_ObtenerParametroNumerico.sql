

-- =================================================
-- Author:		sderkoyorikian
-- Create date: 24/04/2013
-- Description:	Obtiene un parámetro de sistema 
--				de tipo numérico.
-- =================================================
CREATE FUNCTION [dbo].[fn_ObtenerParametroNumerico] (
	@CodParametro	VARCHAR(50),
	@Fecha			DATE 
	)
RETURNS NUMERIC (18,2)
AS
BEGIN

	-- Declare the return variable here
	DECLARE @Res AS NUMERIC (18,2) = 0
	
	SET @CodParametro = UPPER (@CodParametro)
	
	IF (SELECT COUNT (1) 
		FROM EPK_ParametrosSistema
		WHERE UPPER (CodParametro)	= @CodParametro
		AND FechaInicio		<= @Fecha
		AND (FechaFin IS NULL OR  FechaFin  >= @Fecha)
		) >0 
		
		SELECT @Res = ValorNumerico 
		FROM EPK_ParametrosSistema
		WHERE UPPER(CodParametro)	= @CodParametro
		AND FechaInicio		<= @Fecha
		AND (FechaFin IS NULL OR  FechaFin  >= @Fecha)
	
	RETURN @Res

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[fn_ObtenerParametroNumerico] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[fn_ObtenerParametroNumerico] TO PUBLIC
    AS [dbo];

