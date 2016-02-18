CREATE TABLE [dbo].[EPK_Dispositivo] (
    [IdDispositivo]        INT          IDENTITY (1, 1) NOT NULL,
    [IdTipoDispositivo]    SMALLINT     NOT NULL,
    [Serial]               VARCHAR (15) NOT NULL,
    [FechaInicioOperacion] DATETIME     NOT NULL,
    [FechaFinOperacion]    DATETIME     NULL,
    [IdEstatus]            SMALLINT     NOT NULL,
    [IdMarca]              SMALLINT     NOT NULL,
    [NroReporteZ]          VARCHAR (10) NULL,
    [FechaCreacion]        DATETIME     CONSTRAINT [DF_EPK_Dispositivo_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion]    DATETIME     NULL,
    [TStamp]               ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Dispositivos] PRIMARY KEY CLUSTERED ([IdDispositivo] ASC),
    CONSTRAINT [FK_EPK_Dispositivo_EPK_Estatus] FOREIGN KEY ([IdEstatus]) REFERENCES [dbo].[EPK_Estatus] ([IdEstatus]),
    CONSTRAINT [FK_EPK_Dispositivo_EPK_TipoDispositivo] FOREIGN KEY ([IdTipoDispositivo]) REFERENCES [dbo].[EPK_TipoDispositivo] ([IdTipoDispositivo])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Dispositivo] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Dispositivo] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Dispositivo] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Dispositivo] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Dispositivo] TO PUBLIC
    AS [dbo];

