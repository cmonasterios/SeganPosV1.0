CREATE TABLE [dbo].[EPK_CierreVentaPOS] (
    [IdCierreV]   INT             NOT NULL,
    [IdTienda]    INT             CONSTRAINT [DF_EPK_CierreVentaPOS_IdTienda] DEFAULT ((1)) NOT NULL,
    [IdFormaPago] TINYINT         NOT NULL,
    [IdPOS]       INT             NOT NULL,
    [TotalDia]    DECIMAL (18, 2) NOT NULL,
    [MontoCierre] DECIMAL (18, 2) NOT NULL,
    [Observacion] VARCHAR (150)   NULL,
    [LotePOS]     SMALLINT        NULL,
    [TStamp]      ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_CierreVentaDetalle] PRIMARY KEY CLUSTERED ([IdCierreV] ASC, [IdTienda] ASC, [IdFormaPago] ASC, [IdPOS] ASC),
    CONSTRAINT [FK_EPK_CierreVentaDetalle_EPK_FormaPago] FOREIGN KEY ([IdFormaPago]) REFERENCES [dbo].[EPK_FormaPago] ([IdFormaPago]),
    CONSTRAINT [FK_EPK_CierreVentaDetalle_EPK_POS] FOREIGN KEY ([IdPOS]) REFERENCES [dbo].[EPK_POS] ([IdPOS]),
    CONSTRAINT [FK_EPK_CierreVentaPOS_EPK_CierreVentaEncabezado] FOREIGN KEY ([IdCierreV], [IdTienda]) REFERENCES [dbo].[EPK_CierreVentaEncabezado] ([IdCierreV], [IdTienda]),
    CONSTRAINT [FK_EPK_CierreVentaPOS_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda])
);








GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_CierreVentaPOS] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_CierreVentaPOS] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_CierreVentaPOS] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_CierreVentaPOS] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_CierreVentaPOS] TO PUBLIC
    AS [dbo];

