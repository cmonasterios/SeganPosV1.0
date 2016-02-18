-- =============================================
-- Author:		Ronald Pérez
-- Create date: 23/02/2013
-- Description:	Ingresar el registro de acceso
-- =============================================
Create PROCEDURE [dbo].[EPKC_sp_IngresarEmpleadoAcceso]
   @IdRegion       INT
  ,@IdEmpleado     BIGINT
  ,@IdGrupo        SMALLINT
AS
BEGIN

IF NOT EXISTS (SELECT * FROM [EPK_EmpleadoAcceso] WHERE [IdRegion] = @IdRegion
           AND IdGrupo =@IdGrupo AND IdEmpleado =@IdEmpleado AND FechaEliminacion IS NULL)
BEGIN
INSERT INTO  [EPK_EmpleadoAcceso]
           ([IdRegion]
           ,[IdEmpleado]
           ,[IdGrupo]
           ,[FechaCreacion]
           ,[FechaEliminacion])
     VALUES
           (@IdRegion
           ,@IdEmpleado
           ,@IdGrupo
           ,GETDATE()
           ,NULL)
  --------------------         
END--- 
ELSE
BEGIN
 UPDATE  [EPK_EmpleadoAcceso]
 SET [FechaEliminacion] = GETDATE()
 WHERE  [IdRegion] = @IdRegion
      AND
        [IdEmpleado] = @IdEmpleado
      AND 
        [FechaEliminacion] IS NULL   
       
END
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_IngresarEmpleadoAcceso] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_IngresarEmpleadoAcceso] TO PUBLIC
    AS [dbo];

