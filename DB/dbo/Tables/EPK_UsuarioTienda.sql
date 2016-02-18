CREATE TABLE [dbo].[EPK_UsuarioTienda] (
    [IdUsuario]   INT        NOT NULL,
    [IdTienda]    INT        NOT NULL,
    [IdCargo]     INT        CONSTRAINT [DF_EPK_UsuarioTienda_IdCargo] DEFAULT ((1)) NOT NULL,
    [FechaInicio] DATE       CONSTRAINT [DF_EPK_UsuarioTienda_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaFin]    DATE       NULL,
    [TStamp]      ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_UsuarioTienda] PRIMARY KEY CLUSTERED ([IdUsuario] ASC, [IdTienda] ASC, [IdCargo] ASC),
    CONSTRAINT [FK_EPK_UsuarioTienda_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda])
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_UsuarioTienda] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_UsuarioTienda] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_UsuarioTienda] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_UsuarioTienda] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_UsuarioTienda] TO PUBLIC
    AS [dbo];

