CREATE TABLE [dbo].[EPK_FacturaPago] (
    [IdPago]            INT             IDENTITY (1, 1) NOT NULL,
    [IdTienda]          INT             CONSTRAINT [DF_EPK_FacturaPago_IdTienda] DEFAULT ((1)) NOT NULL,
    [IdFormaPago]       TINYINT         NOT NULL,
    [IdFactura]         INT             NOT NULL,
    [IdEntidad]         INT             NULL,
    [IdPOS]             INT             NULL,
    [NumeroPago]        VARCHAR (30)    NULL,
    [Monto]             DECIMAL (18, 2) NOT NULL,
    [MontoVuelto]       DECIMAL (6, 2)  CONSTRAINT [DF_EPK_FacturaPago_MontoVuelto] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]     DATE            CONSTRAINT [DF_EPK_FacturaPago_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion] DATE            NULL,
    [TStamp]            ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_FacturaPago] PRIMARY KEY CLUSTERED ([IdPago] ASC, [IdTienda] ASC),
    CONSTRAINT [FK_EPK_FacturaPago_EPK_EntidadFinanciera] FOREIGN KEY ([IdEntidad]) REFERENCES [dbo].[EPK_EntidadFinanciera] ([IdEntidad]),
    CONSTRAINT [FK_EPK_FacturaPago_EPK_FacturaEncabezado] FOREIGN KEY ([IdFactura], [IdTienda]) REFERENCES [dbo].[EPK_FacturaEncabezado] ([IdFactura], [IdTienda]),
    CONSTRAINT [FK_EPK_FacturaPago_EPK_FormaPago] FOREIGN KEY ([IdFormaPago]) REFERENCES [dbo].[EPK_FormaPago] ([IdFormaPago]),
    CONSTRAINT [FK_EPK_FacturaPago_EPK_POS] FOREIGN KEY ([IdPOS]) REFERENCES [dbo].[EPK_POS] ([IdPOS]),
    CONSTRAINT [FK_EPK_FacturaPago_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda])
);






GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_FacturaPago] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_FacturaPago] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_FacturaPago] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_FacturaPago] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_FacturaPago] TO PUBLIC
    AS [dbo];

