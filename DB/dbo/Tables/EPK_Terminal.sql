CREATE TABLE [dbo].[EPK_Terminal] (
    [IdRegion]             INT          NOT NULL,
    [IdLocalidad]          INT          NOT NULL,
    [IdTerminal]           INT          IDENTITY (11, 1) NOT NULL,
    [IdTipoTerminal]       SMALLINT     NULL,
    [Descripcion]          VARCHAR (30) NULL,
    [DireccionIP]          VARCHAR (39) NULL,
    [Puerto]               INT          NULL,
    [DireccionMAC]         VARCHAR (20) NULL,
    [VersionFirmware]      VARCHAR (50) NULL,
    [NumeroDeSerial]       VARCHAR (30) NULL,
    [VersionSDK]           VARCHAR (50) NULL,
    [Plataforma]           VARCHAR (30) NULL,
    [CardFun]              SMALLINT     NULL,
    [Estatus]              SMALLINT     NULL,
    [FechaHoraDispositivo] DATETIME     NULL,
    [FechaHoraServidor]    DATETIME     NULL,
    [Activo]               BIT          NULL,
    [Modelo]               SMALLINT     NULL,
    [CapacidadUsuario]     INT          NULL,
    [CapacidadHuella]      INT          NULL,
    [CantidadLecturas]     INT          NULL,
    [CantidadClaves]       INT          NULL,
    [CantidadHuellas]      INT          NULL,
    [CantidadUsuarios]     INT          NULL,
    [Principal]            BIT          NULL,
    [Gateway]              VARCHAR (17) NULL,
    [Mascara]              VARCHAR (17) NULL,
    [TStamp]               ROWVERSION   NOT NULL,
    [AntiPassback]         BIT          CONSTRAINT [DF_EPK_Terminal_AntiPassback] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_EPK_Terminal] PRIMARY KEY CLUSTERED ([IdTerminal] ASC),
    CONSTRAINT [UNQ_EPK_Terminal] UNIQUE NONCLUSTERED ([DireccionIP] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Terminal] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Terminal] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Terminal] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Terminal] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Terminal] TO PUBLIC
    AS [dbo];

