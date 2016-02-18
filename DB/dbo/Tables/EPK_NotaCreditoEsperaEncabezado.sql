CREATE TABLE [dbo].[EPK_NotaCreditoEsperaEncabezado] (
    [IdNotaCreditoE]        INT             IDENTITY (1, 1) NOT NULL,
    [IdTienda]              INT             NOT NULL,
    [OrigenTienda]          BIT             CONSTRAINT [DF_EPK_NotaCreditoEsperaEncabezado_OrigenTienda] DEFAULT ((1)) NOT NULL,
    [IdFactura]             INT             NOT NULL,
    [IdFacturaSust]         INT             NULL,
    [IdEstatus]             SMALLINT        NOT NULL,
    [Fecha]                 DATE            NOT NULL,
    [Hora]                  TIME (7)        NOT NULL,
    [PorcDescuento]         DECIMAL (4, 2)  NOT NULL,
    [MontoBase]             DECIMAL (18, 2) NULL,
    [MontoDescuento]        DECIMAL (18, 2) NULL,
    [MontoIVA]              DECIMAL (18, 2) NOT NULL,
    [MontoTotal]            DECIMAL (18, 2) NOT NULL,
    [IdNCTienda]            INT             NULL,
    [TicketFiscalTienda]    VARCHAR (10)    NULL,
    [COO]                   CHAR (6)        NULL,
    [SerialMF]              VARCHAR (15)    NOT NULL,
    [Motivo]                VARCHAR (100)   NULL,
    [Observacion]           VARCHAR (100)   NULL,
    [NroReporteZ]           VARCHAR (10)    NULL,
    [FechaCreacion]         DATETIME        CONSTRAINT [DF_EPK_NotaCreditoEsperaEncabezado_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [IdUsuarioCreacion]     INT             NOT NULL,
    [FechaModificacion]     DATETIME        NULL,
    [IdUsuarioModificacion] INT             NULL,
    [Imagen]                VARBINARY (MAX) NULL,
    [MimeType]              VARCHAR (255)   NULL,
    [FileName]              VARCHAR (255)   NULL,
    [NombreCliente]         VARCHAR (102)   NOT NULL,
    [TStamp]                ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_NotaCreditoEsperaEncabezado] PRIMARY KEY CLUSTERED ([IdNotaCreditoE] ASC, [IdTienda] ASC, [OrigenTienda] ASC),
    CONSTRAINT [FK_EPK_NotaCreditoEsperaEncabezado_EPK_FacturaEncabezado] FOREIGN KEY ([IdFactura], [IdTienda]) REFERENCES [dbo].[EPK_FacturaEncabezado] ([IdFactura], [IdTienda]),
    CONSTRAINT [FK_EPK_NotaCreditoEsperaEncabezado_EPK_FacturaEncabezado1] FOREIGN KEY ([IdFacturaSust], [IdTienda]) REFERENCES [dbo].[EPK_FacturaEncabezado] ([IdFactura], [IdTienda]),
    CONSTRAINT [FK_EPK_NotaCreditoEsperaEncabezado_EPK_NotaCreditoEncabezado] FOREIGN KEY ([IdNCTienda], [IdTienda]) REFERENCES [dbo].[EPK_NotaCreditoEncabezado] ([IdNotaC], [IdTienda])
);


























GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_NotaCreditoEsperaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_NotaCreditoEsperaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_NotaCreditoEsperaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_NotaCreditoEsperaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_NotaCreditoEsperaEncabezado] TO PUBLIC
    AS [dbo];


GO
CREATE NONCLUSTERED INDEX [IX_EPK_NotaCreditoEsperaEncabezado]
    ON [dbo].[EPK_NotaCreditoEsperaEncabezado]([IdFactura] ASC);

