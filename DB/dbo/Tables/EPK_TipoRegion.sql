CREATE TABLE [dbo].[EPK_TipoRegion] (
    [IdTipoRegion]           SMALLINT     NOT NULL,
    [Descripcion]            VARCHAR (40) NULL,
    [BonoAliBaseFraccionado] BIT          CONSTRAINT [DF_EPK_TipoRegion_BonoAliBaseFraccionado] DEFAULT ((0)) NOT NULL,
    [TStamp]                 ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_TipoRegion] PRIMARY KEY CLUSTERED ([IdTipoRegion] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TipoRegion] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TipoRegion] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TipoRegion] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TipoRegion] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TipoRegion] TO PUBLIC
    AS [dbo];

