CREATE TABLE [dbo].[EPK_NotaCreditoEsperaDetalle] (
    [IdNotaCreditoE]        INT             NOT NULL,
    [IdTienda]              INT             CONSTRAINT [DF_EPK_NotaCreditoEsperaDetalle_IdTienda] DEFAULT ((1)) NOT NULL,
    [IdArticulo]            INT             NOT NULL,
    [Cambio]                BIT             NOT NULL,
    [OrigenTienda]          BIT             CONSTRAINT [DF_EPK_NotaCreditoEsperaDetalle_OrigenTienda] DEFAULT ((1)) NOT NULL,
    [Cantidad]              INT             NOT NULL,
    [Precio]                DECIMAL (18, 2) NOT NULL,
    [Descuento]             BIT             NOT NULL,
    [MontoDescuento]        DECIMAL (18, 2) NOT NULL,
    [Exento]                BIT             NOT NULL,
    [MontoImpuesto]         DECIMAL (18, 2) NOT NULL,
    [PrecioNeto]            DECIMAL (18, 2) NOT NULL,
    [FechaCreacion]         DATETIME        CONSTRAINT [DF_EPK_NotaCreditoEsperaDetalle_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [IdUsuarioCreacion]     INT             NOT NULL,
    [FechaModificacion]     DATETIME        NULL,
    [IdUsuarioModificacion] INT             NULL,
    [TStamp]                ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_NotaCreditoEsperaDetalle] PRIMARY KEY CLUSTERED ([IdNotaCreditoE] ASC, [IdTienda] ASC, [IdArticulo] ASC, [Cambio] ASC, [OrigenTienda] ASC),
    CONSTRAINT [FK_EPK_NotaCreditoEsperaDetalle_EPK_Articulo] FOREIGN KEY ([IdArticulo]) REFERENCES [dbo].[EPK_Articulo] ([IdArticulo]),
    CONSTRAINT [FK_EPK_NotaCreditoEsperaDetalle_EPK_NotaCreditoEsperaEncabezado] FOREIGN KEY ([IdNotaCreditoE], [IdTienda], [OrigenTienda]) REFERENCES [dbo].[EPK_NotaCreditoEsperaEncabezado] ([IdNotaCreditoE], [IdTienda], [OrigenTienda]),
    CONSTRAINT [FK_EPK_NotaCreditoEsperaDetalle_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda])
);








GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_NotaCreditoEsperaDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_NotaCreditoEsperaDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_NotaCreditoEsperaDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_NotaCreditoEsperaDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_NotaCreditoEsperaDetalle] TO PUBLIC
    AS [dbo];

