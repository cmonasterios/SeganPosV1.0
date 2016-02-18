CREATE TABLE [dbo].[EPK_CierreVentaEncabezado] (
    [IdCierreV]      INT             IDENTITY (1, 1) NOT NULL,
    [IdTienda]       INT             CONSTRAINT [DF_EPK_CierreVentaEncabezado_IdTienda] DEFAULT ((1)) NOT NULL,
    [Fecha]          DATE            NOT NULL,
    [Hora]           TIME (7)        NOT NULL,
    [IdUsuario]      INT             NOT NULL,
    [Observaciones]  VARCHAR (200)   NULL,
    [MontoBase]      NUMERIC (18, 2) NULL,
    [MontoIVA]       NUMERIC (18, 2) NULL,
    [MontoDescuento] NUMERIC (18, 2) NULL,
    [MontoExento]    NUMERIC (18, 2) NULL,
    [MontoTotal]     NUMERIC (18, 2) NULL,
    [TotalAlivios]   NUMERIC (18, 2) NULL,
    [TotalAperturas] NUMERIC (18, 2) NULL,
    [FechaCreacion]  DATETIME        CONSTRAINT [DF_EPK_CierreVentaEncabezado_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [TStamp]         ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_CierreVentaEncabezado] PRIMARY KEY CLUSTERED ([IdCierreV] ASC, [IdTienda] ASC),
    CONSTRAINT [FK_EPK_CierreVentaEncabezado_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda]),
    CONSTRAINT [FK_EPK_CierreVentaEncabezado_EPK_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario])
);










GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_CierreVentaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_CierreVentaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_CierreVentaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_CierreVentaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_CierreVentaEncabezado] TO PUBLIC
    AS [dbo];

