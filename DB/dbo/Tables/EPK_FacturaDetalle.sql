CREATE TABLE [dbo].[EPK_FacturaDetalle] (
    [IdFactura]          INT             NOT NULL,
    [IdTienda]           INT             CONSTRAINT [DF_EPK_FacturaDetalle_IdTienda] DEFAULT ((1)) NOT NULL,
    [IdArticulo]         INT             NOT NULL,
    [Cantidad]           INT             NOT NULL,
    [Precio]             DECIMAL (18, 2) NOT NULL,
    [Descuento]          BIT             CONSTRAINT [DF_EPK_FacturaDetalle_Descuento] DEFAULT ((0)) NOT NULL,
    [MontoDescuento]     DECIMAL (18, 2) CONSTRAINT [DF_EPK_FacturaDetalle_MontoDescuento] DEFAULT ((0)) NOT NULL,
    [Exento]             BIT             CONSTRAINT [DF_EPK_FacturaDetalle_Excento] DEFAULT ((1)) NOT NULL,
    [MontoImpuesto]      DECIMAL (18, 2) CONSTRAINT [DF_EPK_FacturaDetalle_MontoImpuesto] DEFAULT ((0)) NOT NULL,
    [PrecioNeto]         DECIMAL (18, 2) CONSTRAINT [DF_EPK_FacturaDetalle_PrecioNeto] DEFAULT ((0)) NOT NULL,
    [Cambio]             BIT             CONSTRAINT [DF_EPK_FacturaDetalle_Cambio] DEFAULT ((0)) NOT NULL,
    [IdMotivoDevolucion] TINYINT         NULL,
    [TStamp]             ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_FacturaDetalle] PRIMARY KEY CLUSTERED ([IdFactura] ASC, [IdTienda] ASC, [IdArticulo] ASC, [Cambio] ASC),
    CONSTRAINT [FK_EPK_FacturaDetalle_EPK_Articulo] FOREIGN KEY ([IdArticulo]) REFERENCES [dbo].[EPK_Articulo] ([IdArticulo]),
    CONSTRAINT [FK_EPK_FacturaDetalle_EPK_FacturaEncabezado1] FOREIGN KEY ([IdFactura], [IdTienda]) REFERENCES [dbo].[EPK_FacturaEncabezado] ([IdFactura], [IdTienda]),
    CONSTRAINT [FK_EPK_FacturaDetalle_EPK_MotivoDevolucion] FOREIGN KEY ([IdMotivoDevolucion]) REFERENCES [dbo].[EPK_MotivoDevolucion] ([IdMotivo]),
    CONSTRAINT [FK_EPK_FacturaDetalle_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda])
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_FacturaDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_FacturaDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_FacturaDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_FacturaDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_FacturaDetalle] TO PUBLIC
    AS [dbo];

