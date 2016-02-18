CREATE TABLE [dbo].[EPK_MensajeTerminal] (
    [IdTerminal]       INT        NOT NULL,
    [IdMensaje]        INT        NOT NULL,
    [IdRegion]         INT        NOT NULL,
    [IdLocalidad]      INT        NOT NULL,
    [FechaCreacion]    DATETIME   NOT NULL,
    [FechaEliminacion] DATETIME   NULL,
    [IdUsuario]        BIGINT     NULL,
    [TStamp]           ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_MensajeTerminal] PRIMARY KEY CLUSTERED ([IdTerminal] ASC, [IdMensaje] ASC),
    CONSTRAINT [FK_MensajeTerminal_EPK_Mensaje] FOREIGN KEY ([IdMensaje]) REFERENCES [dbo].[EPK_Mensaje] ([IdMensaje])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_MensajeTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_MensajeTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_MensajeTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_MensajeTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_MensajeTerminal] TO PUBLIC
    AS [dbo];

