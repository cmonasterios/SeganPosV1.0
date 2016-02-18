CREATE TYPE [dbo].[tmp_TTiendaFPago] AS TABLE (
    [IdTipoTienda] INT NOT NULL,
    [IdFormaPago]  INT NOT NULL,
    [Activa]       BIT NOT NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_TTiendaFPago] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_TTiendaFPago] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_TTiendaFPago] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_TTiendaFPago] TO PUBLIC;



