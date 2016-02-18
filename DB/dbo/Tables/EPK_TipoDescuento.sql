CREATE TABLE [dbo].[EPK_TipoDescuento] (
    [IdTipoDescuento] TINYINT       IDENTITY (1, 1) NOT NULL,
    [Descripcion]     VARCHAR (100) NOT NULL,
    [TStamp]          ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_TipoDescuento] PRIMARY KEY CLUSTERED ([IdTipoDescuento] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TipoDescuento] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TipoDescuento] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TipoDescuento] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TipoDescuento] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TipoDescuento] TO PUBLIC
    AS [dbo];

