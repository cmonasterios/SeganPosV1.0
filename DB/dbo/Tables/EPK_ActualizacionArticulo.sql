CREATE TABLE [dbo].[EPK_ActualizacionArticulo] (
    [IdActualizacion]   INT             NOT NULL,
    [IdArticulo]        INT             NOT NULL,
    [PrecioGravable]    DECIMAL (18, 2) NULL,
    [PrecioExento]      DECIMAL (18, 2) NULL,
    [Existencia]        BIGINT          NULL,
    [ExistenciaAlmacen] BIGINT          NULL,
    [Activo]            BIT             NULL,
    [TStamp]            ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_ActualizacionDetalle] PRIMARY KEY CLUSTERED ([IdActualizacion] ASC, [IdArticulo] ASC),
    CONSTRAINT [FK_EPK_ActualizacionDetalle_EPK_ActualizacionEncabezado] FOREIGN KEY ([IdActualizacion]) REFERENCES [dbo].[EPK_ActualizacionEncabezado] ([IdActualizacion]),
    CONSTRAINT [FK_EPK_ActualizacionDetalle_EPK_Articulo1] FOREIGN KEY ([IdArticulo]) REFERENCES [dbo].[EPK_Articulo] ([IdArticulo])
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_ActualizacionArticulo] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_ActualizacionArticulo] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_ActualizacionArticulo] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_ActualizacionArticulo] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_ActualizacionArticulo] TO PUBLIC
    AS [dbo];

