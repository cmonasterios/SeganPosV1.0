-- =============================================
-- Author:		Ronald Pérez
-- Create date: 18/10/2012
-- Description:	Permite verificar los datos de lecturas 
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_LecturasActualizar]
    @IdRegion         INT ,
    @IdLocalidad      INT ,
    @IdEmpleado       INT ,
	@IdTerminal       INT ,
	@Fecha            VARCHAR(10),
	@Hora             VARCHAR(10),
	@TipoEntrada      SMALLINT,
	@IdEstadoLectura  SMALLINT,
	@ModoVerificacion SMALLINT,
	@WorkCode         SMALLINT
	
AS
BEGIN
DECLARE @ZonaActual INT
DECLARE @Resultado INT
DECLARE @IdEmpleadoAct BIGINT

SET  @ZonaActual    = NULL
SET  @IdEmpleadoAct = NULL
SET  @Resultado     =0


IF(SELECT COUNT(*) FROM  [EPK_Lecturas]
        WHERE  @IdEmpleado =[IdEmpleado]
             AND
               @IdTerminal  =[IdTerminal]
             AND 
               @IdLocalidad = IdLocalidad
             AND 
               @IdRegion    = IdRegion
             AND 
               @Fecha       = FechaLectura
             AND 
               @Hora        = HoraLectura
             AND
               @TipoEntrada   =  [TipoEntrada] )=0
BEGIN 
  SELECT @ZonaActual =IdZonaActual, @IdEmpleadoAct =IdEmpleado FROM EPK_Empleados WHERE IdEmpleado = @IdEmpleado      
 IF @IdEmpleadoAct IS NOT NULL
 BEGIN    
 
 INSERT INTO [EPK_Lecturas]
           ([IdRegion]
           ,[IdLocalidad]
           ,[IdTerminal]
           ,[IdEmpleado]
           ,[TipoEntrada]
           ,[IdEstadoLectura]
           ,[ModoVerificacion]
           ,[WorkCode]
           ,[FechaHoraEnvio]
           ,[FechaLectura]
           ,[HoraLectura]
           ,[IdZonaActual])
     VALUES
           (
            @IdRegion
           ,@IdLocalidad
           ,@IdTerminal
           ,@IdEmpleado
           ,@TipoEntrada
           ,@IdEstadoLectura
           ,@ModoVerificacion
           ,@WorkCode
           ,NULL
           ,@Fecha 
           ,@Hora
           ,@ZonaActual)

 
END
END

 SET @Resultado =(  SELECT COUNT(*) FROM EPK_HuellaEmpleado  WHERE IdEmpleado =@IdEmpleado )
 IF @Resultado =0  
 BEGIN
    SET @Resultado=@IdEmpleado
 END  
 ELSE
 BEGIN
    SET @Resultado=0
 END  
  
  RETURN @Resultado
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_LecturasActualizar] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_LecturasActualizar] TO PUBLIC
    AS [dbo];

