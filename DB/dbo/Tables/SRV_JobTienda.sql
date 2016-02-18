CREATE TABLE [dbo].[SRV_JobTienda] (
    [IdJob]    INT NOT NULL,
    [IdTienda] INT NOT NULL,
    [Activo]   BIT CONSTRAINT [DF_SRV_JobTienda_Activo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_SRV_JobTienda] PRIMARY KEY CLUSTERED ([IdJob] ASC, [IdTienda] ASC),
    CONSTRAINT [FK_SRV_JobTienda_EPK_Tienda] FOREIGN KEY ([IdTienda]) REFERENCES [dbo].[EPK_Tienda] ([IdTienda]),
    CONSTRAINT [FK_SRV_JobTienda_SRV_Job] FOREIGN KEY ([IdJob]) REFERENCES [dbo].[SRV_Job] ([IdJob])
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[SRV_JobTienda] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[SRV_JobTienda] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[SRV_JobTienda] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[SRV_JobTienda] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[SRV_JobTienda] TO PUBLIC
    AS [dbo];

