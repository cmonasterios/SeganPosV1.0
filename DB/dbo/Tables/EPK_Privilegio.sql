CREATE TABLE [dbo].[EPK_Privilegio] (
    [IdPrivilegio] SMALLINT   NOT NULL,
    [Descripcion]  CHAR (15)  NULL,
    [TStamp]       ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_Privilegio] PRIMARY KEY CLUSTERED ([IdPrivilegio] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Privilegio] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Privilegio] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Privilegio] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Privilegio] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Privilegio] TO PUBLIC
    AS [dbo];

