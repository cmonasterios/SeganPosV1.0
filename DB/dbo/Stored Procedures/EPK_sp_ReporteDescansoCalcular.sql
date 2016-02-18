-- =============================================
-- Author:		Sderkoyorikian
-- Create date: 28/06/2013
-- Description:	Permite 
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteDescansoCalcular]
	@FechaInicial	DATE,
	@FechaFinal		DATE,
	@HoraDesde		TIME	= NULL,
	@HoraHasta		TIME	= NULL,
	@IdRegion		INT		= NULL,
	@IdEmpleado		BIGINT	= NULL,
	@Nombre		VARCHAR(20)	= NULL,
	@Apellido	VARCHAR(20)	= NULL,
	@IdDepartamento	VARCHAR(25)	= NULL,
	@IdCargo	VARCHAR(25)	= NULL,
	@TipoLectura	CHAR(1) = 'B',
	@tblTurnos	dbo.tmp_DescansoTurno READONLY 
AS
BEGIN
	BEGIN TRY 
		-- SET NOCOUNT ON added to prevent extra result sets FROM
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		SELECT  L.IdEmpleado,
				E.Nombre,
				E.Apellido,
				FECHALECTURA,
				L.IdRegion,
				L.IdTerminal AS Terminal,
				ROW_NUMBER () OVER (PARTITION BY L.IdEmpleado, FechaLectura ORDER BY L.IdEmpleado, FechaLectura,Horalectura) as reg,
				(ROW_NUMBER () OVER (PARTITION BY L.IdEmpleado, FechaLectura ORDER BY L.IdEmpleado, FechaLectura)+1) /2 AS Registro,
				(ROW_NUMBER () OVER (PARTITION BY L.IdEmpleado, FechaLectura ORDER BY L.IdEmpleado, FechaLectura)) /2 AS Regist,
				CASE WHEN ROW_NUMBER () OVER (PARTITION BY L.IdEmpleado, FechaLectura ORDER BY L.IdEmpleado, FechaLectura,Horalectura) % 2 = 1 THEN HoraLectura END AS HoraEntrada,
				CASE WHEN ROW_NUMBER () OVER (PARTITION BY L.IdEmpleado, FechaLectura ORDER BY L.IdEmpleado, FechaLectura,Horalectura) % 2 = 0 THEN HoraLectura END AS HoraSalida,
				CASE WHEN ROW_NUMBER () OVER (PARTITION BY L.IdEmpleado, FechaLectura ORDER BY L.IdEmpleado, FechaLectura,Horalectura) % 2 = 0 THEN HoraLectura END AS HoraEntradaBreak,
				CASE WHEN ROW_NUMBER () OVER (PARTITION BY L.IdEmpleado, FechaLectura ORDER BY L.IdEmpleado, FechaLectura,Horalectura) % 2 = 1 THEN HoraLectura END AS HoraSalidaBreak,
				DBO.fn_ObtenerParametroEntero ('MinimoDescanso', FECHALECTURA, 2)	AS MinBreak
		INTO #Temp
		FROM EPK_Lecturas L
		INNER JOIN EPK_Empleados E
			ON L.IdEmpleado = E.IdEmpleado 
		WHERE	(FechaLectura	BETWEEN @FechaInicial AND @FechaFinal)
		AND		(@HoraDesde		IS NULL OR HoraLectura	>= @HoraDesde)
		AND		(@HoraHasta 	IS NULL OR HoraLectura	<= @HoraHasta)
		AND		(@IdEmpleado	IS NULL OR L.IdEmpleado	= @IdEmpleado)
		AND		(@IdRegion		IS NULL OR L.IdRegion	= @IdRegion)
		AND		(@Nombre		IS NULL OR E.Nombre		LIKE @Nombre)
		AND		(@Apellido		IS NULL OR E.Apellido 	LIKE @Apellido)
		AND		(@IdDepartamento	IS NULL OR E.IdDepartamento 	LIKE @IdDepartamento)
		AND		(@IdCargo		IS NULL OR E.IdCargo 	LIKE @IdCargo)
		AND		((SELECT COUNT (1) FROM @tblTurnos)=0	OR L.IdZonaActual IN (SELECT IdTurno FROM @tblTurnos))
		--WHERE IdEmpleado ='14275604' AND FechaLectura BETWEEN  '2013-06-01' AND GETDATE ()
		ORDER BY FechaLectura, HoraLectura  


		--SELECT * FROM #Temp ORDER BY FechaLectura, Registro 

		SELECT	T.*, 
				R.descripcion AS Region,
				TE.Descripcion AS DescTerminal 
		FROM
			(SELECT IdEmpleado,		Nombre,		Apellido,	
					Registro,		FechaLectura,		'T' AS Tipo,
					IdRegion,		
					MIN(Terminal) AS Terminal,
					MIN (HoraEntrada) AS HoraEntrada, 
					MAX(HoraSalida) AS HoraSalida, 
					DATEDIFF (MINUTE,MIN (HoraEntrada),  MAX(HoraSalida )) AS Tiempo
			FROM #Temp 
			GROUP BY IdEmpleado,	Nombre,			Apellido,	
					 Registro,		FechaLectura,	IdRegion
			UNION ALL
			SELECT  IdEmpleado,		Nombre,		Apellido,	
					Regist,			FechaLectura,		'B' AS Tipo, 
					IdRegion,		
					MIN(Terminal) AS Terminal,
					MIN (HoraEntradaBreak) AS HoraInicioBreak, 
					MAX(HoraSalidaBreak) AS HoraFinBreak, 
					DATEDIFF (MINUTE,MIN (HoraEntradaBreak), MAX(HoraSalidaBreak)) AS Tiempo
			FROM #Temp 
			WHERE Regist >0 
			GROUP BY IdEmpleado,	Nombre,			Apellido,	
					 Regist,		FechaLectura,	MinBreak,	IdRegion
			HAVING MAX(HoraSalidaBreak) IS NOT NULL 
				AND DATEDIFF (MINUTE,MIN (HoraEntradaBreak ), MAX(HoraSalidaBreak))  > MinBreak 
			UNION ALL
			SELECT  IdEmpleado,		Nombre,		Apellido,	
					Regist,			FechaLectura,		'I' AS Tipo, 
					IdRegion,		
					MIN(Terminal) AS Terminal,
					MIN(HoraEntradaBreak) AS HoraInicioBreak, 
					MAX(HoraSalidaBreak) AS HoraFinBreak, 
					DATEDIFF (MINUTE,MIN (HoraEntradaBreak ), MAX(HoraSalidaBreak)) AS Tiempo
			FROM #Temp 
			WHERE Regist >0 
			GROUP BY IdEmpleado,	Nombre,			Apellido,	
					 Regist,		FechaLectura,	MinBreak,	IdRegion
			HAVING MAX(HoraSalidaBreak) IS NOT NULL 
				AND DATEDIFF (MINUTE,MIN (HoraEntradaBreak ),  MAX(HoraSalidaBreak))  <=MinBreak ) T
		INNER JOIN EPK_Region R
			ON T.IdRegion = R.IdRegion
		INNER JOIN EPK_Terminal TE
			ON TE.IdTerminal = T.Terminal  
		WHERE (@TipoLectura IS NULL OR TIPO = @TipoLectura)
		ORDER BY FechaLectura,		HoraEntrada,		Tipo	
			
		DROP TABLE #Temp 


	END TRY 
	BEGIN CATCH
		EXEC EPK_sp_LogErroresGenerar @@SPID
		SELECT 'Linea de error: '+ CAST(ERROR_LINE() as varchar(4)) +' - Nro error: '+ CAST (ERROR_NUMBER () as varchar(30))+' - Mensaje de error: '+ ERROR_MESSAGE () 
		RETURN 0
	END CATCH
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ReporteDescansoCalcular] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteDescansoCalcular] TO PUBLIC
    AS [dbo];

