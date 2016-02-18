CREATE TABLE [dbo].[EPK_DepositoDetalle] (
    [IdDeposito]     BIGINT     NOT NULL,
    [IdTienda]       INT        CONSTRAINT [DF_EPK_DepositoDetalle_IdTienda] DEFAULT ((1)) NOT NULL,
    [IdDenominacion] TINYINT    NOT NULL,
    [Cantidad]       SMALLINT   NOT NULL,
    [tStamp]         ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_DepositoDetalle] PRIMARY KEY CLUSTERED ([IdDeposito] ASC, [IdTienda] ASC, [IdDenominacion] ASC),
    CONSTRAINT [FK_EPK_DepositoDetalle_EPK_Denominacion] FOREIGN KEY ([IdDenominacion]) REFERENCES [dbo].[EPK_Denominacion] ([IdDenominacion]),
    CONSTRAINT [FK_EPK_DepositoDetalle_EPK_DepositoEncabezado] FOREIGN KEY ([IdDeposito], [IdTienda]) REFERENCES [dbo].[EPK_DepositoEncabezado] ([IdDeposito], [IdTienda]),
    CONSTRAINT [FK_EPK_DepositoDetalle_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda])
);






GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_DepositoDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_DepositoDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_DepositoDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_DepositoDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_DepositoDetalle] TO PUBLIC
    AS [dbo];

