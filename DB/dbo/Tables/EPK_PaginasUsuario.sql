CREATE TABLE [dbo].[EPK_PaginasUsuario] (
    [IdPaginaUsuario] BIGINT        NOT NULL,
    [Titulo]          VARCHAR (60)  NOT NULL,
    [Url]             VARCHAR (150) NOT NULL,
    [Descripcion]     VARCHAR (60)  NULL,
    [PaginaInicio]    BIT           NULL,
    [TStamp]          ROWVERSION    NOT NULL,
    CONSTRAINT [PK_PaginasUsuario] PRIMARY KEY CLUSTERED ([IdPaginaUsuario] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_PaginasUsuario] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_PaginasUsuario] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_PaginasUsuario] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_PaginasUsuario] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_PaginasUsuario] TO PUBLIC
    AS [dbo];

