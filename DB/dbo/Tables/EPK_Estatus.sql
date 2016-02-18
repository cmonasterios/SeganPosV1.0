CREATE TABLE [dbo].[EPK_Estatus] (
    [IdEstatus]     SMALLINT     IDENTITY (1, 1) NOT NULL,
    [Descripcion]   VARCHAR (50) NOT NULL,
    [FechaCreacion] DATETIME     CONSTRAINT [DF_EPK_Estatus_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [TStamp]        ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Estatus] PRIMARY KEY CLUSTERED ([IdEstatus] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Estatus] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Estatus] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Estatus] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Estatus] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Estatus] TO PUBLIC
    AS [dbo];

