CREATE TABLE [dbo].[EPK_FlujoEfectivoDetalle] (
    [IdFlujoEfectivo] INT        NOT NULL,
    [IdDenominacion]  TINYINT    NOT NULL,
    [Ingreso]         SMALLINT   NOT NULL,
    [Egreso]          SMALLINT   NOT NULL,
    [TStamp]          ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_CambioEfectivoDetalle] PRIMARY KEY CLUSTERED ([IdFlujoEfectivo] ASC, [IdDenominacion] ASC),
    CONSTRAINT [FK_EPK_CambioEfectivoDetalle_EPK_CambioEfectivo] FOREIGN KEY ([IdFlujoEfectivo]) REFERENCES [dbo].[EPK_FlujoEfectivo] ([IdFlujoEfectivo]),
    CONSTRAINT [FK_EPK_CambioEfectivoDetalle_EPK_Denominacion] FOREIGN KEY ([IdDenominacion]) REFERENCES [dbo].[EPK_Denominacion] ([IdDenominacion])
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_FlujoEfectivoDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_FlujoEfectivoDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_FlujoEfectivoDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_FlujoEfectivoDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_FlujoEfectivoDetalle] TO PUBLIC
    AS [dbo];

