CREATE TYPE [dbo].[tmp_UsuarioTienda] AS TABLE (
    [IdUsuario] INT NOT NULL,
    [IdTienda]  INT NOT NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_UsuarioTienda] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_UsuarioTienda] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_UsuarioTienda] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_UsuarioTienda] TO PUBLIC;



