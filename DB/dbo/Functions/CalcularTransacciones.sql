-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[CalcularTransacciones] 
(
	-- Add the parameters for the function here
	@CodigoTienda VARCHAR(20),
    @FechaDesde   DATETIME,
    @FechaHasta   DATETIME
)
RETURNS INT 
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ResultVar INT
   

SET @ResultVar = (
  SELECT SUM(distinct (ABS((CONVERT(INT,HFactura)  - CONVERT(INT,DFactura)))+ 1)) FROM 
           ACUMULADOVENTASDIARIAS  WHERE CODTIENDA = @CodigoTienda AND CONVERT(VARCHAR(10),FechMFiscal,101) BETWEEN CONVERT(VARCHAR(10),@FechaDesde,101) and CONVERT(VARCHAR(10),@FechaHasta,101)
)

/*
DECLARE Transacciones CURSOR  FOR

   SELECT distinct  FechMFiscal, CODMFISCAL,(ABS((CONVERT(INT,HFactura)  - CONVERT(INT,DFactura)))+ 1) AS CANTIDAD FROM 
           ACUMULADOVENTASDIARIAS  WHERE CODTIENDA = @CodigoTienda AND CONVERT(VARCHAR(10),FechMFiscal,101) BETWEEN CONVERT(VARCHAR(10),@FechaDesde,101) and CONVERT(VARCHAR(10),@FechaHasta,101)
      ORDER BY  FechMFiscal, CODMFISCAL
      OPEN  Transacciones; 
        FETCH NEXT FROM Transacciones INTO
                 @Fecha
				,@CodigoMF
                ,@Valor
        SET @ResultVar = @ResultVar +@Valor

	     WHILE @@FETCH_STATUS = 0 
		 BEGIN
              FETCH NEXT FROM Transacciones INTO
                 @Fecha
				,@CodigoMF
		     	,@Valor
              SET @ResultVar = @ResultVar +@Valor
         END
          SET @ResultVar = @ResultVar - @Valor
         CLOSE Transacciones;
         DEALLOCATE Transacciones;  
	-- Return the result of the function*/
	RETURN @ResultVar

 END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[CalcularTransacciones] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[CalcularTransacciones] TO PUBLIC
    AS [dbo];

