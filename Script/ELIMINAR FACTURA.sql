DECLARE @IDFact INT 
SELECT @IDFact = MAX (IdFactura) FROM EPK_FacturaEncabezado
SELECT @IDFact

DELETE EPK_FacturaDetalle		WHERE IdFactura = @IDFact
DELETE EPK_FacturaPago			WHERE IdFactura = @IDFact
DELETE EPK_FacturaEncabezado	WHERE IdFactura = @IDFact

SELECT @IDFact = MAX (IdFactura) FROM EPK_FacturaEncabezado
DBCC CHECKIDENT (EPK_FacturaEncabezado, RESEED, @IDFact)
SELECT @IDFact
