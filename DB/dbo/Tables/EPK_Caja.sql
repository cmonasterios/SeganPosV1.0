CREATE TABLE [dbo].[EPK_Caja] (
    [IdCaja]            INT          IDENTITY (1, 1) NOT NULL,
    [IdTienda]          INT          DEFAULT ((1)) NOT NULL,
    [Descripcion]       VARCHAR (50) NOT NULL,
    [DireccionMAC]      VARCHAR (30) NOT NULL,
    [DireccionIP]       VARCHAR (38) NOT NULL,
    [Puerto]            VARCHAR (10) NOT NULL,
    [EnDescuento]       BIT          CONSTRAINT [DF_EPK_Caja_EnDescuento] DEFAULT ((0)) NOT NULL,
    [FechaCreacion]     DATETIME     CONSTRAINT [DF_EPK_Caja_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion] DATETIME     NULL,
    [TStamp]            ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Caja] PRIMARY KEY CLUSTERED ([IdCaja] ASC)
);








GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Caja] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Caja] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Caja] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Caja] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Caja] TO PUBLIC
    AS [dbo];

