CREATE TABLE [dbo].[EPK_DepositoCheque] (
    [IdDeposito]    BIGINT     NOT NULL,
    [IdTienda]      INT        CONSTRAINT [DF_EPK_DepositoCheque_IdTienda] DEFAULT ((1)) NOT NULL,
    [IdPago]        INT        NOT NULL,
    [FechaCreacion] DATETIME   CONSTRAINT [DF_EPK_DepositoPago_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [tStamp]        ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_DepositoPago_1] PRIMARY KEY CLUSTERED ([IdDeposito] ASC, [IdTienda] ASC, [IdPago] ASC),
    CONSTRAINT [FK_EPK_DepositoCheque_EPK_DepositoEncabezado] FOREIGN KEY ([IdDeposito], [IdTienda]) REFERENCES [dbo].[EPK_DepositoEncabezado] ([IdDeposito], [IdTienda]),
    CONSTRAINT [FK_EPK_DepositoCheque_EPK_FacturaPago] FOREIGN KEY ([IdPago], [IdTienda]) REFERENCES [dbo].[EPK_FacturaPago] ([IdPago], [IdTienda]),
    CONSTRAINT [FK_EPK_DepositoCheque_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda])
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_DepositoCheque] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_DepositoCheque] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_DepositoCheque] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_DepositoCheque] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_DepositoCheque] TO PUBLIC
    AS [dbo];

