CREATE TABLE [dbo].[EPK_Color] (
    [IdColor]       INT           IDENTITY (1, 1) NOT NULL,
    [CodigoColor]   CHAR (11)     NOT NULL,
    [Descripcion]   VARCHAR (255) NOT NULL,
    [FechaCreacion] DATETIME      CONSTRAINT [DF_EPK_Color_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [TStamp]        ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_Color] PRIMARY KEY CLUSTERED ([IdColor] ASC),
    CONSTRAINT [UNQ_EPK_Color] UNIQUE NONCLUSTERED ([CodigoColor] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Color] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Color] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Color] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Color] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Color] TO PUBLIC
    AS [dbo];

