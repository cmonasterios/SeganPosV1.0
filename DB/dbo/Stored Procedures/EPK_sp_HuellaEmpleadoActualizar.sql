-- =============================================
-- Author:		Ronald Pérez
-- Create date: 19/10/2012
-- Description:	Permite agregar una huella de un usuario 
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_HuellaEmpleadoActualizar]
	 @IdEmpleado     INT
    ,@IdFingerPrint  SMALLINT
    ,@IdFlag         SMALLINT
    ,@TemplateFinger VARCHAR(2000)
AS
BEGIN
IF (SELECT COUNT(*) FROM [EPK_HuellaEmpleado] WHERE @IdEmpleado =[IdEmpleado] AND @IdFingerPrint = [IdFingerPrint])=0
BEGIN 
INSERT INTO [dbo].[EPK_HuellaEmpleado]
           ([IdEmpleado]
           ,[IdFingerPrint]
           ,[IdFlag]
           ,[TemplateFinger])
     VALUES
           (@IdEmpleado
           ,@IdFingerPrint
           ,@IdFlag
           ,@TemplateFinger
           )
END 
ELSE
BEGIN 
  UPDATE [EPK_HuellaEmpleado]
   SET   [TemplateFinger] = @TemplateFinger
        ,[IdFlag] = @IdFlag
   WHERE @IdEmpleado =[IdEmpleado] AND @IdFingerPrint = [IdFingerPrint]
END   

           
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_HuellaEmpleadoActualizar] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_HuellaEmpleadoActualizar] TO PUBLIC
    AS [dbo];

