CREATE TABLE [dbo].[EPK_NotaCreditoEncabezado] (
    [IdNotaC]               INT             IDENTITY (1, 1) NOT NULL,
    [IdTienda]              INT             CONSTRAINT [DF_EPK_NotaCreditoEncabezado_IdTienda] DEFAULT ((1)) NOT NULL,
    [IdFactura]             INT             NOT NULL,
    [IdEstatus]             SMALLINT        NOT NULL,
    [Fecha]                 DATE            NOT NULL,
    [Hora]                  TIME (7)        NOT NULL,
    [PorcDescuento]         DECIMAL (4, 2)  NOT NULL,
    [MontoBase]             DECIMAL (18, 2) NULL,
    [MontoDescuento]        DECIMAL (18, 2) NULL,
    [MontoIVA]              DECIMAL (18, 2) NOT NULL,
    [MontoTotal]            DECIMAL (18, 2) NOT NULL,
    [TicketFiscal]          VARCHAR (10)    NULL,
    [COO]                   CHAR (6)        NULL,
    [SerialMF]              VARCHAR (15)    NOT NULL,
    [Motivo]                VARCHAR (100)   NULL,
    [Observacion]           VARCHAR (100)   NULL,
    [NroReporteZ]           VARCHAR (10)    NULL,
    [FechaCreacion]         DATETIME        CONSTRAINT [DF_EPK_NotaCreditoEncabezado_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [IdUsuarioCreacion]     INT             NOT NULL,
    [FechaModificacion]     DATETIME        NULL,
    [IdUsuarioModificacion] INT             NULL,
    [NombreCliente]         VARCHAR (102)   NOT NULL,
    [TStamp]                ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_NotaCreditoEncabezado_1] PRIMARY KEY CLUSTERED ([IdNotaC] ASC, [IdTienda] ASC),
    CONSTRAINT [FK_EPK_NotaCreditoEncabezado_EPK_FacturaEncabezado1] FOREIGN KEY ([IdFactura], [IdTienda]) REFERENCES [dbo].[EPK_FacturaEncabezado] ([IdFactura], [IdTienda]),
    CONSTRAINT [FK_EPK_NotaCreditoEncabezado_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda])
);


















GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_NotaCreditoEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_NotaCreditoEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_NotaCreditoEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_NotaCreditoEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_NotaCreditoEncabezado] TO PUBLIC
    AS [dbo];


GO
CREATE NONCLUSTERED INDEX [IX_EPK_NotaCreditoEncabezado]
    ON [dbo].[EPK_NotaCreditoEncabezado]([IdFactura] ASC);

