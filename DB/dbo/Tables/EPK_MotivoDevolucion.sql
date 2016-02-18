CREATE TABLE [dbo].[EPK_MotivoDevolucion] (
    [IdMotivo] TINYINT       IDENTITY (1, 1) NOT NULL,
    [Motivo]   VARCHAR (150) NOT NULL,
    [TStamp]   ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_MotivoDevolucion] PRIMARY KEY CLUSTERED ([IdMotivo] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_MotivoDevolucion] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_MotivoDevolucion] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_MotivoDevolucion] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_MotivoDevolucion] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_MotivoDevolucion] TO PUBLIC
    AS [dbo];

