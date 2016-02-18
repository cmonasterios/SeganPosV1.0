CREATE TABLE [dbo].[EPK_AperturaCajeroEncabezado] (
    [IdApertura] BIGINT   IDENTITY (1, 1) NOT NULL,
    [IdCaja]     INT      NOT NULL,
    [IdCajero]   INT      NOT NULL,
    [Fecha]      DATE     NOT NULL,
    [Hora]       TIME (7) NOT NULL,
    [IdCierre]   BIGINT   NULL,
    CONSTRAINT [PK_EPK_AperturaCajero] PRIMARY KEY CLUSTERED ([IdApertura] ASC),
    CONSTRAINT [FK_EPK_AperturaCajero_EPK_Caja] FOREIGN KEY ([IdCaja]) REFERENCES [dbo].[EPK_Caja] ([IdCaja]),
    CONSTRAINT [FK_EPK_AperturaCajero_EPK_Usuario] FOREIGN KEY ([IdCajero]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario])
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_AperturaCajeroEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_AperturaCajeroEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_AperturaCajeroEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_AperturaCajeroEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_AperturaCajeroEncabezado] TO PUBLIC
    AS [dbo];

