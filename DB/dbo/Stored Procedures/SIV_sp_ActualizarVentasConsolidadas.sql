
CREATE PROCEDURE [dbo].[SIV_sp_ActualizarVentasConsolidadas]
 AS
 BEGIN
    --------------------------------------------------------------------------------------------------
    --------------------------------------------------------------------------------------------------
    DECLARE @FECHADEVENTA DATETIME 
    SET @FECHADEVENTA = GETDATE()

    CREATE TABLE #TEMP(
	    [Base] [decimal](18, 2) NULL,
	    [IVA] [decimal](18, 2) NULL,
	    [Total] [decimal](18, 2) NULL,
	    [NroTrans] [int] NULL,
	    [FechaFactura] [datetime] NULL,
	    [Piezas] [int] NULL
    )

    INSERT INTO #TEMP 
        (Base      ,IVA      ,Total      ,NroTrans      ,FechaFactura      ,Piezas)
    SELECT  SUM(MontoBase) Base
           ,SUM(MontoIVA) IVA 
        ,SUM(MontoTotal) Total
        ,COUNT(DISTINCT FE.IdFactura) NroTrans
        ,MAX(FechaCreacion) FechaFactura
        ,SUM(DET.Piezas) Piezas
    FROM EPK_FacturaEncabezado FE 
    INNER JOIN 		
        (SELECT FE2.IdFactura,SUM(CASE WHEN Cambio =1 THEN -Cantidad ELSE Cantidad END) Piezas 
        FROM EPK_FacturaDetalle FD 
        INNER JOIN EPK_FacturaEncabezado FE2 ON FE2.IdFactura = FD.IdFactura 
        WHERE IdEstatus = DBO.fn_ObtenerParametroEntero ('FACProcesada',FE2.FECHA,1) 
        AND CONVERT(VARCHAR(10),FE2.FechaCreacion,112) = CONVERT(VARCHAR(10),@FECHADEVENTA,112)
        GROUP BY FE2.IdFactura) DET
    ON FE.IdFactura = DET.IdFactura 
    WHERE IdEstatus =DBO.fn_ObtenerParametroEntero ('FACProcesada',FE.FECHA,1)  
    AND  CONVERT(VARCHAR(10),FE.FechaCreacion,112) = CONVERT(VARCHAR(10),@FECHADEVENTA,112)


    MERGE #temp AS target
    USING (SELECT  SUM(-MontoBase) Base
                   ,SUM(-MontoIVA) IVA 
                ,SUM(-MontoTotal) Total
                ,0 NroTrans
                ,MAX(FechaCreacion) FechaFactura
                ,-SUM(DET.Piezas)
            FROM EPK_NotaCreditoEncabezado NE 
            INNER JOIN 		
                (SELECT NE2.IdNotaC ,SUM(CASE WHEN Cambio =1 THEN -Cantidad ELSE Cantidad END) Piezas 
                FROM EPK_NotaCreditoDetalle  ND 
                INNER JOIN EPK_NotaCreditoEncabezado  NE2 ON NE2.IdNotaC  = ND.IdNotaC
                WHERE IdEstatus = DBO.fn_ObtenerParametroEntero ('NCEmitida',NE2.FECHA,1) 
                AND CONVERT(VARCHAR(10),NE2.FechaCreacion,112) = CONVERT(VARCHAR(10),@FECHADEVENTA,112)
                GROUP BY NE2.IdNotaC) DET
            ON NE.IdNotaC = DET.IdNotaC
            WHERE IdEstatus =DBO.fn_ObtenerParametroEntero ('NCEmitida',Ne.FECHA,1)  
            AND  CONVERT(VARCHAR(10),NE.FechaCreacion,112) = CONVERT(VARCHAR(10),@FECHADEVENTA,112))
    AS source (Base, IVA, Total, NroTrans, FechaFactura, Piezas)
    ON (cast (target.FechaFactura as date) = cast (source.FechaFactura as date ) )
    WHEN MATCHED THEN 
        UPDATE SET  Base    = target.Base + source.Base,
                    IVA     = target.IVA + source.IVA,
                    Total   = target.Total + source.Total,
                    NroTrans = target.NroTrans + source.NroTrans,
                    Piezas  = target.Piezas + source.Piezas
    WHEN NOT MATCHED THEN	
        INSERT (Base, IVA, Total, NroTrans, FechaFactura, Piezas)
        VALUES (source.Base, source.IVA, source.Total,
                source.NroTrans, source.FechaFactura, source.Piezas);

select * from #TEMP 
    DELETE #TEMP WHERE base IS NULL 
select * from #TEMP 

    MERGE SIV_VentasConsolidadas AS Target
    USING (SELECT Base, IVA, Total, NroTrans, FechaFactura, Piezas FROM #TEMP )
    AS source (Base, IVA, Total, NroTrans, FechaFactura, Piezas)
    ON (cast (target.FechaDeVenta as date ) = cast (source.FechaFactura as date ))
    WHEN MATCHED THEN 
    UPDATE SET
        VentasDia		    = source.Total
        ,VentasImpuesto	    = source.Iva
        ,CantidadVendida    = source.Piezas
        ,NroTransacciones   = source.NroTrans
        ,FechaUltimaActualizacion= @FECHADEVENTA
        ,FechaHoraUltFactura = source.FechaFactura
    WHEN NOT MATCHED THEN 
        INSERT (CodTienda,      FechaDeVenta,           VentasDia,          VentasImpuesto,
                CantidadVendida,FechaUltimaActualizacion,NroTransacciones,  FechaHoraUltFactura)
        VALUES((SELECT TOP 1 CodigoTienda from EPK_Tienda), source.FechaFactura,
                source.Total, source.IVA, 
                source.Piezas, @FECHADEVENTA, source.NroTrans, source.FechaFactura);
    --    ,FechaHoraUltFactura = source.FechaFactura
    --INNER JOIN #TEMP T
    --ON CONVERT(VARCHAR(10),SIV.FechaDeVenta,112)      = T.FechaFactura 
    --       AND SIV.VentasDia   <>  T.Total
    
    DROP TABLE #TEMP 
END
GO



GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[SIV_sp_ActualizarVentasConsolidadas] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[SIV_sp_ActualizarVentasConsolidadas] TO PUBLIC
    AS [dbo];

