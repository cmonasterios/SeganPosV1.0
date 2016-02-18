CREATE TABLE [dbo].[EPK_AlivioEfectivoDetalle] (
    [IdAlivioEfectivo]  BIGINT   NOT NULL,
    [IdDenominacion]    TINYINT  NOT NULL,
    [CantidadCajero]    SMALLINT NOT NULL,
    [CantidadAprobador] SMALLINT NULL,
    CONSTRAINT [PK_EPK_AlivioEfectivoDetalle] PRIMARY KEY CLUSTERED ([IdAlivioEfectivo] ASC, [IdDenominacion] ASC),
    CONSTRAINT [FK_EPK_AlivioEfectivoDetalle_EPK_AlivioEfectivo] FOREIGN KEY ([IdAlivioEfectivo]) REFERENCES [dbo].[EPK_AlivioEfectivoEncabezado] ([IdAlivioEfectivo]),
    CONSTRAINT [FK_EPK_AlivioEfectivoDetalle_EPK_Denominacion] FOREIGN KEY ([IdDenominacion]) REFERENCES [dbo].[EPK_Denominacion] ([IdDenominacion])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_AlivioEfectivoDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_AlivioEfectivoDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_AlivioEfectivoDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_AlivioEfectivoDetalle] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_AlivioEfectivoDetalle] TO PUBLIC
    AS [dbo];

