CREATE TABLE [dbo].[EPK_CajaDispositivo] (
    [IdCajaDispositivo] INT        IDENTITY (1, 1) NOT NULL,
    [IdDispositivo]     INT        NOT NULL,
    [IdCaja]            INT        NOT NULL,
    [FechaInicio]       DATE       NOT NULL,
    [FechaFin]          DATE       NULL,
    [TStamp]            ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_CajaDispositivo_1] PRIMARY KEY CLUSTERED ([IdCajaDispositivo] ASC),
    CONSTRAINT [FK_EPK_CajaDispositivo_EPK_Caja] FOREIGN KEY ([IdCaja]) REFERENCES [dbo].[EPK_Caja] ([IdCaja]),
    CONSTRAINT [FK_EPK_CajaDispositivo_EPK_Dispositivo] FOREIGN KEY ([IdDispositivo]) REFERENCES [dbo].[EPK_Dispositivo] ([IdDispositivo]),
    CONSTRAINT [UNQ_EPK_CajaDispositivo] UNIQUE NONCLUSTERED ([IdDispositivo] ASC, [IdCaja] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_CajaDispositivo] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_CajaDispositivo] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_CajaDispositivo] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_CajaDispositivo] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_CajaDispositivo] TO PUBLIC
    AS [dbo];

