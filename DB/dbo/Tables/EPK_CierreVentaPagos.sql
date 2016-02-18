CREATE TABLE [dbo].[EPK_CierreVentaPagos] (
    [IdCierreV]   INT             NOT NULL,
    [IdTienda]    INT             CONSTRAINT [DF_EPK_CierreVentaPagos_IdTienda] DEFAULT ((1)) NOT NULL,
    [IdFormaPago] TINYINT         NOT NULL,
    [MontoPagos]  DECIMAL (18, 2) NOT NULL,
    [MontoCierre] DECIMAL (18, 2) NOT NULL,
    [Observacion] VARCHAR (200)   NULL,
    [NroControl]  VARCHAR (20)    NULL,
    [TStamp]      ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_CierreVentaPagos] PRIMARY KEY CLUSTERED ([IdCierreV] ASC, [IdTienda] ASC, [IdFormaPago] ASC),
    CONSTRAINT [FK_EPK_CierreVentaPagos_EPK_CierreVentaEncabezado1] FOREIGN KEY ([IdCierreV], [IdTienda]) REFERENCES [dbo].[EPK_CierreVentaEncabezado] ([IdCierreV], [IdTienda]),
    CONSTRAINT [FK_EPK_CierreVentaPagos_EPK_FormaPago] FOREIGN KEY ([IdFormaPago]) REFERENCES [dbo].[EPK_FormaPago] ([IdFormaPago]),
    CONSTRAINT [FK_EPK_CierreVentaPagos_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda])
);








GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_CierreVentaPagos] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_CierreVentaPagos] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_CierreVentaPagos] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_CierreVentaPagos] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_CierreVentaPagos] TO PUBLIC
    AS [dbo];

