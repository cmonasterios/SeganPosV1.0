CREATE TABLE [dbo].[EPK_LogUsuarioClave] (
    [IdLogClave]  BIGINT       IDENTITY (1, 1) NOT NULL,
    [IdUsuario]   INT          NOT NULL,
    [Clave]       VARCHAR (60) NOT NULL,
    [FechaCambio] DATETIME     CONSTRAINT [DF_EPK_LogUsuario_FechaCambio] DEFAULT (getdate()) NOT NULL,
    [TStamp]      ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_LogUsuario] PRIMARY KEY CLUSTERED ([IdLogClave] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_LogUsuarioClave] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_LogUsuarioClave] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_LogUsuarioClave] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_LogUsuarioClave] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_LogUsuarioClave] TO PUBLIC
    AS [dbo];

