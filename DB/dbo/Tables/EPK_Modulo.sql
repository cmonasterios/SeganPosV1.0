CREATE TABLE [dbo].[EPK_Modulo] (
    [IdModulo]          INT          IDENTITY (1, 1) NOT NULL,
    [IdApp]             INT          CONSTRAINT [DF_EPK_Modulo_IdApp] DEFAULT ((1)) NOT NULL,
    [Descripcion]       VARCHAR (50) NOT NULL,
    [Activo]            BIT          CONSTRAINT [DF_EPK_Modulo_Activo] DEFAULT ((1)) NOT NULL,
    [IdPrioridad]       SMALLINT     CONSTRAINT [DF_EPK_Modulo_Prioridad] DEFAULT ((1)) NOT NULL,
    [FechaCreacion]     DATETIME     CONSTRAINT [DF_EPK_Modulo_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion] DATETIME     NULL,
    [TStamp]            ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Modulo] PRIMARY KEY CLUSTERED ([IdModulo] ASC),
    CONSTRAINT [FK_EPK_Modulo_EPK_App] FOREIGN KEY ([IdApp]) REFERENCES [dbo].[EPK_App] ([IdApp]),
    CONSTRAINT [FK_EPK_Modulo_EPK_PrioridadModulo] FOREIGN KEY ([IdPrioridad]) REFERENCES [dbo].[EPK_PrioridadModulo] ([IdPrioridad])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Modulo] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Modulo] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Modulo] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Modulo] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Modulo] TO PUBLIC
    AS [dbo];

