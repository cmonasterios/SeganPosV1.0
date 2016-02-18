/*
Autor: Silvia Derkoyorikian
Fecha:29/10/2015
Descripción: permite obtener  COO y el Serial de Máquina fiscal de la última factura con el precio original 
			 y de la última factura con el precio en descuento en las cuales se ha incluido un mismo artículo. 
*/

SELECT a.CodigoArticulo, Precio, max(IdFactura) IdFactura
INTO #temp 
FROM epk_facturadetalle fd
INNER JOIN EPK_Articulo a
	ON fd.IdArticulo = a.IdArticulo 
	AND a.CodigoArticulo like '215%' 
GROUP BY a.CodigoArticulo, Precio 
ORDER BY 1 ,3 

SELECT t.CodigoArticulo, t.Precio PrecioActual, t.IdFactura FacturaActual, FE.SerialMF SerialMFActual, fe.COO cooActual, fe.Fecha FechaActal,
		t2.Precio PrecioAnterior, t2.IdFactura FacturaAnterior, FE2.SerialMF SerialMFAnterior, fe2.COO cooAnterior, fe2.Fecha FechaAnterior
FROM #temp t
INNER JOIN #temp t2
	ON t.CodigoArticulo = t2.CodigoArticulo 
	AND t.Precio <t2.Precio 
INNER JOIN EPK_FacturaEncabezado fe
	ON t.idfactura = fe.IdFactura 
INNER JOIN EPK_FacturaEncabezado fe2
	ON t2.IdFactura = fe2.idfactura 

DROP TABLE #temp 