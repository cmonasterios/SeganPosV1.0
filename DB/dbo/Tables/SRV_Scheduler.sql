CREATE TABLE [dbo].[SRV_Scheduler] (
    [IdScheduler]           INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]                VARCHAR (100) NULL,
    [Activo]                BIT           NULL,
    [FechaInicio]           DATE          NULL,
    [HoraInicio]            TIME (7)      NULL,
    [FechaFin]              DATE          NULL,
    [HoraFin]               TIME (7)      NULL,
    [PeriodicidadIntervalo] TINYINT       NULL,
    [PeriodicidadCantidad]  TINYINT       NULL,
    [FrecuenciaIntervalo]   TINYINT       NULL,
    [FrecuenciaCantidad]    TINYINT       NULL,
    [Lunes]                 BIT           NULL,
    [Martes]                BIT           NULL,
    [Miercoles]             BIT           NULL,
    [Jueves]                BIT           NULL,
    [Viernes]               BIT           NULL,
    [Sabado]                BIT           NULL,
    [Domingo]               BIT           NULL,
    [FechaCreacion]         DATETIME      CONSTRAINT [DF_EPK_Scheduler_FechaCreacion] DEFAULT (getdate()) NULL,
    [TStamp]                ROWVERSION    NULL,
    CONSTRAINT [PK_EPK_Scheduler] PRIMARY KEY CLUSTERED ([IdScheduler] ASC)
);








GO



GO



GO



GO



GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[SRV_Scheduler] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[SRV_Scheduler] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[SRV_Scheduler] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[SRV_Scheduler] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[SRV_Scheduler] TO PUBLIC
    AS [dbo];

