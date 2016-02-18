--------------------------------------------------------------------------------------------------
/*
  Autor: Ronald Perez
  Fecha: 18/01/2012
  Descripción: Permite inicializar la tabla ventas consolidadas la cual mantienen el monto de ventas consolidadas
               se utiliza para verificar el cambio en el monto de ventas consolidadas y no enviar el mismo monto  
               a traves del Web Service
*/
--------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[SIV_sp_Inicializar_Ventas] 
AS
BEGIN
DECLARE @FechaDesde AS DATETIME
DECLARE @FechaHasta AS DATETIME

SET @FechaDesde = GETDATE()-1
SET @FechaHasta = GETDATE()+1
 WHILE @FechaDesde <= @FechaHasta
 BEGIN
	INSERT INTO [SIV_VentasConsolidadas]
           ([CodTienda]
           ,[FechaDeVenta]
           ,[VentasDia]
           ,[VentasImpuesto]
           ,[CantidadVendida]
           ,[FechaUltimaActualizacion]
           ,[NroTransacciones])
           
	SELECT CodigoTienda, CONVERT(VARCHAR(10),@FechaDesde,101),
			0,0,0,@FechaDesde,0
	FROM  EPK_Tienda WHERE  NOT EXISTS (SELECT FechaDeVenta FROM [SIV_VentasConsolidadas] WHERE 
         CONVERT(VARCHAR(10),FechaDeVenta,101) BETWEEN CONVERT(VARCHAR(10),@FechaDesde,101) AND  CONVERT(VARCHAR(10),@FechaDesde,101))
   SET @FechaDesde = @FechaDesde + 1
END
END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[SIV_sp_Inicializar_Ventas] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[SIV_sp_Inicializar_Ventas] TO PUBLIC
    AS [dbo];

