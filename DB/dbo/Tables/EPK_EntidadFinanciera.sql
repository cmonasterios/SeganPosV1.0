CREATE TABLE [dbo].[EPK_EntidadFinanciera] (
    [IdEntidad]         INT             IDENTITY (1, 1) NOT NULL,
    [CodSudeban]        VARCHAR (4)     NOT NULL,
    [Nombre]            VARCHAR (60)    NOT NULL,
    [MaximoPOS]         SMALLINT        CONSTRAINT [DF_EPK_EntidadFinanciera_MaximoPOS] DEFAULT ((10)) NOT NULL,
    [Logo]              VARBINARY (MAX) NULL,
    [MimeType]          VARCHAR (100)   NULL,
    [FileName]          VARCHAR (300)   NULL,
    [Activa]            BIT             CONSTRAINT [DF_EPK_EntidadFinanciera_Activa] DEFAULT ((1)) NOT NULL,
    [FechaCreacion]     DATETIME        CONSTRAINT [DF_EPK_EntidadFinanciera_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [IdUsuarioCreacion] INT             NOT NULL,
    [FechaModificacion] DATETIME        NULL,
    [TStamp]            ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_EntidadFinanciera] PRIMARY KEY CLUSTERED ([IdEntidad] ASC),
    CONSTRAINT [UNQ_EPK_EntidadFinanciera] UNIQUE NONCLUSTERED ([CodSudeban] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_EntidadFinanciera] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_EntidadFinanciera] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_EntidadFinanciera] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_EntidadFinanciera] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_EntidadFinanciera] TO PUBLIC
    AS [dbo];

