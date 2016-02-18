CREATE TABLE [dbo].[EPK_SeguridadPlantilla] (
    [IdPlantilla] INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL,
    [TStamp]      ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_SeguridadPlantilla] PRIMARY KEY CLUSTERED ([IdPlantilla] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_SeguridadPlantilla] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_SeguridadPlantilla] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_SeguridadPlantilla] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_SeguridadPlantilla] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_SeguridadPlantilla] TO PUBLIC
    AS [dbo];

