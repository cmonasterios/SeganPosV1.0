CREATE TABLE [dbo].[EPK_RegionPais] (
    [IdRegionPais] INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]       VARCHAR (50) NOT NULL,
    [IdPais]       INT          NOT NULL,
    [DiaPedido]    TINYINT      NULL,
    [TStamp]       ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_RegionPais] PRIMARY KEY CLUSTERED ([IdRegionPais] ASC),
    CONSTRAINT [FK_EPK_RegionPais_EPK_Pais] FOREIGN KEY ([IdPais]) REFERENCES [dbo].[EPK_Pais] ([IdPais])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_RegionPais] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_RegionPais] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_RegionPais] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_RegionPais] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_RegionPais] TO PUBLIC
    AS [dbo];

