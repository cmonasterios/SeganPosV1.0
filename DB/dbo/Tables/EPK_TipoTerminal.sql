CREATE TABLE [dbo].[EPK_TipoTerminal] (
    [IdTipoTerminal] SMALLINT     NOT NULL,
    [Descripcion]    VARCHAR (30) NULL,
    [TStamp]         ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_TipoTerminal] PRIMARY KEY CLUSTERED ([IdTipoTerminal] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TipoTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TipoTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TipoTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TipoTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TipoTerminal] TO PUBLIC
    AS [dbo];

