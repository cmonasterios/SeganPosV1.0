CREATE TABLE [dbo].[EPK_MaquinaFiscal] (
    [IdOrganizacion]       BIGINT       NOT NULL,
    [CodTienda]            VARCHAR (20) NOT NULL,
    [CodMaquina]           VARCHAR (10) NOT NULL,
    [Operativa]            BIT          NOT NULL,
    [FechaFinOperacion]    DATETIME     NULL,
    [FechaInicioOperacion] DATETIME     NULL,
    [TStamp]               ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_MaquinaFiscal_1] PRIMARY KEY CLUSTERED ([IdOrganizacion] ASC, [CodTienda] ASC, [CodMaquina] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_MaquinaFiscal] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_MaquinaFiscal] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_MaquinaFiscal] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_MaquinaFiscal] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_MaquinaFiscal] TO PUBLIC
    AS [dbo];

