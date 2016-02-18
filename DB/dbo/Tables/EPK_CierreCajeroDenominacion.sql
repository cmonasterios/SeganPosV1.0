CREATE TABLE [dbo].[EPK_CierreCajeroDenominacion] (
    [IdCierre]       BIGINT     NOT NULL,
    [IdTienda]       INT        CONSTRAINT [DF_EPK_CierreCajeroDenominacion_IdTienda] DEFAULT ((1)) NOT NULL,
    [IdDenominacion] TINYINT    NOT NULL,
    [Cantidad]       SMALLINT   NOT NULL,
    [tStamp]         ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_CierreCajeroDenominacion] PRIMARY KEY CLUSTERED ([IdCierre] ASC, [IdTienda] ASC, [IdDenominacion] ASC),
    CONSTRAINT [FK_EPK_CierreCajeroDenominacion_EPK_CierreCajeroEncabezado1] FOREIGN KEY ([IdCierre], [IdTienda]) REFERENCES [dbo].[EPK_CierreCajeroEncabezado] ([IdCierre], [IdTienda]),
    CONSTRAINT [FK_EPK_CierreCajeroDenominacion_EPK_Denominacion] FOREIGN KEY ([IdDenominacion]) REFERENCES [dbo].[EPK_Denominacion] ([IdDenominacion]),
    CONSTRAINT [FK_EPK_CierreCajeroDenominacion_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda])
);






GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_CierreCajeroDenominacion] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_CierreCajeroDenominacion] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_CierreCajeroDenominacion] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_CierreCajeroDenominacion] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_CierreCajeroDenominacion] TO PUBLIC
    AS [dbo];

