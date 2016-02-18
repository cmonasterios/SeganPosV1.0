CREATE TABLE [dbo].[EPK_HistoricoFacturaPago] (
    [IdPago]             INT             NOT NULL,
    [IdFormaPago]        TINYINT         NOT NULL,
    [IdHistoricoFactura] INT             NOT NULL,
    [IdEntidad]          INT             NULL,
    [IdPOS]              INT             NULL,
    [NumeroPago]         VARCHAR (10)    NULL,
    [Monto]              DECIMAL (18, 2) NOT NULL,
    [TStamp]             ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_HistoricoFacturaPago] PRIMARY KEY CLUSTERED ([IdPago] ASC),
    CONSTRAINT [FK_EPK_HistoricoFacturaPago_EPK_EntidadFinanciera] FOREIGN KEY ([IdEntidad]) REFERENCES [dbo].[EPK_EntidadFinanciera] ([IdEntidad]),
    CONSTRAINT [FK_EPK_HistoricoFacturaPago_EPK_FormaPago] FOREIGN KEY ([IdFormaPago]) REFERENCES [dbo].[EPK_FormaPago] ([IdFormaPago]),
    CONSTRAINT [FK_EPK_HistoricoFacturaPago_EPK_HistoricoFacturaEncabezado] FOREIGN KEY ([IdHistoricoFactura]) REFERENCES [dbo].[EPK_HistoricoFacturaEncabezado] ([IdHistoricoFactura]),
    CONSTRAINT [FK_EPK_HistoricoFacturaPago_EPK_POS] FOREIGN KEY ([IdPOS]) REFERENCES [dbo].[EPK_POS] ([IdPOS])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_HistoricoFacturaPago] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_HistoricoFacturaPago] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_HistoricoFacturaPago] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_HistoricoFacturaPago] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_HistoricoFacturaPago] TO PUBLIC
    AS [dbo];

