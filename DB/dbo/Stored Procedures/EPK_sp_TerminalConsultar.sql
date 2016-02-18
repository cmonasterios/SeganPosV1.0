-- ==========================================================================
-- Author:		sderkoyorikian
-- Create date: 06/05/2013
-- Description:	Permite consultar los terminales asociados a una localidad
-- ==========================================================================
CREATE PROCEDURE [dbo].[EPK_sp_TerminalConsultar]
  @IdRegion		INT        = NULL
 ,@IdLocalidad  INT        = NULL
 ,@IdTerminal   INT        = NULL
 ,@DireccionIP  VARCHAR(18)= NULL
 ,@Descripcion  VARCHAR(30)= NULL
 ,@Activo       BIT        = NULL
 --,@Idusuario	INT		   = NULL
 --,@IdAPP		INT
AS
BEGIN
	BEGIN TRY 
		SELECT	T.*,
				L.Descripcion DesLocal,
				RU.Descripcion DesRegion,
				TT.Descripcion DesTipo
		FROM	EPK_Terminal  T
			INNER JOIN	EPK_Localidad L 
				ON T.IdLocalidad = L.IdLocalidad
			INNER JOIN	EPK_Region RU 
				ON RU.IdRegion = L.IdRegion 
				AND T.IdRegion = RU.IdRegion
			INNER JOIN	EPK_TipoTerminal TT 
				ON TT.IdTipoTerminal = T.IdTipoTerminal
		WHERE	(@IdLocalidad	IS NULL		OR T.IdLocalidad	= @IdLocalidad)
			AND	(@IdTerminal	IS NULL		OR T.IdTerminal		= @IdTerminal)
			AND	(@DireccionIP	IS NULL		OR DireccionIP		= @DireccionIP)
			AND	(@Activo		IS NULL		OR Activo			= @Activo)
			AND	(@Descripcion	IS NULL		OR T.Descripcion	LIKE  @Descripcion)
			AND (@IdRegion      IS NULL     OR T.IdRegion         = @IdRegion)
        ORDER BY T.IdRegion,T.IdLocalidad
		--IF NOT @IdUsuario IS NULL 
		--	--Genera el registro de auditoría
		--	EXEC EPK_sp_AuditoriaActualizar @IdUsuario, @IdAPP            
		--ELSE
		--	BEGIN
		--	SELECT @IdUsuario	 = dbo.fn_ObtenerParametroEntero ('IDAUDITORÍA', getdate ())
		--	--Genera el registro de auditoría
		--	EXEC EPK_sp_AuditoriaActualizar @IdUsuario, @IdAPP
		--	END
								
		RETURN 1
	END TRY 
	BEGIN CATCH
		EXEC EPK_sp_LogErroresGenerar @@SPID
		SELECT 'Linea de error: '+ CAST(ERROR_LINE() as varchar(4)) +' - Nro error: '+ CAST (ERROR_NUMBER () as varchar(30))+' - Mensaje de error: '+ ERROR_MESSAGE () 
		RETURN 0
		ROLLBACK TRAN 
	END CATCH
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_TerminalConsultar] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_TerminalConsultar] TO PUBLIC
    AS [dbo];

