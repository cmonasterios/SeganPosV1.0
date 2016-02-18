CREATE TABLE [dbo].[EPK_TipoTemporada] (
    [IdTipoTemporada] TINYINT       IDENTITY (1, 1) NOT NULL,
    [Descripcion]     VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_EPK_TipoTemporada] PRIMARY KEY CLUSTERED ([IdTipoTemporada] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TipoTemporada] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TipoTemporada] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TipoTemporada] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TipoTemporada] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TipoTemporada] TO PUBLIC
    AS [dbo];

