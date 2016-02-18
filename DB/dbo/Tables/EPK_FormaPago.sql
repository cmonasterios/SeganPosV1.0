CREATE TABLE [dbo].[EPK_FormaPago] (
    [IdFormaPago]          TINYINT         IDENTITY (1, 1) NOT NULL,
    [Codigo_Pago]          VARCHAR (3)     NOT NULL,
    [Descripcion]          VARCHAR (20)    NOT NULL,
    [Logo]                 VARBINARY (MAX) NULL,
    [MimeType]             VARCHAR (100)   NULL,
    [FileName]             VARCHAR (300)   NULL,
    [Activa]               BIT             CONSTRAINT [DF_EPK_FormaPago_Activa] DEFAULT ((1)) NOT NULL,
    [RequiereAutorizacion] BIT             CONSTRAINT [DF_EPK_FormaPago_RequiereAutorizacion] DEFAULT ((0)) NOT NULL,
    [TStamp]               ROWVERSION      NOT NULL,
    [DatosBanco]           BIT             NOT NULL,
    [DatosPOS]             BIT             NOT NULL,
    [Restringida]          BIT             CONSTRAINT [DF_EPK_FormaPago_Restringida] DEFAULT ((0)) NOT NULL,
    [Maximo]               SMALLINT        NULL,
    CONSTRAINT [PK_EPK_FormaPago_1] PRIMARY KEY CLUSTERED ([IdFormaPago] ASC)
);






GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_FormaPago] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_FormaPago] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_FormaPago] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_FormaPago] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_FormaPago] TO PUBLIC
    AS [dbo];

