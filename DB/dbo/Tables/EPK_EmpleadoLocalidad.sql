CREATE TABLE [dbo].[EPK_EmpleadoLocalidad] (
    [IdRegion]             INT        NOT NULL,
    [IdLocalidad]          INT        NOT NULL,
    [IdEmpleado]           BIGINT     NOT NULL,
    [FechaHoraRegistro]    DATETIME   NOT NULL,
    [FechaHoraEliminacion] DATETIME   NULL,
    [FechaHoraInactivo]    DATETIME   NULL,
    [FechaHoraEnvio]       DATETIME   NULL,
    [TStamp]               ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_EmpleadoLocalidad] PRIMARY KEY CLUSTERED ([IdRegion] ASC, [IdLocalidad] ASC, [IdEmpleado] ASC, [FechaHoraRegistro] ASC),
    CONSTRAINT [FK_EPK_EmpleadoLocalidad_EPK_Empleados] FOREIGN KEY ([IdEmpleado]) REFERENCES [dbo].[EPK_Empleados] ([IdEmpleado]),
    CONSTRAINT [FK_EPK_EmpleadoLocalidad_EPK_Localidad] FOREIGN KEY ([IdLocalidad], [IdRegion]) REFERENCES [dbo].[EPK_Localidad] ([IdLocalidad], [IdRegion])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_EmpleadoLocalidad] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_EmpleadoLocalidad] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_EmpleadoLocalidad] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_EmpleadoLocalidad] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_EmpleadoLocalidad] TO PUBLIC
    AS [dbo];

