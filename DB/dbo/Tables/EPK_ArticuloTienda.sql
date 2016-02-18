CREATE TABLE [dbo].[EPK_ArticuloTienda] (
    [IdArticulo] INT        NOT NULL,
    [IdTienda]   INT        NOT NULL,
    [TStamp]     ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_ArticuloTienda] PRIMARY KEY CLUSTERED ([IdArticulo] ASC, [IdTienda] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_ArticuloTienda] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_ArticuloTienda] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_ArticuloTienda] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_ArticuloTienda] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_ArticuloTienda] TO PUBLIC
    AS [dbo];

