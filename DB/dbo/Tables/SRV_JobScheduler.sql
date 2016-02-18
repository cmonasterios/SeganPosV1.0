CREATE TABLE [dbo].[SRV_JobScheduler] (
    [IdJobScheduler]    INT        IDENTITY (1, 1) NOT NULL,
    [IdScheduler]       INT        NULL,
    [IdJob]             INT        NULL,
    [FechaUltEjecucion] DATETIME   NULL,
    [FechaCreacion]     DATETIME   CONSTRAINT [DF_EPK_JobScheduler_FechaCreacion] DEFAULT (getdate()) NULL,
    [FechaModificacion] DATETIME   NULL,
    [TStamp]            ROWVERSION NULL,
    CONSTRAINT [PK_EPK_JobScheduler] PRIMARY KEY CLUSTERED ([IdJobScheduler] ASC),
    CONSTRAINT [FK_EPK_JobScheduler_EPK_Job] FOREIGN KEY ([IdJob]) REFERENCES [dbo].[SRV_Job] ([IdJob]),
    CONSTRAINT [FK_EPK_JobScheduler_EPK_Scheduler] FOREIGN KEY ([IdScheduler]) REFERENCES [dbo].[SRV_Scheduler] ([IdScheduler])
);








GO



GO



GO



GO



GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[SRV_JobScheduler] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[SRV_JobScheduler] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[SRV_JobScheduler] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[SRV_JobScheduler] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[SRV_JobScheduler] TO PUBLIC
    AS [dbo];

