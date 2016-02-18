CREATE TABLE [dbo].[EPK_TipoDispositivo] (
    [IdTipoDispositivo] SMALLINT     IDENTITY (1, 1) NOT NULL,
    [Descripcion]       VARCHAR (30) NOT NULL,
    [Unico]             BIT          CONSTRAINT [DF_EPK_TipoDispositivo_Unico] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]     DATETIME     CONSTRAINT [DF_EPK_TipoDispositivo_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion] DATETIME     NULL,
    [TStamp]            ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_TipoDispositivo] PRIMARY KEY CLUSTERED ([IdTipoDispositivo] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TipoDispositivo] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TipoDispositivo] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TipoDispositivo] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TipoDispositivo] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TipoDispositivo] TO PUBLIC
    AS [dbo];

