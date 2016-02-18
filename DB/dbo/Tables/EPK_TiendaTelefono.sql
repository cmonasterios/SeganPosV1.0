CREATE TABLE [dbo].[EPK_TiendaTelefono] (
    [IdTelefonoTienda] INT          IDENTITY (1, 1) NOT NULL,
    [IdTienda]         INT          NOT NULL,
    [Numero]           VARCHAR (20) NOT NULL,
    [TStamp]           ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_TiendaTelefono] PRIMARY KEY CLUSTERED ([IdTelefonoTienda] ASC),
    CONSTRAINT [FK_EPK_TiendaTelefono_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TiendaTelefono] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TiendaTelefono] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TiendaTelefono] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TiendaTelefono] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TiendaTelefono] TO PUBLIC
    AS [dbo];

