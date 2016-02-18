
-- =============================================================================
-- Author:		Silvia Derkoyorikian
-- Create date: 19/12/2013
-- Description:	Permite listar los totales  por tipo de prenda 
--				del pedido sugerido para una coleccion determinada.
-- =============================================================================
CREATE PROCEDURE [dbo].[EPK_sp_PedidoSugeridoTotales] 
	 @IdColeccion  INT
	,@MenosDe      INT
	,@PidoPMenosDe INT
	,@Entre5y      INT
	,@PidoEntre5y  INT
AS
BEGIN
	DECLARE @StockMinimo INT 

	SET @StockMinimo =  DBO.fn_ObtenerParametroEntero ('StockMinimo',GETDATE(), 1)
	
	
	SELECT TipoPrenda, Pedir
	FROM 
		(SELECT * 
		FROM (SELECT	ISNULL(LTRIM(RTRIM(TP.Descripcion)),'OTROS') TipoPrenda 
					,ISNULL(TP.Ropa,0) Ropa
					,SUM (CASE WHEN  ExistenciaAlmacen > @StockMinimo THEN CASE	WHEN Existencia < 4			THEN 6 
																			WHEN Existencia BETWEEN 4 AND 7	THEN 3 
																			ELSE 0 END 
																ELSE 0 END)Pedir
			FROM EPK_Articulo A
			INNER JOIN EPK_Referencia  R 
				ON A.IdReferencia = R.IdReferencia
			INNER JOIN EPK_Color  C      
				ON C.IdColor = A.IdColor
			INNER JOIN EPK_Talla  T      
				ON T.IdTalla = A.IdTalla   
			INNER JOIN EPK_Genero G      
				ON G.IdGenero = R.IdGenero
			LEFT JOIN EPK_Grupo AS  Gr	 
				ON R.IdGrupo = Gr.IdGrupo 
			LEFT JOIN EPK_TipoPrenda AS TP 
				ON Gr.IdTipoPrenda = TP.IdTipoPrenda
			WHERE	IdColeccion = @IdColeccion
			GROUP BY TP.Ropa,		LTRIM(RTRIM(TP.Descripcion))
			)T
		UNION ALL 
		SELECT * 
		FROM (SELECT	'TOTAL' TipoPrenda
						,-1	Ropa
						,SUM (CASE WHEN  ExistenciaAlmacen > @StockMinimo THEN CASE	WHEN Existencia < 4			THEN 6 
																				WHEN Existencia BETWEEN 4 AND 7	THEN 3 
																				ELSE 0 END 
																	ELSE 0 END)Pedir
				FROM EPK_Articulo A
				INNER JOIN EPK_Referencia  R 
					ON A.IdReferencia = R.IdReferencia
				INNER JOIN EPK_Color  C      
					ON C.IdColor = A.IdColor
				INNER JOIN EPK_Talla  T      
					ON T.IdTalla = A.IdTalla   
				INNER JOIN EPK_Genero G      
					ON G.IdGenero = R.IdGenero
				LEFT JOIN EPK_Grupo AS  Gr	 
					ON R.IdGrupo = Gr.IdGrupo 
				LEFT JOIN EPK_TipoPrenda AS TP 
					ON Gr.IdTipoPrenda = TP.IdTipoPrenda
				WHERE	IdColeccion = @IdColeccion ) T2
		) T3
	ORDER BY T3.Ropa DESC,	T3.TipoPrenda
	--GROUP BY TP.Ropa,		LTRIM(RTRIM(TP.Descripcion))
	--ORDER BY TP.Ropa DESC,	ISNULL(LTRIM(RTRIM(TP.Descripcion)),'OTROS')
	
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_PedidoSugeridoTotales] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_PedidoSugeridoTotales] TO PUBLIC
    AS [dbo];

