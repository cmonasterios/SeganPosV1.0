CREATE TABLE [dbo].[EPK_TipoPrenda] (
    [IdTipoPrenda]     TINYINT      NOT NULL,
    [Descripcion]      VARCHAR (30) NOT NULL,
    [Ropa]             BIT          NOT NULL,
    [RestriccionVenta] BIT          CONSTRAINT [DF_EPK_TipoPrenda_RestriccionVenta] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_EPK_TipoPrenda] PRIMARY KEY CLUSTERED ([IdTipoPrenda] ASC)
);






GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TipoPrenda] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TipoPrenda] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TipoPrenda] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TipoPrenda] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TipoPrenda] TO PUBLIC
    AS [dbo];

