CREATE TABLE [dbo].[EPK_VentasDiarias] (
    [CodTienda]     VARCHAR (20)    NOT NULL,
    [FechMFiscal]   SMALLDATETIME   NOT NULL,
    [CodMFiscal]    VARCHAR (10)    NOT NULL,
    [NroZ]          VARCHAR (50)    NOT NULL,
    [CodArticulo]   VARCHAR (20)    NOT NULL,
    [Descuento]     DECIMAL (18, 9) NOT NULL,
    [TipoDocumento] INT             NOT NULL,
    [DFactura]      VARCHAR (50)    NULL,
    [HFactura]      VARCHAR (50)    NULL,
    [AcumCantidad]  INT             NULL,
    [PrecioBase]    DECIMAL (18, 9) NULL,
    [PrecioIVA]     DECIMAL (18, 9) NULL,
    [PrecioTotal]   DECIMAL (18, 9) NULL,
    [PorcIVA]       DECIMAL (18, 9) NULL,
    [TStamp]        ROWVERSION      NULL,
    CONSTRAINT [PK_EPK_VentasDiarias] PRIMARY KEY CLUSTERED ([CodTienda] ASC, [FechMFiscal] ASC, [CodMFiscal] ASC, [NroZ] ASC, [CodArticulo] ASC, [Descuento] ASC, [TipoDocumento] ASC)
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_VentasDiarias] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_VentasDiarias] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_VentasDiarias] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_VentasDiarias] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_VentasDiarias] TO PUBLIC
    AS [dbo];

