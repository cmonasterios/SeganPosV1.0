CREATE TABLE [dbo].[EPK_Objeto] (
    [IdObjeto]          INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion]       VARCHAR (500) NOT NULL,
    [IdModulo]          INT           NOT NULL,
    [NombreTecnico]     VARCHAR (100) NOT NULL,
    [NombreFuncional]   VARCHAR (100) NOT NULL,
    [IdPadre]           INT           NULL,
    [FechaCreacion]     DATETIME      CONSTRAINT [DF_EPK_Objeto_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion] DATETIME      NULL,
    [TStamp]            ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_Objeto] PRIMARY KEY CLUSTERED ([IdObjeto] ASC),
    CONSTRAINT [FK_EPK_Objeto_EPK_Modulo] FOREIGN KEY ([IdModulo]) REFERENCES [dbo].[EPK_Modulo] ([IdModulo])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Objeto] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Objeto] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Objeto] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Objeto] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Objeto] TO PUBLIC
    AS [dbo];

