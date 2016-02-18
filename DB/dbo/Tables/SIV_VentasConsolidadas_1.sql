CREATE TABLE [dbo].[SIV_VentasConsolidadas] (
    [CodTienda]                VARCHAR (20)    NOT NULL,
    [FechaDeVenta]             DATETIME        NOT NULL,
    [VentasDia]                DECIMAL (18, 2) NULL,
    [VentasImpuesto]           DECIMAL (18, 2) NULL,
    [CantidadVendida]          INT             NULL,
    [FechaUltimaActualizacion] DATETIME        NULL,
    [NroTransacciones]         INT             NULL,
    [FechaHoraUltFactura]      DATETIME        NULL,
    [Existencia]               BIGINT          DEFAULT ((0)) NULL,
    [UltimaExistencia]         BIGINT          DEFAULT ((0)) NULL,
    [NroSKU]                   INT             DEFAULT ((0)) NULL,
    [CodigoDynamics]           CHAR (6)        NULL,
    [CantidadColAnt]           INT             NULL,
    [CantidadActual]           INT             NULL,
    [Bisuteria]                INT             NULL,
    [Accesorios]               INT             NULL,
    [Suministros]              INT             NULL,
    [ShopBag]                  INT             NULL,
    [TStamp]                   ROWVERSION      NULL,
    CONSTRAINT [PK_SIV_VentasConsolidadas] PRIMARY KEY CLUSTERED ([CodTienda] ASC, [FechaDeVenta] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[SIV_VentasConsolidadas] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[SIV_VentasConsolidadas] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[SIV_VentasConsolidadas] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[SIV_VentasConsolidadas] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[SIV_VentasConsolidadas] TO PUBLIC
    AS [dbo];

