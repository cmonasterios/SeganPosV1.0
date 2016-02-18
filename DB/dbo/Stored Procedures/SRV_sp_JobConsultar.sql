
-- =============================================
-- Author:	    Ronald Pérez
-- Create date: 30/04/2014
-- Description:	Permite ejecutar trabajos programados
-- =============================================
CREATE  PROCEDURE [dbo].[SRV_sp_JobConsultar]
AS
BEGIN
---------------------------------------------------------------------------------------
	DECLARE @IdJob			INT
	DECLARE @IdJobScheduler	INT
	DECLARE @TransactSQL	VARCHAR(MAX)
	DECLARE @FechaEjecucion			DATETIME = GETDATE() 
	
	
	SET NOCOUNT ON;
	SET DATEFIRST 1;
	BEGIN TRY	
		SELECT	J.IdJob
			   ,JS.IdJobScheduler 
 			   ,J.TransactSQL
			   ,S.PeriodicidadCantidad
			   ,S.PeriodicidadIntervalo
			   ,S.FrecuenciaCantidad 
			   ,S.FrecuenciaIntervalo
			   ,J.Prioridad
			   ,S.Lunes 
			   ,S.Martes
			   ,S.Miercoles
			   ,S.Jueves
			   ,S.Viernes 
			   ,S.Sabado 
			   ,S.Domingo 
			   ,CASE	WHEN JS.FechaUltEjecucion IS NULL AND FrecuenciaIntervalo =1	
							THEN DATEADD (MINUTE, FrecuenciaCantidad,CAST (CONVERT (VARCHAR,s.FechaInicio,120) +' '+ CONVERT(VARCHAR,s.HoraInicio, 108) AS DATETIME))
						WHEN JS.FechaUltEjecucion IS NULL AND FrecuenciaIntervalo =2	
							THEN DATEADD (HOUR, FrecuenciaCantidad,CAST (CONVERT (VARCHAR,s.FechaInicio,120) +' '+ CONVERT(VARCHAR,s.HoraInicio, 108) AS DATETIME))
						
						WHEN JS.FechaUltEjecucion IS NOT NULL AND FrecuenciaIntervalo =1	
							THEN DATEADD (MINUTE, FrecuenciaCantidad,JS.FechaUltEjecucion)
						WHEN JS.FechaUltEjecucion IS NOT NULL AND FrecuenciaIntervalo =2	
							THEN DATEADD (HOUR, FrecuenciaCantidad,JS.FechaUltEjecucion)
						ELSE JS.FechaUltEjecucion  END ProxEjec
		INTO #JobsExec 
		FROM SRV_Job J 
		INNER JOIN SRV_JobScheduler JS 
			ON J.IdJob = JS.IdJob 
			AND J.Activo =1 
		INNER JOIN SRV_Scheduler S 
			ON S.IdScheduler = JS.IdScheduler
			AND	S.Activo =1
			AND CAST (@FechaEjecucion AS DATE)		BETWEEN FechaInicio		AND FechaFin 
			AND CAST (@FechaEjecucion AS TIME(7))	BETWEEN HoraInicio		AND HoraFin  
  		 ORDER BY Prioridad 
			
			
		DECLARE ListaDeJobs CURSOR  FOR
        SELECT	IdJob
			   ,IdJobScheduler
 			   ,TransactSQL
 		FROM #JobsExec 
		WHERE ProxEjec <= @FechaEjecucion 
		AND (CASE PeriodicidadIntervalo WHEN 2  THEN	CASE DATEPART (DW, @FechaEjecucion)
																		WHEN 1 THEN Lunes 
																		WHEN 2 THEN Martes 
																		WHEN 3 THEN Miercoles 
																		WHEN 4 THEN Jueves 
																		WHEN 5 THEN Viernes 
																		WHEN 6 THEN Sabado 
																		WHEN 7 THEN Domingo  
																	END
					
										WHEN 1  THEN	1 END) =1 
		ORDER BY Prioridad
	
			
	    SET NOCOUNT OFF;					

    ---------------------------------------------------------------------------------------
	    OPEN ListaDeJobs;
	    FETCH NEXT FROM ListaDeJobs INTO
		    @IdJob,
		    @IdJobScheduler,
		    @TransactSQL;
    ---------------------------------------------------------------------------------------

		    WHILE @@FETCH_STATUS = 0
			    BEGIN
    			
			    EXEC  sp_sqlexec @TransactSQL
    			
			    UPDATE SRV_JobScheduler 
			    SET FechaUltEjecucion = @FechaEjecucion 
			    WHERE IdJobScheduler  = @IdJobScheduler
    			
			    FETCH NEXT FROM ListaDeJobs INTO
				    @IdJob,
				    @IdJobScheduler,
				    @TransactSQL
			    END
    	   
	    DROP TABLE #JobsExec
	    CLOSE ListaDeJobs;
        DEALLOCATE ListaDeJobs;
    END TRY
	BEGIN CATCH
		EXEC EPK_sp_LogErroresGenerar @@SPID
		SELECT 'Linea de error: '+ CAST(ERROR_LINE() as varchar(4)) +' - Nro error: '+ CAST (ERROR_NUMBER () as varchar(30))+' - Mensaje de error: '+ ERROR_MESSAGE () 
		RETURN 0
	END CATCH
END
GO



GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[SRV_sp_JobConsultar] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[SRV_sp_JobConsultar] TO PUBLIC
    AS [dbo];

