CREATE TABLE [dbo].[EPK_Region] (
    [IdRegion]                    INT            IDENTITY (32, 1) NOT NULL,
    [Descripcion]                 VARCHAR (150)  NOT NULL,
    [CodigoPostal]                VARCHAR (15)   NULL,
    [IdPais]                      INT            NULL,
    [IdEstado]                    SMALLINT       NULL,
    [IdCiudad]                    SMALLINT       NULL,
    [IdTipoRegion]                SMALLINT       NULL,
    [BonoAlimentacionExtra]       BIT            NULL,
    [HorasBonoAlimentacionBasico] DECIMAL (4, 2) NULL,
    [IdTienda]                    INT            NULL,
    [TStamp]                      ROWVERSION     NOT NULL,
    CONSTRAINT [PK_EPK_RegionUbicacion] PRIMARY KEY CLUSTERED ([IdRegion] ASC),
    CONSTRAINT [FK_EPK_Region_EPK_Pais] FOREIGN KEY ([IdPais]) REFERENCES [dbo].[EPK_Pais] ([IdPais]),
    CONSTRAINT [FK_EPK_RegionUbicacion_EPK_TipoRegion] FOREIGN KEY ([IdTipoRegion]) REFERENCES [dbo].[EPK_TipoRegion] ([IdTipoRegion])
);




GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_Region] TO PUBLIC
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[EPK_Region] TO PUBLIC
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[EPK_Region] TO PUBLIC
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[EPK_Region] TO PUBLIC
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[EPK_Region] TO PUBLIC
    AS [dbo];

