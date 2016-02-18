CREATE TABLE [dbo].[EPK_Estado] (
    [IdEstado]          INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]            VARCHAR (50) NOT NULL,
    [IdRegionPais]      INT          NOT NULL,
    [FechaCreacion]     DATETIME     CONSTRAINT [DF_EPK_Estado_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion] DATETIME     NULL,
    [TStamp]            ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Estado] PRIMARY KEY CLUSTERED ([IdEstado] ASC),
    CONSTRAINT [FK_EPK_Estado_EPK_RegionPais] FOREIGN KEY ([IdRegionPais]) REFERENCES [dbo].[EPK_RegionPais] ([IdRegionPais])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Estado] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Estado] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Estado] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Estado] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Estado] TO PUBLIC
    AS [dbo];

