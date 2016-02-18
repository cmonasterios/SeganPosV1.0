/* Limpieza de tablas para actualización masiva */
DELETE  EPK_ActualizacionColeccion 

DELETE  EPK_ActualizacionArticulo



DELETE  EPK_LogActualizacion 
DBCC CHECKIDENT (EPK_LogActualizacion , RESEED, 0)

DELETE  EPK_ActualizacionEncabezado 


/* Limpieza de tablas para facturas y NC */
DELETE  EPK_NotaCreditoDetalle 

DELETE  EPK_NotaCreditoEncabezado 
DBCC CHECKIDENT (EPK_NotaCreditoEncabezado, RESEED, 0)

DELETE  EPK_FacturaPago 
DBCC CHECKIDENT (EPK_FacturaPago, RESEED, 0)

DELETE  EPK_FacturaDetalle 

DELETE  EPK_FacturaEncabezado 
DBCC CHECKIDENT (EPK_FacturaEncabezado, RESEED, 0)


/*  Limpieza de tablas financieras */
DELETE EPK_AlivioEfectivoDetalle 
DELETE EPK_AlivioEfectivoEncabezado
DBCC CHECKIDENT (EPK_AlivioEfectivoEncabezado, RESEED, 0)

DELETE EPK_AperturaCajeroDenominacion 

DELETE EPK_AperturaCajeroEncabezado
DBCC CHECKIDENT (EPK_AperturaCajeroEncabezado, RESEED, 0)

DELETE  EPK_CierreCajeroPOS 

DELETE EPK_CierreCajeroPagos

DELETE EPK_CierreCajeroDenominacion

DELETE EPK_CierreCajeroEncabezado 
DBCC CHECKIDENT (EPK_CierreCajeroEncabezado, RESEED, 0)

DELETE EPK_CierreVentaPagos
DELETE EPK_CierreVentaPOS
DELETE EPK_CierreVentaEncabezado
DBCC CHECKIDENT (EPK_CierreVentaEncabezado, RESEED, 0)

DELETE EPK_CierreMaquinaFiscal
DBCC CHECKIDENT (EPK_CierreMaquinaFiscal, RESEED, 0)

DELETE dbo.EPK_Depositodetalle 

DELETE dbo.EPK_DepositoEncabezado

DELETE EPK_AlivioEfectivoDetalle

DELETE EPK_AlivioEfectivoEncabezado 
DBCC CHECKIDENT (EPK_AlivioEfectivoEncabezado, RESEED, 0)

DELETE EPK_EfectivoRemanenteDetalle

DELETE EPK_EfectivoRemanenteEncabezado 
DBCC CHECKIDENT (EPK_EfectivoRemanenteEncabezado, RESEED, 0)

DELETE EPK_FacturaEsperaDetalle   
DELETE EPK_FacturaEsperaEncabezado   
DBCC CHECKIDENT (EPK_FacturaEsperaEncabezado, RESEED, 0)

truncate table [dbo].[EPK_Auditoria]
