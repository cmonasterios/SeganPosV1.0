CREATE TABLE [dbo].[EPK_CombinacionGrupos] (
    [IdRegion]      INT        NOT NULL,
    [IdCombinacion] SMALLINT   NOT NULL,
    [Descripcion]   CHAR (50)  NULL,
    [IdGrupo1]      SMALLINT   NULL,
    [IdGrupo2]      SMALLINT   NULL,
    [IdGrupo3]      SMALLINT   NULL,
    [IdGrupo4]      SMALLINT   NULL,
    [IdGrupo5]      SMALLINT   NULL,
    [TStamp]        ROWVERSION NOT NULL,
    CONSTRAINT [PK_EPK_CombinacionGrupos] PRIMARY KEY CLUSTERED ([IdRegion] ASC, [IdCombinacion] ASC),
    CONSTRAINT [FK_EPK_CombinacionGrupos_EPK_RegionUbicacion] FOREIGN KEY ([IdRegion]) REFERENCES [dbo].[EPK_Region] ([IdRegion])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_CombinacionGrupos] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_CombinacionGrupos] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_CombinacionGrupos] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_CombinacionGrupos] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_CombinacionGrupos] TO PUBLIC
    AS [dbo];

