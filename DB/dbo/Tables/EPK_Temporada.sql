CREATE TABLE [dbo].[EPK_Temporada] (
    [IdTemporada]         INT            IDENTITY (1, 1) NOT NULL,
    [Anno]                INT            NOT NULL,
    [Semana]              TINYINT        NOT NULL,
    [PorcentajeAumento]   DECIMAL (5, 2) NOT NULL,
    [SemanasAnalisis]     TINYINT        NOT NULL,
    [IdTipoTemporada]     TINYINT        NOT NULL,
    [MaximoStock]         BIT            CONSTRAINT [DF_EPK_Temporada_MaximoStock] DEFAULT ((0)) NOT NULL,
    [SemanasAnticipacion] TINYINT        CONSTRAINT [DF_EPK_Temporada_SemanasAnticipacion] DEFAULT ((2)) NOT NULL,
    CONSTRAINT [PK_EPK_Temporada] PRIMARY KEY CLUSTERED ([IdTemporada] ASC),
    CONSTRAINT [FK_EPK_Temporada_EPK_TipoTemporada] FOREIGN KEY ([IdTipoTemporada]) REFERENCES [dbo].[EPK_TipoTemporada] ([IdTipoTemporada]),
    CONSTRAINT [IX_EPK_Temporada] UNIQUE NONCLUSTERED ([Anno] ASC, [Semana] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Temporada] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Temporada] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Temporada] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Temporada] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Temporada] TO PUBLIC
    AS [dbo];

