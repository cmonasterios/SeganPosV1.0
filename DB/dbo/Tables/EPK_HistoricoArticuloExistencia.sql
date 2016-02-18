CREATE TABLE [dbo].[EPK_HistoricoArticuloExistencia] (
    [IdHistoricoE]    INT          IDENTITY (1, 1) NOT NULL,
    [CodigoSitio]     VARCHAR (20) NOT NULL,
    [CodigoColeccion] CHAR (11)    NOT NULL,
    [CodigoGrupo]     CHAR (11)    NOT NULL,
    [CodigoTalla]     CHAR (11)    NULL,
    [Semana]          TINYINT      NOT NULL,
    [Anno]            SMALLINT     NOT NULL,
    [Existencia]      INT          NULL,
    [Transferencia]   INT          NULL,
    [Venta]           INT          NOT NULL,
    CONSTRAINT [PK_EPK_HistoricoArticuloExistencia_1] PRIMARY KEY CLUSTERED ([IdHistoricoE] ASC),
    CONSTRAINT [FK_EPK_HistoricoArticuloExistencia_EPK_Grupo] FOREIGN KEY ([CodigoGrupo]) REFERENCES [dbo].[EPK_Grupo] ([CodigoGrupo]),
    CONSTRAINT [unq_EPK_HistoricoArticuloExistencia] UNIQUE NONCLUSTERED ([CodigoSitio] ASC, [CodigoGrupo] ASC, [Semana] ASC, [Anno] ASC, [CodigoColeccion] ASC, [CodigoTalla] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_HistoricoArticuloExistencia] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_HistoricoArticuloExistencia] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_HistoricoArticuloExistencia] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_HistoricoArticuloExistencia] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_HistoricoArticuloExistencia] TO PUBLIC
    AS [dbo];

