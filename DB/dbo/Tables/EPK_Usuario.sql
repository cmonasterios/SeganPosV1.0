CREATE TABLE [dbo].[EPK_Usuario] (
    [IdUsuario]           INT            IDENTITY (1, 1) NOT NULL,
    [Identificacion]      VARCHAR (100)  NOT NULL,
    [Login]               VARCHAR (30)   NOT NULL,
    [Clave]               VARCHAR (60)   NOT NULL,
    [Estatus]             CHAR (1)       CONSTRAINT [DF_EPK_Usuario_Estatus] DEFAULT ('A') NOT NULL,
    [Email]               VARCHAR (50)   NULL,
    [ReqPassChange]       BIT            CONSTRAINT [DF_EPK_Usuario_ReqPassChange] DEFAULT ((0)) NOT NULL,
    [LastPassChange]      DATETIME       CONSTRAINT [DF_EPK_Usuario_LastPassChange] DEFAULT (getdate()) NOT NULL,
    [NewPasswordKey]      NVARCHAR (128) NULL,
    [NewPasswordReq]      DATETIME2 (7)  NULL,
    [Locked]              BIT            CONSTRAINT [DF_EPK_Usuario_Locked] DEFAULT ((0)) NOT NULL,
    [FailedLoginAttempts] TINYINT        CONSTRAINT [DF_EPK_Usuario_FailedLoginAttempts] DEFAULT ((0)) NOT NULL,
    [LastLockedDate]      DATETIME2 (7)  NULL,
    [LastLockedReason]    NVARCHAR (256) NULL,
    [FechaCreacion]       DATETIME       CONSTRAINT [DF_EPK_Usuario_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion]   DATETIME       NULL,
    [TStamp]              ROWVERSION     NOT NULL,
    [IdCajaActual]        INT            NULL,
    [IdTienda]            INT            DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_EPK_UsuarioSEGAN] PRIMARY KEY CLUSTERED ([IdUsuario] ASC),
    CONSTRAINT [FK_EPK_Usuario_EPK_Caja] FOREIGN KEY ([IdCajaActual]) REFERENCES [dbo].[EPK_Caja] ([IdCaja]),
    CONSTRAINT [UNQ_EPK_UsuarioSEGAN] UNIQUE NONCLUSTERED ([Login] ASC)
);








GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Usuario] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Usuario] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Usuario] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Usuario] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Usuario] TO PUBLIC
    AS [dbo];

