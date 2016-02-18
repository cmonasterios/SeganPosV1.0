CREATE TABLE [dbo].[EPK_EfectivoRemanenteEncabezado] (
    [IdEfectivoR] INT             IDENTITY (1, 1) NOT NULL,
    [Fecha]       DATE            NOT NULL,
    [Hora]        TIME (7)        NOT NULL,
    [IdUsuario]   INT             NOT NULL,
    [MontoTotal]  DECIMAL (18, 2) NOT NULL,
    [tStamp]      ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_EfectivoRemanente] PRIMARY KEY CLUSTERED ([IdEfectivoR] ASC)
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_EfectivoRemanenteEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_EfectivoRemanenteEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_EfectivoRemanenteEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_EfectivoRemanenteEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_EfectivoRemanenteEncabezado] TO PUBLIC
    AS [dbo];

