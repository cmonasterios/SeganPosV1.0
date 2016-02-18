-- =============================================
-- Author:		Ronald Pérez
-- Create date: 12/10/2013
-- Description:	Este método permite obtener las ventas del día que serán enviadas a Dynamics
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_VentasDynamics]
	@FechaDeVentaDesde DATETIME
  , @FechaDeVentaHasta DATETIME
AS
BEGIN

	DECLARE @CodigoTienda CHAR(10)
	DECLARE @IVA DECIMAL (18,2)
	SET @CodigoTienda =(select TOP 1 CodigoTienda from epk_tienda)
	SET @IVA = (SELECT dbo.fn_ObtenerParametroNumerico('IVA',GETDATE()))
	
    ---- se almacena de forma temporal las ventas que seran sincronizadasa
    INSERT INTO [EPK_VentasDiarias]
           ([CodTienda]
           ,[FechMFiscal]
           ,[CodMFiscal]
           ,[NroZ]
           ,[CodArticulo]
           ,[Descuento]
           ,[TipoDocumento]
           ,[DFactura]
           ,[HFactura]
           ,[AcumCantidad]
           ,[PrecioBase]
           ,[PrecioIVA]
           ,[PrecioTotal]
           ,[PorcIVA])
  
	SELECT 
	  @CodigoTienda CodigoTienda
	, CONVERT(VARCHAR(10), FE.FechaCreacion,112)
	, SerialMF
	, CAST(NroReporteZ AS INT) NroReporteZ
	, A.CodigoArticulo, PorcDescuento
	, CASE WHEN SUM(CASE WHEN FD.Cambio = 1 THEN FD.Cantidad *-1 ELSE FD .Cantidad END) > 0 THEN 3 ELSE 4 END TipoDoc
	, (SELECT MIN(TICKETFISCAL) FROM EPK_FacturaEncabezado FE2 WHERE FE.SerialMF = FE2.SerialMF
	  AND CONVERT(varchar(10), FE.FechaCreacion,112) = CONVERT(varchar(10),FE2.FechaCreacion,112)  AND LEN(TICKETFISCAL)>0 AND IdEstatus =9) Desde
	, (SELECT MAX(TICKETFISCAL) FROM EPK_FacturaEncabezado FE2 WHERE IdEstatus =9 AND FE.SerialMF = FE2.SerialMF 
	  AND CONVERT(varchar(10), FE.FechaCreacion,112) = CONVERT(varchar(10),FE2.FechaCreacion,112)  AND LEN(TICKETFISCAL)>0) Hasta
	, SUM(CASE WHEN FD.Cambio = 1 THEN FD.Cantidad *-1 ELSE FD .Cantidad END)                                        Cantidad
	, SUM(FD.Precio * (CASE WHEN FD.Cambio = 1 THEN FD.Cantidad *-1 ELSE FD .Cantidad END))                          Base
	, SUM((FD.Precio*(@IVA/100)) * (CASE WHEN FD.Cambio = 1 THEN FD.Cantidad *-1 ELSE FD .Cantidad END))             Impuesto
	, SUM((FD.Precio+(FD.Precio*(@IVA/100))) * (CASE WHEN FD.Cambio = 1 THEN FD.Cantidad *-1 ELSE FD .Cantidad END)) Neto
	, @IVA																										  	 PorcentajeIva
	FROM EPK_FacturaEncabezado FE	      INNER JOIN
	     EPK_FacturaDetalle FD 
	      ON FE.IdFactura = FD.IdFactura  INNER JOIN 
	     EPK_Articulo A       
	      ON A.IdArticulo = FD.IdArticulo
	WHERE 
	    IdEstatus =9 -- sólo facturas procesadas
	 AND--- Si no se ha procesado las ventas para Dynamics
	    NOT EXISTS (SELECT TOP 1* FROM EPK_VentasDiarias VD WHERE VD.FechMFiscal BETWEEN @FechaDeVentaDesde AND @FechaDeVentaHasta)
	 AND--- Si existe el cierre de ventas del día 
	    EXISTS ( SELECT * FROM EPK_CierreVentaEncabezado CVE WHERE CVE.Fecha  BETWEEN @FechaDeVentaDesde AND @FechaDeVentaHasta)     
	 AND
	    CONVERT(varchar(10), FE.FechaCreacion,112) BETWEEN @FechaDeVentaDesde AND @FechaDeVentaHasta
	    
	GROUP BY 
	      CONVERT(varchar(10),FE.FechaCreacion,112)
	    , SerialMF
	    , NroReporteZ
	    , A.CodigoArticulo
	    , PorcDescuento
	HAVING SUM(CASE WHEN FD.Cambio = 1 THEN FD.Cantidad *-1 ELSE FD .Cantidad END) <> 0

END
GO



GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_VentasDynamics] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_VentasDynamics] TO PUBLIC
    AS [dbo];

