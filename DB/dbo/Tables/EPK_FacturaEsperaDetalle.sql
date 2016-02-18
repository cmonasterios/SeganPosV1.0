CREATE TABLE [dbo].[EPK_FacturaEsperaDetalle] (
    [IdFacturaEspera] INT             NOT NULL,
    [IdArticulo]      INT             NOT NULL,
    [Cantidad]        INT             NOT NULL,
    [Precio]          DECIMAL (18, 2) NOT NULL,
    [Descuento]       BIT             CONSTRAINT [DF_EPK_FacturaEsperaDetalle_Descuento] DEFAULT ((0)) NOT NULL,
    [MontoDescuento]  DECIMAL (18, 2) CONSTRAINT [DF_EPK_FacturaEsperaDetalle_MontoDescuento] DEFAULT ((0)) NOT NULL,
    [Exento]          BIT             CONSTRAINT [DF_EPK_FacturaEsperaDetalle_Excento] DEFAULT ((1)) NOT NULL,
    [MontoImpuesto]   DECIMAL (18, 2) CONSTRAINT [DF_EPK_FacturaEsperaDetalle_MontoImpuesto] DEFAULT ((0)) NOT NULL,
    [PrecioNeto]      DECIMAL (18, 2) NOT NULL,
    [Cambio]          BIT             CONSTRAINT [DF_EPK_FacturaEsperaDetalle_Cambio] DEFAULT ((0)) NOT NULL,
    [TStamp]          ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_FacturaEsperaDetalle_1] PRIMARY KEY CLUSTERED ([IdFacturaEspera] ASC, [IdArticulo] ASC, [Cambio] ASC),
    CONSTRAINT [FK_EPK_FacturaEsperaDetalle_EPK_Articulo] FOREIGN KEY ([IdArticulo]) REFERENCES [dbo].[EPK_Articulo] ([IdArticulo]),
    CONSTRAINT [FK_EPK_FacturaEsperaDetalle_EPK_FacturaEsperaEncabezado] FOREIGN KEY ([IdFacturaEspera]) REFERENCES [dbo].[EPK_FacturaEsperaEncabezado] ([IdFacturaEspera])
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_FacturaEsperaDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_FacturaEsperaDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_FacturaEsperaDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_FacturaEsperaDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_FacturaEsperaDetalle] TO PUBLIC
    AS [dbo];

