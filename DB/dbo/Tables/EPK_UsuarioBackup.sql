CREATE TABLE [dbo].[EPK_UsuarioBackup] (
    [IdUsuario]               VARCHAR (25)  NOT NULL,
    [Identificacion]          VARCHAR (60)  NOT NULL,
    [PalabraClave]            VARCHAR (25)  NOT NULL,
    [FechaCreacion]           DATETIME      NOT NULL,
    [FechaUltimaModificacion] DATETIME      NULL,
    [Email]                   VARCHAR (60)  NULL,
    [FechaActualizacion]      DATETIME      NULL,
    [IdPreguntaSecreta]       INT           NULL,
    [RespuestaSecreta]        VARCHAR (255) NULL,
    [IdOrganizacion]          INT           NULL,
    [IdLenguaje]              VARCHAR (10)  NULL,
    [IdPaginaPrincipal]       BIGINT        NULL,
    [IdPerfil]                INT           NULL,
    [CodTienda]               VARCHAR (20)  NULL,
    [Activo]                  BIT           CONSTRAINT [DF_EPK_Usuario_Activo] DEFAULT ((1)) NULL,
    [TStamp]                  ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_Usuario] PRIMARY KEY CLUSTERED ([IdUsuario] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_UsuarioBackup] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_UsuarioBackup] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_UsuarioBackup] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_UsuarioBackup] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_UsuarioBackup] TO PUBLIC
    AS [dbo];

