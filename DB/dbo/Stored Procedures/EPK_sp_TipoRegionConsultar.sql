-- ===========================================================
-- Author:		sderkoyorikian
-- Create date: 21/05/2013
-- Description:	Permite consultar las ciudades 
-- ===========================================================
CREATE PROCEDURE [dbo].[EPK_sp_TipoRegionConsultar]
(
	@IdTipoRegion  SMALLINT	    = NULL,
	@Descripcion   VARCHAR(50)	= NULL,
	@BonoAliBaseFraccionado	BIT	= NULL 
)
AS 
BEGIN
	BEGIN TRY 
		
		SELECT *
		FROM EPK_TipoRegion
		WHERE	(@IdTipoRegion 	IS NULL OR IdTipoRegion	= @IdTipoRegion)
		AND 	(@BonoAliBaseFraccionado  	IS NULL OR BonoAliBaseFraccionado = @BonoAliBaseFraccionado)
		AND		(@Descripcion		IS NULL OR Descripcion	LIKE @Descripcion)
	
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
    ON OBJECT::[dbo].[EPK_sp_TipoRegionConsultar] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_TipoRegionConsultar] TO PUBLIC
    AS [dbo];

