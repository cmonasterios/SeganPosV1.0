CREATE TABLE [dbo].[EPK_Denominacion] (
    [IdDenominacion] TINYINT         IDENTITY (1, 1) NOT NULL,
    [Denominacion]   DECIMAL (18, 2) NOT NULL,
    [Billete]        BIT             CONSTRAINT [DF_EPK_Denominacion_Billete] DEFAULT ((1)) NOT NULL,
    [Logo]           VARBINARY (MAX) NULL,
    [MimeType]       VARCHAR (100)   NULL,
    [FileName]       VARCHAR (300)   NULL,
    [TStamp]         ROWVERSION      NOT NULL,
    CONSTRAINT [PK_EPK_Denominacion] PRIMARY KEY CLUSTERED ([IdDenominacion] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Denominacion] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Denominacion] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Denominacion] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Denominacion] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Denominacion] TO PUBLIC
    AS [dbo];

