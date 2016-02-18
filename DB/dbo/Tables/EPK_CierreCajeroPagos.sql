CREATE TABLE [dbo].[EPK_CierreCajeroPagos] (
    [IdCierre]    BIGINT          NOT NULL,
    [IdTienda]    INT             CONSTRAINT [DF_EPK_CierreCajeroPagos_IdTienda] DEFAULT ((1)) NOT NULL,
    [IdFormaPago] TINYINT         NOT NULL,
    [MontoPagos]  DECIMAL (18, 2) NOT NULL,
    [MontoCierre] DECIMAL (18, 2) NOT NULL,
    [Observacion] VARCHAR (200)   NULL,
    [tStamp]      ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_CierreCajeroPagos_1] PRIMARY KEY CLUSTERED ([IdCierre] ASC, [IdTienda] ASC, [IdFormaPago] ASC),
    CONSTRAINT [FK_EPK_CierreCajeroPagos_EPK_CierreCajeroEncabezado1] FOREIGN KEY ([IdCierre], [IdTienda]) REFERENCES [dbo].[EPK_CierreCajeroEncabezado] ([IdCierre], [IdTienda]),
    CONSTRAINT [FK_EPK_CierreCajeroPagos_EPK_FormaPago] FOREIGN KEY ([IdFormaPago]) REFERENCES [dbo].[EPK_FormaPago] ([IdFormaPago]),
    CONSTRAINT [FK_EPK_CierreCajeroPagos_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda])
);






GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_CierreCajeroPagos] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_CierreCajeroPagos] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_CierreCajeroPagos] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_CierreCajeroPagos] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_CierreCajeroPagos] TO PUBLIC
    AS [dbo];

