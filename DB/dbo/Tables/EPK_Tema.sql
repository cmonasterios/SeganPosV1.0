CREATE TABLE [dbo].[EPK_Tema] (
    [IdTema]        INT           IDENTITY (1, 1) NOT NULL,
    [CodigoTema]    CHAR (11)     NOT NULL,
    [Descripcion]   VARCHAR (255) NOT NULL,
    [FechaCreacion] DATETIME      CONSTRAINT [DF_EPK_Tema_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [TStamp]        ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_Tema] PRIMARY KEY CLUSTERED ([IdTema] ASC),
    CONSTRAINT [UNQ_EPK_Tema] UNIQUE NONCLUSTERED ([CodigoTema] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Tema] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Tema] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Tema] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Tema] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Tema] TO PUBLIC
    AS [dbo];

