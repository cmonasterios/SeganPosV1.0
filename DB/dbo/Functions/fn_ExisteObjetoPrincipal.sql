-- =================================================
-- Author:		sderkoyorikian
-- Create date: 07/05/2013
-- Description:	
-- =================================================
CREATE FUNCTION [dbo].[fn_ExisteObjetoPrincipal] (
	@IdModulo	INT 
	)
RETURNS INT
AS
BEGIN

	-- Declare the return variable here
	DECLARE @Res AS INT = 0	
	
	IF (SELECT	COUNT(1) 
		FROM	EPK_Objeto AS O
		WHERE	IdModulo= @IdModulo AND IdPadre IS NULL)>0
		SET @Res = 1
			
	RETURN @Res

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[fn_ExisteObjetoPrincipal] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[fn_ExisteObjetoPrincipal] TO PUBLIC
    AS [dbo];

