CREATE TABLE [dbo].[EPK_Genero] (
    [IdGenero]     INT          IDENTITY (1, 1) NOT NULL,
    [CodigoGenero] VARCHAR (11) NOT NULL,
    [Descripcion]  VARCHAR (50) NULL,
    [TStamp]       ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Generos] PRIMARY KEY CLUSTERED ([IdGenero] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_EPK_Genero]
    ON [dbo].[EPK_Genero]([CodigoGenero] ASC);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Genero] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Genero] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Genero] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Genero] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Genero] TO PUBLIC
    AS [dbo];

