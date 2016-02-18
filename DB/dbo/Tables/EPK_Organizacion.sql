CREATE TABLE [dbo].[EPK_Organizacion] (
    [IdOrganizacion]  INT             NOT NULL,
    [Descripcion]     VARCHAR (60)    NOT NULL,
    [IdPais]          INT             NOT NULL,
    [RIF]             VARCHAR (14)    NULL,
    [Logo]            VARBINARY (MAX) NULL,
    [MimeType]        VARCHAR (100)   NULL,
    [FileName]        VARCHAR (300)   NULL,
    [Url]             VARCHAR (60)    NULL,
    [Email1]          VARCHAR (60)    NULL,
    [Email2]          VARCHAR (60)    NULL,
    [Email3]          VARCHAR (60)    NULL,
    [IdLenguaje]      VARCHAR (10)    NULL,
    [TStamp]          ROWVERSION      NOT NULL,
    [ImagenDefault]   VARBINARY (MAX) NULL,
    [MimeTypeDefault] VARCHAR (100)   NULL,
    [FileNameDefault] VARCHAR (300)   NULL,
    CONSTRAINT [PK_EPK_Organizacion] PRIMARY KEY CLUSTERED ([IdOrganizacion] ASC),
    CONSTRAINT [FK_EPK_Organizacion_EPK_Lenguaje] FOREIGN KEY ([IdLenguaje]) REFERENCES [dbo].[EPK_Lenguaje] ([IdLenguaje]),
    CONSTRAINT [FK_EPK_Organizacion_EPK_Pais] FOREIGN KEY ([IdPais]) REFERENCES [dbo].[EPK_Pais] ([IdPais])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Organizacion] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Organizacion] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Organizacion] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Organizacion] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Organizacion] TO PUBLIC
    AS [dbo];

