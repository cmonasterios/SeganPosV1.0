CREATE TABLE [dbo].[EPK_Descuento] (
    [IdDescuento]     INT             IDENTITY (1, 1) NOT NULL,
    [IdTipoDescuento] TINYINT         NOT NULL,
    [Descripcion]     VARCHAR (150)   NULL,
    [FechaInicio]     DATE            NOT NULL,
    [FechaFin]        DATE            NOT NULL,
    [PorcDescuento]   DECIMAL (4, 2)  NULL,
    [MontoLimite]     DECIMAL (18, 2) NULL,
    [TStamp]          ROWVERSION      NULL,
    CONSTRAINT [PK_EPK_Descuento] PRIMARY KEY CLUSTERED ([IdDescuento] ASC),
    CONSTRAINT [FK_EPK_Descuento_EPK_TipoDescuento] FOREIGN KEY ([IdTipoDescuento]) REFERENCES [dbo].[EPK_TipoDescuento] ([IdTipoDescuento])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Descuento] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Descuento] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Descuento] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Descuento] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Descuento] TO PUBLIC
    AS [dbo];

