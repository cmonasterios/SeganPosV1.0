CREATE TABLE [dbo].[EPK_Empleados] (
    [IdEmpleado]         BIGINT       NOT NULL,
    [Nombre]             VARCHAR (15) NULL,
    [Apellido]           VARCHAR (15) NULL,
    [IdUsuario]          INT          NULL,
    [FechaCreacion]      DATETIME     NULL,
    [Estatus]            BIT          NULL,
    [FechaFinRelacion]   DATETIME     NULL,
    [RecibeNotificacion] BIT          NULL,
    [FechaEliminacion]   DATETIME     NULL,
    [CodigoTarjeta]      VARCHAR (10) NULL,
    [Clave]              VARCHAR (20) NULL,
    [IdPrivilegio]       SMALLINT     NULL,
    [IdRegion]           INT          NULL,
    [IdZonaActual]       INT          NULL,
    [IdDepartamento]     INT          NULL,
    [IdCargo]            INT          NULL,
    [TStamp]             ROWVERSION   NOT NULL,
    [IdModoVerificacion] SMALLINT     NULL,
    [FechaEgreso] DATE NULL, 
    [FechaIngreso] DATE NULL, 
    CONSTRAINT [PK_EPK_Empleados] PRIMARY KEY CLUSTERED ([IdEmpleado] ASC),
    CONSTRAINT [FK_EPK_Empleados_EPK_ModoVerificacion] FOREIGN KEY ([IdModoVerificacion]) REFERENCES [dbo].[EPK_ModoVerificacion] ([IdModoVerificacion]),
    CONSTRAINT [FK_EPK_Empleados_EPK_Privilegio] FOREIGN KEY ([IdPrivilegio]) REFERENCES [dbo].[EPK_Privilegio] ([IdPrivilegio]),
    CONSTRAINT [FK_EPK_Empleados_EPK_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Empleados] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Empleados] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Empleados] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Empleados] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Empleados] TO PUBLIC
    AS [dbo];

