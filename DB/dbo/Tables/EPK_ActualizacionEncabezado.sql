CREATE TABLE [dbo].[EPK_ActualizacionEncabezado] (
    [IdActualizacion]    INT           NOT NULL,
    [Descripcion]        VARCHAR (300) NOT NULL,
    [TipoActualizacion]  SMALLINT      NOT NULL,
    [IdEstatus]          SMALLINT      NULL,
    [FechaCreacion]      DATETIME      CONSTRAINT [DF_EPK_ActualizacionEncabezado_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion]  DATETIME      NULL,
    [FechaRecepcion]     DATETIME      NULL,
    [FechaProcesamiento] DATETIME      NULL,
    [FechaInicio]        DATETIME      NULL,
    [CantidadDetalles]   INT           NULL,
    [TStamp]             ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_ActualizacionEncabezado] PRIMARY KEY CLUSTERED ([IdActualizacion] ASC)
);






GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_ActualizacionEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_ActualizacionEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_ActualizacionEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_ActualizacionEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_ActualizacionEncabezado] TO PUBLIC
    AS [dbo];


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1= Articulos Precios, 2= Articulos Estatus, 3=Articulos Existencias, 4= Coleccion Status', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EPK_ActualizacionEncabezado', @level2type = N'COLUMN', @level2name = N'TipoActualizacion';

