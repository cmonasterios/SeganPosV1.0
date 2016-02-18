CREATE TABLE [dbo].[EPK_EmpleadoAcceso] (
    [IdRegion]         INT        NOT NULL,
    [IdEmpleado]       BIGINT     NOT NULL,
    [IdGrupo]          SMALLINT   NOT NULL,
    [FechaCreacion]    DATETIME   NOT NULL,
    [FechaEliminacion] DATETIME   NULL,
    [TStamp]           ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_EmpleadoAcceso_1] PRIMARY KEY CLUSTERED ([IdRegion] ASC, [IdEmpleado] ASC, [IdGrupo] ASC, [FechaCreacion] ASC),
    CONSTRAINT [FK_EPK_EmpleadoAcceso_EPK_Empleados] FOREIGN KEY ([IdEmpleado]) REFERENCES [dbo].[EPK_Empleados] ([IdEmpleado]),
    CONSTRAINT [FK_EPK_EmpleadoAcceso_EPK_RegionUbicacion] FOREIGN KEY ([IdRegion]) REFERENCES [dbo].[EPK_Region] ([IdRegion])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_EmpleadoAcceso] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_EmpleadoAcceso] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_EmpleadoAcceso] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_EmpleadoAcceso] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_EmpleadoAcceso] TO PUBLIC
    AS [dbo];

