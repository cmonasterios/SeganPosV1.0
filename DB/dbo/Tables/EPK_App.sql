CREATE TABLE [dbo].[EPK_App] (
    [IdApp]             INT             IDENTITY (15, 1) NOT NULL,
    [Nombre]            VARCHAR (50)    NOT NULL,
    [Descripcion]       VARCHAR (150)   NULL,
    [TipoAplicacion]    CHAR (1)        NULL,
    [Activa]            BIT             CONSTRAINT [DF_EPK_App_Activa] DEFAULT ((1)) NOT NULL,
    [Logo]              VARBINARY (MAX) NULL,
    [MimeType]          VARCHAR (100)   NULL,
    [Filename]          VARCHAR (300)   NULL,
    [FechaCreacion]     DATETIME        CONSTRAINT [DF_EPK_App_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion] DATETIME        NULL,
    [TStamp]            ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_App_1] PRIMARY KEY CLUSTERED ([IdApp] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UNQ_EPK_NombreApp]
    ON [dbo].[EPK_App]([Nombre] ASC);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_App] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_App] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_App] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_App] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_App] TO PUBLIC
    AS [dbo];

