CREATE TABLE [dbo].[EPK_Talla] (
    [IdTalla]       INT           IDENTITY (1, 1) NOT NULL,
    [CodigoTalla]   CHAR (11)     NOT NULL,
    [Descripcion]   VARCHAR (255) NOT NULL,
    [FechaCreacion] DATETIME      CONSTRAINT [DF_EPK_Talla_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [Orden]         INT           CONSTRAINT [DF_EPK_Talla_Orden] DEFAULT ((1)) NOT NULL,
    [TStamp]        ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_Talla] PRIMARY KEY CLUSTERED ([IdTalla] ASC),
    CONSTRAINT [UNQ_EPK_Talla] UNIQUE NONCLUSTERED ([CodigoTalla] ASC)
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Talla] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Talla] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Talla] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Talla] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Talla] TO PUBLIC
    AS [dbo];

