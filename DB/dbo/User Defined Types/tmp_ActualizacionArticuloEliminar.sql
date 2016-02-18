CREATE TYPE [dbo].[tmp_ActualizacionArticuloEliminar] AS TABLE (
    [IdActualizacion] INT NOT NULL,
    [IdArticulo]      INT NOT NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_ActualizacionArticuloEliminar] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_ActualizacionArticuloEliminar] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_ActualizacionArticuloEliminar] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_ActualizacionArticuloEliminar] TO PUBLIC;



