CREATE TABLE [dbo].[EPK_UsuarioApp] (
    [IdUsuario]         INT        NOT NULL,
    [IdApp]             INT        NOT NULL,
    [IdPerfil]          INT        NOT NULL,
    [IdObjetoPrincipal] INT        NULL,
    [TStamp]            ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_UsuarioApp] PRIMARY KEY CLUSTERED ([IdUsuario] ASC, [IdApp] ASC),
    CONSTRAINT [FK_EPK_UsuarioAppSEGAN_EPK_App] FOREIGN KEY ([IdApp]) REFERENCES [dbo].[EPK_App] ([IdApp]),
    CONSTRAINT [FK_EPK_UsuarioAppSEGAN_EPK_Perfil] FOREIGN KEY ([IdPerfil]) REFERENCES [dbo].[EPK_Perfil] ([IdPerfil]),
    CONSTRAINT [FK_EPK_UsuarioAppSEGAN_EPK_UsuarioSEGAN] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_UsuarioApp] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_UsuarioApp] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_UsuarioApp] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_UsuarioApp] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_UsuarioApp] TO PUBLIC
    AS [dbo];

