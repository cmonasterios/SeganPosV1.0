

-- ===========================================================
-- Author:		sderkoyorikian
-- Create date: 14/08/2013
-- Description:	Permite consultar las facturas y sus detalles
-- ===========================================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteReferenciasSinMovimiento]
(
	@FechaDesde		DATE,
	@FechaHasta		DATE,
	@IdColeccion	INT = NULL,
	@CodReferencia	VARCHAR(11) = NULL,
	@IdTalla		INT = NULL,
	@IdColor		INT = NULL,
	@IdGenero		INT = NULL,
	@IdGrupo		INT = NULL,
	@IdTema			INT = NULL,
	@IdTipoPrenda	TINYINT = NULL
)
AS 
BEGIN
	BEGIN TRY 
		
		IF @CodReferencia = ''
			SET @CodReferencia = NULL 
		
		SELECT DISTINCT A.IdArticulo, A.CodigoArticulo, A.Descripcion, R.Descripcion Referencia, T.ultventa, A.Existencia
		FROM EPK_Articulo  A
		INNER JOIN EPK_Referencia R
			ON A.IdReferencia = R.IdReferencia 
		INNER JOIN EPK_Grupo G
			ON R.IdGrupo  = R.IdGrupo 
		LEFT JOIN (SELECT df.IdArticulo, MAX (f.Fecha) ultventa 
					FROM EPK_FacturaDetalle df
					INNER JOIN EPK_FacturaEncabezado f
						ON f.IdFactura = df.IdFactura 
					GROUP BY df.IdArticulo) T
			ON A.IdArticulo =  T.IdArticulo 
		WHERE A.Activo = 1
			AND A.Existencia <>0
			AND	(T.ultventa IS NULL OR ultventa BETWEEN @FechaDesde  AND DATEADD (DAY, -8, @FechaHasta))
			AND (@IdColeccion IS NULL	OR  R.IdColeccion	= @IdColeccion)
			AND (@CodReferencia IS NULL	OR  R.CodigoReferencia LIKE @CodReferencia+'%') 
			AND (@IdTalla IS NULL		OR  A.IdTalla		= @IdTalla)
			AND (@IdColor IS NULL		OR  A.IdColor 		= @IdColor)
			AND (@IdGenero IS NULL		OR  R.IdGenero 		= @IdGenero)
			AND (@IdGrupo IS NULL		OR  R.IdGrupo 		= @IdGrupo)
			AND (@IdTema IS NULL		OR  R.IdTema 		= @IdTema)
			AND (@IdTipoPrenda IS NULL	OR  G.IdTipoPrenda 	= @IdTipoPrenda)
		
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
    ON OBJECT::[dbo].[EPK_sp_ReporteReferenciasSinMovimiento] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteReferenciasSinMovimiento] TO PUBLIC
    AS [dbo];

