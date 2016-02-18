CREATE TABLE [dbo].[EPK_TipoInsumo] (
    [IdTipoInsumo] SMALLINT     IDENTITY (1, 1) NOT NULL,
    [Nombre]       VARCHAR (50) NULL,
    CONSTRAINT [PK_IdTipoInsumo] PRIMARY KEY CLUSTERED ([IdTipoInsumo] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TipoInsumo] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TipoInsumo] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TipoInsumo] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TipoInsumo] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TipoInsumo] TO PUBLIC
    AS [dbo];

