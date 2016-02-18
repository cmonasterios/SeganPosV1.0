CREATE TYPE [dbo].[tmp_POSTienda] AS TABLE (
    [IdPOS]    INT NOT NULL,
    [IdTienda] INT NOT NULL,
    [Activo]   BIT NOT NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_POSTienda] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_POSTienda] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_POSTienda] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_POSTienda] TO PUBLIC;



