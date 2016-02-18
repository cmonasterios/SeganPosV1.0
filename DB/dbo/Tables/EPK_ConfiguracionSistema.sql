CREATE TABLE [dbo].[EPK_ConfiguracionSistema] (
    [Porcentaje]       DECIMAL (18, 2) NULL,
    [UnidadTributaria] DECIMAL (18, 2) NULL,
    [FechaIngreso]     DATETIME        NULL,
    [FechaEliminacion] DATETIME        NULL,
    [TStamp]           ROWVERSION      NOT NULL
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_ConfiguracionSistema] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_ConfiguracionSistema] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_ConfiguracionSistema] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_ConfiguracionSistema] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_ConfiguracionSistema] TO PUBLIC
    AS [dbo];

