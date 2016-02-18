CREATE TABLE [dbo].[EPK_HistoricoNotaCreditoDetalle] (
    [IdNota]                INT             NOT NULL,
    [IdArticulo]            INT             NOT NULL,
    [Cantidad]              INT             NOT NULL,
    [Precio]                DECIMAL (18, 2) NOT NULL,
    [Descuento]             BIT             NOT NULL,
    [FechaCreacion]         DATETIME        CONSTRAINT [DF_EPK_HistoricoNotaCreditoEsperaDetalle_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [IdUsuarioCreacion]     INT             NOT NULL,
    [FechaModificacion]     DATETIME        NULL,
    [IdUsuarioModificacion] INT             NULL,
    [TStamp]                ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_HistoricoNotaCreditoEsperaDetalle] PRIMARY KEY CLUSTERED ([IdNota] ASC, [IdArticulo] ASC),
    CONSTRAINT [FK_EPK_HistoricoNotaCreditoDetalle_EPK_Articulo] FOREIGN KEY ([IdArticulo]) REFERENCES [dbo].[EPK_Articulo] ([IdArticulo]),
    CONSTRAINT [FK_EPK_HistoricoNotaCreditoEsperaDetalle_EPK_HistoricoNotaCreditoEsperaEncabezado] FOREIGN KEY ([IdNota]) REFERENCES [dbo].[EPK_HistoricoNotaCreditoEncabezado] ([IdNota])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_HistoricoNotaCreditoDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_HistoricoNotaCreditoDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_HistoricoNotaCreditoDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_HistoricoNotaCreditoDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_HistoricoNotaCreditoDetalle] TO PUBLIC
    AS [dbo];

