CREATE TABLE [dbo].[EPK_LogActualizacion] (
    [IdLog]           INT           IDENTITY (1, 1) NOT NULL,
    [IdActualizacion] INT           NOT NULL,
    [IdUsuario]       INT           NOT NULL,
    [IdEstatus]       INT           NOT NULL,
    [FechaEstatus]    DATETIME      CONSTRAINT [DF_EPK_LogActualizacion_FechaEstatus] DEFAULT (getdate()) NOT NULL,
    [Observacion]     VARCHAR (500) NULL,
    [TStamp]          ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_LogActualizacion] PRIMARY KEY CLUSTERED ([IdLog] ASC),
    CONSTRAINT [FK_EPK_LogActualizacion_EPK_ActualizacionEncabezado] FOREIGN KEY ([IdActualizacion]) REFERENCES [dbo].[EPK_ActualizacionEncabezado] ([IdActualizacion]),
    CONSTRAINT [FK_EPK_LogActualizacion_EPK_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_LogActualizacion] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_LogActualizacion] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_LogActualizacion] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_LogActualizacion] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_LogActualizacion] TO PUBLIC
    AS [dbo];

