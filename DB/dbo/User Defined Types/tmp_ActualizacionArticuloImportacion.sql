CREATE TYPE [dbo].[tmp_ActualizacionArticuloImportacion] AS TABLE (
    [IdUsuario]      INT             NULL,
    [CodArticulo]    VARCHAR (31)    NULL,
    [PrecioGravable] DECIMAL (18, 2) NULL,
    [PrecioExcento]  DECIMAL (18, 2) NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_ActualizacionArticuloImportacion] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_ActualizacionArticuloImportacion] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_ActualizacionArticuloImportacion] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_ActualizacionArticuloImportacion] TO PUBLIC;



