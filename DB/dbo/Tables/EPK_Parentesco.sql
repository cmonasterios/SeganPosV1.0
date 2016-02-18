CREATE TABLE [dbo].[EPK_Parentesco] (
    [IdEmpleado]        BIGINT       NOT NULL,
    [IdParentesco]      BIGINT       IDENTITY (1, 1) NOT NULL,
    [Nombre]            VARCHAR (15) NULL,
    [Apellido]          VARCHAR (15) NULL,
    [FechaDeNacimiento] DATETIME     NULL,
    [Sexo]              CHAR (1)     NULL,
    [IdTipoParentesco]  SMALLINT     NULL,
    [TStamp]            ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Parentesco] PRIMARY KEY CLUSTERED ([IdEmpleado] ASC, [IdParentesco] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Parentesco] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Parentesco] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Parentesco] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Parentesco] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Parentesco] TO PUBLIC
    AS [dbo];

