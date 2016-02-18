
-- ===========================================================
-- Author:		sderkoyorikian
-- Create date: 14/08/2013
-- Description:	Permite consultar las facturas y sus detalles
-- ===========================================================
CREATE PROCEDURE [dbo].[EPK_sp_ReporteComportamientoVta]
(
  @FechaInicio	DATE,
  @FechaFin		  DATE,
  @Intervalo		TINYINT,
  @HoraDesde		TIME		= NULL,
  @HoraHasta		TIME		= NULL
)
AS 
BEGIN
  BEGIN TRY 
    DECLARE @Status			TINYINT

    SET  @Status  = DBO.fn_ObtenerParametroEntero ('FACProcesada', GETDATE(),1)	
    
    SELECT	t.Fecha,						t.HoraInicial,						t.HoraFinal, 
        SUM (t.NroPiezas)TotNroPiezas,	SUM (t.MontoBase) TotMontoBase,		SUM(t.MontoIVA) TotMontoIVA, 
        SUM(t.MontoTotal) TotMontoNeto, AVG (t.MontoTotal) TicketPromedio,	COUNT (t.IdFactura) CantFacturas,	
        AVG(t.NroPiezas) PromPiezasXFactura
    FROM (SELECT	fe.IdFactura , 
            fe.Fecha,  
            DATEADD (MINUTE 
                , ((DATEPART (MINUTE, fe.Hora)/@Intervalo)*@Intervalo)
                , CAST (
                    CAST(
                      DATEPART (HOUR, fe.Hora) 
                      AS VARCHAR(2)) +':00'
                    AS TIME)
                    ) AS HoraInicial,
            DATEADD (MINUTE 
                , ((DATEPART (MINUTE, fe.Hora)/@Intervalo)*@Intervalo)+@Intervalo
                , CAST (
                    CAST(
                      DATEPART (HOUR, fe.Hora) 
                      AS VARCHAR(2)) +':00'
                    AS TIME)
                    ) AS HoraFinal,
            SUM(cantidad) NroPiezas, 
            --SUM(fd.Cantidad*fd.Precio) MontoBase, 
            fe.MontoBase MontoBase, 
            fe.MontoIVA, 
            fe.MontoTotal 
        FROM EPK_FacturaDetalle fd
        INNER JOIN EPK_FacturaEncabezado fe
          ON fe.IdFactura = fd.IdFactura 
        WHERE FE.Fecha between  @FechaInicio  and @FechaFin 
        AND (@HoraDesde IS NULL		OR FE.Hora >= @HoraDesde)
        AND (@HoraHasta IS NULL		OR FE.Hora <= @HoraHasta )
        AND fe.IdEstatus = @Status
        GROUP BY fe.IdFactura, fe.Fecha, fe.Hora, fe.MontoBase, fe.MontoIVA, fe.MontoTotal) AS T
    GROUP BY t.Fecha, t.HoraInicial, t.HoraFinal 
    
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
    ON OBJECT::[dbo].[EPK_sp_ReporteComportamientoVta] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_ReporteComportamientoVta] TO PUBLIC
    AS [dbo];

