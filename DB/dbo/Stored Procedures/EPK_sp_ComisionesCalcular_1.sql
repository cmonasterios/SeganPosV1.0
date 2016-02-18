-- =============================================================================
-- Author:		Sderkoyorikian
-- Create date: 10/12/2013
-- Description:	Permite asignar  los vendedores de acuerdo a sus registros 
--				en el biométrico, y calcular las comisiones de todos los 
--				empleados que las perciban.
-- =============================================================================
CREATE PROCEDURE [dbo].[EPK_sp_ComisionesCalcular]
	@FechaFiltro	DATE
AS
BEGIN
	BEGIN TRY 
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;
		
		DECLARE @IdEmpleado	BIGINT
		DECLARE @FECHA		DATE
		DECLARE @Entrada	TIME
		DECLARE @Salida		TIME
		DECLARE @Hora		TIME
		DECLARE @Idfactura	INT
		--DECLARE @FechaFiltro	DATE	='20131117'
		DECLARE @CantEmpleados	TINYINT =0
		DECLARE @Cont			TINYINT =0
		DECLARE @Cargo		    INT
		DECLARE @CargoAsistVta  INT
		DECLARE @Temporada	    INT
		DECLARE @EmpleadoNoAtendidos	    INT
		DECLARE @CargoComision	VARCHAR(5) =''
		
		SELECT @CargoAsistVta   = DBO.fn_ObtenerParametroEntero ('IdCargoAsistVen', GETDATE(),1)
		SELECT @Cargo       = DBO.fn_ObtenerParametroEntero ('IdCargoVendedor', GETDATE(),1)
		SELECT @Temporada   = DBO.fn_ObtenerParametroEntero ('TemporadaComision', GETDATE(),1)
		SELECT @EmpleadoNoAtendidos = DBO.fn_ObtenerParametroEntero ('EmpleadoComision', GETDATE(),1)		
		
		SELECT @CargoComision = CargoComision
		FROM  EPK_Cargo 
		WHERE IdCargo = dbo.fn_ObtenerParametroEntero ('IdCargoCajero', GETDATE(),1)
		
		
		--/*Guarda un respaldo de las ventas personalizadas */
		INSERT INTO EPK_FacturaEncabezadocalBackup 
			(IdFactura,		TicketFiscal,	IdCaja,			COO,		SerialMF,			IdEstatus,	
			 Fecha,			Hora,			PorcDescuento,	IdCliente,	MontoBase,			MontoDescuento,	
			 MontoIVA,		MontoTotal,		NroReporteZ,	IdVendedor,	FechaCreacion,		IdUsuarioCreacion,	
			 FechaModificacion,				IdUsuarioModificacion, IdTienda)
		SELECT	IdFactura,	TicketFiscal,	IdCaja,			COO,		SerialMF,			IdEstatus,	
				Fecha,		Hora,			PorcDescuento,	IdCliente,	MontoBase,			MontoDescuento,	
				MontoIVA,	MontoTotal,		NroReporteZ,	IdVendedor,	FechaCreacion,		IdUsuarioCreacion,	
				FechaModificacion,			IdUsuarioModificacion, IdTienda 
		FROM EPK_FacturaEncabezado
		WHERE Fecha		= @FechaFiltro 
		AND IdVendedor	IS NOT NULL
		AND IdFactura	NOT IN (SELECT IdFactura FROM EPK_FacturaEncabezadocalBackup)
		
		IF @Temporada = 1
            BEGIN 
	        /* Cursor para recorrer las ventas no personalizadas a fin de asignar rotativamente */
	        DECLARE Facturas  CURSOR FOR         
	        SELECT	IdFactura, Hora	
	        FROM	EPK_FacturaEncabezado
	        WHERE	Fecha=@FechaFiltro      AND		IdEstatus=9 
	        AND		MontoTotal>0            AND		IdVendedor IS NULL
	        AND		Fecha	= @FechaFiltro
	        ORDER BY Hora

	        OPEN Facturas    		
	        /* Cursor para ubicar el horario cubierto por los vendedores */
	        DECLARE Asistencia SCROLL CURSOR  FOR
	        SELECT IdEmpleado,FechaLectura, MIN(HoraLectura)Entrada, MAX(HoraLectura) Salida  
	        FROM EPK_Lecturas 
	        WHERE IdEmpleado IN (SELECT IdEmpleado 
	        					 FROM EPK_Empleados
	        					 WHERE IdCargo in (@Cargo, @CargoAsistVta )
	        					 AND IdRegion IN (	SELECT IdRegion         FROM EPK_Region R 
	        										INNER JOIN EPK_Tienda T ON R.IdTienda = T.IdTienda ))--=(5))
	        AND FechaLectura =@FechaFiltro
	        GROUP BY IdEmpleado,FechaLectura

	        OPEN  Asistencia    		                      
	        FETCH NEXT FROM Facturas 
	        INTO	@Idfactura, @Hora
	        WHILE @@FETCH_STATUS = 0 
	        BEGIN
	        	FETCH NEXT FROM Asistencia 
	        	INTO	@IdEmpleado,	@Fecha,		@Entrada,	@Salida
    	        
	        	SET @CantEmpleados = @@CURSOR_ROWS
    	        
	        	IF @@FETCH_STATUS <>0 
	        		FETCH FIRST FROM Asistencia 
	        		INTO	@IdEmpleado,	@Fecha,		@Entrada,	@Salida 
    	                      
	        	WHILE @Hora <@Entrada or @Hora>@Salida
	        		BEGIN
	        		FETCH NEXT FROM Asistencia 
	        		INTO	@IdEmpleado,	@Fecha,		@Entrada,	@Salida 
    				
	        		SET @Cont = @Cont +1    				
	        		IF @@FETCH_STATUS <>0 
	        			IF @Cont < (@CantEmpleados *2)
	        				FETCH FIRST FROM Asistencia 
	        				INTO	@IdEmpleado,	@Fecha,		@Entrada,	@Salida  
	        			ELSE
	        				BEGIN
	        				/* ASIGNAR EMPLEADO POTE */
	        				SET @Cont = 0 
	        				SET @IdEmpleado = @EmpleadoNoAtendidos
	        				BREAK
	        				END
	        		END 
    			
	        	UPDATE EPK_FacturaEncabezado
	        	SET		IdVendedor = @IdEmpleado
	        	WHERE	IdVendedor IS NULL  
	        		AND IdFactura = @Idfactura

	        	FETCH NEXT FROM Facturas 
	        	INTO	@Idfactura, @Hora
    			
	        END
    			
	        CLOSE Asistencia;
	        DEALLOCATE Asistencia;

	        CLOSE Facturas;
	        DEALLOCATE Facturas;
		    END
        
        UPDATE EPK_FacturaEncabezado SET IdVendedor = @EmpleadoNoAtendidos  WHERE IdVendedor is null
		
		/* Inserta registro de comisiones para empleados que generan comisiones sobre el total de la venta */
		INSERT INTO SIV_ComisionEmpleado
				(CodTienda		     ,IdEmpleado
			  ,FechaActualizacion	  ,IdCargoFacturado
			  ,IdCargo      		  ,MontoComision
			  ,MontoFacturado)
		SELECT	t.CodigoTienda, e.IdEmpleado, t2.Fecha, @CargoComision, c.CargoComision /*'002'*/, (t2.Montobase * c.PorcentajeComision) /100 comision, t2.Montobase
		FROM EPK_Cargo c
		INNER JOIN EPK_Empleados e
			ON c.IdCargo = e.IdCargo    		AND c.ComisionTotal = 1
		INNER JOIN EPK_Region r
			ON e .IdRegion = r.IdRegion 
		INNER JOIN EPK_EmpleadoLocalidad l
			ON E.IdEmpleado = L.IdEmpleado		AND R.IdRegion = L.IdRegion 
			AND L.FechaHoraInactivo IS NULL 
		INNER JOIN EPK_Tienda t
			ON r.IdTienda = t.IdTienda 
		CROSS JOIN 
			(SELECT  Fecha, SUM (MontoBase) Montobase
			FROM EPK_Facturaencabezado
			WHERE MontoBase		>0 			AND MontoDescuento	=0 
			AND IdEstatus	= dbo.fn_ObtenerParametroEntero ('FACProcesada', fecha,1)
			AND Fecha		= @FechaFiltro
			GROUP BY fecha) t2
		ORDER BY e.IdEmpleado,  t2.Fecha 

		/* Resta al monto el total de las notas de crédito para empleados que generan comisiones sobre el total de la venta */
		MERGE SIV_ComisionEmpleado AS target
		USING (SELECT	t.CodigoTienda, e.IdEmpleado, t2.Fecha, 
						@CargoComision IdCargoFacturado, c.CargoComision /*'002'*/ IdCargo, 
						(t2.Montobase * c.PorcentajeComision) /100 Comision, t2.Montobase
				FROM EPK_Cargo c
				INNER JOIN EPK_Empleados e
					ON c.IdCargo = e.IdCargo            AND c.ComisionTotal = 1
				INNER JOIN EPK_Region r
					ON e .IdRegion = r.IdRegion 
				INNER JOIN EPK_EmpleadoLocalidad l
					ON E.IdEmpleado = L.IdEmpleado      AND R.IdRegion = L.IdRegion 
					AND L.FechaHoraInactivo IS NULL 
				INNER JOIN EPK_Tienda t
					ON r.IdTienda = t.IdTienda 
				CROSS JOIN 
					(SELECT  Fecha, SUM (MontoBase) Montobase
					FROM EPK_NotaCreditoEncabezado 
					WHERE MontoBase		>0          AND MontoDescuento	=0 
					AND IdEstatus	= dbo.fn_ObtenerParametroEntero ('FACProcesada', fecha,1)
					AND Fecha		= @FechaFiltro
					GROUP BY fecha) t2) AS source 
				(CodTienda,				IdEmpleado,			FechaActualizacion, 
				IdCargoFacturado,		IdCargo, 
				MontoComision,			MontoFacturado)
		ON (TARGET.IdEmpleado				= SOURCE.IdEmpleado 
			AND TARGET.IdCargoFacturado		= SOURCE.IdCargoFacturado 
			AND TARGET.IdCargo				= SOURCE.IdCargo 
			AND TARGET.FechaActualizacion	= SOURCE.FechaActualizacion
			AND TARGET.CodTienda			= SOURCE.CodTienda)
		WHEN MATCHED 
			THEN	UPDATE SET	MontoFacturado	= target.MontoFacturado	- source.MontoFacturado,
								MontoComision	= target.MontoComision		- source.MontoComision 
		WHEN  NOT MATCHED 
			THEN	INSERT (CodTienda						  ,IdEmpleado
						  ,FechaActualizacion   			  ,IdCargoFacturado
						  ,IdCargo					          ,MontoComision
						  ,MontoFacturado)
					VALUES (source.CodTienda				  ,source.IdEmpleado
						  ,source.FechaActualizacion		  ,source.IdCargoFacturado
						  ,source.IdCargo					  ,-source.MontoComision
						  ,-source.MontoFacturado);
		
		
		/* Inserta registro de comisiones para cajeros */
		INSERT INTO SIV_ComisionEmpleado
				(CodTienda		   	  ,IdEmpleado
			  ,FechaActualizacion	  ,IdCargoFacturado
			  ,IdCargo          	  ,MontoComision
			  ,MontoFacturado)
		SELECT	ti.CodigoTienda, e.IdEmpleado, t.Fecha, c.CargoComision, c.CargoComision /*'001'*/, (t.Montobase * C.PorcentajeComision) /100 Comision,  t.Montobase 
		FROM (SELECT  Fecha, IdUsuarioCreacion IdCajero,  SUM (MontoBase) Montobase
			FROM EPK_Facturaencabezado
			WHERE MontoBase		>0 			AND MontoDescuento	=0 
			AND IdEstatus	= dbo.fn_ObtenerParametroEntero ('FACProcesada', fecha,1)
			AND Fecha		= @FechaFiltro
			GROUP BY Fecha,IdUsuarioCreacion) t
		INNER JOIN EPK_Empleados e
			ON t.IdCajero = e.IdUsuario 
		INNER JOIN EPK_Cargo c
			ON e.IdCargo = c.IdCargo
		INNER JOIN EPK_Region r
			ON e .IdRegion = r.IdRegion 
		INNER JOIN EPK_Tienda ti
			ON r.IdTienda = ti.IdTienda 
		--CROSS JOIN (SELECT porcentajecomision, CargoComision
		--			FROM  EPK_Cargo 
		--			WHERE IdCargo = dbo.fn_ObtenerParametroEntero ('IdCargoCajero', GETDATE(),1)) t2
		ORDER BY e.IdEmpleado,  t.Fecha 
		
		/* Resta al monto el total de las notas de crédito de comisiones para cajeros */
		MERGE SIV_ComisionEmpleado AS target
		USING (SELECT	ti.CodigoTienda,			e.IdEmpleado,			t.Fecha, 
						@CargoComision IdCargoFacturado,		c.CargoComision /*'001'*/ IdCargo, 
						(t.Montobase * C.PorcentajeComision) /100 Comision, t.Montobase 
				FROM (SELECT  NC.Fecha, FE.IdUsuarioCreacion IdCajero,  SUM (NC.MontoBase) Montobase
					FROM EPK_NotaCreditoEncabezado NC
					INNER JOIN EPK_FacturaEncabezado FE
						ON NC.IdFactura = FE.IdFactura 
					WHERE NC.MontoBase		>0 					AND NC.MontoDescuento	=0 
					AND NC.IdEstatus	= dbo.fn_ObtenerParametroEntero ('FACProcesada', NC.Fecha,1)
					AND NC.Fecha		= @FechaFiltro
					GROUP BY NC.Fecha,FE.IdUsuarioCreacion) t
				INNER JOIN EPK_Empleados e
					ON t.IdCajero = e.IdUsuario 
				INNER JOIN EPK_Cargo c
					on e.IdCargo = c.IdCargo
				INNER JOIN EPK_Region r
					ON e .IdRegion = r.IdRegion 
				INNER JOIN EPK_Tienda ti
					ON r.IdTienda = ti.IdTienda 
				--CROSS JOIN (SELECT porcentajecomision, CargoComision
				--			FROM  EPK_Cargo 
				--			WHERE IdCargo = dbo.fn_ObtenerParametroEntero ('IdCargoCajero', GETDATE(),1)) t2
				) AS source 
				(CodTienda,				IdEmpleado,			FechaActualizacion, 
				IdCargoFacturado,		IdCargo, 
				MontoComision,			MontoFacturado)
		ON (TARGET.IdEmpleado				= SOURCE.IdEmpleado 
			AND TARGET.IdCargoFacturado		= SOURCE.IdCargoFacturado 
			AND TARGET.IdCargo				= SOURCE.IdCargo 
			AND TARGET.FechaActualizacion	= SOURCE.FechaActualizacion
			AND TARGET.CodTienda			= SOURCE.CodTienda)
		WHEN MATCHED 
			THEN	UPDATE SET	MontoFacturado	= target.MontoFacturado		- source.MontoFacturado,
								MontoComision	= target.MontoComision		- source.MontoComision 
		WHEN  NOT MATCHED 
			THEN	INSERT (CodTienda						  ,IdEmpleado
						  ,FechaActualizacion				  ,IdCargoFacturado
						  ,IdCargo  						  ,MontoComision
						  ,MontoFacturado)
					VALUES (source.CodTienda				  ,source.IdEmpleado
						  ,source.FechaActualizacion		  ,source.IdCargoFacturado
						  ,source.IdCargo   				  ,-source.MontoComision
						  ,-source.MontoFacturado);
						  
		

		/* Inserta registro de comisiones para vendedores */
		INSERT INTO SIV_ComisionEmpleado
				(CodTienda			  ,IdEmpleado
			  ,FechaActualizacion	  ,IdCargoFacturado
			  ,IdCargo  			  ,MontoComision
			  ,MontoFacturado)
		SELECT	ti.CodigoTienda, e.IdEmpleado, t.Fecha, @CargoComision, c.CargoComision /*'001'*/ IdCargo, 
						(t.Montobase * C.PorcentajeComision) /100 Comision, t.Montobase 
		FROM (SELECT  Fecha, IdVendedor,  SUM (MontoBase) Montobase
			FROM EPK_Facturaencabezado
			WHERE MontoBase >0 			AND MontoDescuento =0 
			AND IdEstatus = dbo.fn_ObtenerParametroEntero ('FACProcesada', Fecha,1)
			AND Fecha		= @FechaFiltro
			GROUP BY Fecha,IdVendedor) t
		INNER JOIN EPK_Empleados e
			ON t.IdVendedor = e.IdEmpleado 
		INNER JOIN EPK_Cargo c
			ON E.IdCargo = c.IdCargo 
		INNER JOIN EPK_EmpleadoLocalidad EL
					ON E.IdEmpleado = EL.IdEmpleado         AND EL.FechaHoraEliminacion IS NULL  
				INNER JOIN EPK_Region r
					ON eL.IdRegion = r.IdRegion 
		INNER JOIN EPK_Tienda ti
			ON r.IdTienda = ti.IdTienda 
		--CROSS JOIN (SELECT porcentajecomision, CargoComision
		--			FROM  EPK_Cargo 
		--			WHERE IdCargo = dbo.fn_ObtenerParametroEntero ('IdCargoVendedor', GETDATE(),1)) t2
		ORDER BY e.IdEmpleado,  t.Fecha 


		/* Resta al monto el total de las notas de crédito de comisiones para vendedores */
		MERGE SIV_ComisionEmpleado AS target
		USING (SELECT	ti.CodigoTienda, e.IdEmpleado, t.Fecha, @CargoComision IdCargoFacturado, c.CargoComision /*'001'*/ IdCargo, 
						(t.Montobase * C.PorcentajeComision) /100 Comision,  t.Montobase 
				FROM (SELECT  NC.Fecha, FE.IdVendedor ,  SUM (NC.MontoBase) Montobase
					FROM EPK_NotaCreditoEncabezado NC
					INNER JOIN EPK_FacturaEncabezado FE
						ON NC.IdFactura = FE.IdFactura 
					WHERE NC.MontoBase		>0 					AND NC.MontoDescuento	=0 
					AND NC.IdEstatus	= dbo.fn_ObtenerParametroEntero ('FACProcesada', NC.Fecha,1)
					AND NC.Fecha		= @FechaFiltro
					GROUP BY NC.Fecha,FE.IdVendedor) t
				INNER JOIN EPK_Empleados e
					ON t.IdVendedor = e.IdEmpleado
				INNER JOIN EPK_Cargo c
			        ON E.IdCargo = c.IdCargo  
				INNER JOIN EPK_EmpleadoLocalidad EL
					ON E.IdEmpleado = EL.IdEmpleado         AND EL.FechaHoraEliminacion IS NULL  
				INNER JOIN EPK_Region r
					ON eL.IdRegion = r.IdRegion 
				INNER JOIN EPK_Tienda ti
					ON r.IdTienda = ti.IdTienda 
				--CROSS JOIN (SELECT porcentajecomision, CargoComision
				--			FROM  EPK_Cargo 
				--			WHERE IdCargo = dbo.fn_ObtenerParametroEntero ('IdCargoVendedor', GETDATE(),1)) t2
				) AS source 
				(CodTienda,				IdEmpleado,			FechaActualizacion, 
				IdCargoFacturado,		IdCargo, 
				MontoComision,			MontoFacturado)
		ON (TARGET.IdEmpleado				= SOURCE.IdEmpleado 
			AND TARGET.IdCargoFacturado		= SOURCE.IdCargoFacturado 
			AND TARGET.IdCargo				= SOURCE.IdCargo 
			AND TARGET.FechaActualizacion	= SOURCE.FechaActualizacion
			AND TARGET.CodTienda			= SOURCE.CodTienda)
		WHEN MATCHED 
			THEN	UPDATE SET	MontoFacturado	= target.MontoFacturado		- source.MontoFacturado ,
								MontoComision	= target.MontoComision		- source.MontoComision 
		WHEN  NOT MATCHED 
			THEN	INSERT (CodTienda					  ,IdEmpleado
						  ,FechaActualizacion			  ,IdCargoFacturado
						  ,IdCargo  					  ,MontoComision
						  ,MontoFacturado)
					VALUES (source.CodTienda			  ,source.IdEmpleado
						  ,source.FechaActualizacion	  ,source.IdCargoFacturado
						  ,source.IdCargo				  ,-source.MontoComision 
						  ,-source.MontoFacturado);
	END TRY 
	BEGIN CATCH
		EXEC EPK_sp_LogErroresGenerar @@SPID
		SELECT 'Linea de error: '+ CAST(ERROR_LINE() as varchar(4)) +' - Nro error: '+ CAST (ERROR_NUMBER () as varchar(30))+' - Mensaje de error: '+ ERROR_MESSAGE () 
		RETURN 0
	END CATCH
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ComisionesCalcular] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ComisionesCalcular] TO PUBLIC
    AS [dbo];

