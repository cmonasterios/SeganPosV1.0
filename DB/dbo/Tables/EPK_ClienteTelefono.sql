CREATE TABLE [dbo].[EPK_ClienteTelefono] (
    [IdClienteTelefono] INT          IDENTITY (1, 1) NOT NULL,
    [IdCliente]         INT          NOT NULL,
    [Numero]            VARCHAR (20) NOT NULL,
    [TipoTelefono]      TINYINT      NOT NULL,
    [Principal]         BIT          CONSTRAINT [DF_EPK_ClienteTelefono_Principal] DEFAULT ((1)) NOT NULL,
    [TStamp]            ROWVERSION   NOT NULL,
    [IdTipoDocumento]   TINYINT      NULL,
    [NumeroDocumento]   VARCHAR (30) NULL,
    CONSTRAINT [PK_EPK_ClienteTelefono] PRIMARY KEY CLUSTERED ([IdClienteTelefono] ASC),
    CONSTRAINT [FK_EPK_ClienteTelefono_EPK_Cliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[EPK_Cliente] ([IdCliente])
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_ClienteTelefono] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_ClienteTelefono] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_ClienteTelefono] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_ClienteTelefono] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_ClienteTelefono] TO PUBLIC
    AS [dbo];


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1= Celular,  2= Habitacion,  3= Oficina', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EPK_ClienteTelefono', @level2type = N'COLUMN', @level2name = N'TipoTelefono';

