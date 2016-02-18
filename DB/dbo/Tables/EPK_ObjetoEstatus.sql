CREATE TABLE [dbo].[EPK_ObjetoEstatus] (
    [IdEstatus] SMALLINT   NOT NULL,
    [IdObjeto]  INT        NOT NULL,
    [TStamp]    ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_ObjetoEstatus] PRIMARY KEY CLUSTERED ([IdEstatus] ASC, [IdObjeto] ASC),
    CONSTRAINT [FK_EPK_ObjetoEstatus_EPK_Estatus] FOREIGN KEY ([IdEstatus]) REFERENCES [dbo].[EPK_Estatus] ([IdEstatus]),
    CONSTRAINT [FK_EPK_ObjetoEstatus_EPK_Objeto] FOREIGN KEY ([IdObjeto]) REFERENCES [dbo].[EPK_Objeto] ([IdObjeto])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_ObjetoEstatus] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_ObjetoEstatus] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_ObjetoEstatus] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_ObjetoEstatus] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_ObjetoEstatus] TO PUBLIC
    AS [dbo];

