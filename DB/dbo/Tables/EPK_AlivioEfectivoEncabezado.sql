CREATE TABLE [dbo].[EPK_AlivioEfectivoEncabezado] (
    [IdAlivioEfectivo]    BIGINT          IDENTITY (1, 1) NOT NULL,
    [IdUsuarioCajero]     INT             NOT NULL,
    [IdCaja]              INT             NOT NULL,
    [FechaAlivio]         DATE            NOT NULL,
    [HoraAlivio]          TIME (7)        NOT NULL,
    [TotalPagosEfectivo]  DECIMAL (18, 2) NOT NULL,
    [TotalAlivio]         DECIMAL (18, 2) NOT NULL,
    [TotalAprobado]       DECIMAL (18, 2) NULL,
    [IdMotivoDesc]        TINYINT         NULL,
    [Observacion]         VARCHAR (1000)  NULL,
    [IdEstatus]           SMALLINT        CONSTRAINT [DF_EPK_AlivioEfectivoEncabezado_IdEstatus] DEFAULT ((1)) NOT NULL,
    [IdUsuarioCreacion]   INT             NOT NULL,
    [FechaCreacion]       DATETIME        NOT NULL,
    [IdUsuarioAprobador]  INT             NULL,
    [FechaHoraAprobacion] DATETIME        NULL,
    CONSTRAINT [PK_EPK_AlivioEfectivo] PRIMARY KEY CLUSTERED ([IdAlivioEfectivo] ASC),
    CONSTRAINT [FK_EPK_AlivioEfectivo_EPK_Usuario] FOREIGN KEY ([IdUsuarioCreacion]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario]),
    CONSTRAINT [FK_EPK_AlivioEfectivo_EPK_Usuario1] FOREIGN KEY ([IdUsuarioAprobador]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario]),
    CONSTRAINT [FK_EPK_AlivioEfectivo_EPK_Usuario2] FOREIGN KEY ([IdUsuarioCajero]) REFERENCES [dbo].[EPK_Usuario] ([IdUsuario]),
    CONSTRAINT [FK_EPK_AlivioEfectivoEncabezado_EPK_Caja] FOREIGN KEY ([IdCaja]) REFERENCES [dbo].[EPK_Caja] ([IdCaja]),
    CONSTRAINT [FK_EPK_AlivioEfectivoEncabezado_EPK_MotivoDescuento] FOREIGN KEY ([IdMotivoDesc]) REFERENCES [dbo].[EPK_MotivoDescuento] ([IdMotivoDesc])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_AlivioEfectivoEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_AlivioEfectivoEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_AlivioEfectivoEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_AlivioEfectivoEncabezado] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_AlivioEfectivoEncabezado] TO PUBLIC
    AS [dbo];

