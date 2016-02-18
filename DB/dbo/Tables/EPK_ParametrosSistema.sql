CREATE TABLE [dbo].[EPK_ParametrosSistema] (
    [IdParametro]   INT             IDENTITY (1, 1) NOT NULL,
    [IdTipoTienda]  SMALLINT        CONSTRAINT [DF_EPK_ParametrosSistema_IdTipoTienda] DEFAULT ((1)) NOT NULL,
    [CodParametro]  VARCHAR (50)    NOT NULL,
    [TipoParametro] SMALLINT        CONSTRAINT [DF_EPK_ParametrosSistema_TipoParametro] DEFAULT ((1)) NOT NULL,
    [ValorCadena]   VARCHAR (MAX)   NULL,
    [ValorNumerico] NUMERIC (18, 2) NULL,
    [ValorEntero]   INT             NULL,
    [FechaInicio]   DATE            CONSTRAINT [DF_EPK_ParametrosSistema_FechaInicio] DEFAULT (getdate()) NOT NULL,
    [FechaFin]      DATE            NULL,
    [TStamp]        ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_ParametrosSistema] PRIMARY KEY CLUSTERED ([IdParametro] ASC),
    CONSTRAINT [UNQ_EPK_ParametrosSistema] UNIQUE NONCLUSTERED ([CodParametro] ASC, [FechaInicio] ASC, [IdTipoTienda] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_ParametrosSistema] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_ParametrosSistema] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_ParametrosSistema] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_ParametrosSistema] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_ParametrosSistema] TO PUBLIC
    AS [dbo];


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1= Cadena, 2= numérico, 3= entero', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EPK_ParametrosSistema', @level2type = N'COLUMN', @level2name = N'TipoParametro';

