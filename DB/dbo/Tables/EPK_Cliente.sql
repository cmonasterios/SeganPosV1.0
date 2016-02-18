CREATE TABLE [dbo].[EPK_Cliente] (
    [IdCliente]             INT           IDENTITY (1, 1) NOT NULL,
    [NumeroDocumento]       VARCHAR (30)  NOT NULL,
    [IdTipoDocumento]       TINYINT       NOT NULL,
    [Nombre]                VARCHAR (50)  NOT NULL,
    [Apellido]              VARCHAR (50)  NOT NULL,
    [Direccion]             VARCHAR (500) NOT NULL,
    [Email]                 VARCHAR (100) NULL,
    [Sexo]                  CHAR (1)      NULL,
    [FechaNacimiento]       DATE          NULL,
    [IdEstadoNacimiento]    INT           NULL,
    [Credito]               VARCHAR (10)  NULL,
    [IdEstatus]             SMALLINT      NULL,
    [Especial]              BIT           NULL,
    [IdTipoDescuento]       TINYINT       NULL,
    [FechaCreacion]         DATETIME      CONSTRAINT [DF_EPK_Cliente_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [IdUsuarioCreacion]     INT           NOT NULL,
    [FechaModificacion]     DATETIME      NULL,
    [IdUsuarioModificacion] INT           NULL,
    [TStamp]                ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_Cliente_1] PRIMARY KEY CLUSTERED ([IdCliente] ASC),
    CONSTRAINT [FK_EPK_Cliente_EPK_Estado] FOREIGN KEY ([IdEstadoNacimiento]) REFERENCES [dbo].[EPK_Estado] ([IdEstado]),
    CONSTRAINT [FK_EPK_Cliente_EPK_Estatus] FOREIGN KEY ([IdEstatus]) REFERENCES [dbo].[EPK_Estatus] ([IdEstatus]),
    CONSTRAINT [FK_EPK_Cliente_EPK_TipoDescuento] FOREIGN KEY ([IdTipoDescuento]) REFERENCES [dbo].[EPK_TipoDescuento] ([IdTipoDescuento]),
    CONSTRAINT [FK_EPK_Cliente_EPK_TipoDocumento] FOREIGN KEY ([IdTipoDocumento]) REFERENCES [dbo].[EPK_TipoDocumento] ([IdTipoDocumento]),
    CONSTRAINT [UNQ_EPK_Cliente] UNIQUE NONCLUSTERED ([IdTipoDocumento] ASC, [NumeroDocumento] ASC)
);








GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Cliente] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Cliente] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Cliente] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Cliente] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Cliente] TO PUBLIC
    AS [dbo];


GO


