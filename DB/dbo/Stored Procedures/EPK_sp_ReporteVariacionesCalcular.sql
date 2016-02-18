-- ================================================================================
-- Author:		Sderkoyorikian
-- Create date: 15/05/2013
-- Description:	Pemite calcular las horas trabajadas los días domingos y feriados.
-- ================================================================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteVariacionesCalcular]
(
	@FechaI	AS DATE,
	@FechaF	AS DATE,
	@IdEmpleado	AS BIGINT	= NULL,
	@IdRegion	AS INT		= NULL,
	@IdGerencia	AS CHAR(21)	= NULL,
	@IdCargo	AS CHAR(21)	= NULL
)
AS
BEGIN
	BEGIN TRY 
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		SET DATEFIRST 1;

		SELECT	L.IdEmpleado, 
				E.Nombre,
				E.Apellido, 
				C.NombreCargo,
				FechaLectura, 
				dbo.EPK_ObtenerDiaSemanaDesc (DATEPART (DW, FechaLectura)) AS Dia,
				MIN (HoraLectura) AS HoraEntrada, 
				MAX (HoraLectura) AS HoraSalida, 
				--DATEDIFF (MINUTE,MIN (HoraLectura), MAX (HoraLectura)) AS MinutosTrabajados, 
				CAST(
					CAST (DATEDIFF (MINUTE,MIN (HoraLectura), MAX (HoraLectura))/60 AS VARCHAR(2)) +':'+
					CAST (DATEDIFF (MINUTE,MIN (HoraLectura), MAX (HoraLectura))%60 AS VARCHAR(2))
					AS TIME) AS HorasTrabajadas
		FROM epk_lecturas L
		INNER JOIN EPK_Empleados E
			ON E.IdEmpleado = l.IdEmpleado 
		INNER JOIN EPK_Cargo C
			ON E.IdCargo = C.CodCargo 
		LEFT JOIN 
						(SELECT Fer.*,FR.IdRegion  
						FROM EPK_Feriados fer
						LEFT JOIN EPK_FeriadosRegion fr
						ON fer.IdFeriado = fr.IdFeriado ) AS F
					ON  DATEPART (DAY, L.FechaLectura)		BETWEEN DATEPART (DAY, F.FechaInicio)	AND DATEPART (DAY, F.FechaFin)
					AND DATEPART (MONTH, L.FechaLectura)	BETWEEN DATEPART (MONTH, F.FechaInicio) AND DATEPART (MONTH, F.FechaFin)
					AND DATEPART (YEAR, L.FechaLectura)	  = CASE	WHEN F.Anual = 1 
																	THEN DATEPART (YEAR, L.FechaLectura)
																	ELSE DATEPART (YEAR, F.FechaInicio)
															END 
					AND (F.IdRegion IS NULL OR F.IdRegion = E.IdRegion)					 
		WHERE ((DATEPART (DW, FechaLectura) = 7 
				OR	F.Descripcion IS NOT NULL)
				--OR FechaLectura in (SELECT  CAST(YEAR(FechaLectura) AS VARCHAR)+ MesInicio + DiaInicio AS fechainicio
				--					FROM         EPK_Feriados
				--					WHERE     (CAST(YEAR(FechaLectura) AS VARCHAR) BETWEEN AñoInicio AND AñoFin)
				--					)
				)
			AND	FechaLectura BETWEEN @FechaI AND @FechaF
			AND (@IdEmpleado IS NULL	OR L.IdEmpleado		= @IdEmpleado)
			AND (@IdRegion IS NULL		OR L.IdRegion		= @IdRegion)
			AND	(@IdGerencia IS NULL	OR E.IdDepartamento	= @IdGerencia)
			AND (@IdCargo IS NULL		OR E.IdCargo		= @IdCargo)
		GROUP BY L.IdEmpleado, E.Nombre, E.Apellido, C.NombreCargo, FechaLectura				
		ORDER BY FechaLectura, L.IdEmpleado
		
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
    ON OBJECT::[dbo].[EPK_sp_ReporteVariacionesCalcular] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteVariacionesCalcular] TO PUBLIC
    AS [dbo];

