CREATE TABLE [dbo].[EPK_PreguntaSecreta] (
    [IdPregunta] INT           NOT NULL,
    [Pregunta]   VARCHAR (250) NULL,
    [TStamp]     ROWVERSION    NOT NULL
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_PreguntaSecreta] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_PreguntaSecreta] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_PreguntaSecreta] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_PreguntaSecreta] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_PreguntaSecreta] TO PUBLIC
    AS [dbo];

