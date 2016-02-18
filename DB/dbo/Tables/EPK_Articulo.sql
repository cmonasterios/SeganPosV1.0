CREATE TABLE [dbo].[EPK_Articulo] (
    [IdArticulo]            INT             IDENTITY (1, 1) NOT NULL,
    [CodigoArticulo]        VARCHAR (31)    NOT NULL,
    [IdReferencia]          INT             NOT NULL,
    [Descripcion]           VARCHAR (100)   NOT NULL,
    [IdColor]               INT             NULL,
    [IdTalla]               INT             NULL,
    [PrecioGravableInicial] DECIMAL (18, 2) NULL,
    [PrecioGravable]        DECIMAL (18, 2) NOT NULL,
    [PrecioExentoInicial]   DECIMAL (18, 2) NULL,
    [PrecioExento]          DECIMAL (18, 2) NOT NULL,
    [Existencia]            SMALLINT        CONSTRAINT [DF_EPK_Articulo_Existencia] DEFAULT ((0)) NOT NULL,
    [ExistenciaAlmacen]     INT             CONSTRAINT [DF_EPK_Articulo_ExistenciaAlmacen] DEFAULT ((0)) NULL,
    [Activo]                BIT             CONSTRAINT [DF_EPK_Articulo_Activo] DEFAULT ((1)) NOT NULL,
    [Exento]                BIT             NOT NULL,
    [FechaCreacion]         DATETIME        CONSTRAINT [DF_EPK_Articulo_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion]     DATETIME        NULL,
    [TStamp]                ROWVERSION      NOT NULL,
    [FechaInicioBloqueo]    DATETIME        NULL,
    [FechaFinBloqueo]       DATETIME        NULL,
    CONSTRAINT [PK_EPK_Articulo] PRIMARY KEY CLUSTERED ([IdArticulo] ASC),
    CONSTRAINT [FK_EPK_Articulo_EPK_Color] FOREIGN KEY ([IdColor]) REFERENCES [dbo].[EPK_Color] ([IdColor]),
    CONSTRAINT [FK_EPK_Articulo_EPK_Referencia] FOREIGN KEY ([IdReferencia]) REFERENCES [dbo].[EPK_Referencia] ([IdReferencia]),
    CONSTRAINT [FK_EPK_Articulo_EPK_Talla] FOREIGN KEY ([IdTalla]) REFERENCES [dbo].[EPK_Talla] ([IdTalla])
);








GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Articulo] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Articulo] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Articulo] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Articulo] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Articulo] TO PUBLIC
    AS [dbo];


GO


