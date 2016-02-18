CREATE TYPE [dbo].[tmp_DescansoTurno] AS TABLE (
    [IdTurno] INT NOT NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_DescansoTurno] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_DescansoTurno] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_DescansoTurno] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_DescansoTurno] TO PUBLIC;



