CREATE TABLE [dbo].[EPK_Almacen] (
    [IdAlmacen]           TINYINT       IDENTITY (1, 1) NOT NULL,
    [CodigoAlmacen]       VARCHAR (20)  NOT NULL,
    [Descripcion]         VARCHAR (100) NOT NULL,
    [IdCiudad]            SMALLINT      NOT NULL,
    [IdEstado]            SMALLINT      NOT NULL,
    [Activa]              BIT           NOT NULL,
    [IdOrganizacion]      BIGINT        NOT NULL,
    [CodigoTienda]        VARCHAR (20)  NULL,
    [IdAlmacenReposicion] TINYINT       NULL,
    [TStamp]              ROWVERSION    NOT NULL,
    [MinStockPieza]       TINYINT       NULL,
    [FrecuenciaPedido]    TINYINT       NULL,
    [DiaPedido]           TINYINT       NULL,
    CONSTRAINT [PK_EPK_Almacen] PRIMARY KEY CLUSTERED ([IdAlmacen] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Almacen] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Almacen] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Almacen] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Almacen] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Almacen] TO PUBLIC
    AS [dbo];

