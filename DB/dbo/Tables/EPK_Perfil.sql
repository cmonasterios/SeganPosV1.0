CREATE TABLE [dbo].[EPK_Perfil] (
    [IdPerfil]          INT          IDENTITY (13, 1) NOT NULL,
    [Descripcion]       VARCHAR (60) NULL,
    [Autorizador]       BIT          CONSTRAINT [DF_EPK_Perfil_Autorizador] DEFAULT ((0)) NOT NULL,
    [IdNivel]           SMALLINT     CONSTRAINT [DF_EPK_Perfil_Nivel] DEFAULT ((1)) NOT NULL,
    [FechaCreacion]     DATETIME     CONSTRAINT [DF_EPK_Perfil_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion] DATETIME     NULL,
    [MostrarNiveles]    BIT          CONSTRAINT [DF_EPK_Perfil_MostrarNiveles] DEFAULT ((0)) NOT NULL,
    [Asistencia]        BIT          CONSTRAINT [DF_EPK_Perfil_Asistencia] DEFAULT ((1)) NOT NULL,
    [BloqueoClave]      BIT          CONSTRAINT [DF_EPK_Perfil_BloqueoClave] DEFAULT ((1)) NOT NULL,
    [TStamp]            ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Perfil] PRIMARY KEY CLUSTERED ([IdPerfil] ASC),
    CONSTRAINT [FK_EPK_Perfil_EPK_NivelPerfil] FOREIGN KEY ([IdNivel]) REFERENCES [dbo].[EPK_NivelPerfil] ([IdNivel])
);






GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Perfil] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Perfil] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Perfil] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Perfil] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Perfil] TO PUBLIC
    AS [dbo];

