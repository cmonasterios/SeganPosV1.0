CREATE TABLE [dbo].[EPK_NivelPerfil] (
    [IdNivel]       SMALLINT     IDENTITY (1, 1) NOT NULL,
    [Descripcion]   VARCHAR (50) NOT NULL,
    [FechaCreacion] DATETIME     CONSTRAINT [DF_EPK_NivelPerfil_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [TStamp]        ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_NivelPerfil] PRIMARY KEY CLUSTERED ([IdNivel] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_NivelPerfil] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_NivelPerfil] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_NivelPerfil] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_NivelPerfil] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_NivelPerfil] TO PUBLIC
    AS [dbo];

