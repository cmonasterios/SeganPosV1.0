CREATE TABLE [dbo].[EPK_Localidad] (
    [IdLocalidad] INT          NOT NULL,
    [IdRegion]    INT          NOT NULL,
    [Descripcion] VARCHAR (50) NULL,
    [TStamp]      ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Localidad] PRIMARY KEY CLUSTERED ([IdLocalidad] ASC, [IdRegion] ASC),
    CONSTRAINT [FK_EPK_Localidad_EPK_RegionUbicacion] FOREIGN KEY ([IdRegion]) REFERENCES [dbo].[EPK_Region] ([IdRegion])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Localidad] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Localidad] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Localidad] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Localidad] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Localidad] TO PUBLIC
    AS [dbo];

