CREATE TYPE [dbo].[tmp_ArticuloActGenero] AS TABLE (
    [IdGenero] INT NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_ArticuloActGenero] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_ArticuloActGenero] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_ArticuloActGenero] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_ArticuloActGenero] TO PUBLIC;



