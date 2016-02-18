CREATE TABLE [dbo].[EPK_EmpleadoTerminal] (
    [IdRegion]             INT        NOT NULL,
    [IdEmpleado]           BIGINT     NOT NULL,
    [IdTerminal]           INT        NOT NULL,
    [FechaHoraRegistro]    DATETIME   NOT NULL,
    [FechaHoraEliminacion] DATETIME   NULL,
    [FechaHoraInactivo]    DATETIME   NULL,
    [FechaHoraEnvio]       DATETIME   NULL,
    [TStamp]               ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_EmpleadoTerminal] PRIMARY KEY CLUSTERED ([IdRegion] ASC, [IdEmpleado] ASC, [IdTerminal] ASC, [FechaHoraRegistro] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_EmpleadoTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_EmpleadoTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_EmpleadoTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_EmpleadoTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_EmpleadoTerminal] TO PUBLIC
    AS [dbo];

