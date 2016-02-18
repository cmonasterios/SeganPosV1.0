CREATE TABLE [dbo].[EPK_POSTienda] (
    [IdPOS]             INT          NOT NULL,
    [IdTienda]          INT          NOT NULL,
    [Activo]            BIT          CONSTRAINT [DF_EPK_POSTienda_Activo] DEFAULT ((1)) NOT NULL,
    [FechaCreacion]     DATETIME     CONSTRAINT [DF_EPK_POSTienda_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion] DATETIME     NULL,
    [SerialPOS]         VARCHAR (15) NULL,
    [TStamp]            ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_POSTienda_1] PRIMARY KEY CLUSTERED ([IdPOS] ASC, [IdTienda] ASC),
    CONSTRAINT [FK_EPK_POSTienda_EPK_POS] FOREIGN KEY ([IdPOS]) REFERENCES [dbo].[EPK_POS] ([IdPOS]),
    CONSTRAINT [FK_EPK_POSTienda_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda])
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_POSTienda] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_POSTienda] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_POSTienda] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_POSTienda] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_POSTienda] TO PUBLIC
    AS [dbo];

