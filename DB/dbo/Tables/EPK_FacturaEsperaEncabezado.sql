CREATE TABLE [dbo].[EPK_FacturaEsperaEncabezado] (
    [IdFacturaEspera]       INT             IDENTITY (1, 1) NOT NULL,
    [IdCaja]                INT             NOT NULL,
    [IdEstatus]             SMALLINT        NOT NULL,
    [Fecha]                 DATE            CONSTRAINT [DF_EPK_FacturaEsperaEncabezado_Fecha] DEFAULT (getdate()) NOT NULL,
    [Hora]                  TIME (7)        CONSTRAINT [DF_EPK_FacturaEsperaEncabezado_Hora] DEFAULT (getdate()) NOT NULL,
    [PorcDescuento]         DECIMAL (4, 2)  CONSTRAINT [DF_EPK_FacturaEsperaEncabezado_PorcDescuento] DEFAULT ((0)) NOT NULL,
    [IdCliente]             INT             NOT NULL,
    [MontoBase]             DECIMAL (18, 2) CONSTRAINT [DF_EPK_FacturaEsperaEncabezado_MontoBase] DEFAULT ((0)) NULL,
    [MontoDescuento]        DECIMAL (18, 2) CONSTRAINT [DF_EPK_FacturaEsperaEncabezado_MontoDescuento] DEFAULT ((0)) NULL,
    [MontoIVA]              DECIMAL (18, 2) CONSTRAINT [DF_EPK_FacturaEsperaEncabezado_MontoIVA] DEFAULT ((0)) NOT NULL,
    [MontoTotal]            DECIMAL (18, 2) CONSTRAINT [DF_EPK_FacturaEsperaEncabezado_MontoTotal] DEFAULT ((0)) NOT NULL,
    [IdVendedor]            INT             NULL,
    [IdFactura]             INT             NULL,
    [FechaCreacion]         DATETIME        CONSTRAINT [DF_EPK_FacturaEsperaEncabezado_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [IdUsuarioCreacion]     INT             NOT NULL,
    [FechaModificacion]     DATETIME        CONSTRAINT [DF_EPK_FacturaEsperaEncabezado_FechaModificacion] DEFAULT (getdate()) NULL,
    [IdUsuarioModificacion] INT             NULL,
    [TStamp]                ROWVERSION      NOT NULL,
    [IdTipoDocumento]       TINYINT         NULL,
    [NumeroDocumento]       VARCHAR (30)    NULL,
    CONSTRAINT [PK_EPK_FacturaEsperaEncabezado_1] PRIMARY KEY CLUSTERED ([IdFacturaEspera] ASC),
    CONSTRAINT [FK_EPK_FacturaEsperaEncabezado_EPK_Caja] FOREIGN KEY ([IdCaja]) REFERENCES [dbo].[EPK_Caja] ([IdCaja]),
    CONSTRAINT [FK_EPK_FacturaEsperaEncabezado_EPK_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[EPK_Cliente] ([IdCliente]),
    CONSTRAINT [FK_EPK_FacturaEsperaEncabezado_EPK_Estatus] FOREIGN KEY ([IdEstatus]) REFERENCES [dbo].[EPK_Estatus] ([IdEstatus]),
    CONSTRAINT [FK_EPK_FacturaEsperaEncabezado_EPK_Usuario] FOREIGN KEY ([IdUsuarioCreacion]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario]),
    CONSTRAINT [FK_EPK_FacturaEsperaEncabezado_EPK_Usuario1] FOREIGN KEY ([IdUsuarioModificacion]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario])
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_FacturaEsperaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_FacturaEsperaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_FacturaEsperaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_FacturaEsperaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_FacturaEsperaEncabezado] TO PUBLIC
    AS [dbo];

