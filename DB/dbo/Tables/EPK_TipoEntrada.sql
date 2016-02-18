CREATE TABLE [dbo].[EPK_TipoEntrada] (
    [IdTipoEntrada] SMALLINT     NOT NULL,
    [Descripcion]   VARCHAR (20) NULL,
    [TStamp]        ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_TipoEntrada] PRIMARY KEY CLUSTERED ([IdTipoEntrada] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TipoEntrada] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TipoEntrada] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TipoEntrada] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TipoEntrada] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TipoEntrada] TO PUBLIC
    AS [dbo];

