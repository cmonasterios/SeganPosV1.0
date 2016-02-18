CREATE TABLE [dbo].[EPK_PerfilObjetos] (
    [IdPerfil]   INT        NOT NULL,
    [IdObjeto]   INT        NOT NULL,
    [Habilitado] BIT        NOT NULL,
    [TStamp]     ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_PerfilObjetos] PRIMARY KEY CLUSTERED ([IdPerfil] ASC, [IdObjeto] ASC),
    CONSTRAINT [FK_EPK_PerfilObjetos_EPK_Objeto] FOREIGN KEY ([IdObjeto]) REFERENCES [dbo].[EPK_Objeto] ([IdObjeto]),
    CONSTRAINT [FK_EPK_PerfilObjetos_EPK_Perfil] FOREIGN KEY ([IdPerfil]) REFERENCES [dbo].[EPK_Perfil] ([IdPerfil])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_PerfilObjetos] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_PerfilObjetos] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_PerfilObjetos] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_PerfilObjetos] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_PerfilObjetos] TO PUBLIC
    AS [dbo];

