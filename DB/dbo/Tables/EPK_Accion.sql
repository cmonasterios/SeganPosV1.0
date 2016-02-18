CREATE TABLE [dbo].[EPK_Accion] (
    [IdAccion]             INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion]          VARCHAR (50) NOT NULL,
    [Habilitada]           BIT          CONSTRAINT [DF_EPK_Accion_Habilitado] DEFAULT ((1)) NOT NULL,
    [IdUsuarioEliminacion] INT          NULL,
    [FechaCreacion]        DATETIME     CONSTRAINT [DF_EPK_Accion_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion]    DATETIME     NULL,
    [TStamp]               ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Accion] PRIMARY KEY CLUSTERED ([IdAccion] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Accion] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Accion] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Accion] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Accion] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Accion] TO PUBLIC
    AS [dbo];

