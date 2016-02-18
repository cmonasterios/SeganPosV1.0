-- =============================================
-- Author:		Ronald Pérez
-- Create date: 12/10/2013
-- Description:	Este método permite obtener las ventas del día
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_VentasConsolidadas]
@FechaDeVenta DATETIME
AS
BEGIN

	DECLARE @CodigoTienda CHAR(10)
	DECLARE @IVA DECIMAL (18,2)
	SET @CodigoTienda =(select TOP 1 CodigoTienda from epk_tienda)
	SET @IVA = (SELECT dbo.fn_ObtenerParametroNumerico('IVA',GETDATE()))
    
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
	,CONVERT(VARCHAR(10), FE.FechaCreacion,112)
	,SerialMF
	, NroReporteZ
	, A.CodigoArticulo, PorcDescuento
	, CASE WHEN SUM(CASE WHEN FD.Cambio = 1 THEN FD.Cantidad *-1 ELSE FD .Cantidad END) > 0 THEN 3 ELSE 4 END TipoDoc
	,'00'+( SELECT MIN(TICKETFISCAL) FROM EPK_FacturaEncabezado FE2 WHERE FE.SerialMF = FE2.SerialMF
	  AND CONVERT(varchar(10), FE.FechaCreacion,112) = CONVERT(varchar(10),FE2.FechaCreacion,112)  AND LEN(TICKETFISCAL)>0 AND IdEstatus =9
	/* AND FE2.Fecha NOT IN (SELECT VD.FechMFiscal FROM EPK_VentasDiarias VD)*/) Desde
	,'00'+( SELECT MAX(TICKETFISCAL) FROM EPK_FacturaEncabezado FE2 WHERE IdEstatus =9 AND FE.SerialMF = FE2.SerialMF 
	  AND CONVERT(varchar(10), FE.FechaCreacion,112) = CONVERT(varchar(10),FE2.FechaCreacion,112)  AND LEN(TICKETFISCAL)>0
	/* AND  FE2.Fecha NOT IN (SELECT VD.FechMFiscal FROM EPK_VentasDiarias VD)*/) Hasta
	, SUM(CASE WHEN FD.Cambio = 1 THEN FD.Cantidad *-1 ELSE FD .Cantidad END)Cantidad
	, SUM(FD.Precio * (CASE WHEN FD.Cambio = 1 THEN FD.Cantidad *-1 ELSE FD .Cantidad END))Base
	, SUM((FD.Precio*(@IVA/100)) * (CASE WHEN FD.Cambio = 1 THEN FD.Cantidad *-1 ELSE FD .Cantidad END))Impuesto
	, SUM((FD.Precio+(FD.Precio*(@IVA/100))) * (CASE WHEN FD.Cambio = 1 THEN FD.Cantidad *-1 ELSE FD .Cantidad END))Neto
	, @IVA PorcentajeIva
	FROM EPK_FacturaEncabezado FE
	INNER JOIN EPK_FacturaDetalle FD ON FE.IdFactura = FD.IdFactura 
	INNER JOIN EPK_Articulo A        ON A.IdArticulo = FD.IdArticulo
	WHERE IdEstatus =9 AND NOT EXISTS (SELECT * FROM EPK_VentasDiarias VD WHERE CONVERT(varchar(10),VD.FechMFiscal,112) =@FechaDeVenta)
	 AND CONVERT(varchar(10), FE.FechaCreacion,112) =@FechaDeVenta
	GROUP BY CONVERT(varchar(10),FE.FechaCreacion,112),SerialMF,NroReporteZ, A.CodigoArticulo, PorcDescuento
	HAVING SUM(CASE WHEN FD.Cambio = 1 THEN FD.Cantidad *-1 ELSE FD .Cantidad END) <> 0

END


--select * from EPK_FacturaDetalle
--where MontoDescuento>0 and 
--IdArticulo in (41481
--,41584)

--select * from EPK_Articulo
--where IdArticulo in (41481
--,41584)
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_VentasConsolidadas] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_VentasConsolidadas] TO PUBLIC
    AS [dbo];

