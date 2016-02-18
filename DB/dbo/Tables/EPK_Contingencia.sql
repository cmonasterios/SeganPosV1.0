CREATE TABLE [dbo].[EPK_Contingencia] (
    [IdCaja]            INT        NOT NULL,
    [IdFactura]         INT        CONSTRAINT [DF_EPK_Contingencia_IdFactura] DEFAULT ((0)) NOT NULL,
    [IdPago]            INT        CONSTRAINT [DF_EPK_Contingencia_IdPago] DEFAULT ((0)) NOT NULL,
    [IdNotaC]           INT        CONSTRAINT [DF_EPK_Contingencia_IdNotaC] DEFAULT ((0)) NOT NULL,
    [IdCliente]         INT        NOT NULL,
    [IdApertura]        BIGINT     CONSTRAINT [DF_EPK_Contingencia_IdApertura] DEFAULT ((0)) NOT NULL,
    [IdAlivioEfectivo]  BIGINT     CONSTRAINT [DF_EPK_Contingencia_IdAlivioEfectivo] DEFAULT ((0)) NOT NULL,
    [IdCierre]          BIGINT     CONSTRAINT [DF_EPK_Contingencia_IdCierreCajero] DEFAULT ((0)) NOT NULL,
    [IdCierreV]         INT        CONSTRAINT [DF_EPK_Contingencia_IdCierreV] DEFAULT ((0)) NOT NULL,
    [FechaModificacion] DATETIME   CONSTRAINT [DF_EPK_Contingencia_FechaModificacion] DEFAULT (getdate()) NOT NULL,
    [tStamp]            ROWVERSION NOT NULL,
    CONSTRAINT [PK__EPK_Cont__3B7BF2C533758E3C] PRIMARY KEY CLUSTERED ([IdCaja] ASC),
    CONSTRAINT [FK_EPK_Contingencia_EPK_Caja] FOREIGN KEY ([IdCaja]) REFERENCES [dbo].[EPK_Caja] ([IdCaja])
);








GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Contingencia] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Contingencia] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Contingencia] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Contingencia] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Contingencia] TO PUBLIC
    AS [dbo];

