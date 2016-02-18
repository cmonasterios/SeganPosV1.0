CREATE TABLE [dbo].[EPK_LogSesiones] (
    [IdUsuario] INT        NOT NULL,
    [IdObjeto]  INT        NOT NULL,
    [IdAccion]  INT        NULL,
    [Fecha]     DATE       CONSTRAINT [DF_EPK_LogSesiones_Fecha] DEFAULT (getdate()) NOT NULL,
    [Hora]      TIME (7)   CONSTRAINT [DF_EPK_LogSesiones_Hora] DEFAULT (getdate()) NOT NULL,
    [TStamp]    ROWVERSION NOT NULL
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_LogSesiones] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_LogSesiones] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_LogSesiones] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_LogSesiones] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_LogSesiones] TO PUBLIC
    AS [dbo];

