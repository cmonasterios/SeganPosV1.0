-- ===============================================================
-- Author:		sderkoyorikian
-- Create date: 21/05/2013
-- Description:	Permite consultar los artículos 
-- ===============================================================
CREATE PROCEDURE [dbo].[EPK_sp_ArticuloConsultar]
(
	@IdArticulo		INT			= NULL,
	@CodigoArticulo	CHAR(11)	= NULL, 
	@IdReferencia	INT			= NULL,
	@Descripcion	VARCHAR(100)	= NULL,
	@IdColor		INT			= NULL,
	@IdTalla		INT			= NULL,
	@Activo			BIT			= NULL,
	@Exento			BIT			= NULL,
	@Referencia		VARCHAR(20)	= NULL,
	@IdGrupo		INT			= NULL,
	@IdGenero		INT			= NULL,
	@IdTema			INT			= NULL,
	@IdColeccion	INT			= NULL
)
AS 
BEGIN
	BEGIN TRY 
		
		SELECT A.Activo
		      ,LTRIM(RTRIM(A.CodigoArticulo))CodigoArticulo
		      ,LTRIM(RTRIM(A.Descripcion))Descripcion
		      ,A.Exento
		      ,A.Existencia
		      ,A.ExistenciaAlmacen
		      ,A.FechaCreacion
		      ,A.FechaModificacion
		      ,A.IdArticulo
		      ,A.IdColor
		      ,A.IdReferencia
		      ,A.IdTalla
		      ,A.PrecioExento
		      ,A.PrecioExentoInicial
		      ,A.PrecioGravable
		      ,A.PrecioGravableInicial
		      ,A.TStamp
		      ,FotoPequena = R.FotoMediana
		      ,R.CodigoReferencia
		FROM EPK_Articulo A
		INNER JOIN EPK_Referencia R
			ON A.IdReferencia = R.IdReferencia 
		WHERE	(@IdArticulo  		IS NULL OR IdArticulo		= @IdArticulo)
		AND 	(@CodigoArticulo    IS NULL OR CodigoArticulo	= @CodigoArticulo)
		AND		(@IdReferencia 		IS NULL OR A.IdReferencia	= @IdReferencia)
		AND 	(@IdColor		IS NULL OR IdColor		= @IdColor)
		AND 	(@IdTalla		IS NULL OR IdTalla		= @IdTalla)
		AND 	(@Activo  		IS NULL OR A.Activo		= @Activo)
		AND 	(@Exento  		IS NULL OR Exento		= @Exento)
		AND		(@IdGrupo  		IS NULL OR R.IdGrupo 	= @IdGrupo)
		AND		(@IdGenero  	IS NULL OR R.IdGenero  	= @IdGenero)
		AND		(@IdTema  		IS NULL OR R.IdTema   	= @IdTema)
		AND		(@IdColeccion  	IS NULL OR R.IdColeccion		= @IdColeccion)
		AND		(@Descripcion	IS NULL OR A.Descripcion		LIKE @Descripcion)
		AND		(@Referencia	IS NULL OR R.CodigoReferencia	LIKE @Referencia)
	
		RETURN 1
	END TRY
	BEGIN CATCH
		EXEC EPK_sp_LogErroresGenerar @@SPID
		SELECT 'Linea de error: '+ CAST(ERROR_LINE() as varchar(4)) +' - Nro error: '+ CAST (ERROR_NUMBER () as varchar(30))+' - Mensaje de error: '+ ERROR_MESSAGE () 
		RETURN 0
	END CATCH
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ArticuloConsultar] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ArticuloConsultar] TO PUBLIC
    AS [dbo];

