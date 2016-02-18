CREATE TABLE [dbo].[EPK_FacturaEncabezado] (
    [IdFactura]             INT             IDENTITY (1, 1) NOT NULL,
    [IdTienda]              INT             CONSTRAINT [DF_EPK_FacturaEncabezado_IdTienda] DEFAULT ((1)) NOT NULL,
    [TicketFiscal]          VARCHAR (10)    NULL,
    [IdCaja]                INT             NOT NULL,
    [COO]                   CHAR (6)        NULL,
    [SerialMF]              VARCHAR (15)    NOT NULL,
    [IdEstatus]             SMALLINT        NOT NULL,
    [Fecha]                 DATE            CONSTRAINT [DF_EPK_FacturaEncabezado_Fecha] DEFAULT (getdate()) NOT NULL,
    [Hora]                  TIME (7)        CONSTRAINT [DF_EPK_FacturaEncabezado_Hora] DEFAULT (getdate()) NOT NULL,
    [PorcDescuento]         DECIMAL (4, 2)  CONSTRAINT [DF_EPK_FacturaEncabezado_PorcDescuento] DEFAULT ((0)) NOT NULL,
    [IdCliente]             INT             NOT NULL,
    [MontoBase]             DECIMAL (18, 2) NULL,
    [MontoDescuento]        DECIMAL (18, 2) NULL,
    [MontoIVA]              DECIMAL (18, 2) NOT NULL,
    [MontoTotal]            DECIMAL (18, 2) NULL,
    [NroReporteZ]           VARCHAR (10)    NULL,
    [IdVendedor]            BIGINT          NULL,
    [FechaCreacion]         DATETIME        CONSTRAINT [DF_EPK_FacturaEncabezado_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [IdUsuarioCreacion]     INT             NOT NULL,
    [FechaModificacion]     DATETIME        CONSTRAINT [DF_EPK_FacturaEncabezado_FechaModificacion] DEFAULT (getdate()) NULL,
    [IdUsuarioModificacion] INT             NULL,
    [TStamp]                ROWVERSION      NOT NULL,
    [IdTipoDocumento]       TINYINT         NULL,
    [NumeroDocumento]       VARCHAR (30)    NULL,
    CONSTRAINT [PK_EPK_FacturaEncabezado_1] PRIMARY KEY CLUSTERED ([IdFactura] ASC, [IdTienda] ASC),
    CONSTRAINT [FK_EPK_FacturaEncabezado_EPK_Caja] FOREIGN KEY ([IdCaja]) REFERENCES [dbo].[EPK_Caja] ([IdCaja]),
    CONSTRAINT [FK_EPK_FacturaEncabezado_EPK_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[EPK_Cliente] ([IdCliente]),
    CONSTRAINT [FK_EPK_FacturaEncabezado_EPK_Empleados] FOREIGN KEY ([IdVendedor]) REFERENCES [dbo].[EPK_Empleados] ([IdEmpleado]),
    CONSTRAINT [FK_EPK_FacturaEncabezado_EPK_Estatus] FOREIGN KEY ([IdEstatus]) REFERENCES [dbo].[EPK_Estatus] ([IdEstatus]),
    CONSTRAINT [FK_EPK_FacturaEncabezado_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda]),
    CONSTRAINT [FK_EPK_FacturaEncabezado_EPK_Usuario] FOREIGN KEY ([IdUsuarioCreacion]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario]),
    CONSTRAINT [FK_EPK_FacturaEncabezado_EPK_Usuario1] FOREIGN KEY ([IdUsuarioModificacion]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario])
);






GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_FacturaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_FacturaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_FacturaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_FacturaEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_FacturaEncabezado] TO PUBLIC
    AS [dbo];

