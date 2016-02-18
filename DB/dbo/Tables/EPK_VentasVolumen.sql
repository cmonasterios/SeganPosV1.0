CREATE TABLE [dbo].[EPK_VentasVolumen] (
    [IdVentasVolumen]    INT           IDENTITY (1, 1) NOT NULL,
    [IdTienda]           INT           NOT NULL,
    [IdFactura]          INT           NOT NULL,
    [IdUsuarioAprobador] INT           NOT NULL,
    [Observacion]        VARCHAR (150) NULL,
    [TStamp]             ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_VentasVolumen] PRIMARY KEY CLUSTERED ([IdVentasVolumen] ASC),
    CONSTRAINT [FK_EPK_VentasVolumen_EPK_FacturaEncabezado] FOREIGN KEY ([IdFactura], [IdTienda]) REFERENCES [dbo].[EPK_FacturaEncabezado] ([IdFactura], [IdTienda]),
    CONSTRAINT [FK_EPK_VentasVolumen_EPK_Usuario] FOREIGN KEY ([IdUsuarioAprobador]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario])
);

