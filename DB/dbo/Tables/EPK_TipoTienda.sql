CREATE TABLE [dbo].[EPK_TipoTienda] (
    [IdTipoTienda]      SMALLINT     IDENTITY (1, 1) NOT NULL,
    [Descripcion]       VARCHAR (30) NULL,
    [FechaCreacion]     DATETIME     CONSTRAINT [DF_EPK_TipoTienda_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion] DATETIME     NULL,
    [TStamp]            ROWVERSION   NOT NULL,
    [AplicaImpuesto]    BIT          CONSTRAINT [DF_EPK_TipoTienda_AplicaImpuesto] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_EPK_TipoTienda] PRIMARY KEY CLUSTERED ([IdTipoTienda] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TipoTienda] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TipoTienda] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TipoTienda] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TipoTienda] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TipoTienda] TO PUBLIC
    AS [dbo];

