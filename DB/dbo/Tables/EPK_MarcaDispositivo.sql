CREATE TABLE [dbo].[EPK_MarcaDispositivo] (
    [IdMarca]           SMALLINT      IDENTITY (1, 1) NOT NULL,
    [Descripcion]       VARCHAR (100) NOT NULL,
    [FechaCreacion]     DATETIME      CONSTRAINT [DF_EPK_MarcaDispositivo_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion] DATETIME      NULL,
    [TStamp]            ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_MarcaDispositivo] PRIMARY KEY CLUSTERED ([IdMarca] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_MarcaDispositivo] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_MarcaDispositivo] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_MarcaDispositivo] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_MarcaDispositivo] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_MarcaDispositivo] TO PUBLIC
    AS [dbo];

