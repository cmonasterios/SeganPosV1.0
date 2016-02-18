-- =============================================
-- Author:		Ronald Pérez
-- Create date: 08/11/2012
-- Description:	Permite actualizar los parámetros del eventos de terminal 
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_ActualizarEventoTerminal]
	 @IdRegion            INT
	,@IdLocalidad         INT
	,@IdTerminal          INT
	,@IdEvento            INT
	,@Mensaje             XML      = NULL
	,@FechaHoraEvento     DATETIME = NULL
	,@FechaHoraEnvio      DATETIME = NULL
	,@FechaHoraEjecucion  DATETIME = NULL

AS
BEGIN
	UPDATE  [EPK_EventoTerminal]
   SET 
       [FechaHoraEvento]    = CASE WHEN @FechaHoraEvento    IS NULL THEN [FechaHoraEvento] ELSE @FechaHoraEvento END 
      ,[Mensaje]            = CASE WHEN @Mensaje            IS NULL THEN [Mensaje] ELSE @Mensaje END
      ,[FechaHoraEnvio]     = CASE WHEN @FechaHoraEnvio     IS NULL THEN [FechaHoraEnvio] ELSE @FechaHoraEnvio END
      ,[FechaHoraEjecucion] = CASE WHEN @FechaHoraEjecucion IS NULL THEN [FechaHoraEjecucion] ELSE @FechaHoraEjecucion END
 WHERE
       @IdRegion      = [IdRegion]
      AND
       @IdLocalidad   = [IdLocalidad]
      AND
        @IdTerminal    = [IdTerminal]
      AND
       @IdEvento       = [IdEvento]
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_ActualizarEventoTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_ActualizarEventoTerminal] TO PUBLIC
    AS [dbo];

