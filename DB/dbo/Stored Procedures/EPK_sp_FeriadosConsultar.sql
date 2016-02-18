-- =============================================
-- Author:		sderkoyorikian
-- Create date: 03/05/2013
-- Description:	Permite consultar los feriados 
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_FeriadosConsultar]
  @IdFeriado   SMALLINT =NULL  
  ,@Descripcion VARCHAR(50)=NULL
  ,@MesInicio   CHAR(2)=NULL
  ,@DiaInicio   CHAR(2)=NULL
  ,@MesFin      CHAR(2)=NULL
  ,@DiaFin      CHAR(2)=NULL
  --,@IdUsuario	INT
AS
BEGIN
	BEGIN TRY
		SELECT	IdFeriado
				,Descripcion
				,MesInicio
				,DiaInicio
				,MesFin
				,DiaFin
		INTO #TEMP 
		FROM  [EPK_Feriados]
		WHERE	(@IdFeriado      IS NULL OR  @IdFeriado = IdFeriado)
		AND		(@Descripcion IS NULL OR  Descripcion LIKE @Descripcion) 
		AND		(@MesInicio   IS NULL OR  @MesInicio = MesInicio)
		AND		(@DiaInicio   IS NULL OR  @DiaInicio = DiaInicio)
		AND		(@MesFin      IS NULL OR  @MesFin = MesFin)
		AND		(@DiaFin      IS NULL OR  @DiaFin = DiaFin)
		 
		 
		SELECT * 
		FROM #TEMP 

		SELECT FR.* 
		FROM EPK_FeriadosRegion  FR 
		INNER JOIN #TEMP  T
		ON FR.IdFeriado = T.IdFeriado 	 

		--EXEC EPK_sp_AuditoriaActualizar @IdUsuario	
	
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
    ON OBJECT::[dbo].[EPK_sp_FeriadosConsultar] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_FeriadosConsultar] TO PUBLIC
    AS [dbo];

