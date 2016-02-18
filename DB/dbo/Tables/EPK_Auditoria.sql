CREATE TABLE [dbo].[EPK_Auditoria] (
    [IdAuditoria]     BIGINT        IDENTITY (1, 1) NOT NULL,
    [IdAPP]           INT           CONSTRAINT [DF_EPK_Auditoria_IdAPP] DEFAULT ((1)) NOT NULL,
    [IdUsuario]       INT           NOT NULL,
    [AccionEjecutada] VARCHAR (MAX) NOT NULL,
    [FechaEjecucion]  DATETIME      CONSTRAINT [DF_EPK_Auditoria_FechaEjecucion] DEFAULT (getdate()) NOT NULL,
    [EventLevel]      VARCHAR (50)  NULL,
    [IP]              VARCHAR (50)  NULL,
    [Host]            VARCHAR (50)  NULL,
    [Exception]       VARCHAR (MAX) NULL,
    [TStamp]          ROWVERSION    NOT NULL,
    CONSTRAINT [PK_EPK_Auditoria] PRIMARY KEY CLUSTERED ([IdAuditoria] ASC)
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Auditoria] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Auditoria] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Auditoria] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Auditoria] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Auditoria] TO PUBLIC
    AS [dbo];

