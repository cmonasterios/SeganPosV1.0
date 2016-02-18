CREATE TABLE [dbo].[EPK_Lecturas] (
    [IdLectura]        BIGINT     IDENTITY (1, 1) NOT NULL,
    [IdRegion]         INT        NOT NULL,
    [IdLocalidad]      INT        NOT NULL,
    [IdTerminal]       INT        NOT NULL,
    [IdEmpleado]       BIGINT     NOT NULL,
    [TipoEntrada]      SMALLINT   NOT NULL,
    [FechaLectura]     DATE       NULL,
    [HoraLectura]      TIME (7)   NULL,
    [IdEstadoLectura]  SMALLINT   NULL,
    [ModoVerificacion] SMALLINT   NULL,
    [WorkCode]         SMALLINT   NULL,
    [FechaHoraEnvio]   DATETIME   NULL,
    [IdZonaActual]     SMALLINT   NULL,
    [TStamp]           ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_Lecturas_1] PRIMARY KEY CLUSTERED ([IdLectura] ASC),
    CONSTRAINT [FK_EPK_Lecturas_EPK_Empleados] FOREIGN KEY ([IdEmpleado]) REFERENCES [dbo].[EPK_Empleados] ([IdEmpleado]),
    CONSTRAINT [FK_EPK_Lecturas_EPK_Terminal] FOREIGN KEY ([IdTerminal]) REFERENCES [dbo].[EPK_Terminal] ([IdTerminal]),
    CONSTRAINT [IX_EPK_Lecturas] UNIQUE NONCLUSTERED ([IdRegion] ASC, [IdLocalidad] ASC, [IdTerminal] ASC, [IdEmpleado] ASC, [TipoEntrada] ASC, [FechaLectura] ASC, [HoraLectura] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Lecturas] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Lecturas] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Lecturas] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Lecturas] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Lecturas] TO PUBLIC
    AS [dbo];

