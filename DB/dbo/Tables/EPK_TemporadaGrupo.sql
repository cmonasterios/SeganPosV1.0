CREATE TABLE [dbo].[EPK_TemporadaGrupo] (
    [IdTemporada]       INT            NOT NULL,
    [IdGrupo]           INT            NOT NULL,
    [PorcentajeAumento] DECIMAL (5, 2) NULL,
    CONSTRAINT [PK_EPK_TemporadaGrupo] PRIMARY KEY CLUSTERED ([IdTemporada] ASC, [IdGrupo] ASC),
    CONSTRAINT [FK_EPK_TemporadaGrupo_EPK_Grupo] FOREIGN KEY ([IdGrupo]) REFERENCES [dbo].[EPK_Grupo] ([IdGrupo]),
    CONSTRAINT [FK_EPK_TemporadaGrupo_EPK_Temporada] FOREIGN KEY ([IdTemporada]) REFERENCES [dbo].[EPK_Temporada] ([IdTemporada])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_TemporadaGrupo] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_TemporadaGrupo] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_TemporadaGrupo] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_TemporadaGrupo] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_TemporadaGrupo] TO PUBLIC
    AS [dbo];

