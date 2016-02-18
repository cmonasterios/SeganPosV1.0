CREATE TABLE [dbo].[EPK_MotivoDescuento] (
    [IdMotivoDesc] TINYINT       IDENTITY (1, 1) NOT NULL,
    [Motivo]       VARCHAR (150) NOT NULL,
    CONSTRAINT [PK_EPK_MotivoDescuento] PRIMARY KEY CLUSTERED ([IdMotivoDesc] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_MotivoDescuento] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_MotivoDescuento] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_MotivoDescuento] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_MotivoDescuento] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_MotivoDescuento] TO PUBLIC
    AS [dbo];

