CREATE TABLE [dbo].[EPK_HistoricoNotaCreditoEncabezado] (
    [IdNota]                INT             NOT NULL,
    [IdFactura]             INT             NOT NULL,
    [IdEstatus]             SMALLINT        NOT NULL,
    [Fecha]                 DATE            NOT NULL,
    [Hora]                  TIME (7)        NOT NULL,
    [MontoTotal]            DECIMAL (18, 2) NOT NULL,
    [TicketFiscal]          VARCHAR (10)    NULL,
    [Motivo]                VARCHAR (100)   NULL,
    [Observacion]           VARCHAR (100)   NULL,
    [FechaCreacion]         DATETIME        CONSTRAINT [DF_EPK_HistoricoNotaCreditoEsperaEncabezado_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [IdUsuarioCreacion]     INT             NOT NULL,
    [FechaModificacion]     DATETIME        NULL,
    [IdUsuarioModificacion] INT             NULL,
    [TStamp]                ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_HistoricoNotaCreditoEsperaEncabezado] PRIMARY KEY CLUSTERED ([IdNota] ASC),
    CONSTRAINT [FK_EPK_HistoricoNotaCreditoEncabezado_EPK_HistoricoFacturaEncabezado] FOREIGN KEY ([IdFactura]) REFERENCES [dbo].[EPK_HistoricoFacturaEncabezado] ([IdHistoricoFactura]),
    CONSTRAINT [FK_EPK_HistoricoNotaCreditoEncabezado_EPK_Usuario] FOREIGN KEY ([IdUsuarioCreacion]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario]),
    CONSTRAINT [FK_EPK_HistoricoNotaCreditoEncabezado_EPK_Usuario1] FOREIGN KEY ([IdUsuarioModificacion]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_HistoricoNotaCreditoEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_HistoricoNotaCreditoEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_HistoricoNotaCreditoEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_HistoricoNotaCreditoEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_HistoricoNotaCreditoEncabezado] TO PUBLIC
    AS [dbo];

