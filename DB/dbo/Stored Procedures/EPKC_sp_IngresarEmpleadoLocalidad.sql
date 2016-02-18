-- =============================================
-- Author:		Ronald Pérez
-- Create date: 30/01/2013
-- Description:	Ingresar la ubicacion del registro de empleado en una localidad
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_IngresarEmpleadoLocalidad]
   @IdRegion       INT
  ,@IdLocalidad    INT
  ,@IdEmpleado     BIGINT
  ,@Seleccionado   BIT 
  ,@Resultado      INT  OUTPUT
AS
BEGIN
IF(@Seleccionado = 1)
BEGIN
  IF NOT EXISTS (SELECT * FROM [EPK_EmpleadoLocalidad] WHERE [IdRegion] = @IdRegion
           AND [IdLocalidad] =@IdLocalidad AND IdEmpleado =@IdEmpleado AND FechaHoraEliminacion IS NULL)
  --------------------         
		INSERT INTO  [EPK_EmpleadoLocalidad]
				   ([IdRegion]
				   ,[IdLocalidad]
				   ,[IdEmpleado]
				   ,[FechaHoraRegistro]
				   ,[FechaHoraEliminacion]
				   ,[FechaHoraInactivo]
				   ,[FechaHoraEnvio])
			 VALUES
				   (@IdRegion
				   ,@IdLocalidad
				   ,@IdEmpleado
				   ,GETDATE()
				   ,NULL
				   ,NULL
				   ,NULL
				   )
  
  SET @Resultado =22
  --------------------         
END--- FIN DE LA CONDICION @Seleccionado = 1
ELSE
BEGIN
  UPDATE  [EPK_EmpleadoLocalidad]
  SET [FechaHoraEliminacion] = GETDATE()
  WHERE 
          IdRegion     = @IdRegion 
        AND 
          IdLocalidad  = @IdLocalidad    
        AND        
          IdEmpleado   = @IdEmpleado
        AND 
          [FechaHoraEliminacion] IS NULL   
          
    IF @@ROWCOUNT >0 
     SET @Resultado =24
    ELSE 
     SET @Resultado =0
     
        
END
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_IngresarEmpleadoLocalidad] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_IngresarEmpleadoLocalidad] TO PUBLIC
    AS [dbo];

