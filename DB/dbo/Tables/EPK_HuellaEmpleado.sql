CREATE TABLE [dbo].[EPK_HuellaEmpleado] (
    [IdEmpleado]     BIGINT        NOT NULL,
    [IdFingerPrint]  SMALLINT      NOT NULL,
    [IdFlag]         SMALLINT      NOT NULL,
    [TemplateFinger] VARCHAR (MAX) NULL,
    [TStamp]         ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_HuellaEmpleado] PRIMARY KEY CLUSTERED ([IdEmpleado] ASC, [IdFingerPrint] ASC),
    CONSTRAINT [FK_EPK_HuellaEmpleado_EPK_Empleados] FOREIGN KEY ([IdEmpleado]) REFERENCES [dbo].[EPK_Empleados] ([IdEmpleado])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_HuellaEmpleado] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_HuellaEmpleado] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_HuellaEmpleado] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_HuellaEmpleado] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_HuellaEmpleado] TO PUBLIC
    AS [dbo];

