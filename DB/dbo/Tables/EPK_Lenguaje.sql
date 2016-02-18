﻿CREATE TABLE [dbo].[EPK_Lenguaje] (
    [IdLenguaje]         VARCHAR (10) NOT NULL,
    [Descripcion]        VARCHAR (60) NULL,
    [FechaActualizacion] DATETIME     NULL,
    [TStamp]             ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Lenguaje] PRIMARY KEY CLUSTERED ([IdLenguaje] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Lenguaje] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Lenguaje] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Lenguaje] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Lenguaje] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Lenguaje] TO PUBLIC
    AS [dbo];

