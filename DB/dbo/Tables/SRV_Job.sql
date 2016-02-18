CREATE TABLE [dbo].[SRV_Job] (
    [IdJob]                 INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]                VARCHAR (150) NULL,
    [Activo]                BIT           CONSTRAINT [DF_EPK_Job_Activo] DEFAULT ((0)) NULL,
    [General]               BIT           CONSTRAINT [DF_EPK_Job_General] DEFAULT ((1)) NULL,
    [TransactSQL]           VARCHAR (MAX) NULL,
    [Prioridad]             TINYINT       NULL,
    [FechaCreación]         DATETIME      CONSTRAINT [DF_EPK_Job_FechaCreación] DEFAULT (getdate()) NULL,
    [FechaModificacion]     DATETIME      NULL,
    [IdUsuarioCreacion]     INT           NULL,
    [IdUsuarioModificacion] INT           NULL,
    [TStamp]                ROWVERSION    NULL,
    CONSTRAINT [PK_EPK_Job] PRIMARY KEY CLUSTERED ([IdJob] ASC)
);








GO



GO



GO



GO



GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[SRV_Job] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[SRV_Job] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[SRV_Job] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[SRV_Job] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[SRV_Job] TO PUBLIC
    AS [dbo];

