CREATE TABLE [dbo].[EPK_PrioridadModulo] (
    [IdPrioridad]       SMALLINT     IDENTITY (1, 1) NOT NULL,
    [Descripcion]       VARCHAR (50) NOT NULL,
    [FechaCreacion]     DATETIME     CONSTRAINT [DF_EPK_PrioridadModulo_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion] DATETIME     NULL,
    [TStamp]            ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_ModuloNivel] PRIMARY KEY CLUSTERED ([IdPrioridad] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_PrioridadModulo] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_PrioridadModulo] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_PrioridadModulo] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_PrioridadModulo] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_PrioridadModulo] TO PUBLIC
    AS [dbo];

