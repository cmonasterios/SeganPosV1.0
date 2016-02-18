CREATE TABLE [dbo].[EPK_TipoParentesco] (
    [IdTipoParentesco] SMALLINT     IDENTITY (1, 1) NOT NULL,
    [Descripcion]      VARCHAR (30) NULL,
    [TStamp]           ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_TipoParentesco] PRIMARY KEY CLUSTERED ([IdTipoParentesco] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TipoParentesco] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TipoParentesco] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TipoParentesco] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TipoParentesco] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TipoParentesco] TO PUBLIC
    AS [dbo];

