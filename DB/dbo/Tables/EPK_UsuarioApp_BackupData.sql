CREATE TABLE [dbo].[EPK_UsuarioApp_BackupData] (
    [IdUsuario]         INT        NOT NULL,
    [IdPerfil]          INT        NOT NULL,
    [IdApp]             INT        NOT NULL,
    [IdObjetoPrincipal] INT        NULL,
    [TStamp]            ROWVERSION NOT NULL
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_UsuarioApp_BackupData] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_UsuarioApp_BackupData] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_UsuarioApp_BackupData] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_UsuarioApp_BackupData] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_UsuarioApp_BackupData] TO PUBLIC
    AS [dbo];

