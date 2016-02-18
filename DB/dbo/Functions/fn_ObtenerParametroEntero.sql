

-- =================================================
-- Author:		sderkoyorikian
-- Create date: 24/04/2013
-- Description:	Obtiene un parámetro de sistema 
--				de tipo entero.
-- =================================================
CREATE FUNCTION [dbo].[fn_ObtenerParametroEntero] (
	@CodParametro	VARCHAR(50),
	@Fecha			DATE,
	@TipoTienda		TINYINT = NULL
	)
RETURNS INT
AS
BEGIN

	-- Declare the return variable here
	DECLARE @Res AS INT = 0
	
	SET @CodParametro = UPPER (@CodParametro)
	
	IF (SELECT COUNT (1) 
		FROM EPK_ParametrosSistema
		WHERE UPPER (CodParametro)	= @CodParametro
		AND FechaInicio		<= @Fecha
		AND (FechaFin IS NULL OR  FechaFin  >= @Fecha)
		AND	(IdTipoTienda = 1 OR (IdTipoTienda  IS NULL OR IdTipoTienda = @TipoTienda))
		) >0 
		
		SELECT @Res = ValorEntero
		FROM EPK_ParametrosSistema
		WHERE UPPER(CodParametro)	= @CodParametro
		AND FechaInicio		<= @Fecha
		AND (FechaFin IS NULL OR  FechaFin  >= @Fecha)
		AND	(IdTipoTienda = 1 OR (IdTipoTienda  IS NULL OR IdTipoTienda = @TipoTienda))
	
	RETURN @Res

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[fn_ObtenerParametroEntero] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[fn_ObtenerParametroEntero] TO PUBLIC
    AS [dbo];

