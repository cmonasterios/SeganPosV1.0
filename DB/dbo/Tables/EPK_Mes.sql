CREATE TABLE [dbo].[EPK_Mes] (
    [Codigo_Mes] VARCHAR (3)  NOT NULL,
    [Nombre]     VARCHAR (20) NULL,
    [TStamp]     ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Mes] PRIMARY KEY CLUSTERED ([Codigo_Mes] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Mes] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Mes] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Mes] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Mes] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Mes] TO PUBLIC
    AS [dbo];

