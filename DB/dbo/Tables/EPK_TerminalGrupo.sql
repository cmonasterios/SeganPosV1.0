CREATE TABLE [dbo].[EPK_TerminalGrupo] (
    [IdTerminal]       INT        NOT NULL,
    [IdGrupo]          SMALLINT   NOT NULL,
    [IdRegion]         INT        NOT NULL,
    [FechaCreacion]    DATETIME   NULL,
    [FechaEliminacion] DATETIME   NULL,
    [TStamp]           ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_TerminalGrupo_1] PRIMARY KEY CLUSTERED ([IdTerminal] ASC, [IdGrupo] ASC),
    CONSTRAINT [FK_EPK_TerminalGrupo_EPK_GrupoZona] FOREIGN KEY ([IdRegion], [IdGrupo]) REFERENCES [dbo].[EPK_GrupoZona] ([IdRegion], [IdGrupo]),
    CONSTRAINT [FK_EPK_TerminalGrupo_EPK_Terminal] FOREIGN KEY ([IdTerminal]) REFERENCES [dbo].[EPK_Terminal] ([IdTerminal])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TerminalGrupo] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TerminalGrupo] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TerminalGrupo] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TerminalGrupo] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TerminalGrupo] TO PUBLIC
    AS [dbo];

