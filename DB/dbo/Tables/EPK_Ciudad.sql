CREATE TABLE [dbo].[EPK_Ciudad] (
    [IdCiudad]          INT          NOT NULL,
    [Nombre]            VARCHAR (60) NOT NULL,
    [IdEstado]          INT          NOT NULL,
    [FechaCreacion]     DATETIME     CONSTRAINT [DF_EPK_Ciudad_FechaCreacion] DEFAULT (getdate()) NOT NULL,
    [FechaModificacion] DATETIME     NULL,
    [TStamp]            ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Ciudad_1] PRIMARY KEY CLUSTERED ([IdCiudad] ASC),
    CONSTRAINT [FK_EPK_Ciudad_EPK_Estado] FOREIGN KEY ([IdEstado]) REFERENCES [dbo].[EPK_Estado] ([IdEstado])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Ciudad] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Ciudad] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Ciudad] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Ciudad] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Ciudad] TO PUBLIC
    AS [dbo];

