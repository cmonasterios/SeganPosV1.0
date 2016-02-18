
-- ===================================================================
-- Author:		Sderkoyorikian
-- Create date: 02/07/2013
-- Description:	Permite generar el cálculo de las inasistencias.
-- ===================================================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteInasistenciasCalcular]
	@FechaInicial	DATE,
	@FechaFinal		DATE,
	@IdRegion		INT		= NULL,
	@IdEmpleado		BIGINT	= NULL,
	@Nombre		VARCHAR(20)	= NULL,
	@Apellido	VARCHAR(20)	= NULL,
	@IdDepartamento	VARCHAR(25)	= NULL,
	@IdCargo	VARCHAR(25)	= NULL,
	@tblTurnos	dbo.tmp_DescansoTurno READONLY 
AS
BEGIN
	BEGIN TRY 
		-- SET NOCOUNT ON added to prevent extra result sets FROM
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		IF @FechaFinal > GETDATE () 
			BEGIN
				SELECT 'La fecha final no puede superar la fecha actual.'
				RETURN 0
			END 

		SET DATEFIRST 1;
 					
		CREATE TABLE #temp 
		(
		Fecha		DATE, 
		)

		DECLARE @FechaC DATE 
		SET @FechaC = @FechaInicial 
		WHILE @FechaC <= @FechaFinal 
			BEGIN 
			 INSERT INTO #temp (Fecha) VALUES (@FechaC )
			 SET @FechaC =  DATEADD (DAY,1,@FechaC )
			END 



		SELECT	L.IdEmpleado, FechaLectura, E.IdRegion, 
				MIN(HoraLectura) AS HE, 
				MAX(HoraLectura) AS HS,
				DATEPART (DW, L.FechaLectura) AS Dia,
				CASE DATEPART (DW, L.FechaLectura)   
					WHEN 1 THEN Z.LunesHoraE 
					WHEN 2 THEN Z.MartesHoraE 
					WHEN 3 THEN Z.MiercolesHoraE 
					WHEN 4 THEN Z.JuevesHoraE 
					WHEN 5 THEN Z.ViernesHoraE 
					WHEN 6 THEN Z.SabadoHoraE  
					WHEN 7 THEN Z.DomingoHoraE
					END AS HORAE,
				CASE DATEPART (DW, L.FechaLectura)   
					WHEN 1 THEN Z.LunesHoraS 
					WHEN 2 THEN Z.MartesHoraS 
					WHEN 3 THEN Z.MiercolesHoraS 
					WHEN 4 THEN Z.JuevesHoraS  
					WHEN 5 THEN Z.ViernesHoraS
					WHEN 6 THEN Z.SabadoHoraS  
					WHEN 7 THEN Z.DomingoHoraS 
					END AS HoraS
			INTO #Temp2	
			FROM EPK_Lecturas L
			INNER JOIN EPK_Zonas Z
				ON	L.IdZonaActual	= Z.IdZona 
				AND L.IdRegion		= Z.IdRegion
				AND L.TipoEntrada NOT IN (6,7)
			INNER JOIN EPK_Empleados E
				ON L.IdEmpleado = E.IdEmpleado
			WHERE		(@IdRegion	IS NULL		OR E.IdRegion	= @IdRegion )
				AND		(@IdEmpleado IS NULL 	OR E.IdEmpleado = @IdEmpleado)
				AND		(@Nombre	IS NULL		OR E.Nombre		LIKE @Nombre)
				AND		(@Apellido	IS NULL		OR E.Apellido LIKE @Apellido)
				AND		(@IdCargo	IS NULL		OR E.IdCargo = @IdCargo)
				AND		(@IdDepartamento IS NULL OR E.IdDepartamento = @IdDepartamento)
				AND		((SELECT COUNT (1) FROM @tblTurnos) =0 OR E.IdZonaActual IN (SELECT IdTurno FROM @tblTurnos))
				AND		(@FechaInicial IS NULL	OR L.FechaLectura >= @FechaInicial)
				AND		(@FechaFinal   IS NULL	OR L.FechaLectura <= @FechaFinal)
			GROUP BY L.IdEmpleado, L.FechaLectura, E.IdRegion , CASE DATEPART (DW, L.FechaLectura)   
						WHEN 1 THEN Z.LunesHoraE 
						WHEN 2 THEN Z.MartesHoraE 
						WHEN 3 THEN Z.MiercolesHoraE 
						WHEN 4 THEN Z.JuevesHoraE 
						WHEN 5 THEN Z.ViernesHoraE 
						WHEN 6 THEN Z.SabadoHoraE  
						WHEN 7 THEN Z.DomingoHoraE
						END ,
					CASE DATEPART (DW, L.FechaLectura)   
						WHEN 1 THEN Z.LunesHoraS 
						WHEN 2 THEN Z.MartesHoraS 
						WHEN 3 THEN Z.MiercolesHoraS 
						WHEN 4 THEN Z.JuevesHoraS  
						WHEN 5 THEN Z.ViernesHoraS
						WHEN 6 THEN Z.SabadoHoraS  
						WHEN 7 THEN Z.DomingoHoraS 
						END 
			ORDER BY 2 DESC




		SELECT I.*, E.Nombre , E.Apellido, C.NombreCargo   FROM 
				(SELECT T2.IdEmpleado,	T2.FechaLectura AS Fecha,		T2.Dia,
						CAST (HoraE as varchar(8)) +' - '+ CAST (HoraS as varchar(8)) AS Horario,
						CAST (HE as varchar(8)) +' - '+ CAST (HS as varchar(8)) AS Trabajado,
						DATEDIFF (MINUTE ,HE, HS)  - DATEDIFF (MINUTE ,HoraE,HoraS) Inasistencia
				FROM #Temp2  t2
				WHERE DATEDIFF (MINUTE ,HE, HS)  - DATEDIFF (MINUTE ,HoraE,HoraS)  <0
				UNION ALL	
				SELECT	T.IdEmpleado, T.Fecha,
						DATEPART (DW, T.Fecha) AS Dia,
						CAST (CASE DATEPART (DW, T.Fecha)   
								WHEN 1 THEN Z.LunesHoraE 
								WHEN 2 THEN Z.MartesHoraE 
								WHEN 3 THEN Z.MiercolesHoraE 
								WHEN 4 THEN Z.JuevesHoraE 
								WHEN 5 THEN Z.ViernesHoraE 
								WHEN 6 THEN Z.SabadoHoraE  
								WHEN 7 THEN Z.DomingoHoraE
								END AS  VARCHAR(8))
						+' - '+
						CAST (CASE DATEPART (DW, T.Fecha)   
							WHEN 1 THEN Z.LunesHoraS 
							WHEN 2 THEN Z.MartesHoraS 
							WHEN 3 THEN Z.MiercolesHoraS 
							WHEN 4 THEN Z.JuevesHoraS  
							WHEN 5 THEN Z.ViernesHoraS
							WHEN 6 THEN Z.SabadoHoraS  
							WHEN 7 THEN Z.DomingoHoraS 
							END AS VARCHAR(8)) AS Horario,
						'00:00:00 - 00:00:00' AS Trabajado,
						CASE DATEPART (DW, T.Fecha)   
								WHEN 1 THEN DATEDIFF (MINUTE , Z.LunesHoraS, Z.LunesHoraE)
								WHEN 2 THEN DATEDIFF (MINUTE, Z.MartesHoraS, Z.MartesHoraE) 
								WHEN 3 THEN DATEDIFF (MINUTE, Z.MiercolesHoraS, Z.MiercolesHoraE)
								WHEN 4 THEN DATEDIFF (MINUTE, Z.JuevesHoraS, Z.JuevesHoraE)
								WHEN 5 THEN DATEDIFF (MINUTE, Z.ViernesHoraS, Z.ViernesHoraE)
								WHEN 6 THEN DATEDIFF (MINUTE, Z.SabadoHoraS, Z.SabadoHoraE)
								WHEN 7 THEN DATEDIFF (MINUTE, Z.DomingoHoraS, Z.DomingoHoraE)
								END AS Inasistencia
				FROM	(SELECT Fecha, E.IdEmpleado, E.IdZonaActual as idzona, E.IdRegion 
						FROM EPK_Empleados E
						CROSS JOIN #temp T 
						WHERE		(@IdRegion	IS NULL		OR E.IdRegion	= @IdRegion )
							AND		(@IdEmpleado IS NULL 	OR E.IdEmpleado = @IdEmpleado)
							AND		(@Nombre	IS NULL		OR E.Nombre		LIKE @Nombre)
							AND		(@Apellido	IS NULL		OR E.Apellido LIKE @Apellido)
							AND		(@IdCargo	IS NULL		OR E.IdCargo = @IdCargo)
							AND		(@IdDepartamento IS NULL OR E.IdDepartamento = @IdDepartamento)
							AND		((SELECT COUNT (1) FROM @tblTurnos) =0 OR E.IdZonaActual IN (SELECT IdTurno FROM @tblTurnos))) T
				INNER JOIN EPK_Zonas Z
					ON	T.IdZona	= Z.IdZona 
					AND T.IdRegion	= Z.IdRegion
				LEFT JOIN EPK_Lecturas L
					 ON  T.fecha		= L.FechaLectura 
					 AND T.IdEmpleado	= L.IdEmpleado 
				INNER JOIN EPK_Empleados E
					ON   E.IdEmpleado	= T.IdEmpleado
				INNER JOIN	(SELECT	IdRegion, IdZona, Descripcion, Intervalos, 
									CASE 
										WHEN LunesHoraE		='00:00:00'		AND LunesHoraS='00:01:00'		THEN 1
										WHEN MartesHoraE	='00:00:00'		AND MartesHoraS='00:01:00'		THEN 2 
										WHEN MiercolesHoraE	='00:00:00'		AND MiercolesHoraS='00:01:00'	THEN 3
										WHEN JuevesHoraE	='00:00:00'		AND JuevesHoraS='00:01:00'		THEN 4
										WHEN ViernesHoraE	='00:00:00'		AND ViernesHoraS='00:01:00'		THEN 5 
										WHEN SabadoHoraE	='00:00:00'		AND SabadoHoraS='00:01:00'		THEN 6
										WHEN DomingoHoraE	='00:00:00'		AND DomingoHoraS='00:01:00'		THEN 7  END AS DiaLibre1,
									CASE 
										WHEN DomingoHoraE	='00:00:00'		AND DomingoHoraS='00:01:00'		THEN 7
										WHEN SabadoHoraE	='00:00:00'		AND SabadoHoraS='00:01:00'		THEN 6
										WHEN ViernesHoraE	='00:00:00'		AND ViernesHoraS='00:01:00'		THEN 5
										WHEN JuevesHoraE	='00:00:00'		AND JuevesHoraS='00:01:00'		THEN 4  
										WHEN MiercolesHoraE	='00:00:00'		AND MiercolesHoraS='00:01:00'	THEN 3
										WHEN MartesHoraE	='00:00:00'		AND MartesHoraS='00:01:00'		THEN 2  
										WHEN LunesHoraE		='00:00:00'		AND LunesHoraS='00:01:00'		THEN 1 END AS DiaLibre2
							FROM EPK_Zonas) D
					ON D.IdRegion = E.IdRegion 
					AND D.IdZona  = E.IdZonaActual 
				LEFT JOIN 
						(SELECT Fer.*,FR.IdRegion  
						FROM EPK_Feriados fer
						LEFT JOIN EPK_FeriadosRegion fr
						ON fer.IdFeriado = fr.IdFeriado ) AS F--EPK_Feriados F
					ON  DATEPART (DAY, T.FECHA)		BETWEEN DATEPART (DAY, F.FechaInicio)	AND DATEPART (DAY, F.FechaFin)
					AND DATEPART (MONTH, T.FECHA)	BETWEEN DATEPART (MONTH, F.FechaInicio) AND DATEPART (MONTH, F.FechaFin)
					AND DATEPART (YEAR, T.FECHA)	= CASE	WHEN F.Anual = 1 
															THEN DATEPART (YEAR, T.Fecha)
															ELSE DATEPART (YEAR, F.FechaInicio)
															END 
					AND (F.IdRegion IS NULL OR F.IdRegion = E.IdRegion)					
				WHERE L.FechaLectura IS NULL 
				AND DATEPART (DW,t.Fecha)<> DiaLibre1  
				AND DATEPART (DW,t.Fecha)<>DiaLibre2 
				AND F.FechaInicio IS NULL) I 
		INNER JOIN EPK_Empleados E
			ON I.IdEmpleado = E.IdEmpleado 
		INNER JOIN EPK_Cargo C
			ON E.IdCargo = C.IdCargo 
		ORDER BY I.Fecha 
		 
		DROP TABLE #Temp
		DROP TABLE #Temp2

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
    ON OBJECT::[dbo].[EPK_sp_ReporteInasistenciasCalcular] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteInasistenciasCalcular] TO PUBLIC
    AS [dbo];

