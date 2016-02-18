
BEGIN TRAN
/*Clientes*/
--DELETE EPK_ClienteTelefono
--DBCC CHECKIDENT (EPK_ClienteTelefono , RESEED, 0)

--DELETE EPK_Cliente
--DBCC CHECKIDENT (EPK_Cliente , RESEED, 0)

/* Limpieza de tablas para actualización masiva */
DELETE  EPK_ActualizacionColeccion 

DELETE  EPK_ActualizacionArticulo

IF (SELECT COUNT(1) FROM EPK_LogActualizacion) >0 
	BEGIN 
	DELETE  EPK_LogActualizacion 
	DBCC CHECKIDENT (EPK_LogActualizacion , RESEED, 0)		
	END

DELETE  EPK_ActualizacionEncabezado 


/* Limpieza de tablas para facturas y NC */
DELETE EPK_DepositoCheque 

DELETE  EPK_NotaCreditoDetalle 
IF (SELECT COUNT(1) FROM EPK_NotaCreditoEncabezado) >0 
	BEGIN 
	DELETE  EPK_NotaCreditoEncabezado 
	DBCC CHECKIDENT (EPK_NotaCreditoEncabezado, RESEED, 0)	
	END


IF (SELECT COUNT(1) FROM EPK_FacturaPago) >0 
	BEGIN 
	DELETE  EPK_FacturaPago 
	DBCC CHECKIDENT (EPK_FacturaPago, RESEED, 0)	
	END

DELETE  EPK_FacturaDetalle 
IF (SELECT COUNT(1) FROM EPK_FacturaEncabezado) >0 
	BEGIN 
	DELETE  EPK_FacturaEncabezado
	DBCC CHECKIDENT (EPK_FacturaEncabezado, RESEED, 0)	
	END


DELETE EPK_FacturaEsperaDetalle
IF (SELECT COUNT(1) FROM EPK_FacturaEsperaEncabezado) >0 
	BEGIN 
	DELETE EPK_FacturaEsperaEncabezado
	DBCC CHECKIDENT (EPK_FacturaEsperaEncabezado, RESEED, 0)	
	END


DELETE EPK_AperturaCajeroDenominacion 
IF (SELECT COUNT(1) FROM EPK_AperturaCajeroEncabezado) >0 
	BEGIN 
	DELETE EPK_AperturaCajeroEncabezado
	DBCC CHECKIDENT (EPK_AperturaCajeroEncabezado, RESEED, 0)	
	END


DELETE  EPK_CierreCajeroPOS 

DELETE EPK_CierreCajeroPagos

DELETE EPK_CierreCajeroDenominacion
IF (SELECT COUNT(1) FROM EPK_CierreCajeroEncabezado) >0 
	BEGIN 
	DELETE EPK_CierreCajeroEncabezado 
	DBCC CHECKIDENT (EPK_CierreCajeroEncabezado, RESEED, 0)	
	END


DELETE EPK_CierreVentaPOS 
DELETE EPK_CierreVentaPagos 
IF (SELECT COUNT(1) FROM EPK_CierreVentaEncabezado) >0 
	BEGIN 
	DELETE EPK_CierreVentaEncabezado 
	DBCC CHECKIDENT (EPK_CierreVentaEncabezado, RESEED, 0)	
	END


DELETE dbo.EPK_Depositodetalle 

DELETE dbo.EPK_DepositoEncabezado

DELETE EPK_AlivioEfectivoDetalle
IF (SELECT COUNT(1) FROM EPK_AlivioEfectivoEncabezado) >0 
	BEGIN 
	DELETE EPK_AlivioEfectivoEncabezado 
	DBCC CHECKIDENT (EPK_AlivioEfectivoEncabezado, RESEED, 0)	
	END


DELETE EPK_EfectivoRemanenteDetalle
IF (SELECT COUNT(1) FROM EPK_EfectivoRemanenteEncabezado) >0 
	BEGIN 
	DELETE EPK_EfectivoRemanenteEncabezado 
	DBCC CHECKIDENT (EPK_EfectivoRemanenteEncabezado, RESEED, 0)	
	END

IF (SELECT COUNT(1) FROM EPK_CierreMaquinaFiscal) >0 
	BEGIN 
	DELETE EPK_CierreMaquinaFiscal
	DBCC CHECKIDENT (EPK_CierreMaquinaFiscal, RESEED, 0)	
	END


DELETE EPK_FlujoEfectivoDetalle
IF (SELECT COUNT(1) FROM EPK_FlujoEfectivo) >0 
	BEGIN 
	DELETE EPK_FlujoEfectivo
	DBCC CHECKIDENT (EPK_FlujoEfectivo, RESEED, 0)	
	END


--ROLLBACK TRAN 

--COMMIT TRAN
