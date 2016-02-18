CREATE TABLE [dbo].[EPK_FlujoEfectivo] (
    [IdFlujoEfectivo] INT             IDENTITY (1, 1) NOT NULL,
    [IdCaja]          INT             NOT NULL,
    [IdUsuario]       INT             NOT NULL,
    [Cambio]          BIT             CONSTRAINT [DF_EPK_FlujoEfectivo_Cambio] DEFAULT ((1)) NOT NULL,
    [Total]           DECIMAL (18, 2) NOT NULL,
    [FechaCreacion]   DATETIME        CONSTRAINT [DF_EPK_CambioEfectivo_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [Observacion]     VARCHAR (100)   NULL,
    [TStamp]          ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_CambioEfectivo] PRIMARY KEY CLUSTERED ([IdFlujoEfectivo] ASC),
    CONSTRAINT [FK_EPK_CambioEfectivo_EPK_Caja] FOREIGN KEY ([IdCaja]) REFERENCES [dbo].[EPK_Caja] ([IdCaja]),
    CONSTRAINT [FK_EPK_CambioEfectivo_EPK_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario])
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_FlujoEfectivo] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_FlujoEfectivo] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_FlujoEfectivo] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_FlujoEfectivo] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_FlujoEfectivo] TO PUBLIC
    AS [dbo];

