CREATE TYPE [dbo].[tmp_FeriadosRegion] AS TABLE (
    [IdFeriado] SMALLINT NULL,
    [IdRegion]  INT      NOT NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_FeriadosRegion] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_FeriadosRegion] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_FeriadosRegion] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_FeriadosRegion] TO PUBLIC;



