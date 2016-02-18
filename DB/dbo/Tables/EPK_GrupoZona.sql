CREATE TABLE [dbo].[EPK_GrupoZona] (
    [IdRegion]         INT          NOT NULL,
    [IdGrupo]          SMALLINT     NOT NULL,
    [Descripcion]      VARCHAR (50) NULL,
    [TipoVerificacion] SMALLINT     NULL,
    [FeriadosValidos]  BIT          NULL,
    [IdZona1]          SMALLINT     NULL,
    [IdZona2]          SMALLINT     NULL,
    [IdZona3]          SMALLINT     NULL,
    [TStamp]           ROWVERSION   NOT NULL,
    CONSTRAINT [PK_EPK_GrupoZona] PRIMARY KEY CLUSTERED ([IdRegion] ASC, [IdGrupo] ASC),
    CONSTRAINT [FK_EPK_GrupoZona_EPK_RegionUbicacion1] FOREIGN KEY ([IdRegion]) REFERENCES [dbo].[EPK_Region] ([IdRegion])
);


GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_GrupoZona] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_GrupoZona] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_GrupoZona] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_GrupoZona] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_GrupoZona] TO PUBLIC
    AS [dbo];

