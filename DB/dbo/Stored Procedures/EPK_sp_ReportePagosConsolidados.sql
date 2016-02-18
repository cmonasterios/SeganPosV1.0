-- =============================================
-- Author:		sderkoyorikian
-- Create date: 12/08/2013
-- Description:	Consulta los pagos consolidados
-- =============================================
CREATE PROCEDURE [dbo].[EPK_sp_ReportePagosConsolidados] 
	@FechaDesde date,
	@FechaHasta date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT p.IdFormaPago, fp.Descripcion FormaPago, ISNULL (e.Nombre , '' ) Entidad,  SUM(Monto) Monto
	FROM EPK_FacturaPago P
	INNER JOIN EPK_FormaPago FP
		ON p.IdFormaPago = fp.IdFormaPago 
	LEFT JOIN EPK_POS POS
		ON p.IdPOS = pos.IdPOS 
	LEFT JOIN EPK_EntidadFinanciera E
		ON pos.IdEntidad = e.IdEntidad 	
	WHERE	IdFactura in (SELECT IdFactura FROM EPK_FacturaEncabezado WHERE Fecha BETWEEN @FechaDesde AND @FechaHasta) 
	GROUP BY p.IdFormaPago, fp.Descripcion, ISNULL (e.Nombre , '' ) 
	ORDER BY p.IdFormaPago, ISNULL (e.Nombre , '' ) 

	SELECT p.IdPOS, pos.Descripcion POS, P.IdFormaPago, fp.Descripcion FormaPago, SUM(Monto) Monto
	FROM EPK_FacturaPago P
	INNER JOIN EPK_POS POS
		ON p.IdPOS = pos.IdPOS 
	INNER JOIN EPK_FormaPago FP
		ON P.IdFormaPago = FP.IdFormaPago 
	WHERE	IdFactura in (SELECT IdFactura FROM EPK_FacturaEncabezado WHERE Fecha BETWEEN @FechaDesde AND @FechaHasta) 
		AND p.IdPOS is not  null
	GROUP BY p.IdPOS, pos.Descripcion,  P.IdFormaPago, fp.Descripcion
	ORDER BY pos.Descripcion, P.IdFormaPago
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ReportePagosConsolidados] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReportePagosConsolidados] TO PUBLIC
    AS [dbo];

