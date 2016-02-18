CREATE TABLE [dbo].[EPK_ClienteCompra] (
    [IdVentaCliente]  BIGINT       IDENTITY (1, 1) NOT NULL,
    [IdTipoDocumento] TINYINT      NOT NULL,
    [NumeroDocumento] VARCHAR (30) NOT NULL,
    [IdArticulo]      INT          NOT NULL,
    [Cantidad]        TINYINT      NOT NULL,
    [FechaUltAct]     DATETIME     CONSTRAINT [DF_EPK_ClienteCompra_FechaUltAct] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_EPK_ClienteCompra] PRIMARY KEY CLUSTERED ([IdVentaCliente] ASC),
    CONSTRAINT [FK_EPK_ClienteCompra_EPK_Articulo] FOREIGN KEY ([IdArticulo]) REFERENCES [dbo].[EPK_Articulo] ([IdArticulo]),
    CONSTRAINT [FK_EPK_ClienteCompra_EPK_Cliente] FOREIGN KEY ([IdTipoDocumento], [NumeroDocumento]) REFERENCES [dbo].[EPK_Cliente] ([IdTipoDocumento], [NumeroDocumento]),
    CONSTRAINT [IX_EPK_ClienteCompra] UNIQUE NONCLUSTERED ([IdTipoDocumento] ASC, [NumeroDocumento] ASC, [IdArticulo] ASC)
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_ClienteCompra] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_ClienteCompra] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_ClienteCompra] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_ClienteCompra] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_ClienteCompra] TO PUBLIC
    AS [dbo];

