CREATE TABLE [dbo].[EPK_Grupo] (
    [IdGrupo]               INT           IDENTITY (1, 1) NOT NULL,
    [CodigoGrupo]           CHAR (11)     NOT NULL,
    [Descripcion]           VARCHAR (255) NOT NULL,
    [IdTipoPrenda]          TINYINT       CONSTRAINT [DF_EPK_Grupo_IdTipoPrenda] DEFAULT ((1)) NOT NULL,
    [FechaCreacion]         DATETIME      CONSTRAINT [DF_EPK_Grupo_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion]     DATETIME      NULL,
    [IdUsuarioModificacion] INT           NULL,
    [TStamp]                ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_Grupo] PRIMARY KEY CLUSTERED ([IdGrupo] ASC),
    CONSTRAINT [FK_EPK_Grupo_EPK_TipoPrenda] FOREIGN KEY ([IdTipoPrenda]) REFERENCES [dbo].[EPK_TipoPrenda] ([IdTipoPrenda]),
    CONSTRAINT [UNQ_EPK_Grupo] UNIQUE NONCLUSTERED ([CodigoGrupo] ASC)
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Grupo] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Grupo] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Grupo] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Grupo] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Grupo] TO PUBLIC
    AS [dbo];

