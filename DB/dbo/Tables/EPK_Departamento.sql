CREATE TABLE [dbo].[EPK_Departamento] (
    [IdDepartamento]  INT        IDENTITY (1, 1) NOT NULL,
    [CodDepartamento] CHAR (21)  NOT NULL,
    [Descripcion]     CHAR (51)  NOT NULL,
    [TStamp]          ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_Departamento] PRIMARY KEY CLUSTERED ([IdDepartamento] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Departamento] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Departamento] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Departamento] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Departamento] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Departamento] TO PUBLIC
    AS [dbo];

