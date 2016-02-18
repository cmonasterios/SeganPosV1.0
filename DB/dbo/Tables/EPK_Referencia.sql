CREATE TABLE [dbo].[EPK_Referencia] (
    [IdReferencia]     INT             IDENTITY (1, 1) NOT NULL,
    [CodigoReferencia] CHAR (11)       NOT NULL,
    [Descripcion]      VARCHAR (50)    NOT NULL,
    [Activo]           BIT             NOT NULL,
    [IdGrupo]          INT             NULL,
    [IdGenero]         INT             NULL,
    [IdColeccion]      INT             NULL,
    [IdTema]           INT             NULL,
    [IdEquivalente]    INT             NULL,
    [FechaCreacion]    DATETIME        CONSTRAINT [DF_EPK_Referencia_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FotoMediana]      VARBINARY (MAX) NULL,
    [MimeTypeMediana]  VARCHAR (100)   NULL,
    [FileNameMediana]  VARCHAR (300)   NULL,
    [TStamp]           ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_Referencia] PRIMARY KEY CLUSTERED ([IdReferencia] ASC),
    CONSTRAINT [FK_EPK_Referencia_EPK_Coleccion] FOREIGN KEY ([IdColeccion]) REFERENCES [dbo].[EPK_Coleccion] ([IdColeccion]),
    CONSTRAINT [FK_EPK_Referencia_EPK_Genero] FOREIGN KEY ([IdGenero]) REFERENCES [dbo].[EPK_Genero] ([IdGenero]),
    CONSTRAINT [FK_EPK_Referencia_EPK_Grupo] FOREIGN KEY ([IdGrupo]) REFERENCES [dbo].[EPK_Grupo] ([IdGrupo]),
    CONSTRAINT [FK_EPK_Referencia_EPK_Tema] FOREIGN KEY ([IdTema]) REFERENCES [dbo].[EPK_Tema] ([IdTema])
);




GO
CREATE NONCLUSTERED INDEX [IX_EPK_Referencia]
    ON [dbo].[EPK_Referencia]([CodigoReferencia] ASC);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Referencia] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Referencia] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Referencia] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Referencia] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Referencia] TO PUBLIC
    AS [dbo];


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Codigo del valor categoría de GP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EPK_Referencia', @level2type = N'COLUMN', @level2name = N'CodigoReferencia';

