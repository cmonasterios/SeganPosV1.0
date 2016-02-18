-- =============================================
-- Author:		Ronald Pérez
-- Create date: 07/11/2012
-- Description:	Permite Ingresar eventos de terminal generados por la aplicación administrativa
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_IngresarEventoTerminal]
	 @IdRegion          INT 
	,@IdLocalidad     INT 
	,@IdTerminal      INT 
	,@IdEvento        INT OUTPUT
AS
BEGIN

BEGIN TRY
INSERT INTO  [EPK_EventoTerminal]
           ([IdRegion]
           ,[IdLocalidad]
           ,[IdTerminal]
           ,[FechaHoraEvento]
           ,[Mensaje]
           ,[FechaHoraEnvio]
           ,[FechaHoraEjecucion])
     VALUES
           (@IdRegion
           ,@IdLocalidad
           ,@IdTerminal
           ,NULL
           ,NULL
           ,NULL
           ,NULL
)
 SET  @IdEvento = (SELECT @@IDENTITY)
END TRY
BEGIN CATCH
  SET  @IdEvento = -1
END CATCH
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_IngresarEventoTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_IngresarEventoTerminal] TO PUBLIC
    AS [dbo];

