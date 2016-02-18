CREATE TABLE [dbo].[EPK_ActualizacionColeccion] (
    [IdActualizacion] INT        NOT NULL,
    [IdColeccion]     INT        NOT NULL,
    [Activa]          BIT        NOT NULL,
    [TStamp]          ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_ActualizacionColeccion] PRIMARY KEY CLUSTERED ([IdActualizacion] ASC, [IdColeccion] ASC),
    CONSTRAINT [FK_EPK_ActualizacionColeccion_EPK_ActualizacionEncabezado] FOREIGN KEY ([IdActualizacion]) REFERENCES [dbo].[EPK_ActualizacionEncabezado] ([IdActualizacion]),
    CONSTRAINT [FK_EPK_ActualizacionColeccion_EPK_Coleccion] FOREIGN KEY ([IdColeccion]) REFERENCES [dbo].[EPK_Coleccion] ([IdColeccion])
);








GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_ActualizacionColeccion] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_ActualizacionColeccion] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_ActualizacionColeccion] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_ActualizacionColeccion] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_ActualizacionColeccion] TO PUBLIC
    AS [dbo];

