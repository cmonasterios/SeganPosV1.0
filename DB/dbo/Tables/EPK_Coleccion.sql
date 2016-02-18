CREATE TABLE [dbo].[EPK_Coleccion] (
    [IdColeccion]         INT          IDENTITY (1, 1) NOT NULL,
    [CodigoColeccion]     CHAR (11)    NOT NULL,
    [Descripcion]         VARCHAR (50) NOT NULL,
    [FechaCreacion]       DATETIME     NOT NULL,
    [Activo]              BIT          NOT NULL,
    [Actual]              BIT          CONSTRAINT [DF_EPK_Coleccion_Actual] DEFAULT ((0)) NOT NULL,
    [IdColeccionAnterior] INT          NULL,
    [TStamp]              ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Coleccion] PRIMARY KEY CLUSTERED ([IdColeccion] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_EPK_Coleccion]
    ON [dbo].[EPK_Coleccion]([CodigoColeccion] ASC);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Coleccion] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Coleccion] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Coleccion] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Coleccion] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Coleccion] TO PUBLIC
    AS [dbo];


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Código del valor categoría de GP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EPK_Coleccion', @level2type = N'COLUMN', @level2name = N'CodigoColeccion';

