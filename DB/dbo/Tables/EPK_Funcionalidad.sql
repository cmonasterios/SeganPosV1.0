CREATE TABLE [dbo].[EPK_Funcionalidad] (
    [IdFuncionalidad]      INT          NOT NULL,
    [IdGrupoFuncionalidad] INT          NOT NULL,
    [IdTipoFuncionalidad]  INT          NOT NULL,
    [Descripcion]          VARCHAR (60) NULL,
    [TStamp]               ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Funcionalidad_1] PRIMARY KEY CLUSTERED ([IdFuncionalidad] ASC),
    CONSTRAINT [FK_EPK_Funcionalidad_EPK_GrupoFuncionalidad] FOREIGN KEY ([IdGrupoFuncionalidad]) REFERENCES [dbo].[EPK_GrupoFuncionalidad] ([IdGrupoFuncionalidad]),
    CONSTRAINT [FK_EPK_Funcionalidad_EPK_TipoFuncionalidad] FOREIGN KEY ([IdTipoFuncionalidad]) REFERENCES [dbo].[EPK_TipoFuncionalidad] ([IdTipoFuncionalidad])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Funcionalidad] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Funcionalidad] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Funcionalidad] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Funcionalidad] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Funcionalidad] TO PUBLIC
    AS [dbo];

