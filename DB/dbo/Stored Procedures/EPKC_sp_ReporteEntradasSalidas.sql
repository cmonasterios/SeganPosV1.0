-- =============================================
-- Author:		Ronald Pérez
-- Create date: 21/02/2013
-- Description:	Generar el reporte de horas trabajadas
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_ReporteEntradasSalidas]
    @IdRegion       INT            = NULL
   ,@IdEmpleado     BIGINT         = NULL
   ,@Nombre         VARCHAR(15)    = NULL
   ,@Apellido       VARCHAR(15)    = NULL
   ,@FechaDesde          DATETIME  = NULL
   ,@FechaHasta          DATETIME  = NULL
   ,@IdDepartamento      CHAR(21)  = NULL
   ,@IdCargo             CHAR(21)  = NULL
AS
BEGIN

 SELECT 
      L.IdRegion
     ,E.IdEmpleado
     ,Nombre
     ,Apellido
     ,APR_Department_Descripti DescripcionDpto
     ,Descripcion
     ,DATEADD(dd, 0, DATEDIFF(dd, 0, FechaHora))Fecha
     ,CONVERT(VARCHAR(8),MIN(FechaHora),108) Entrada
     ,CONVERT(VARCHAR(8),MAX(FechaHora),108) Salida
     ,CONVERT(VARCHAR(10),MAX(FechaHora)-MIN(FechaHora),108)EnHoras
     ,DATEDIFF(hh,MIN(FechaHora),MAX(FechaHora))%24 Horas
     ,DATEDIFF(mi,MIN(FechaHora),MAX(FechaHora))%60 Minutos
     ,DATEDIFF(ss,MIN(FechaHora),MAX(FechaHora)) Segundos
FROM EPK_LECTURAS L
INNER JOIN EPK_Empleados E ON E.IdEmpleado = L.IdEmpleado
LEFT JOIN EPKDGP04.EPK.DBO.APR_DEPARtMENT_MSTR ON APR_Department_ID = IdDepartamento
INNER JOIN EPK_RegionUbicacion RU ON RU.IdRegion = L.IdRegion
  WHERE  
     (@IdEmpleado IS NULL OR  @IdEmpleado = E.IdEmpleado) 
    AND
     (@Nombre     IS NULL OR  Nombre LIKE @Nombre) 
    AND
     (@Apellido   IS NULL OR  Apellido LIKE @Apellido) 
    AND
     (@FechaDesde   IS NULL OR DATEADD(dd, 0, DATEDIFF(dd, 0, FechaHora)) BETWEEN DATEADD(dd, 0, DATEDIFF(dd, 0, @FechaDesde)) AND DATEADD(dd, 0, DATEDIFF(dd, 0, @FechaHasta)) ) 
    AND 
     (@IdDepartamento      IS NULL OR @IdDepartamento= IdDepartamento)
    AND 
     (@IdCargo             IS NULL OR @IdCargo= IdCargo)
    AND 
     (@IdRegion             IS NULL OR @IdRegion= L.IdRegion)

GROUP BY 
      L.IdRegion 
     ,E.IdEmpleado
     ,Nombre
     ,Apellido
     ,APR_Department_Descripti
     ,Descripcion
     ,DATEADD(dd, 0, DATEDIFF(dd, 0, FechaHora))
ORDER BY 
      DATEADD(dd, 0, DATEDIFF(dd, 0, FechaHora))DESC
     ,Nombre
     ,Apellido

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_ReporteEntradasSalidas] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_ReporteEntradasSalidas] TO PUBLIC
    AS [dbo];

