-- =============================================
-- Author:		Ronald Pérez
-- Create date: 07/11/2012
-- Description:	Permite Ingresar eventos de terminal generados por la aplicación administrativa
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_ActualizarDatosUsuarioTerminal]
	 @IdRegion        INT 
	,@IdLocalidad     INT 
	,@IdTerminal      INT 
	,@IdEmpleado      BIGINT 
    ,@Mensaje         XML
    ,@Solicitud       BIT
AS
BEGIN
  DECLARE @IdEvento INT
  DECLARE @IdTerminalCursor  INT
  DECLARE @IdLocalidadCursor INT
  
DECLARE TerminalesActualizar CURSOR FOR 

SELECT IdTerminal,T.IdLocalidad
FROM EPK_Terminal T INNER JOIN EPK_EmpleadoLocalidad EL
ON T.IdLocalidad = EL.IdLocalidad  AND T.IdRegion = EL.IdRegion
WHERE   @IdRegion =  T.IdRegion
      AND
       @IdTerminal != IdTerminal
       AND
       EL.IdEmpleado = @IdEmpleado

 OPEN TerminalesActualizar
 
FETCH NEXT FROM TerminalesActualizar 
INTO @IdTerminalCursor, @IdLocalidadCursor

WHILE @@FETCH_STATUS = 0
BEGIN  
  
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
           ,@IdLocalidadCursor
           ,@IdTerminalCursor
           ,GETDATE()
           ,NULL
           ,NULL
           ,NULL
)

SET  @IdEvento = (SELECT @@IDENTITY)
  IF @Solicitud = 1 
  BEGIN
  SET  @Mensaje.modify('replace value of (/EPKCenturion/Mensaje/IdEvento/text())[1] with sql:variable("@IdEvento") ')
  SET  @Mensaje.modify('replace value of (/EPKCenturion/Mensaje/IdMaquina/text())[1] with sql:variable("@IdTerminalCursor") ')
  SET  @Mensaje.modify('replace value of (/EPKCenturion/Mensaje/IdTienda/text())[1] with sql:variable("@IdLocalidadCursor") ')
  END
  ELSE
  BEGIN
  SET  @Mensaje.modify('replace value of (/EPKCentinela/Mensaje/IdEvento/text())[1] with sql:variable("@IdEvento") ')
  SET  @Mensaje.modify('replace value of (/EPKCentinela/Mensaje/IdMaquina/text())[1] with sql:variable("@IdTerminalCursor") ')
  SET  @Mensaje.modify('replace value of (/EPKCentinela/Mensaje/IdTienda/text())[1] with sql:variable("@IdLocalidadCursor") ')
  END

  
UPDATE  [EPK_EventoTerminal] 
SET Mensaje = @Mensaje
WHERE IdEvento = @IdEvento
  
   
FETCH NEXT FROM TerminalesActualizar 
INTO @IdTerminalCursor, @IdLocalidadCursor
END
 CLOSE TerminalesActualizar
 DEALLOCATE TerminalesActualizar
  
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ActualizarDatosUsuarioTerminal] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ActualizarDatosUsuarioTerminal] TO PUBLIC
    AS [dbo];

