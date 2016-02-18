CREATE TABLE [dbo].[EPK_Mensaje] (
    [IdMensaje]   INT           NOT NULL,
    [Bandera]     SMALLINT      NULL,
    [Minutos]     SMALLINT      NULL,
    [FechaInicio] VARCHAR (17)  NULL,
    [Mensaje]     VARCHAR (100) NULL,
    [TStamp]      ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_Mensaje] PRIMARY KEY CLUSTERED ([IdMensaje] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Mensaje] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Mensaje] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Mensaje] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Mensaje] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Mensaje] TO PUBLIC
    AS [dbo];

