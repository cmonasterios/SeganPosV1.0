CREATE TABLE [dbo].[EPK_POS] (
    [IdPOS]             INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion]       VARCHAR (100) NOT NULL,
    [IdEntidad]         INT           NOT NULL,
    [Activo]            BIT           CONSTRAINT [DF_EPK_POS_Activo] DEFAULT ((1)) NOT NULL,
    [FechaCreacion]     DATETIME      CONSTRAINT [DF_EPK_POS_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion] DATETIME      NULL,
    [TStamp]            ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_POS] PRIMARY KEY CLUSTERED ([IdPOS] ASC),
    CONSTRAINT [FK_EPK_POS_EPK_EntidadFinanciera] FOREIGN KEY ([IdEntidad]) REFERENCES [dbo].[EPK_EntidadFinanciera] ([IdEntidad])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_POS] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_POS] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_POS] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_POS] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_POS] TO PUBLIC
    AS [dbo];

