CREATE TYPE [dbo].[tmp_ActualizacionColeccion] AS TABLE (
    [IdActualizacion] INT  NOT NULL,
    [IdColeccion]     INT  NOT NULL,
    [Activa]          BIT  NOT NULL,
    [FechaInicio]     DATE NOT NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_ActualizacionColeccion] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_ActualizacionColeccion] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_ActualizacionColeccion] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_ActualizacionColeccion] TO PUBLIC;



