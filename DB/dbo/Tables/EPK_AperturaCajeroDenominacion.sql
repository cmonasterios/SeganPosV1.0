CREATE TABLE [dbo].[EPK_AperturaCajeroDenominacion] (
    [IdApertura]     BIGINT  NOT NULL,
    [IdDenominacion] TINYINT NOT NULL,
    [Cantidad]       TINYINT NOT NULL,
    CONSTRAINT [PK_EPK_AperturaCajeroDenominacion] PRIMARY KEY CLUSTERED ([IdApertura] ASC, [IdDenominacion] ASC),
    CONSTRAINT [FK_EPK_AperturaCajeroDenominacion_EPK_AperturaCajeroEncabezado] FOREIGN KEY ([IdApertura]) REFERENCES [dbo].[EPK_AperturaCajeroEncabezado] ([IdApertura]),
    CONSTRAINT [FK_EPK_AperturaCajeroDenominacion_EPK_Denominacion] FOREIGN KEY ([IdDenominacion]) REFERENCES [dbo].[EPK_Denominacion] ([IdDenominacion])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_AperturaCajeroDenominacion] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_AperturaCajeroDenominacion] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_AperturaCajeroDenominacion] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_AperturaCajeroDenominacion] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_AperturaCajeroDenominacion] TO PUBLIC
    AS [dbo];

