CREATE TABLE [dbo].[EPK_HistoricoFacturaDetalle] (
    [IdHistoricoFactura] INT             NOT NULL,
    [IdArticulo]         INT             NOT NULL,
    [Cantidad]           INT             NOT NULL,
    [Precio]             DECIMAL (18, 2) NOT NULL,
    [Descuento]          BIT             CONSTRAINT [DF_EPK_HistoricoFacturaDetalle_Descuento] DEFAULT ((0)) NOT NULL,
    [Exento]             BIT             CONSTRAINT [DF_EPK_HistoricoFacturaDetalle_Excento] DEFAULT ((1)) NOT NULL,
    [Cambio]             BIT             CONSTRAINT [DF_EPK_HistoricoFacturaDetalle_Cambio] DEFAULT ((0)) NOT NULL,
    [IdMotivoDevolucion] TINYINT         NULL,
    [TStamp]             ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_HistoricoFacturaDetalle_1] PRIMARY KEY CLUSTERED ([IdHistoricoFactura] ASC, [IdArticulo] ASC),
    CONSTRAINT [FK_EPK_HistoricoFacturaDetalle_EPK_Articulo] FOREIGN KEY ([IdArticulo]) REFERENCES [dbo].[EPK_Articulo] ([IdArticulo]),
    CONSTRAINT [FK_EPK_HistoricoFacturaDetalle_EPK_HistoricoFacturaEncabezado] FOREIGN KEY ([IdHistoricoFactura]) REFERENCES [dbo].[EPK_HistoricoFacturaEncabezado] ([IdHistoricoFactura])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_HistoricoFacturaDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_HistoricoFacturaDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_HistoricoFacturaDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_HistoricoFacturaDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_HistoricoFacturaDetalle] TO PUBLIC
    AS [dbo];

