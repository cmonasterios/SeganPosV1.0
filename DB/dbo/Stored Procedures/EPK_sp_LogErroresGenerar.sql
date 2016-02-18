CREATE PROCEDURE [dbo].[EPK_sp_LogErroresGenerar]
(
 @SPID AS SMALLINT  
)
AS
BEGIN
	DECLARE @Login AS VARCHAR (50)

	SET @Login  =  (SELECT TOP 1 ses.login_name  
					FROM sys.dm_exec_requests er  
						LEFT JOIN sys.dm_exec_sessions ses  
						ON ses.session_id = er.session_id  
					WHERE er.session_id = @SPID)
	
	INSERT INTO EPK_LogErrores 
		(  
		Procedimiento,  
		Linea,  
		NroError,  
		Descripcion,  
		Usuario  
		)   
	VALUES 
		(  
		ERROR_PROCEDURE (),  
		ERROR_LINE (),  
		ERROR_NUMBER (),  
		ERROR_MESSAGE (),  
		@Login  
		)  
	END
GO
GRANT VIEW DEFINITION
    ON OBJECT::[dbo].[EPK_sp_LogErroresGenerar] TO PUBLIC
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[dbo].[EPK_sp_LogErroresGenerar] TO PUBLIC
    AS [dbo];

