CREATE TABLE [dbo].[EPK_Tienda_old] (
    [CodTienda]      VARCHAR (20)  NOT NULL,
    [IdOrganizacion] INT           NOT NULL,
    [Descripcion]    VARCHAR (100) NULL,
    [Sabado]         BIT           NULL,
    [Domingo]        BIT           NULL,
    [Outlet]         BIT           NULL,
    [IdCiudad]       SMALLINT      NULL,
    [IdEstado]       SMALLINT      NULL,
    [Activa]         BIT           NULL,
    [PagaComisiones] BIT           NULL,
    [CodigoDynamics] VARCHAR (6)   NULL,
    [TStamp]         ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_Tienda_1] PRIMARY KEY CLUSTERED ([CodTienda] ASC),
    CONSTRAINT [FK_EPK_Tienda_EPK_Organizacion] FOREIGN KEY ([IdOrganizacion]) REFERENCES [dbo].[EPK_Organizacion] ([IdOrganizacion])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Tienda_old] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Tienda_old] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Tienda_old] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Tienda_old] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Tienda_old] TO PUBLIC
    AS [dbo];

