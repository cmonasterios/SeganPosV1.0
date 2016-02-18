CREATE TABLE [dbo].[EPK_HistoricoFacturaEncabezado] (
    [IdHistoricoFactura]    INT             NOT NULL,
    [TicketFiscal]          VARCHAR (10)    NOT NULL,
    [IdCaja]                INT             NOT NULL,
    [COO]                   CHAR (6)        NOT NULL,
    [SerialMF]              VARCHAR (15)    NOT NULL,
    [IdEstatus]             SMALLINT        NOT NULL,
    [Fecha]                 DATE            CONSTRAINT [DF_EPK_HistoricoFacturaEncabezado_Fecha] DEFAULT (getdate()) NOT NULL,
    [Hora]                  TIME (7)        CONSTRAINT [DF_EPK_HistoricoFacturaEncabezado_Hora] DEFAULT (getdate()) NOT NULL,
    [PorcDescuento]         DECIMAL (4, 2)  CONSTRAINT [DF_EPK_HistoricoFacturaEncabezado_PorcDescuento] DEFAULT ((0)) NOT NULL,
    [IdCliente]             INT             NOT NULL,
    [MontoTotal]            DECIMAL (18, 2) NOT NULL,
    [MontoIVA]              DECIMAL (18, 2) NOT NULL,
    [NroReporteZ]           VARCHAR (10)    NULL,
    [FechaCreacion]         DATETIME        CONSTRAINT [DF_EPK_HistoricoFacturaEncabezado_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [IdUsuarioCreacion]     INT             NOT NULL,
    [FechaModificacion]     DATETIME        CONSTRAINT [DF_EPK_HistoricoFacturaEncabezado_FechaModificacion] DEFAULT (getdate()) NULL,
    [IdUsuarioModificacion] INT             NULL,
    [TStamp]                ROWVERSION      NOT NULL,
    [IdTipoDocumento]       TINYINT         NULL,
    [NumeroDocumento]       VARCHAR (30)    NULL,
    CONSTRAINT [PK_EPK_HistoricoFacturaEncabezado_1] PRIMARY KEY CLUSTERED ([IdHistoricoFactura] ASC),
    CONSTRAINT [FK_EPK_HistoricoFacturaEncabezado_EPK_Caja] FOREIGN KEY ([IdCaja]) REFERENCES [dbo].[EPK_Caja] ([IdCaja]),
    CONSTRAINT [FK_EPK_HistoricoFacturaEncabezado_EPK_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[EPK_Cliente] ([IdCliente]),
    CONSTRAINT [FK_EPK_HistoricoFacturaEncabezado_EPK_Usuario] FOREIGN KEY ([IdUsuarioCreacion]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario]),
    CONSTRAINT [FK_EPK_HistoricoFacturaEncabezado_EPK_Usuario1] FOREIGN KEY ([IdUsuarioModificacion]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario])
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_HistoricoFacturaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_HistoricoFacturaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_HistoricoFacturaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_HistoricoFacturaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_HistoricoFacturaEncabezado] TO PUBLIC
    AS [dbo];

