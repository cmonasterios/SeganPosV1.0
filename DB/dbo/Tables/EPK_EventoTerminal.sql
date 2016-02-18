CREATE TABLE [dbo].[EPK_EventoTerminal] (
    [IdRegion]           INT        NOT NULL,
    [IdLocalidad]        INT        NOT NULL,
    [IdTerminal]         INT        NOT NULL,
    [IdEvento]           INT        IDENTITY (1, 1) NOT NULL,
    [FechaHoraEvento]    DATETIME   NULL,
    [Mensaje]            XML        NULL,
    [FechaHoraEnvio]     DATETIME   NULL,
    [FechaHoraEjecucion] DATETIME   NULL,
    [TStamp]             ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_EventoTerminal_1] PRIMARY KEY CLUSTERED ([IdTerminal] ASC, [IdEvento] ASC),
    CONSTRAINT [FK_EPK_EventoTerminal_EPK_Terminal] FOREIGN KEY ([IdTerminal]) REFERENCES [dbo].[EPK_Terminal] ([IdTerminal])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_EventoTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_EventoTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_EventoTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_EventoTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_EventoTerminal] TO PUBLIC
    AS [dbo];

