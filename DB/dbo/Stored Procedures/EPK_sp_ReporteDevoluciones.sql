


-- ===========================================================
-- Author:		motero
-- Create date: 10/09/2013
-- Description:	Permite consultar las devoluciones
-- ===========================================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteDevoluciones]
(
	@FechaDesde		date,--varchar(10),
	@FechaHasta		date,--varchar(10),
	@FactDesde		INT = NULL,
	@FactHasta		INT = NULL,
	@IdMotDev		INT = NULL,
	--@IdCajero		INT = NULL,
	@IdAutoriz		INT = NULL,
	@IdColeccion	INT = NULL,
	@IdGenero		INT = NULL,
	@IdGrupo		INT = NULL,
	@Cajero         VARCHAR(30) = NULL
)
AS 
BEGIN
	BEGIN TRY 
		
		declare @idAprobada as int
		SET  @idAprobada  = DBO.fn_ObtenerParametroEntero ('FACProcesada', GETDATE(),1)


				SELECT		FactE.Fecha,
						CONVERT(VARCHAR(8),FactE.Hora,114) as Hora, 
						FactE.IdFactura, 
						FactE.MontoTotal, 
						Art.IdArticulo, 
						Art.CodigoArticulo, 
						Ref.IdReferencia, 
						FotoPequena = Ref.FotoMediana,
						FactD.Cantidad, 
						FactD.IdMotivoDevolucion, 
						MotDev.Motivo, 
						Col.IdColeccion, 
						Col.Descripcion AS Coleccion, 
						Gen.IdGenero, 
						Gen.Descripcion AS Genero, 
						Grup.IdGrupo, 
						Grup.Descripcion AS Grupo, 
						FactE.IdUsuarioCreacion, 
						FactE.IdUsuarioModificacion, 
						Caj.Identificacion AS Cajero, 
						Autori.Identificacion AS Autorizador
				FROM	EPK_FacturaEncabezado AS FactE 
				INNER JOIN EPK_FacturaDetalle AS FactD ON FactE.IdFactura = FactD.IdFactura 
				INNER JOIN EPK_Articulo AS Art ON FactD.IdArticulo = Art.IdArticulo 
				INNER JOIN EPK_Referencia AS Ref ON Art.IdReferencia = Ref.IdReferencia 
				INNER JOIN EPK_Coleccion AS Col ON Ref.IdColeccion = Col.IdColeccion 
				INNER JOIN EPK_Grupo AS Grup ON Ref.IdGrupo = Grup.IdGrupo 
				INNER JOIN EPK_Genero AS Gen ON Ref.IdGenero = Gen.IdGenero INNER JOIN
						EPK_MotivoDevolucion AS MotDev ON FactD.IdMotivoDevolucion = MotDev.IdMotivo INNER JOIN
						EPK_Usuario AS Caj ON FactE.IdUsuarioCreacion = Caj.IdUsuario left JOIN
						EPK_Usuario AS Autori ON FactE.IdUsuarioModificacion = Autori.IdUsuario
			    WHERE  FactE.Fecha BETWEEN @FechaDesde AND @FechaHasta
					    AND (@FactDesde IS NULL	OR FactE.IdFactura >= @FactDesde)
					    AND (@FactHasta IS NULL OR FactE.IdFactura <= @FactHasta )
					    AND (@IdColeccion IS NULL OR Col.IdColeccion = @IdColeccion)
					    AND (@IdMotDev IS NULL OR FactD.IdMotivoDevolucion = @IdMotDev) 
					    --AND (@IdCajero IS NULL OR FactE.IdUsuarioCreacion = @IdCajero)
					    AND (@Cajero IS NULL	OR CAJ.Identificacion  like '%'+@Cajero+'%')
					    AND (@IdAutoriz IS NULL OR Autori.IdUsuario = @IdAutoriz)
					    AND (@IdGenero IS NULL OR Ref.IdGenero = @IdGenero)
					    AND (@IdGrupo IS NULL OR Grup.IdGrupo = @IdGrupo)
					    AND FactE.IdEstatus = @idAprobada
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
    ON OBJECT::[dbo].[EPK_sp_ReporteDevoluciones] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteDevoluciones] TO PUBLIC
    AS [dbo];

