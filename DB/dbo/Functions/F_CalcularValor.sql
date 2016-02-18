-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[F_CalcularValor]
(
-- Add the parameters for the stored procedure here
    @Anterior  numeric(19, 5) ,
    @Actual    numeric(19, 5) 
	)
RETURNS     numeric(19, 5)
AS
BEGIN
   set @Anterior =  @Anterior +@Actual
	-- Return the result of the function
	RETURN @Anterior

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[F_CalcularValor] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[F_CalcularValor] TO PUBLIC
    AS [dbo];

