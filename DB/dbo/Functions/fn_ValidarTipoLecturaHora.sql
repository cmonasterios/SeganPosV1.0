-- =================================================
-- Author:		sderkoyorikian
-- Create date: 24/04/2013
-- Description:	Determina la diferencia entre 
--				la hora de marcaje y la hora base.
-- =================================================
CREATE FUNCTION [dbo].[fn_ValidarTipoLecturaHora] (
	@Hora	as time(7),
	@HoraBase	as time(7)
	)
RETURNS INT
AS
BEGIN

	-- Declare the return variable here
	DECLARE @Res AS INT = 0

	SET @Res  = DATEDIFF (MINUTE, @Hora , @HoraBase)
	
	RETURN @RES

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[fn_ValidarTipoLecturaHora] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[fn_ValidarTipoLecturaHora] TO PUBLIC
    AS [dbo];

