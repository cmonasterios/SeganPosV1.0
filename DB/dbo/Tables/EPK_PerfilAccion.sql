CREATE TABLE [dbo].[EPK_PerfilAccion] (
    [IdPerfil]    INT        NOT NULL,
    [IdObjeto]    INT        NOT NULL,
    [IdAccion]    INT        NOT NULL,
    [Autorizador] BIT        CONSTRAINT [DF_EPK_PerfilAccion_Autorizador] DEFAULT ((0)) NOT NULL,
    [Habilitado]  BIT        CONSTRAINT [DF_EPK_PerfilAccion_Habilitado] DEFAULT ((1)) NOT NULL,
    [TStamp]      ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_PerfilAccion] PRIMARY KEY CLUSTERED ([IdPerfil] ASC, [IdObjeto] ASC, [IdAccion] ASC),
    CONSTRAINT [FK_EPK_PerfilAccion_EPK_Accion] FOREIGN KEY ([IdAccion]) REFERENCES [dbo].[EPK_Accion] ([IdAccion]),
    CONSTRAINT [FK_EPK_PerfilAccion_EPK_Perfil] FOREIGN KEY ([IdPerfil]) REFERENCES [dbo].[EPK_Perfil] ([IdPerfil])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_PerfilAccion] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_PerfilAccion] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_PerfilAccion] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_PerfilAccion] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_PerfilAccion] TO PUBLIC
    AS [dbo];

