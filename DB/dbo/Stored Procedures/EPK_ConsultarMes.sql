
-- =============================================
-- Author:		Ronald Pérez
-- Create date: 28/10/2011
-- Description:	Consultar los meses de año
-- =============================================
CREATE PROCEDURE [dbo].[EPK_ConsultarMes]
	@Codigo_Mes  VARCHAR(3) = NULL,
	@Nombre      VARCHAR(20) = NULL,
	@Idioma       VARCHAR(3) = NULL
AS
BEGIN
	SELECT Codigo_Mes,Nombre FROM EPK_MES
    WHERE
    (@Codigo_Mes IS NULL OR @Codigo_Mes = Codigo_Mes)
     AND
    (@Nombre IS NULL OR  NOMBRE LIKE @Nombre)
     
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_ConsultarMes] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_ConsultarMes] TO PUBLIC
    AS [dbo];

