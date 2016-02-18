CREATE TYPE [dbo].[tmp_ActualizacionColeccionEliminar] AS TABLE (
    [IdActualizacion] INT NOT NULL,
    [IdColeccion]     INT NOT NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_ActualizacionColeccionEliminar] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_ActualizacionColeccionEliminar] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_ActualizacionColeccionEliminar] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_ActualizacionColeccionEliminar] TO PUBLIC;



