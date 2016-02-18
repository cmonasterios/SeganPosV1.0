CREATE TABLE [dbo].[EPK_LogErrores] (
    [IdError]       INT            IDENTITY (1, 1) NOT NULL,
    [Procedimiento] VARCHAR (100)  NULL,
    [Linea]         INT            NULL,
    [NroError]      VARCHAR (50)   NULL,
    [Descripcion]   VARCHAR (1000) NULL,
    [FechaError]    DATETIME       CONSTRAINT [DF_EPK_LogErrores_FechaError] DEFAULT (getdate()) NOT NULL,
    [Usuario]       VARCHAR (500)  CONSTRAINT [DF_EPK_LogErrores_Usuario] DEFAULT ('@@ntuser') NOT NULL,
    [TStamp]        ROWVERSION     NOT NULL,
    CONSTRAINT [PK_EPK_LogErrores] PRIMARY KEY CLUSTERED ([IdError] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_LogErrores] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_LogErrores] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_LogErrores] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_LogErrores] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_LogErrores] TO PUBLIC
    AS [dbo];

