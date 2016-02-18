CREATE TABLE [dbo].[EPK_TipoFuncionalidad] (
    [IdTipoFuncionalidad] INT          NOT NULL,
    [Descripcion]         VARCHAR (50) NULL,
    [TStamp]              ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_TipoFuncionalidad] PRIMARY KEY CLUSTERED ([IdTipoFuncionalidad] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TipoFuncionalidad] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TipoFuncionalidad] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TipoFuncionalidad] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TipoFuncionalidad] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TipoFuncionalidad] TO PUBLIC
    AS [dbo];

