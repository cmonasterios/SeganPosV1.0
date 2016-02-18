CREATE TYPE [dbo].[tmp_ObjetoAccion] AS TABLE (
    [IdAccion]             INT NOT NULL,
    [IdObjeto]             INT NOT NULL,
    [NecesitaAutorizacion] BIT NOT NULL);




GO
GRANT VIEW DEFINITION
    ON TYPE::[dbo].[tmp_ObjetoAccion] TO PUBLIC;




GO
GRANT TAKE OWNERSHIP
    ON TYPE::[dbo].[tmp_ObjetoAccion] TO PUBLIC;




GO
GRANT REFERENCES
    ON TYPE::[dbo].[tmp_ObjetoAccion] TO PUBLIC;




GO
GRANT CONTROL
    ON TYPE::[dbo].[tmp_ObjetoAccion] TO PUBLIC;



