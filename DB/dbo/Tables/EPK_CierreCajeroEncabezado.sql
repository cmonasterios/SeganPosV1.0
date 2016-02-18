CREATE TABLE [dbo].[EPK_CierreCajeroEncabezado] (
    [IdCierre]     BIGINT          IDENTITY (1, 1) NOT NULL,
    [IdTienda]     INT             CONSTRAINT [DF_EPK_CierreCajeroEncabezado_IdTienda] DEFAULT ((1)) NOT NULL,
    [IdCaja]       INT             NOT NULL,
    [IdCajero]     INT             NOT NULL,
    [TotalAlivios] DECIMAL (18, 2) NULL,
    [Fecha]        DATE            NOT NULL,
    [Hora]         TIME (7)        NOT NULL,
    [tStamp]       ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_CierreCajero] PRIMARY KEY CLUSTERED ([IdCierre] ASC, [IdTienda] ASC),
    CONSTRAINT [FK_EPK_CierreCajero_EPK_Caja] FOREIGN KEY ([IdCaja]) REFERENCES [dbo].[EPK_Caja] ([IdCaja]),
    CONSTRAINT [FK_EPK_CierreCajero_EPK_Usuario] FOREIGN KEY ([IdCajero]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario]),
    CONSTRAINT [FK_EPK_CierreCajeroEncabezado_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda])
);












GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_CierreCajeroEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_CierreCajeroEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_CierreCajeroEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_CierreCajeroEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_CierreCajeroEncabezado] TO PUBLIC
    AS [dbo];

