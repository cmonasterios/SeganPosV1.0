
--===============================================
-- Author:		sderkoyorikian
-- Create date: 12/09/2013
-- Description:	Reporte para apertura de cajeros.
-- ===============================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteAperturaCajero] 
	@FechaDesde		DATE,
	@FechaHasta		DATE,
	@IdCaja			INT = NULL,
	@Cajero		    VARCHAR(50)=NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT U.Identificacion Cajero, ACE.IdApertura, ACE.fecha Fecha,
			CAST((CAST(DATEPART(HOUR, ACE.hora) AS VARCHAR(2))+':'+CAST(DATEPART(MINUTE,ACE.hora) AS VARCHAR(2))) AS TIME)Hora, 
			C.Descripcion Caja,  D.Denominacion, AD.Cantidad, D.Denominacion * AD.Cantidad  Total
	FROM  EPK_AperturaCajeroEncabezado ACE
	INNER JOIN EPK_AperturaCajeroDenominacion AD
		ON ACE.IdApertura = AD.IdApertura 
	INNER JOIN EPK_Denominacion D
		ON AD.IdDenominacion = D.IdDenominacion 
	INNER JOIN EPK_Usuario U
		ON ACE.IdCajero = U.IdUsuario 	
	 INNER JOIN EPK_Caja C
		ON ACE.IdCaja = C.IdCaja 
	WHERE (Fecha BETWEEN @FechaDesde AND @FechaHasta)
	AND (@Cajero IS NULL OR U.Identificacion LIKE '%'+@Cajero+'%')
	AND (@IdCaja IS NULL OR ACE.IdCaja = @IdCaja)
	
	--DECLARE @hijos varchar(max)		= ''
	--DECLARE @cabecera varchar(max)	= ''
	--DECLARE @CONSULTA varchar(max)	= ''
	----DECLARE @FILTRO varchar(1000)	= 'WHERE Fecha BETWEEN '''+ CONVERT (VARCHAR(10), @FechaDesde, 112) +''' AND '''+  CONVERT (VARCHAR(10), @FechaHasta , 112) +''''
	--DECLARE @FILTRO varchar(1000)	= 'WHERE Fecha BETWEEN '''+ @FechaDesde +''' AND '''+  @FechaHasta  +''''
	--PRINT @FILTRO
	--IF @IdCaja IS NOT NULL 
	--	SET @FILTRO = @FILTRO  +' AND IdCaja ='+ CAST (@IdCaja AS VARCHAR(10))
	--IF @IdCajero IS NOT NULL 
	--	SET @FILTRO = @FILTRO  +' AND IdCajero ='+ CAST (@IdCajero AS VARCHAR(10))

	
	--/* llenado de cadena para formato de pivot */
	--SELECT @hijos = @hijos+'[' + CAST (IdDenominacion AS VARCHAR(10))+'],' 
	--FROM EPK_Denominacion

	--SET @hijos = SUBSTRING(@hijos,1,LEN(@hijos)-1)
	----PRINT(@hijos)


	--/* llenado de cadena para formato  equivalencias y encabezado de pivot */
	--SELECT @cabecera = @cabecera+'[' +CAST (IdDenominacion AS VARCHAR(10))+'] AS '+ '['+CAST (Denominacion AS VARCHAR(20))+'],' 
	--FROM EPK_Denominacion

	--SET @cabecera = SUBSTRING(@cabecera,1,LEN(@cabecera)-1)
	----PRINT (@cabecera)

	--/* llenado de cadena con el query a ejecutar */
	--SET @CONSULTA=
	--'SELECT U.Identificacion Cajero, ACE.fecha, ACE.hora, C.Descripcion Caja,  t.*
	-- FROM  EPK_AperturaCajeroEncabezado ACE
	-- INNER JOIN  (SELECT IdApertura,'+ @cabecera +
	--			 ' FROM (	SELECT D.* 
	--				FROM EPK_AperturaCajeroDenominacion D 
	--				INNER JOIN EPK_AperturaCajeroEncabezado E
	--					ON D.IdApertura = E.IdApertura 
	--				'+ @FILTRO +' 
	--				) TA  
	--			 PIVOT (SUM(Cantidad) FOR IdDenominacion IN('+ @HIJOS +'))AS Hijo ) t 
	--	ON ACE.IdApertura = t.IdApertura
	-- INNER JOIN EPK_Usuario U
	--	ON ACE.IdCajero = U.IdUsuario 
	-- INNER JOIN EPK_Caja C
	--	ON ACE.IdCaja = C.IdCaja '
 
	-- PRINT  @CONSULTA
	-- EXECUTE( @CONSULTA) 
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ReporteAperturaCajero] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteAperturaCajero] TO PUBLIC
    AS [dbo];

