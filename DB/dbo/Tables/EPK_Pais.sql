CREATE TABLE [dbo].[EPK_Pais] (
    [IdPais]            INT          IDENTITY (2, 1) NOT NULL,
    [Nombre]            VARCHAR (30) NOT NULL,
    [FechaCreacion]     DATETIME     CONSTRAINT [DF_EPK_Pais_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion] DATETIME     NULL,
    [TStamp]            ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Pais] PRIMARY KEY CLUSTERED ([IdPais] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Pais] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Pais] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Pais] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Pais] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Pais] TO PUBLIC
    AS [dbo];

