CREATE TYPE [dbo].[tmp_UsuarioApp] AS TABLE (
    [IdUsuario]         INT      NOT NULL,
    [IdPerfil]          INT      NOT NULL,
    [IdApp]             SMALLINT NOT NULL,
    [IdObjetoPrincipal] INT      NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_UsuarioApp] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_UsuarioApp] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_UsuarioApp] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_UsuarioApp] TO PUBLIC;



