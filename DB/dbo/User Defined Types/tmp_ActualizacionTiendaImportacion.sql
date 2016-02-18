CREATE TYPE [dbo].[tmp_ActualizacionTiendaImportacion] AS TABLE (
    [IdTienda] INT NOT NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_ActualizacionTiendaImportacion] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_ActualizacionTiendaImportacion] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_ActualizacionTiendaImportacion] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_ActualizacionTiendaImportacion] TO PUBLIC;



