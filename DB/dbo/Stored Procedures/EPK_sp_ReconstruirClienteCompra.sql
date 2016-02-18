
-- ==================================================================================
-- Author:		Sderkoyorikian
-- Create date: 29/01/2015
-- Description:	Actualiza las compras acumuladas por cliente para las restricciones.
-- ==================================================================================
CREATE PROCEDURE [dbo].[EPK_sp_ReconstruirClienteCompra]
AS
BEGIN
	BEGIN TRY 
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		DECLARE @Dias TINYINT, @FacProc INT, @NcProc INT 
        DECLARE @Fecha  DATE = GETDATE ()
        DECLARE @FechaC DATETIME = GETDATE ()

        SELECT @Dias = dbo.fn_ObtenerParametroEntero ('DiasRestriccion',getdate(), 1)
        SELECT @FacProc = dbo.fn_ObtenerParametroEntero ('FACProcesada',getdate(), 1)
        SELECT @NcProc = dbo.fn_ObtenerParametroEntero ('NCEmitida',getdate(), 1)
        

        TRUNCATE TABLE EPK_ClienteCompra

        INSERT INTO EPK_ClienteCompra 
        (IdTipoDocumento, NumeroDocumento , IdArticulo, Cantidad, FechaUltAct )
        SELECT IdTipoDocumento, NumeroDocumento, FD.IdArticulo, CASE WHEN SUM (CASE WHEN cambio = 0 THEN cantidad ELSE -cantidad END)>0 
																  THEN SUM (CASE WHEN cambio = 0 THEN cantidad ELSE -cantidad END)
																  ELSE 0 END , @FechaC
        FROM EPK_FacturaEncabezado fe
        INNER JOIN EPK_FacturaDetalle fd
            ON fe.IdFactura = fd.IdFactura 
            AND FE.IdEstatus = @FacProc
        INNER JOIN EPK_Articulo A
			ON FD.IdArticulo = A.IdArticulo
		INNER JOIN EPK_Referencia R
			ON A.IdReferencia = R.IdReferencia
		INNER JOIN EPK_Grupo G
			ON R.IdGrupo = G.IdGrupo
		INNER JOIN EPK_TipoPrenda TP 
			ON G.IdTipoPrenda = TP.IdTipoPrenda
			AND TP.RestriccionVenta=1
        WHERE Fecha between DATEADD(DAY, -@Dias, @Fecha) and @Fecha		
        GROUP BY IdTipoDocumento, NumeroDocumento, FD.IdArticulo

        UPDATE CC
        SET Cantidad = CASE WHEN (cantidad -t.Cant)>0 THEN cantidad -t.Cant ELSE 0 END,
            FechaUltAct =t.FechaUltAct 
        FROM EPK_ClienteCompra CC
        INNER JOIN 
            (SELECT IdTipoDocumento, NumeroDocumento, IdArticulo, SUM (CASE WHEN cambio = 0 THEN cantidad ELSE -cantidad END) Cant, @Fecha FechaUltAct
            FROM EPK_NotaCreditoEncabezado  NE
            INNER JOIN EPK_NotaCreditoDetalle ND
                ON NE.IdNotaC  = ND.IdNotaC
                AND NE.IdTienda = ND.IdTienda
                AND NE.IdFactura = @NcProc  
            INNER JOIN EPK_FacturaEncabezado FE
                ON FE.IdFactura = NE.IdFactura 
                AND FE.IdTienda = NE.IdTienda 
            WHERE NE.Fecha BETWEEN DATEADD(DAY, -@Dias, @Fecha) AND @Fecha
            GROUP BY IdTipoDocumento, NumeroDocumento, IdArticulo) T
        ON CC.IdTipoDocumento = T.IdTipoDocumento 
        AND CC.NumeroDocumento = T.NumeroDocumento 
        AND CC.IdArticulo = T.IdArticulo 

        UPDATE EPK_ClienteCompra
        SET cantidad = 0 
        WHERE cantidad  <0
	END TRY 
	BEGIN CATCH
		EXEC EPK_sp_LogErroresGenerar @@SPID
		SELECT 'Linea de error: '+ CAST(ERROR_LINE() as varchar(4)) +' - Nro error: '+ CAST (ERROR_NUMBER () as varchar(30))+' - Mensaje de error: '+ ERROR_MESSAGE () 
		RETURN 0
	END CATCH
END
GO



GO


