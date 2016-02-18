CREATE TABLE [dbo].[EPK_CierreMaquinaFiscal] (
    [IdCierreMF]         BIGINT          IDENTITY (1, 1) NOT NULL,
    [IdTienda]           INT             CONSTRAINT [DF_EPK_CierreMaquinaFiscal_IdTienda] DEFAULT ((1)) NOT NULL,
    [IdMaquina]          INT             NOT NULL,
    [Fecha]              DATE            NOT NULL,
    [Hora]               TIME (7)        NOT NULL,
    [ReporteZ]           VARCHAR (10)    NOT NULL,
    [COO]                CHAR (6)        NULL,
    [FacturaDesde]       VARCHAR (10)    NULL,
    [FacturaHasta]       VARCHAR (10)    NULL,
    [CantidadFacturas]   INT             NULL,
    [BaseImponibleFact]  DECIMAL (18, 2) NULL,
    [ExentoFact]         DECIMAL (18, 2) NULL,
    [DescuentoFact]      DECIMAL (18, 2) NULL,
    [ImpuestoFact]       DECIMAL (18, 2) NULL,
    [MontoTotalFact]     DECIMAL (18, 2) NOT NULL,
    [NCDesde]            VARCHAR (10)    NULL,
    [NCHasta]            VARCHAR (10)    NULL,
    [CantidadNC]         INT             NULL,
    [BaseImponibleNC]    DECIMAL (18, 2) NULL,
    [ExentoNC]           DECIMAL (18, 2) NULL,
    [DescuentoNC]        DECIMAL (18, 2) NULL,
    [ImpuestoNC]         DECIMAL (18, 2) NULL,
    [MontoTotalNC]       DECIMAL (18, 2) NULL,
    [FacturaDesdeZ]      VARCHAR (10)    NULL,
    [FacturaHastaZ]      VARCHAR (10)    NULL,
    [CantidadFacturasZ]  INT             NULL,
    [BaseImponibleFactZ] DECIMAL (18, 2) NULL,
    [ExentoFactZ]        DECIMAL (18, 2) NULL,
    [DescuentoFactZ]     DECIMAL (18, 2) NULL,
    [ImpuestoFactZ]      DECIMAL (18, 2) NULL,
    [TotalFactZ]         DECIMAL (18, 2) NULL,
    [BaseImponibleNCZ]   DECIMAL (18, 2) NULL,
    [ImpuestoNCZ]        DECIMAL (18, 2) NULL,
    [ExentoNCZ]          DECIMAL (18, 2) NULL,
    [TotalNCZ]           DECIMAL (18, 2) NULL,
    [Zrestantes]         INT             NULL,
    [tStamp]             ROWVERSION      NOT NULL,
    [Manual]             BIT             CONSTRAINT [DF_EPK_CierreMaquinaFiscal_Manual] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_EPK_CierreMaquinaFiscal] PRIMARY KEY CLUSTERED ([IdCierreMF] ASC, [IdTienda] ASC),
    CONSTRAINT [FK_EPK_CierreMaquinaFiscal_EPK_Dispositivo] FOREIGN KEY ([IdMaquina]) REFERENCES [dbo].[EPK_Dispositivo] ([IdDispositivo]),
    CONSTRAINT [IX_EPK_CierreMaquinaFiscal] UNIQUE NONCLUSTERED ([IdMaquina] ASC, [ReporteZ] ASC)
);


















GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_CierreMaquinaFiscal] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_CierreMaquinaFiscal] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_CierreMaquinaFiscal] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_CierreMaquinaFiscal] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_CierreMaquinaFiscal] TO PUBLIC
    AS [dbo];

