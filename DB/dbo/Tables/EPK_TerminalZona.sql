CREATE TABLE [dbo].[EPK_TerminalZona] (
    [IdLocalidad]      INT        NOT NULL,
    [IdTerminal]       INT        NOT NULL,
    [IdGrupo]          SMALLINT   NOT NULL,
    [FechaCreacion]    DATETIME   NULL,
    [FechaEliminacion] DATETIME   NULL,
    [TStamp]           ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_TerminalZona] PRIMARY KEY CLUSTERED ([IdLocalidad] ASC, [IdTerminal] ASC, [IdGrupo] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TerminalZona] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TerminalZona] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TerminalZona] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TerminalZona] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TerminalZona] TO PUBLIC
    AS [dbo];

