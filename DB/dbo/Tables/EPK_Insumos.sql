CREATE TABLE [dbo].[EPK_Insumos] (
    [IdInsumo]     INT             IDENTITY (1, 1) NOT NULL,
    [Nombre]       VARCHAR (50)    NULL,
    [IdTipoInsumo] SMALLINT        NULL,
    [Foto]         VARBINARY (MAX) NULL,
    [Nota]         VARCHAR (50)    NULL,
    [Existencia]   SMALLINT        NULL,
    [Entradas]     SMALLINT        NULL,
    [Salidas]      SMALLINT        NULL,
    [Habilitado]   BIT             NULL,
    CONSTRAINT [PK_IdInsumo] PRIMARY KEY CLUSTERED ([IdInsumo] ASC),
    CONSTRAINT [FK_EPK_Insumos_EPK_TipoInsumo] FOREIGN KEY ([IdTipoInsumo]) REFERENCES [dbo].[EPK_TipoInsumo] ([IdTipoInsumo])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Insumos] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Insumos] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Insumos] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Insumos] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Insumos] TO PUBLIC
    AS [dbo];

