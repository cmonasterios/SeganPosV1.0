CREATE TYPE [dbo].[tmp_PerfilObjetos] AS TABLE (
    [IdPerfil]   INT NOT NULL,
    [IdObjeto]   INT NOT NULL,
    [Habilitado] BIT NOT NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_PerfilObjetos] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_PerfilObjetos] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_PerfilObjetos] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_PerfilObjetos] TO PUBLIC;



