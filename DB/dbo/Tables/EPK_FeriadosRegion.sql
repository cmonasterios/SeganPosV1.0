CREATE TABLE [dbo].[EPK_FeriadosRegion] (
    [IdFeriado] SMALLINT   NOT NULL,
    [IdRegion]  INT        NOT NULL,
    [TStamp]    ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_FeriadoRegion] PRIMARY KEY CLUSTERED ([IdFeriado] ASC, [IdRegion] ASC),
    CONSTRAINT [FK_EPK_FeriadoRegion_EPK_Feriados] FOREIGN KEY ([IdFeriado]) REFERENCES [dbo].[EPK_Feriados] ([IdFeriado]),
    CONSTRAINT [FK_EPK_FeriadoRegion_EPK_RegionUbicacion] FOREIGN KEY ([IdRegion]) REFERENCES [dbo].[EPK_Region] ([IdRegion])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_FeriadosRegion] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_FeriadosRegion] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_FeriadosRegion] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_FeriadosRegion] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_FeriadosRegion] TO PUBLIC
    AS [dbo];

