CREATE TABLE [dbo].[EPK_HistoricoContingencia] (
    [FechaStatus]       DATETIME   CONSTRAINT [DF_EPK_HistoricoContingencia_FechaStatus] DEFAULT (getdate()) NOT NULL,
    [IdCaja]            INT        NOT NULL,
    [IdFactura]         INT        CONSTRAINT [DF_EPK_HistoricoContingencia_IdFactura] DEFAULT ((0)) NOT NULL,
    [IdPago]            INT        CONSTRAINT [DF_EPK_HistoricoContingencia_IdPago] DEFAULT ((0)) NOT NULL,
    [IdNotaC]           INT        CONSTRAINT [DF_EPK_HistoricoContingencia_IdNotaC] DEFAULT ((0)) NOT NULL,
    [IdCliente]         INT        NOT NULL,
    [IdApertura]        BIGINT     CONSTRAINT [DF_EPK_HistoricoContingencia_IdApertura] DEFAULT ((0)) NOT NULL,
    [IdAlivioEfectivo]  BIGINT     CONSTRAINT [DF_EPK_HistoricoContingencia_IdAlivioEfectivo] DEFAULT ((0)) NOT NULL,
    [IdCierre]          BIGINT     CONSTRAINT [DF_EPK_HistoricoContingencia_IdCierreCajero] DEFAULT ((0)) NOT NULL,
    [IdCierreV]         INT        CONSTRAINT [DF_EPK_HistoricoContingencia_IdCierreV] DEFAULT ((0)) NOT NULL,
    [FechaModificacion] DATETIME   CONSTRAINT [DF_EPK_HistoricoContingencia_FechaModificacion] DEFAULT (getdate()) NOT NULL,
    [TStamp]            ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_HistoricoContingencia] PRIMARY KEY CLUSTERED ([FechaStatus] ASC, [IdCaja] ASC),
    CONSTRAINT [FK_EPK_HistoricoContingencia_EPK_Caja] FOREIGN KEY ([IdCaja]) REFERENCES [dbo].[EPK_Caja] ([IdCaja])
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_HistoricoContingencia] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_HistoricoContingencia] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_HistoricoContingencia] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_HistoricoContingencia] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_HistoricoContingencia] TO PUBLIC
    AS [dbo];

