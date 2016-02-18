CREATE TABLE [dbo].[EPK_SeguridadPlantillaApp] (
    [IdPlantilla] INT        NOT NULL,
    [IdApp]       INT        NOT NULL,
    [IdPerfil]    INT        NOT NULL,
    [TStamp]      ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_SeguridadPlantillaApp] PRIMARY KEY CLUSTERED ([IdPlantilla] ASC, [IdApp] ASC, [IdPerfil] ASC),
    CONSTRAINT [FK_EPK_SeguridadPlantillaApp_EPK_App] FOREIGN KEY ([IdApp]) REFERENCES [dbo].[EPK_App] ([IdApp]),
    CONSTRAINT [FK_EPK_SeguridadPlantillaApp_EPK_Perfil] FOREIGN KEY ([IdPerfil]) REFERENCES [dbo].[EPK_Perfil] ([IdPerfil]),
    CONSTRAINT [FK_EPK_SeguridadPlantillaApp_EPK_SeguridadPlantilla] FOREIGN KEY ([IdPlantilla]) REFERENCES [dbo].[EPK_SeguridadPlantilla] ([IdPlantilla])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_SeguridadPlantillaApp] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_SeguridadPlantillaApp] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_SeguridadPlantillaApp] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_SeguridadPlantillaApp] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_SeguridadPlantillaApp] TO PUBLIC
    AS [dbo];

