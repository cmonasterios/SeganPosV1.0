CREATE TABLE [dbo].[EPK_ObjetoAccion] (
    [IdAccion]             INT        NOT NULL,
    [IdObjeto]             INT        NOT NULL,
    [NecesitaAutorizacion] BIT        CONSTRAINT [DF_EPK_ObjetoAccion_NecesitaAutorizacion] DEFAULT ((0)) NOT NULL,
    [TStamp]               ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_ObjetoAccion] PRIMARY KEY CLUSTERED ([IdAccion] ASC, [IdObjeto] ASC),
    CONSTRAINT [FK_EPK_ObjetoAccion_EPK_Accion] FOREIGN KEY ([IdAccion]) REFERENCES [dbo].[EPK_Accion] ([IdAccion]),
    CONSTRAINT [FK_EPK_ObjetoAccion_EPK_Objeto] FOREIGN KEY ([IdObjeto]) REFERENCES [dbo].[EPK_Objeto] ([IdObjeto])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_ObjetoAccion] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_ObjetoAccion] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_ObjetoAccion] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_ObjetoAccion] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_ObjetoAccion] TO PUBLIC
    AS [dbo];

