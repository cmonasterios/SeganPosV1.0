CREATE TABLE [dbo].[EPK_ClienteFormaPago] (
    [IdClienteFPago]  INT          IDENTITY (1, 1) NOT NULL,
    [IdCliente]       INT          NOT NULL,
    [IdFormaPago]     TINYINT      NOT NULL,
    [FechaCreacion]   DATETIME     CONSTRAINT [DF_EPK_ClienteFormaPago_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [Principal]       BIT          CONSTRAINT [DF_EPK_ClienteFormaPago_Principal] DEFAULT ((0)) NOT NULL,
    [tStamp]          ROWVERSION   NOT NULL,
    [IdTipoDocumento] TINYINT      NULL,
    [NumeroDocumento] VARCHAR (30) NULL,
    CONSTRAINT [PK_EPK_ClienteFormaPago] PRIMARY KEY CLUSTERED ([IdClienteFPago] ASC),
    CONSTRAINT [FK_EPK_ClienteFormaPago_EPK_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[EPK_Cliente] ([IdCliente]),
    CONSTRAINT [FK_EPK_ClienteFormaPago_EPK_FormaPago] FOREIGN KEY ([IdFormaPago]) REFERENCES [dbo].[EPK_FormaPago] ([IdFormaPago])
);








GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_ClienteFormaPago] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_ClienteFormaPago] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_ClienteFormaPago] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_ClienteFormaPago] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_ClienteFormaPago] TO PUBLIC
    AS [dbo];

