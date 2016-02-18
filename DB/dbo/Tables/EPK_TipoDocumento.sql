CREATE TABLE [dbo].[EPK_TipoDocumento] (
    [IdTipoDocumento] TINYINT      IDENTITY (1, 1) NOT NULL,
    [Descripcion]     VARCHAR (50) NOT NULL,
    [Sigla]           CHAR (1)     NOT NULL,
    [PersonaNatural]  BIT          CONSTRAINT [DF_EPK_TipoDocumento_PersonaNatural] DEFAULT ((1)) NOT NULL,
    [Principal]       BIT          CONSTRAINT [DF_EPK_TipoDocumento_Principal] DEFAULT ((0)) NOT NULL,
    [Validacion]      VARCHAR (20) NULL,
    [TStamp]          ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_TipoDocumento] PRIMARY KEY CLUSTERED ([IdTipoDocumento] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TipoDocumento] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TipoDocumento] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TipoDocumento] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TipoDocumento] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TipoDocumento] TO PUBLIC
    AS [dbo];

