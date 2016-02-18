CREATE TYPE [dbo].[tmp_ActualizacionArticulo] AS TABLE (
    [IdActualizacion]   INT             NULL,
    [IdArticulo]        INT             NULL,
    [PrecioGravable]    DECIMAL (18, 2) NULL,
    [PrecioExcento]     DECIMAL (18, 2) NULL,
    [Existencia]        BIGINT          NULL,
    [Activo]            BIT             NULL,
    [TipoActualizacion] SMALLINT        NOT NULL,
    [FechaInicio]       DATE            NOT NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_ActualizacionArticulo] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_ActualizacionArticulo] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_ActualizacionArticulo] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_ActualizacionArticulo] TO PUBLIC;



