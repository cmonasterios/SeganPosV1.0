CREATE TABLE [dbo].[EPK_FacturaEncabezadocalBackup] (
    [IdTienda]              INT             CONSTRAINT [DF_EPK_FacturaEncabezadocalBackup_IdTienda] DEFAULT ((1)) NOT NULL,
    [IdFactura]             INT             NOT NULL,
    [TicketFiscal]          VARCHAR (10)    NULL,
    [IdCaja]                INT             NOT NULL,
    [COO]                   CHAR (6)        NULL,
    [SerialMF]              VARCHAR (15)    NOT NULL,
    [IdEstatus]             SMALLINT        NOT NULL,
    [Fecha]                 DATE            NOT NULL,
    [Hora]                  TIME (7)        NOT NULL,
    [PorcDescuento]         DECIMAL (4, 2)  NOT NULL,
    [IdCliente]             INT             NOT NULL,
    [MontoBase]             DECIMAL (18, 2) NULL,
    [MontoDescuento]        DECIMAL (18, 2) NULL,
    [MontoIVA]              DECIMAL (18, 2) NOT NULL,
    [MontoTotal]            DECIMAL (18, 2) NULL,
    [NroReporteZ]           VARCHAR (10)    NULL,
    [IdVendedor]            BIGINT          NULL,
    [FechaCreacion]         DATETIME        NOT NULL,
    [IdUsuarioCreacion]     INT             NOT NULL,
    [FechaModificacion]     DATETIME        NULL,
    [IdUsuarioModificacion] INT             NULL,
    [TStamp]                ROWVERSION      NOT NULL
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_FacturaEncabezadocalBackup] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_FacturaEncabezadocalBackup] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_FacturaEncabezadocalBackup] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_FacturaEncabezadocalBackup] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_FacturaEncabezadocalBackup] TO PUBLIC
    AS [dbo];

