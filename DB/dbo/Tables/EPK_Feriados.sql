CREATE TABLE [dbo].[EPK_Feriados] (
    [IdFeriado]      SMALLINT     IDENTITY (1, 1) NOT NULL,
    [Descripcion]    VARCHAR (50) NOT NULL,
    [IdOrganizacion] INT          CONSTRAINT [DF_EPK_Feriados_IdOrganizacion] DEFAULT ((1)) NOT NULL,
    [Anual]          BIT          CONSTRAINT [DF_EPK_Feriados_Anual] DEFAULT ((1)) NOT NULL,
    [FechaInicio]    DATE         NULL,
    [FechaFin]       DATE         NULL,
    [TStamp]         ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_Feriados] PRIMARY KEY CLUSTERED ([IdFeriado] ASC),
    CONSTRAINT [FK_EPK_Feriados_EPK_Organizacion] FOREIGN KEY ([IdOrganizacion]) REFERENCES [dbo].[EPK_Organizacion] ([IdOrganizacion])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Feriados] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Feriados] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Feriados] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Feriados] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Feriados] TO PUBLIC
    AS [dbo];

