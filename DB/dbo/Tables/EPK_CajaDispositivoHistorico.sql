CREATE TABLE [dbo].[EPK_CajaDispositivoHistorico] (
    [IdCajaDispositivo] INT          NOT NULL,
    [IdDispositivo]     INT          NOT NULL,
    [IdCaja]            INT          NOT NULL,
    [FechaInicio]       DATE         NOT NULL,
    [FechaFin]          DATE         NULL,
    [ReporteZIni]       VARCHAR (10) NULL,
    [ReporteZFin]       VARCHAR (10) NULL,
    [TStamp]            ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_CajaDispositivoHistorico] PRIMARY KEY CLUSTERED ([IdCajaDispositivo] ASC),
    CONSTRAINT [FK_EPK_CajaDispositivoHistorico_EPK_Caja] FOREIGN KEY ([IdCaja]) REFERENCES [dbo].[EPK_Caja] ([IdCaja]),
    CONSTRAINT [FK_EPK_CajaDispositivoHistorico_EPK_Dispositivo] FOREIGN KEY ([IdDispositivo]) REFERENCES [dbo].[EPK_Dispositivo] ([IdDispositivo])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_CajaDispositivoHistorico] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_CajaDispositivoHistorico] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_CajaDispositivoHistorico] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_CajaDispositivoHistorico] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_CajaDispositivoHistorico] TO PUBLIC
    AS [dbo];

