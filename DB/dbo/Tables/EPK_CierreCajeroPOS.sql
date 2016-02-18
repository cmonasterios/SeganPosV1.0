CREATE TABLE [dbo].[EPK_CierreCajeroPOS] (
    [IdCierre]    BIGINT          NOT NULL,
    [IdTienda]    INT             CONSTRAINT [DF_EPK_CierreCajeroPOS_IdTienda] DEFAULT ((1)) NOT NULL,
    [IdFormaPago] TINYINT         NOT NULL,
    [IdPOS]       INT             NOT NULL,
    [LotePOS]     SMALLINT        NOT NULL,
    [MontoPOS]    DECIMAL (18, 2) NOT NULL,
    [MontoPago]   DECIMAL (18, 2) NOT NULL,
    [Observacion] VARCHAR (200)   NULL,
    [tStamp]      ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_CierreCajeroPOS] PRIMARY KEY CLUSTERED ([IdCierre] ASC, [IdTienda] ASC, [IdFormaPago] ASC, [IdPOS] ASC),
    CONSTRAINT [FK_EPK_CierreCajeroPOS_EPK_CierreCajeroEncabezado1] FOREIGN KEY ([IdCierre], [IdTienda]) REFERENCES [dbo].[EPK_CierreCajeroEncabezado] ([IdCierre], [IdTienda]),
    CONSTRAINT [FK_EPK_CierreCajeroPOS_EPK_FormaPago] FOREIGN KEY ([IdFormaPago]) REFERENCES [dbo].[EPK_FormaPago] ([IdFormaPago]),
    CONSTRAINT [FK_EPK_CierreCajeroPOS_EPK_POS] FOREIGN KEY ([IdPOS]) REFERENCES [dbo].[EPK_POS] ([IdPOS]),
    CONSTRAINT [FK_EPK_CierreCajeroPOS_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda])
);






GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_CierreCajeroPOS] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_CierreCajeroPOS] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_CierreCajeroPOS] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_CierreCajeroPOS] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_CierreCajeroPOS] TO PUBLIC
    AS [dbo];

