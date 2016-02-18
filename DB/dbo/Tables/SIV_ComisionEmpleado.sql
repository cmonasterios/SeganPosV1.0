CREATE TABLE [dbo].[SIV_ComisionEmpleado] (
    [CodTienda]          VARCHAR (20)    NOT NULL,
    [IdEmpleado]         BIGINT          NOT NULL,
    [FechaActualizacion] DATETIME        NOT NULL,
    [IdCargoFacturado]   VARCHAR (3)     NOT NULL,
    [IdCargo]            VARCHAR (3)     NOT NULL,
    [MontoComision]      DECIMAL (18, 9) NULL,
    [MontoFacturado]     DECIMAL (18, 9) NULL,
    [TStamp]             ROWVERSION      NOT NULL,
    CONSTRAINT [PK_SIV_ComisionEmpleado] PRIMARY KEY CLUSTERED ([CodTienda] ASC, [IdEmpleado] ASC, [FechaActualizacion] ASC, [IdCargoFacturado] ASC, [IdCargo] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[SIV_ComisionEmpleado] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[SIV_ComisionEmpleado] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[SIV_ComisionEmpleado] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[SIV_ComisionEmpleado] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[SIV_ComisionEmpleado] TO PUBLIC
    AS [dbo];

