-- =============================================
-- Author:		Ronald Pérez
-- Create date: 16/11/2012
-- Description:	Permite consultar las lecturas de acuerdo al 
           -- criterio de busqueda dada por los usuarios 
-- =============================================
CREATE PROCEDURE [dbo].[EPKC_sp_ConsultarLecturas]
    @IdEmpleado       BIGINT     = NULL
   ,@Nombre           VARCHAR(15)= NULL
   ,@Apellido         VARCHAR(15)= NULL
   ,@IdPrivilegio     SMALLINT   = NULL  
   ,@ModoVerificacion SMALLINT   = NULL  
   ,@FechaHoraDesde   DATETIME   = NULL  
   ,@FechaHoraHasta   DATETIME   = NULL  
   ,@IdLocalidad      INT        = NULL  
   ,@IdTerminal       INT        = NULL  
   ,@IdDepartamento   CHAR(21)   = NULL
   ,@IdCargo          CHAR(21)   = NULL
   ,@TipoLectura      SMALLINT   = NULL
   ,@HoraDesde        CHAR(8)    = NULL
   ,@HoraHasta        CHAR(8)   = NULL
AS
BEGIN
IF @TipoLectura > 2
BEGIN
SELECT   	  IdEmpleado
			 ,Nombre
			 ,Apellido  
             ,Fecha
			 ,(CASE WHEN @TipoLectura = 3 THEN MIN(Hora)
                    ELSE MAX(Hora) END
               )AS Hora  
			 ,Lugar
			 ,NombreTerminal
			 ,Entrada
			 ,IdEstadoLectura
			 ,DMV
			 ,WorkCode
			 ,IdTerminal
			 ,IdTipoTerminal
             ,IdPrivilegio
             ,Descripcion  
        FROM
		(SELECT 
			  E.IdEmpleado
			 ,Nombre
			 ,Apellido  
             ,FechaLectura  Fecha
			 ,HoraLectura  Hora
			 ,LL.Descripcion Lugar
			 ,T.Descripcion + ' - ' + TT.Descripcion NombreTerminal
			 ,(CASE TipoEntrada WHEN 0 THEN 'Entrada' WHEN 1 THEN 'Salida'  WHEN 2 THEN 'Break Out' WHEN 3 THEN 'Break In' WHEN 4 THEN 'H.E Out' WHEN 5 THEN 'H.E. In'  ELSE 'No' END )AS Entrada
			 ,IdEstadoLectura
			 ,(SELECT Descripcion FROM EPK_ModoVerificacion MV WHERE MV.IDModoVerificacion = L.ModoVerificacion)AS DMV
			 ,WorkCode
			 ,T.IdTerminal
			 ,T.IdTipoTerminal
             ,E.IdPrivilegio
             ,P.Descripcion  
		FROM EPK_LECTURAS L
				 INNER JOIN EPK_Empleados    E  ON(E.IdEmpleado      = L.IdEmpleado)
                 INNER JOIN EPK_Privilegio   P  ON(E.IdPrivilegio    = P.IdPrivilegio)
				 INNER JOIN EPK_Terminal     T  ON(T.IdTerminal      = L.IdTerminal)
				 INNER JOIN EPK_TipoTerminal TT ON(TT.IdTipoTerminal = T.IdTipoTerminal)
				 INNER JOIN EPK_Localidad    LL ON(LL.IdLocalidad    = T.IdLocalidad)  
		WHERE 
            (@IdEmpleado       IS NULL OR  @IdEmpleado =   E.IdEmpleado) 
           AND
            (@Nombre           IS NULL OR  E.Nombre LIKE @Nombre) 
           AND
            (@Apellido         IS NULL OR  E.Apellido LIKE @Apellido) 
           AND
            (@IdPrivilegio     IS NULL OR  E.IdPrivilegio = @IdPrivilegio) 
           AND
            (@ModoVerificacion IS NULL OR  @ModoVerificacion =   L.ModoVerificacion) 
           AND
            (@FechaHoraDesde   IS NULL OR  FechaLectura BETWEEN @FechaHoraDesde AND @FechaHoraHasta) 
           AND
            (@IdLocalidad      IS NULL OR  @IdLocalidad  =   LL.IdLocalidad) 
           AND
            (@IdTerminal       IS NULL OR  @IdTerminal   =   L.IdTerminal) 
           AND 
            (@IdDepartamento   IS NULL OR @IdDepartamento= IdDepartamento)
           AND 
            (@IdCargo          IS NULL OR @IdCargo= IdCargo)
         )A
WHERE (@HoraDesde IS NULL OR (A.Hora BETWEEN @HoraDesde AND @HoraHasta))
GROUP BY  IdEmpleado,Nombre,Apellido,Fecha,Lugar,NombreTerminal,Entrada,IdEstadoLectura
         ,DMV,WorkCode,IdTerminal,IdTipoTerminal,IdPrivilegio,Descripcion  
ORDER BY Fecha DESC,Hora ,Nombre,Apellido
END
ELSE
BEGIN
SELECT   	  IdEmpleado
			 ,Nombre
			 ,Apellido  
             ,Fecha
			 ,Hora  
			 ,Lugar
			 ,NombreTerminal
			 ,Entrada
			 ,IdEstadoLectura
			 ,DMV
			 ,WorkCode
			 ,IdTerminal
			 ,IdTipoTerminal
             ,IdPrivilegio
             ,Descripcion  
        FROM
		(SELECT 
			  E.IdEmpleado
			 ,Nombre
			 ,Apellido  
             ,FechaLectura  Fecha
			 ,HoraLectura   Hora
			 ,LL.Descripcion Lugar
			 ,T.Descripcion + ' - ' + TT.Descripcion NombreTerminal
			 ,(CASE TipoEntrada WHEN 0 THEN 'Entrada' WHEN 1 THEN 'Salida'  WHEN 2 THEN 'Break Out' WHEN 3 THEN 'Break In' WHEN 4 THEN 'H.E Out' WHEN 5 THEN 'H.E. In'  ELSE 'No' END )AS Entrada
			 ,IdEstadoLectura
			 ,(SELECT Descripcion FROM EPK_ModoVerificacion MV WHERE MV.IDModoVerificacion = L.ModoVerificacion)AS DMV
			 ,WorkCode
			 ,T.IdTerminal
			 ,T.IdTipoTerminal
             ,E.IdPrivilegio
             ,P.Descripcion  
		FROM EPK_LECTURAS L
				 INNER JOIN EPK_Empleados    E  ON(E.IdEmpleado    = L.IdEmpleado)
                 INNER JOIN EPK_Privilegio   P  ON(E.IdPrivilegio  = P.IdPrivilegio)
				 INNER JOIN EPK_Terminal     T  ON(T.IdTerminal    = L.IdTerminal)
				 INNER JOIN EPK_TipoTerminal TT ON (TT.IdTipoTerminal = T.IdTipoTerminal)
				 INNER JOIN EPK_Localidad LL    ON (LL.IdLocalidad = T.IdLocalidad)  
		WHERE 
            (@IdEmpleado       IS NULL OR  @IdEmpleado =   E.IdEmpleado) 
           AND
            (@Nombre           IS NULL OR  E.Nombre LIKE @Nombre) 
           AND
            (@Apellido         IS NULL OR  E.Apellido LIKE @Apellido) 
           AND
            (@IdPrivilegio     IS NULL OR  E.IdPrivilegio = @IdPrivilegio) 
           AND
            (@ModoVerificacion IS NULL OR  @ModoVerificacion =   L.ModoVerificacion) 
           AND
            (@FechaHoraDesde   IS NULL OR  FechaLectura BETWEEN @FechaHoraDesde AND @FechaHoraHasta) 
           AND
            (@IdLocalidad      IS NULL OR  @IdLocalidad  =   LL.IdLocalidad) 
           AND
            (@IdTerminal       IS NULL OR  @IdTerminal   =   L.IdTerminal) 
           AND 
            (@IdDepartamento   IS NULL OR @IdDepartamento= IdDepartamento)
           AND 
            (@IdCargo          IS NULL OR @IdCargo= IdCargo)
         )A
 WHERE (@HoraDesde IS NULL OR (A.Hora BETWEEN @HoraDesde AND @HoraHasta))
ORDER BY Fecha DESC,Hora,Nombre,Apellido
END
END

--select * from EPK_Lecturas
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPKC_sp_ConsultarLecturas] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPKC_sp_ConsultarLecturas] TO PUBLIC
    AS [dbo];

