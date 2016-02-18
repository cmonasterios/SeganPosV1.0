CREATE TABLE [dbo].[EPK_TipoTiendaFormaPago] (
    [IdTipoTienda]      SMALLINT   NOT NULL,
    [IdFormaPago]       TINYINT    NOT NULL,
    [Activa]            BIT        CONSTRAINT [DF_EPK_TipoTiendaFormaPago_Activa] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]     DATETIME   CONSTRAINT [DF_EPK_TipoTiendaFormaPago_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion] DATETIME   NULL,
    [TStamp]            ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_TipoTiendaFormaPago] PRIMARY KEY CLUSTERED ([IdTipoTienda] ASC, [IdFormaPago] ASC),
    CONSTRAINT [FK_EPK_TipoTiendaFormaPago_EPK_TipoTienda] FOREIGN KEY ([IdTipoTienda]) REFERENCES [dbo].[EPK_TipoTienda] ([IdTipoTienda]),
    CONSTRAINT [FK_EPK_TipoTiendaFormaPago_EPK_TipoTiendaFormaPago] FOREIGN KEY ([IdFormaPago]) REFERENCES [dbo].[EPK_FormaPago] ([IdFormaPago])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TipoTiendaFormaPago] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TipoTiendaFormaPago] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TipoTiendaFormaPago] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TipoTiendaFormaPago] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TipoTiendaFormaPago] TO PUBLIC
    AS [dbo];

