CREATE TABLE [dbo].[EPK_Tienda] (
    [IdTienda]                INT             IDENTITY (1, 1) NOT NULL,
    [IdOrganizacion]          INT             NOT NULL,
    [IdCiudad]                INT             NOT NULL,
    [IdTipoTienda]            SMALLINT        NOT NULL,
    [CodigoTienda]            VARCHAR (20)    NOT NULL,
    [CodigoSitio]             VARCHAR (20)    NOT NULL,
    [Descripcion]             VARCHAR (100)   NOT NULL,
    [DireccionIP]             VARCHAR (36)    NULL,
    [Puerto]                  VARCHAR (10)    NULL,
    [PiedeFactura]            VARCHAR (150)   NULL,
    [CapacidadPiezas]         INT             NULL,
    [CapacidadPisoVta]        INT             NULL,
    [CapacidadDeposito]       INT             NULL,
    [CapacidadMezzanina]      INT             NULL,
    [EspacioPisoVta]          SMALLINT        NULL,
    [EspacioDeposito]         SMALLINT        NULL,
    [EspacioMezzanina]        SMALLINT        NULL,
    [FechaCreacion]           DATETIME        CONSTRAINT [DF_EPK_Tienda_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion]       DATETIME        NULL,
    [Activa]                  BIT             CONSTRAINT [DF_EPK_Tienda_Activa] DEFAULT ((1)) NOT NULL,
    [SitioColeccionActual]    TINYINT         NULL,
    [SitioColeccionesPasadas] TINYINT         NULL,
    [TStamp]                  ROWVERSION      NOT NULL,
    [TopeApertura]            DECIMAL (18, 2) CONSTRAINT [DF_EPK_Tienda_TopeApertura] DEFAULT ((200)) NOT NULL,
    [ClientesCentralizados]   BIT             CONSTRAINT [DF_EPK_Tienda_ClientesCentralizados] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_EPK_Tienda_2] PRIMARY KEY CLUSTERED ([IdTienda] ASC),
    CONSTRAINT [FK_EPK_Tienda_EPK_Ciudad] FOREIGN KEY ([IdCiudad]) REFERENCES [dbo].[EPK_Ciudad] ([IdCiudad]),
    CONSTRAINT [FK_EPK_Tienda_EPK_Organizacion1] FOREIGN KEY ([IdOrganizacion]) REFERENCES [dbo].[EPK_Organizacion] ([IdOrganizacion]),
    CONSTRAINT [FK_EPK_Tienda_EPK_TipoTienda] FOREIGN KEY ([IdTipoTienda]) REFERENCES [dbo].[EPK_TipoTienda] ([IdTipoTienda])
);






GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Tienda] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Tienda] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Tienda] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Tienda] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Tienda] TO PUBLIC
    AS [dbo];

