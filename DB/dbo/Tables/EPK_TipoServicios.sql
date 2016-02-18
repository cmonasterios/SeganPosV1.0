CREATE TABLE [dbo].[EPK_TipoServicios] (
    [IdServicio]  SMALLINT      IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (50)  NULL,
    [Observacion] VARCHAR (250) NULL,
    [Habilitado]  BIT           NULL,
    CONSTRAINT [PK_IdServicio] PRIMARY KEY CLUSTERED ([IdServicio] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TipoServicios] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TipoServicios] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TipoServicios] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TipoServicios] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TipoServicios] TO PUBLIC
    AS [dbo];

