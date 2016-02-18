-- =============================================
-- Author:		Ronald Pérez
-- Create date: 07/11/2012
-- Description:	Permite consultar los eventos de un terminal
-- =============================================
create PROCEDURE [dbo].[EPK_sp_EventoTerminalConsultar]
     @IdRegion             INT      = NULL
    ,@IdLocalidad             INT      = NULL
	,@IdTerminal              INT      = NULL
	,@IdEvento                INT      = NULL
	,@FechaHoraEventoDesde    DATETIME = NULL
	,@FechaHoraEventoHasta    DATETIME = NULL
	,@FechaHoraEnvioDesde     DATETIME = NULL
	,@FechaHoraEnvioHasta     DATETIME = NULL
	,@FechaHoraEjecucionDesde DATETIME = NULL
	,@FechaHoraEjecucionHasta DATETIME = NULL
    ,@Pendientes              BIT
AS
BEGIN

 IF @Pendientes = 1
 BEGIN 
   SELECT [IdLocalidad]
      ,[IdTerminal]
      ,[IdEvento]
      ,[FechaHoraEvento]
      ,[Mensaje]
      ,[FechaHoraEnvio]
      ,[FechaHoraEjecucion]
  FROM  [EPK_EventoTerminal]
  WHERE 
        (@IdRegion     IS NULL OR @IdRegion = IdRegion)
       AND
        (@IdLocalidad     IS NULL OR @IdLocalidad = IdLocalidad)
       AND
	    (@IdTerminal      IS NULL OR @IdTerminal  = IdTerminal )
       AND
        [FechaHoraEjecucion] IS NULL
  ORDER BY [IdEvento]
 END
 ELSE
 BEGIN 
   SELECT [IdLocalidad]
      ,[IdTerminal]
      ,[IdEvento]
      ,[FechaHoraEvento]
      ,[Mensaje]
      ,[FechaHoraEnvio]
      ,[FechaHoraEjecucion]
  FROM  [EPK_EventoTerminal]
  WHERE 
        (@IdRegion     IS NULL OR @IdRegion = IdRegion)
       AND
        (@IdLocalidad     IS NULL OR @IdLocalidad = IdLocalidad)
       AND
	    (@IdTerminal      IS NULL OR @IdTerminal  = IdTerminal )
       AND
        (@IdEvento        IS NULL OR @IdEvento    = IdEvento   )
       AND 
   	    (@FechaHoraEventoDesde IS NULL OR (FechaHoraEvento BETWEEN @FechaHoraEventoDesde AND @FechaHoraEventoHasta) )
       AND 
        (@FechaHoraEnvioDesde  IS NULL OR (FechaHoraEnvio BETWEEN @FechaHoraEnvioDesde AND @FechaHoraEnvioHasta))
       AND 
        (@FechaHoraEjecucionDesde IS NULL OR (FechaHoraEjecucion BETWEEN @FechaHoraEjecucionDesde AND @FechaHoraEjecucionHasta ))
  ORDER BY [IdEvento]
 END

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_EventoTerminalConsultar] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_EventoTerminalConsultar] TO PUBLIC
    AS [dbo];

