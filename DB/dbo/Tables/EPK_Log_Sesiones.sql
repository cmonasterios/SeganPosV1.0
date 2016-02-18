CREATE TABLE [dbo].[EPK_Log_Sesiones] (
    [FechaHora]       DATETIME      NOT NULL,
    [IdUsuario]       VARCHAR (25)  NOT NULL,
    [IdPaginaUsuario] INT           NOT NULL,
    [Operacion]       VARCHAR (150) NOT NULL,
    [TStamp]          ROWVERSION    NOT NULL
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Log_Sesiones] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Log_Sesiones] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Log_Sesiones] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Log_Sesiones] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Log_Sesiones] TO PUBLIC
    AS [dbo];

