--////***Marbella Otero***
CREATE PROCEDURE [dbo].[EPK_sp_ReporteResumenDiarioVtas] 
	@FechaDesde		DATE,
	@FechaHasta			DATE,
	@SerialMF	varchar(12) = NULL
AS
BEGIN
	BEGIN TRY 
	SET NOCOUNT ON;

	DECLARE @Status			TINYINT

	SET  @Status  = DBO.fn_ObtenerParametroEntero ('FACProcesada', GETDATE(),1)

SELECT  

		de.SerialMF, 
		de.NroReporteZ as ReporteZ ,
		
		MAX(de.COO)as COO  ,
		(select count(d.TicketFiscal)from EPK_FacturaEncabezado as d where d.Fecha between @FechaDesde and @FechaHasta
		and d.IdEstatus=@Status and d.SerialMF=de.SerialMF and d.NroReporteZ=de.NroReporteZ) as FacturasEmitidas,
		
		MIN(de.TicketFiscal) Desde,
		MAX(de.TicketFiscal) Hasta,
		
		(select distinct sum(d.MontoBase)from EPK_FacturaEncabezado as d where d.Fecha between @FechaDesde and @FechaHasta
		and d.IdEstatus=@Status and d.SerialMF=de.SerialMF and d.NroReporteZ=de.NroReporteZ)as MontoBase,
   		
   		(select sum(d.Precio*d.Cantidad)from EPK_FacturaDetalle as d inner join EPK_FacturaEncabezado AS e ON e.IdFactura = d.IdFactura 
   		where e.Fecha between @FechaDesde and @FechaHasta and e.IdEstatus=@Status and d.Exento=1 
   		and e.SerialMF=de.SerialMF and e.NroReporteZ=de.NroReporteZ)as Exento,
        
        (select distinct sum(d.MontoIVA)from EPK_FacturaEncabezado as d where d.Fecha between @FechaDesde and @FechaHasta
		and d.IdEstatus=@Status and d.SerialMF=de.SerialMF and d.NroReporteZ=de.NroReporteZ) as MontoIVA,
		
		(select distinct sum(d.MontoTotal)from EPK_FacturaEncabezado as d where d.Fecha between @FechaDesde and @FechaHasta
		and d.IdEstatus=@Status and d.SerialMF=de.SerialMF and d.NroReporteZ=de.NroReporteZ) as MontoTotal,
        
         (select distinct sum(nc.MontoBase)from EPK_NotaCreditoEncabezado as nc where nc.Fecha between @FechaDesde and @FechaHasta
        and nc.SerialMF=de.SerialMF and nc.NroReporteZ=de.NroReporteZ)as ncbig,
        
        (select distinct sum(nc.MontoIVA)from EPK_NotaCreditoEncabezado as nc where nc.Fecha between @FechaDesde and @FechaHasta
        and nc.SerialMF=de.SerialMF and nc.NroReporteZ=de.NroReporteZ) as ivanc,
		
		(select distinct sum(nc.MontoTotal)from EPK_NotaCreditoEncabezado as nc where nc.Fecha between @FechaDesde and @FechaHasta
		and nc.SerialMF=de.SerialMF and nc.NroReporteZ=de.NroReporteZ) as totalnc

FROM		dbo.EPK_FacturaDetalle AS df INNER JOIN
            dbo.EPK_FacturaEncabezado AS de ON df.IdFactura = de.IdFactura left join
            dbo.EPK_NotaCreditoEncabezado as nce ON de.IdFactura = nce.IdFactura left join
            dbo.EPK_NotaCreditoDetalle as ncd ON nce.IdNotaC = ncd.IdNotaC
            where df.Cambio=0 and de.Fecha between @FechaDesde and @FechaHasta
            and de.IdEstatus=@Status
			AND 	(@SerialMF = '' OR de.SerialMF			= @SerialMF)

           group by
		de.SerialMF, de.NroReporteZ
		
		RETURN 1
		END TRY
			BEGIN CATCH
		EXEC EPK_sp_LogErroresGenerar @@SPID
		SELECT 'Linea de error: '+ CAST(ERROR_LINE() as varchar(4)) +' - Nro error: '+ CAST (ERROR_NUMBER () as varchar(30))+' - Mensaje de error: '+ ERROR_MESSAGE () 
		RETURN 0
	END CATCH

END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_ReporteResumenDiarioVtas] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteResumenDiarioVtas] TO PUBLIC
    AS [dbo];

