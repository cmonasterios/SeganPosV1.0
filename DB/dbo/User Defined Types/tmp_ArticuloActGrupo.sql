CREATE TYPE [dbo].[tmp_ArticuloActGrupo] AS TABLE (
    [IdGrupo] INT NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_ArticuloActGrupo] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_ArticuloActGrupo] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_ArticuloActGrupo] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_ArticuloActGrupo] TO PUBLIC;



