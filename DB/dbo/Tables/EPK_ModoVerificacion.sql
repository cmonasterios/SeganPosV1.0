CREATE TABLE [dbo].[EPK_ModoVerificacion] (
    [IdModoVerificacion] SMALLINT     NOT NULL,
    [Descripcion]        VARCHAR (30) NULL,
    [TStamp]             ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_ModoVerificacion] PRIMARY KEY CLUSTERED ([IdModoVerificacion] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_ModoVerificacion] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_ModoVerificacion] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_ModoVerificacion] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_ModoVerificacion] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_ModoVerificacion] TO PUBLIC
    AS [dbo];

