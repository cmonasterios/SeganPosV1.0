CREATE TABLE [dbo].[EPK_DepositoEncabezado] (
    [IdDeposito]            BIGINT          IDENTITY (1, 1) NOT NULL,
    [IdTienda]              INT             CONSTRAINT [DF_EPK_DepositoEncabezado_IdTienda] DEFAULT ((1)) NOT NULL,
    [FechaDeposito]         DATETIME        CONSTRAINT [DF_EPK_DepositoEncabezado_FechaDeposito] DEFAULT (getdate()) NOT NULL,
    [DepositoValores]       BIT             CONSTRAINT [DF_EPK_DepositoEncabezado_DepositoValores] DEFAULT ((1)) NOT NULL,
    [MontoEfectivo]         DECIMAL (18, 2) NOT NULL,
    [MontoCheque]           DECIMAL (18, 2) NULL,
    [Saldo]                 DECIMAL (18, 2) NULL,
    [FechaVenta]            DATE            CONSTRAINT [DF_EPK_DepositoEncabezado_FechaVenta] DEFAULT (getdate()) NOT NULL,
    [SerialPrecinto]        VARCHAR (20)    NULL,
    [NumeroTransaccion]     VARCHAR (30)    NOT NULL,
    [IdEntidad]             INT             NULL,
    [IdUsuarioResponsable]  INT             NOT NULL,
    [IdUsuarioResponsable2] INT             NULL,
    [Observaciones]         VARCHAR (40)    NULL,
    [FechaRecogida]         DATETIME        NULL,
    [ImagenCataporte]       VARBINARY (MAX) NULL,
    [MimeType]              VARCHAR (255)   NULL,
    [FileName]              VARCHAR (255)   NULL,
    [TStamp]                ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_Deposito] PRIMARY KEY CLUSTERED ([IdDeposito] ASC, [IdTienda] ASC),
    CONSTRAINT [FK_EPK_DepositoEncabezado_EPK_EntidadFinanciera] FOREIGN KEY ([IdEntidad]) REFERENCES [dbo].[EPK_EntidadFinanciera] ([IdEntidad]),
    CONSTRAINT [FK_EPK_DepositoEncabezado_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda]),
    CONSTRAINT [FK_EPK_DepositoEncabezado_EPK_Usuario] FOREIGN KEY ([IdUsuarioResponsable]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario]),
    CONSTRAINT [FK_EPK_DepositoEncabezado_EPK_Usuario1] FOREIGN KEY ([IdUsuarioResponsable2]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario])
);






















GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_DepositoEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_DepositoEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_DepositoEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_DepositoEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_DepositoEncabezado] TO PUBLIC
    AS [dbo];

