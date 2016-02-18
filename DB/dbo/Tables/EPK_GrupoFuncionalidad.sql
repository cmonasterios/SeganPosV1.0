CREATE TABLE [dbo].[EPK_GrupoFuncionalidad] (
    [IdGrupoFuncionalidad] INT           NOT NULL,
    [Descripcion]          VARCHAR (60)  NULL,
    [URL]                  VARCHAR (500) NULL,
    [Tipo]                 CHAR (1)      NULL,
    [Padre]                INT           NULL,
    [TipoServicio]         SMALLINT      NULL,
    [TStamp]               ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_GrupoFuncionalidad] PRIMARY KEY CLUSTERED ([IdGrupoFuncionalidad] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_GrupoFuncionalidad] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_GrupoFuncionalidad] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_GrupoFuncionalidad] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_GrupoFuncionalidad] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_GrupoFuncionalidad] TO PUBLIC
    AS [dbo];

