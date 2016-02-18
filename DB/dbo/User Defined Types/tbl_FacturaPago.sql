CREATE TYPE [dbo].[tbl_FacturaPago] AS TABLE (
    [IdPago]      INT             NOT NULL,
    [IdFormaPago] TINYINT         NOT NULL,
    [IdFactura]   INT             NOT NULL,
    [IdEntidad]   INT             NULL,
    [IdPOS]       INT             NULL,
    [NumeroPago]  VARCHAR (10)    NULL,
    [Monto]       DECIMAL (18, 2) NOT NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tbl_FacturaPago] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tbl_FacturaPago] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tbl_FacturaPago] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tbl_FacturaPago] TO PUBLIC;



