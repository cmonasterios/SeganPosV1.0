-- =============================================
-- Author:		Christian Ortiz
-- Create date: 01/03/2013
-- Description:	Generar el reporte de horas trabajadas considerando el break
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_ReporteEntradasSalidas_test]
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
     ,APR_Position_Description Cargo
     ,APR_Department_Descripti DescripcionDpto
     ,ru.Descripcion
     ,FechaLectura Fecha
     ,MIN(HoraLectura) Entrada
     ,MAX(HoraLectura) Salida
     ,DATEDIFF(HH,CAST(MIN(HoraLectura) AS DATETIME),CAST(MAX(HoraLectura) AS DATETIME))  EnHoras
     ,DATEDIFF(hh,MIN(HoraLectura),MAX(HoraLectura))%24 Horas
     ,DATEDIFF(mi,MIN(HoraLectura),MAX(HoraLectura))%60 Minutos
     ,DATEDIFF(ss,MIN(HoraLectura),MAX(HoraLectura)) Segundos
FROM EPK_LECTURAS L
INNER JOIN EPK_Empleados E ON E.IdEmpleado = L.IdEmpleado
LEFT JOIN EPKDGP04.EPK.DBO.APR_DEPARtMENT_MSTR ON APR_Department_ID = IdDepartamento
INNER JOIN EPK_Region RU ON RU.IdRegion = L.IdRegion
INNER JOIN EPKDGP04.EPK.DBO.APR_POSITION_MSTR C ON C.APR_Position_ID collate SQL_Latin1_General_CP1_CI_AS = E.IdCargo

  WHERE  
     (@IdEmpleado IS NULL OR  @IdEmpleado = E.IdEmpleado) 
    AND
     (@Nombre     IS NULL OR  Nombre LIKE @Nombre) 
    AND
     (@Apellido   IS NULL OR  Apellido LIKE @Apellido) 
    AND
     (@FechaDesde   IS NULL OR FechaLectura BETWEEN @FechaDesde AND  @FechaHasta ) 
    AND 
     (@IdDepartamento      IS NULL OR @IdDepartamento= IdDepartamento)
    AND 
     (@IdCargo             IS NULL OR @IdCargo= E.IdCargo)
    AND 
     (@IdRegion             IS NULL OR @IdRegion= L.IdRegion)

GROUP BY 
      L.IdRegion 
     ,E.IdEmpleado
     ,Nombre
     ,Apellido
     ,ru.Descripcion
     ,APR_Position_Description
     ,APR_Department_Descripti
     ,FechaLectura
ORDER BY 
      Apellido
     ,Nombre
     ,FechaLectura ASC


/*
DECLARE @entradassalidas TABLE(IdRegion int
     ,IdEmpleado BIGINT
     ,Nombre VARCHAR(100)
     ,Apellido VARCHAR(100)
     ,Cargo VARCHAR(100)
     ,DescripcionDpto VARCHAR(100)
     ,Fecha DATETIME
     ,Entrada VARCHAR(8)
     ,Salida VARCHAR(8)
     ,EnHoras VARCHAR(10)
     ,Segundos INT)     
INSERT INTO @entradassalidas
SELECT 
      L.IdRegion
     ,E.IdEmpleado
     ,Nombre
     ,Apellido
     ,APR_Position_Description Cargo
     ,APR_Department_Descripti DescripcionDpto
     ,DATEADD(dd, 0, DATEDIFF(dd, 0, FechaHora))Fecha
     ,CONVERT(VARCHAR(8),MIN(FechaHora),108) Entrada
     ,CONVERT(VARCHAR(8),MAX(FechaHora),108) Salida
     ,CONVERT(VARCHAR(10),MAX(FechaHora)-MIN(FechaHora),108) EnHoras
     ,DATEDIFF(ss,MIN(FechaHora),MAX(FechaHora)) Segundos 
FROM EPK_LECTURAS L
INNER JOIN EPK_Empleados E ON E.IdEmpleado = L.IdEmpleado
--INNER JOIN EPK_RegionUbicacion RU ON RU.IdRegion = L.IdRegion
LEFT JOIN EPKDGP04.EPK.DBO.APR_DEPARtMENT_MSTR ON APR_Department_ID = IdDepartamento
INNER JOIN EPKDGP04.EPK.DBO.APR_POSITION_MSTR C ON C.APR_Position_ID collate SQL_Latin1_General_CP1_CI_AS = E.IdCargo
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
     ,APR_Position_Description
     ,APR_Department_Descripti
     ,DATEADD(dd, 0, DATEDIFF(dd, 0, FechaHora))
ORDER BY 
	  APR_Position_Description,
	  DATEADD(dd, 0, DATEDIFF(dd, 0, FechaHora))DESC
	 ,Nombre
     ,Apellido

SELECT 
      ES.IdRegion 
     ,ES.IdEmpleado
     ,ES.Nombre
     ,ES.Apellido
     ,Cargo
     ,DescripcionDpto
     ,CONVERT(VARCHAR(10),ES.Fecha,103) Fecha
     ,ES.Entrada 
     ,ES.Salida
     ,CONVERT(VARCHAR(8),MIN(FechaHora),108) SalidaBreak
     ,CONVERT(VARCHAR(8),MAX(FechaHora),108) RegresoBreak
     ,ES.EnHoras HorasJornada
     ,CONVERT(VARCHAR(10),MAX(FechaHora)-MIN(FechaHora),108) HorasBreak
     ,CONVERT(VARCHAR(10), CONVERT(DATETIME, ES.EnHoras,108)-CONVERT(VARCHAR(10),MAX(FechaHora)-MIN(FechaHora),108),108)EnHoras
     ,ES.Segundos SegundosJornada    
     ,DATEDIFF(ss,MIN(FechaHora),MAX(FechaHora)) SegundosBreak 
FROM EPK_LECTURAS L
INNER JOIN @entradassalidas ES ON L.IdEmpleado=ES.IdEmpleado AND DATEADD(dd, 0, DATEDIFF(dd, 0, FechaHora))=ES.Fecha
INNER JOIN EPK_Empleados E ON E.IdEmpleado = L.IdEmpleado
--INNER JOIN EPK_RegionUbicacion RU ON RU.IdRegion = L.IdRegion
INNER JOIN EPK_EmpleadoAcceso EA ON L.IdEmpleado=EA.IdEmpleado AND L.IdRegion=EA.IdRegion
WHERE  
     (@IdEmpleado IS NULL OR  @IdEmpleado = E.IdEmpleado) 
    AND
     (@Nombre     IS NULL OR  E.Nombre LIKE @Nombre) 
    AND
     (@Apellido   IS NULL OR  E.Apellido LIKE @Apellido) 
    AND
     (@FechaDesde   IS NULL OR DATEADD(dd, 0, DATEDIFF(dd, 0, FechaHora)) BETWEEN DATEADD(dd, 0, DATEDIFF(dd, 0, @FechaDesde)) AND DATEADD(dd, 0, DATEDIFF(dd, 0, @FechaHasta)) ) 
    AND 
     (@IdDepartamento      IS NULL OR @IdDepartamento= IdDepartamento)
    AND 
     (@IdCargo             IS NULL OR @IdCargo= IdCargo)
    AND 
     (@IdRegion             IS NULL OR @IdRegion= L.IdRegion)
    AND CONVERT(VARCHAR(8),FechaHora,108) > ES.Entrada AND CONVERT(VARCHAR(8),FechaHora,108) < ES.Salida 
  --  AND EA.FechaEliminacion IS NULL OR DATEADD(dd, 0, DATEDIFF(dd, 0, FechaHora)) BETWEEN DATEADD(dd, 0, DATEDIFF(dd, 0, ea.FechaCreacion)) AND DATEADD(dd, 0, DATEDIFF(dd, 0, EA.FechaEliminacion))
GROUP BY 
      ES.IdRegion 
     ,ES.IdEmpleado
     ,ES.Nombre
     ,ES.Apellido
     ,Cargo
     ,DescripcionDpto
     ,ES.Fecha
     ,ES.Entrada 
     ,ES.Salida
     ,ES.EnHoras
     ,ES.Segundos
     ,DATEADD(dd, 0, DATEDIFF(dd, 0, FechaHora))
ORDER BY 
	  Nombre
	 ,Apellido
	 ,DATEADD(dd, 0, DATEDIFF(dd, 0, FechaHora))
*/	 
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_ReporteEntradasSalidas_test] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_ReporteEntradasSalidas_test] TO PUBLIC
    AS [dbo];

