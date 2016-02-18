CREATE TABLE [dbo].[EPK_Politica] (
    [IdPolitica]           INT          IDENTITY (1, 1) NOT NULL,
    [IdOrganizacion]       INT          NOT NULL,
    [Nivel]                SMALLINT     NOT NULL,
    [Descripcion]          VARCHAR (48) NULL,
    [ImprimeMaquinaFiscal] BIT          NOT NULL,
    [TStamp]               ROWVERSION   NOT NULL
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Politica] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Politica] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Politica] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Politica] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Politica] TO PUBLIC
    AS [dbo];

