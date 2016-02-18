
-- ==========================================================================================
-- Author:		Sderkoyorikian
-- Create date: 07/10/2013
-- Description:	Script para ejecutar la distribución de las actualizaciones a los maestros.
-- ==========================================================================================
CREATE PROCEDURE [dbo].[EPK_sp_ActualizacionArticuloEjecutar]
AS
BEGIN
	BEGIN TRY 
		

		--UPDATE EPK_Articulo 
		--SET Existencia =0
		
		--UPDATE EPK_ActualizacionEncabezado 
		--SET IdEstatus = DBO.fn_ObtenerParametroEntero ('ACTAprobacion',GETDATE(),1)

		DECLARE @IdEstAprobado		INT,
				@IdEstProcesado		INT,				
				@IdEstError			INT,
				@RegExist			INT,
				@IdActExistencia	INT,
				@RegPrecio			INT,
				@IdActPrecio		INT,
				@RegStatus			INT,
				@IdActStatus		INT,
				@IdActColeccion		INT,
				@IdUsuario			INT,
				@IdAct				INT
				
		DECLARE  @ChangeResult	TABLE	(IdArticulo			INTEGER)
		DECLARE  @AExist		TABLE	(IdActualizacion	INTEGER)
		DECLARE  @APrecio		TABLE	(IdActualizacion	INTEGER)
		DECLARE  @AStatus		TABLE	(IdActualizacion	INTEGER)
		DECLARE  @AColeccion	TABLE	(IdActualizacion	INTEGER)
				
		-- CARGA DE PARÁMETROS DE SISTEMA PARA STATUS, TIPO DE ACT Y USUARIO PARA LOG
		SELECT @IdUsuario		= DBO.fn_ObtenerParametroEntero ('IDAUDITORÍA',GETDATE(),1)		

		SELECT @IdEstAprobado	= DBO.fn_ObtenerParametroEntero ('ACTAprobacion',GETDATE(),1)
		SELECT @IdEstProcesado	= DBO.fn_ObtenerParametroEntero ('ACTProcesado',GETDATE(),1)
		SELECT @IdEstError		= DBO.fn_ObtenerParametroEntero ('ACTErrProcesado',GETDATE(),1)

		SELECT @IdActExistencia = DBO.fn_ObtenerParametroEntero ('ACTEXISTENCIA',GETDATE(),1)
		SELECT @IdActPrecio		= DBO.fn_ObtenerParametroEntero ('ACTPRECIO',GETDATE(),1)
		SELECT @IdActStatus 	= DBO.fn_ObtenerParametroEntero ('ACTESTATUS',GETDATE(),1)
		SELECT @IdActColeccion 	= DBO.fn_ObtenerParametroEntero ('ACTCOLECCION',GETDATE(),1)

		--CREACIÓN DE TABLA TEMPORAL CON LOS DATOS DE LAS ACTUALIZACIONES DE EXISTENCIA
		INSERT INTO @AExist
		SELECT AE.IdActualizacion 
		FROM EPK_ActualizacionEncabezado AE
		WHERE IdEstatus			= @IdEstAprobado
		AND TipoActualizacion	= @IdActExistencia
		AND FechaInicio			<= GETDATE ()
		AND AE.CantidadDetalles = (SELECT COUNT (1) 
									FROM EPK_ActualizacionArticulo 
									WHERE IdActualizacion = AE.IdActualizacion )

		
		SELECT AA.*, AE.FechaInicio 
		INTO #ActExist
		FROM EPK_ActualizacionEncabezado AE
		INNER JOIN EPK_ActualizacionArticulo AA
			ON AE.IdActualizacion = AA.IdActualizacion 
		WHERE  AE.IdActualizacion IN (SELECT IdActualizacion FROM @AExist)


		--CONTEO DE REGISTROS A ACTUALIZAR EXISTENCIA
		SELECT @RegExist =  COUNT (1)	
		FROM  #ActExist AA
		INNER JOIN (SELECT IdArticulo, MAX(IDACTUALIZACION) ID FROM #ActExist  GROUP BY IdArticulo)T
				ON AA.IdArticulo = T.IdArticulo	AND AA.IdActualizacion = T.ID

		IF @RegExist >0
			BEGIN	
				IF @RegExist	=	(SELECT COUNT (1)	FROM  #ActExist AA 
														INNER JOIN EPK_Articulo AR ON AA.IdArticulo = AR.IdArticulo
														INNER JOIN (SELECT IdArticulo, MAX(IDACTUALIZACION) ID FROM #ActExist  GROUP BY IdArticulo)T
															ON AA.IdArticulo = T.IdArticulo	AND AA.IdActualizacion = T.ID)
					BEGIN
					DECLARE cAct CURSOR FOR
					SELECT DISTINCT IdActualizacion FROM @AExist 
					
					OPEN cAct
					FETCH NEXT FROM cAct
					INTO @IDAct

					WHILE @@FETCH_STATUS = 0
						BEGIN
							DELETE  @ChangeResult
							BEGIN TRAN
							SELECT @RegExist =  COUNT (1)	FROM  #ActExist WHERE IdActualizacion= @IDAct
							MERGE EPK_Articulo AS target
							USING (	SELECT  AA.IdArticulo, Existencia, ExistenciaAlmacen, FechaInicio 
									FROM #ActExist AA
									INNER JOIN (SELECT IdArticulo, MAX(IDACTUALIZACION) ID FROM #ActExist  GROUP BY IdArticulo)T
										ON AA.IdArticulo = T.IdArticulo	AND AA.IdActualizacion = T.ID
									WHERE IdActualizacion= @IDAct) source
									(IdArticulo, Existencia, ExistenciaAlmacen, FechaInicio)
							ON	(target.IdArticulo	= source.IdArticulo)
							WHEN MATCHED
								THEN	UPDATE SET  Existencia = source.Existencia,
													ExistenciaAlmacen = source.ExistenciaAlmacen
							OUTPUT inserted.IdArticulo  INTO @ChangeResult;
							
							select(SELECT COUNT(1) FROM @ChangeResult), @RegExist
							
							IF (SELECT COUNT(1) FROM @ChangeResult)= @RegExist 
								BEGIN 
								--ACTUALIZAR ESTATUS DEL ENCABEZADO 
								UPDATE EPK_ActualizacionEncabezado
								SET IdEstatus = @IdEstProcesado,
									FechaProcesamiento = getdate() 
								WHERE IdActualizacion = @IDAct 
								
								INSERT INTO EPK_LogActualizacion (IdActualizacion, IdEstatus, FechaEstatus, IdUsuario)
								VALUES (@IDAct,   @IdEstProcesado,	GETDATE(),	@IdUsuario)
								
										
								COMMIT TRAN
								END
							ELSE
								BEGIN
								PRINT 'Existencias: NO SE PUDIERON ACTUALIZAR TODOS LOS ARTÍCULOS.	Actualizacion: '+ cast (@idact as varchar)
								IF @@TRANCOUNT >0  ROLLBACK TRAN 
								INSERT INTO EPK_LogActualizacion (IdActualizacion, IdEstatus, FechaEstatus, IdUsuario, Observacion )
									VALUES ( @IDAct,   @IdEstError,	GETDATE(),	@IdUsuario,	'NO SE PUDIERON ACTUALIZAR TODOS LOS ARTÍCULOS')
									/*SELECT	DISTINCT  @IDAct,   
											@IdEstError,
											GETDATE(),
											@IdUsuario,
											'NO SE PUDIERON ACTUALIZAR TODOS LOS ARTÍCULOS'
										FROM #ActExist*/
								DROP TABLE #ActExist
								END
							
							FETCH NEXT FROM cAct
							INTO @IDAct	
						END
					CLOSE cAct
					DEALLOCATE cAct
					END
				ELSE
					BEGIN 
					PRINT 'FALTAN ARTÍCULOS'
					IF @@TRANCOUNT >0 ROLLBACK TRAN 
					INSERT INTO EPK_LogActualizacion (IdActualizacion, IdEstatus, FechaEstatus, IdUsuario, Observacion )
					SELECT	DISTINCT IdActualizacion,   
								@IdEstError,
								GETDATE(),
								@IdUsuario,
								'FALTAN ARTÍCULOS'
							FROM #ActExist
					DROP TABLE #ActExist
					END
			END
		DROP TABLE #ActExist




		--CREACIÓN DE TABLA TEMPORAL CON LOS DATOS DE LAS ACTUALIZACIONES DE PRECIOS
		INSERT INTO @APrecio 
		SELECT AE.IdActualizacion 
		FROM EPK_ActualizacionEncabezado AE
		WHERE IdEstatus			= @IdEstAprobado
		AND TipoActualizacion	= @IdActPrecio
		AND FechaInicio			<= GETDATE ()
		AND AE.CantidadDetalles = (SELECT COUNT (1) 
									FROM EPK_ActualizacionArticulo 
									WHERE IdActualizacion = AE.IdActualizacion)
									
		SELECT AA.*, AE.FechaInicio 
		INTO #ActPrecio
		FROM EPK_ActualizacionEncabezado AE
		INNER JOIN EPK_ActualizacionArticulo AA
			ON AE.IdActualizacion = AA.IdActualizacion 
		WHERE  AE.IdActualizacion IN (SELECT IdActualizacion FROM @APrecio)
		
		----CONTEO DE REGISTROS A ACTUALIZAR PRECIOS
		--SELECT @RegPrecio =  COUNT (1)
		--FROM  #ActPrecio

		--CONTEO DE REGISTROS A ACTUALIZAR PRECIOS
		SELECT @RegPrecio =  COUNT (1)	FROM  #ActPrecio AA
		INNER JOIN (SELECT IdArticulo, MAX(IDACTUALIZACION) ID FROM #ActPrecio   GROUP BY IdArticulo)T
			ON AA.IdArticulo = T.IdArticulo	AND AA.IdActualizacion = T.ID

		IF @RegPrecio >0
			BEGIN	
				IF @RegPrecio	=	(SELECT COUNT (1)	
									 FROM  #ActPrecio AA 
									 INNER JOIN EPK_Articulo AR ON AA.IdArticulo = AR.IdArticulo
									 INNER JOIN (SELECT IdArticulo, MAX(IDACTUALIZACION) ID FROM #ActPrecio  GROUP BY IdArticulo)T
															ON AA.IdArticulo = T.IdArticulo	AND AA.IdActualizacion = T.ID)
					BEGIN
					DECLARE cAct CURSOR FOR
					SELECT DISTINCT IdActualizacion FROM @APrecio 
					
					OPEN cAct
					FETCH NEXT FROM cAct
					INTO @IDAct

					WHILE @@FETCH_STATUS = 0
						BEGIN
							DELETE  @ChangeResult
							BEGIN TRAN
							SELECT @RegPrecio =  COUNT (1)	FROM  #ActPrecio WHERE IdActualizacion= @IDAct
											
							MERGE EPK_Articulo AS target
							USING (	SELECT  AA.IdArticulo, PrecioExento, PrecioGravable
									FROM #ActPrecio AA
									INNER JOIN (SELECT IdArticulo, MAX(IDACTUALIZACION) ID FROM #ActPrecio  GROUP BY IdArticulo)T
															ON AA.IdArticulo = T.IdArticulo	AND AA.IdActualizacion = T.ID
									WHERE IdActualizacion =@IdAct) AS source 
									(IdArticulo, PrecioExento, PrecioGravable)
							ON	(target.IdArticulo	= source.IdArticulo)
							WHEN MATCHED
								THEN	UPDATE SET  PrecioExento		= source.PrecioExento, 
													PrecioExentoInicial	= CASE WHEN PrecioExentoInicial IS NULL THEN source.PrecioExento ELSE PrecioExentoInicial END , 
													PrecioGravable		= source.PrecioGravable,
													PrecioGravableInicial	= CASE WHEN PrecioGravableInicial IS NULL THEN source.PrecioGravable ELSE PrecioGravableInicial END
							OUTPUT inserted.IdArticulo  INTO @ChangeResult;
							
							IF (SELECT COUNT(1) FROM @ChangeResult) = @RegPrecio  
								BEGIN 
								--ACTUALIZAR ESTATUS DEL ENCABEZADO 
								UPDATE EPK_ActualizacionEncabezado
								SET IdEstatus = @IdEstProcesado,
									FechaProcesamiento = GETDATE()
								WHERE IdActualizacion = @IDAct
								INSERT INTO EPK_LogActualizacion (IdActualizacion, IdEstatus, FechaEstatus, IdUsuario)
											VALUES (@IDAct,   @IdEstProcesado,	GETDATE(),	@IdUsuario)
								COMMIT TRAN
								END
							ELSE
								BEGIN
								PRINT 'Precios: NO SE PUDIERON ACTUALIZAR TODOS LOS ARTÍCULOS'
								IF @@TRANCOUNT >0  ROLLBACK TRAN 
								INSERT INTO EPK_LogActualizacion (IdActualizacion, IdEstatus, FechaEstatus, IdUsuario, Observacion )
											VALUES (@IDAct,   @IdEstError,	GETDATE(),	@IdUsuario,	'Actualizacion. '+ cast (@IdAct as varchar) +' NO SE PUDIERON ACTUALIZAR TODOS LOS ARTÍCULOS')
								END
							
							FETCH NEXT FROM cAct
							INTO @IDAct	
						END
					CLOSE cAct
					DEALLOCATE cAct
					END
				ELSE
					BEGIN 
					PRINT 'FALTAN ARTÍCULOS'
					IF @@TRANCOUNT >0 ROLLBACK TRAN 
					INSERT INTO EPK_LogActualizacion (IdActualizacion, IdEstatus, FechaEstatus, IdUsuario, Observacion )
								VALUES (@IdAct,   @IdEstError,	GETDATE(),	@IdUsuario,	'Actualizacion. '+ cast (@IdAct as varchar) +' FALTAN ARTÍCULOS')
					END
			END
		DROP TABLE #ActPrecio
		
		INSERT INTO @AStatus 
		SELECT AE.IdActualizacion 
		FROM EPK_ActualizacionEncabezado AE
		WHERE IdEstatus			= @IdEstAprobado
		AND TipoActualizacion	= @IdActStatus
		AND FechaInicio			<= GETDATE ()
		AND AE.CantidadDetalles = (SELECT COUNT (1) 
									FROM EPK_ActualizacionArticulo 
									WHERE IdActualizacion = AE.IdActualizacion)
		
		SELECT AA.*, AE.FechaInicio 
		INTO #ActStatus
		FROM EPK_ActualizacionEncabezado AE
		INNER JOIN EPK_ActualizacionArticulo AA
			ON AE.IdActualizacion = AA.IdActualizacion 
		WHERE IdEstatus		= @IdEstAprobado
		AND TipoActualizacion	= @IdActStatus 
		AND FechaInicio		<= GETDATE ()

		--CONTEO DE REGISTROS A ACTUALIZAR STATUS
		SELECT @RegStatus =  COUNT (1)
		FROM  #ActStatus AA
		INNER JOIN (SELECT IdArticulo, MAX(IDACTUALIZACION) ID FROM #ActStatus GROUP BY IdArticulo)T
				ON AA.IdArticulo = T.IdArticulo
				AND AA.IdActualizacion = T.ID
		
		SELECT  A.IdArticulo, Activo, a.FechaInicio 
		FROM #ActStatus A
		inner join (SELECT IdArticulo, MAX(IDACTUALIZACION) ID FROM #ActStatus GROUP BY IdArticulo)T
			ON A.IdArticulo = T.IdArticulo
			AND A.IdActualizacion = T.ID 	
		
		SELECT @RegStatus	
		
		SELECT COUNT (1)
		FROM #ActStatus AA
		INNER JOIN EPK_Articulo AR
			ON AA.IdArticulo = AR.IdArticulo 
		INNER JOIN (SELECT IdArticulo, MAX(IDACTUALIZACION) ID FROM #ActStatus GROUP BY IdArticulo)T
				ON AA.IdArticulo = T.IdArticulo
				AND AA.IdActualizacion = T.ID

		IF @RegStatus >0 
			BEGIN	
				IF @RegStatus	=
					(SELECT COUNT (1)
					FROM #ActStatus AA
					INNER JOIN EPK_Articulo AR
						ON AA.IdArticulo = AR.IdArticulo 
					INNER JOIN (SELECT IdArticulo, MAX(IDACTUALIZACION) ID FROM #ActStatus GROUP BY IdArticulo)T
							ON AA.IdArticulo = T.IdArticulo
							AND AA.IdActualizacion = T.ID 	) 
					
						BEGIN
						DELETE  @ChangeResult
						BEGIN TRAN
						
						SELECT  A.IdArticulo, Activo, a.FechaInicio 
						FROM #ActStatus A
						inner join (SELECT IdArticulo, MAX(IDACTUALIZACION) ID FROM #ActStatus GROUP BY IdArticulo)T
							ON A.IdArticulo = T.IdArticulo
							AND A.IdActualizacion = T.ID 
				
						MERGE EPK_Articulo AS target
						USING (	SELECT  A.IdArticulo, Activo, a.FechaInicio 
								FROM #ActStatus A
								INNER JOIN (SELECT IdArticulo, MAX(IDACTUALIZACION) ID 
											FROM #ActStatus GROUP BY IdArticulo)T
									ON A.IdArticulo = T.IdArticulo
									AND A.IdActualizacion = T.ID ) AS source 
								(IdArticulo, Activo, FechaInicio)
						ON	(target.IdArticulo	= source.IdArticulo)
						WHEN MATCHED
							THEN	UPDATE SET  Activo	= source.Activo
						OUTPUT inserted.IdArticulo  INTO @ChangeResult;
						
						--SELECT * FROM @ChangeResult
						IF (SELECT COUNT(1) FROM @ChangeResult)= @RegStatus  
							BEGIN 
							--ACTUALIZAR ESTATUS DEL ENCABEZADO 
							UPDATE EPK_ActualizacionEncabezado
							SET IdEstatus = @IdEstProcesado
							WHERE IdActualizacion IN (	SELECT DISTINCT IdActualizacion  
														FROM #ActStatus)
														
							INSERT INTO EPK_LogActualizacion (IdActualizacion, IdEstatus, FechaEstatus, IdUsuario)
							SELECT		DISTINCT IdActualizacion,   
										@IdEstProcesado,
										GETDATE(),
										@IdUsuario
									FROM #ActStatus 
							COMMIT TRAN
							END
						ELSE
							BEGIN
							PRINT 'Status: NO SE PUDIERON ACTUALIZAR TODOS LOS ARTÍCULOS'
							IF @@TRANCOUNT >0  ROLLBACK TRAN 
							INSERT INTO EPK_LogActualizacion (IdActualizacion, IdEstatus, FechaEstatus, IdUsuario, Observacion )
							SELECT		DISTINCT IdActualizacion,   
										@IdEstError,
										GETDATE(),
										@IdUsuario,
										'NO SE PUDIERON ACTUALIZAR TODOS LOS ARTÍCULOS'
									FROM #ActStatus 
							END
						END
				ELSE
					BEGIN 
					PRINT 'FALTAN ARTÍCULOS'
					IF @@TRANCOUNT >0  ROLLBACK TRAN 
							INSERT INTO EPK_LogActualizacion (IdActualizacion, IdEstatus, FechaEstatus, IdUsuario, Observacion )
							SELECT		DISTINCT IdActualizacion,   
										@IdEstError,
										GETDATE(),
										@IdUsuario,
										'FALTAN ARTÍCULOS'
									FROM #ActStatus 
					END
			END
		DROP TABLE #ActStatus
		
		
		--ACTUALIZACIÓN DE COLECCIONES
		INSERT INTO @AColeccion 
		SELECT AE.IdActualizacion 
		FROM EPK_ActualizacionEncabezado AE
		WHERE IdEstatus			= @IdEstAprobado
		AND TipoActualizacion	= @IdActColeccion 
		AND FechaInicio			<= GETDATE ()
		
		DECLARE @IdActu INT		
		DECLARE  CUR CURSOR 
		FOR	
			SELECT * FROM @AColeccion
			
		BEGIN TRAN
		
		OPEN CUR
		FETCH NEXT FROM CUR INTO @IdActu	
		
		WHILE @@FETCH_STATUS = 0
		BEGIN 		
		
			SELECT A.IdArticulo, AC.Activa, AE.FechaInicio, AE.IdActualizacion 
			INTO #ActColec
			FROM EPK_ActualizacionEncabezado AE
			INNER JOIN EPK_ActualizacionColeccion AC
				ON AE.IdActualizacion = AC.IdActualizacion
				AND AE.IdActualizacion = @IdActu
			INNER JOIN EPK_Referencia R
				ON AC.IdColeccion = R.IdColeccion 
			INNER JOIN EPK_Articulo A
				ON A.IdReferencia = R.IdReferencia 
				
			DELETE  @ChangeResult		
			
				MERGE EPK_Articulo AS target
				USING (	SELECT  IdArticulo, Activa, FechaInicio 
						FROM  #ActColec ) AS source 
						(IdArticulo, Activo, FechaInicio)
				ON	(target.IdArticulo	= source.IdArticulo)
				WHEN MATCHED
					THEN	UPDATE SET  Activo	= source.Activo
				OUTPUT inserted.IdArticulo  INTO @ChangeResult;
				
				--SELECT * FROM @ChangeResult
				
				--ACTUALIZAR ESTATUS DEL ENCABEZADO 
				UPDATE EPK_ActualizacionEncabezado
				SET IdEstatus = @IdEstProcesado
				WHERE IdActualizacion IN (	SELECT DISTINCT IdActualizacion  
											FROM #ActColec)
											
				INSERT INTO EPK_LogActualizacion (IdActualizacion, IdEstatus, FechaEstatus, IdUsuario)
				SELECT		DISTINCT IdActualizacion,   
							@IdEstProcesado,
							GETDATE(),
							@IdUsuario
				FROM #ActColec 				
				
			DROP TABLE #ActColec				
			FETCH NEXT FROM CUR INTO @IdActu
		END 
		
		CLOSE CUR
		DEALLOCATE CUR 
		
		COMMIT TRAN
	
	END TRY 
	BEGIN CATCH
		WHILE  @@TRANCOUNT >0 
			BEGIN
			ROLLBACK TRAN
			END
		EXEC EPK_sp_LogErroresGenerar @@SPID
		SELECT 'Linea de error: '+ CAST(ERROR_LINE() as varchar(4)) +' - Nro error: '+ CAST (ERROR_NUMBER () as varchar(30))+' - Mensaje de error: '+ ERROR_MESSAGE () 
		RETURN 0
	END CATCH
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ActualizacionArticuloEjecutar] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ActualizacionArticuloEjecutar] TO PUBLIC
    AS [dbo];

