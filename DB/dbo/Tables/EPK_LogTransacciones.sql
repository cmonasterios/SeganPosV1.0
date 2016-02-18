CREATE TABLE [dbo].[EPK_LogTransacciones] (
    [IdUsusario]  INT           NOT NULL,
    [FechaHora]   DATETIME      NOT NULL,
    [Descripcion] VARCHAR (200) NULL,
    [Operacion]   VARCHAR (10)  NULL,
    [IdCaja]      INT           NOT NULL,
    [TStamp]      ROWVERSION    NOT NULL
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_LogTransacciones] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_LogTransacciones] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_LogTransacciones] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_LogTransacciones] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_LogTransacciones] TO PUBLIC
    AS [dbo];

