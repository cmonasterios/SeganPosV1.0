CREATE TYPE [dbo].[tmp_ActualizacionTienda] AS TABLE (
    [IdActualizacion] INT      NOT NULL,
    [IdTienda]        INT      NOT NULL,
    [FechaEnvio]      DATETIME NULL,
    [FechaRecepcion]  DATETIME NULL,
    [FechaProceso]    DATETIME NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_ActualizacionTienda] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_ActualizacionTienda] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_ActualizacionTienda] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_ActualizacionTienda] TO PUBLIC;



