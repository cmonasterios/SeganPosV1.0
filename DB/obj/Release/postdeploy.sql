/*
Post-Deployment Script Template              
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.    
 Use SQLCMD syntax to include a file in the post-deployment script.      
 Example:      :r .\myfile.sql                
 Use SQLCMD syntax to reference a variable in the post-deployment script.    
 Example:      :setvar TableName MyTable              
               SELECT * FROM [$(TableName)]          
--------------------------------------------------------------------------------------
*/

--SET IDENTITY_INSERT [dbo].[EPK_ParametrosSistema] OFF
--GO
--SET IDENTITY_INSERT [dbo].[EPK_ParametrosSistema] ON

--INSERT INTO [dbo].[EPK_ParametrosSistema] ([IdParametro], [IdTipoTienda], [CodParametro], [TipoParametro], [ValorCadena],
--                                           [ValorNumerico], [ValorEntero], [FechaInicio], [FechaFin])
--  VALUES (1, 1, 'PorcentajeBonoAlimentacion', 3, NULL,
--          NULL, 25, GETDATE(), NULL)

--SET IDENTITY_INSERT [dbo].[EPK_ParametrosSistema] OFF

/*
Post-Deployment Script Template                            
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.        
 Use SQLCMD syntax to include a file in the post-deployment script.            
 Example:      :r .\myfile.sql                                
 Use SQLCMD syntax to reference a variable in the post-deployment script.        
 Example:      :setvar TableName MyTable                            
               SELECT * FROM [$(TableName)]                    
--------------------------------------------------------------------------------------
*/

/*Count : 1 */

declare @cStatement varchar(255)

declare G_cursor CURSOR for select 'grant select,update,insert,delete on [' + convert(varchar(128),name) + '] to PUBLIC' from sysobjects 
	where (type = 'U' or type = 'V') and uid = 1
set nocount on
OPEN G_cursor
FETCH NEXT FROM G_cursor INTO @cStatement 
WHILE (@@FETCH_STATUS <> -1)
begin
	EXEC (@cStatement)
	FETCH NEXT FROM G_cursor INTO @cStatement 
end
DEALLOCATE G_cursor


/****/
declare G_cursor CURSOR for select 'GRANT VIEW DEFINITION ON [' + convert(varchar(128),name) + '] to PUBLIC' from sysobjects 
	where (type = 'U' or type = 'V') and uid = 1
set nocount on
OPEN G_cursor
FETCH NEXT FROM G_cursor INTO @cStatement 
WHILE (@@FETCH_STATUS <> -1)
begin
	EXEC (@cStatement)
	FETCH NEXT FROM G_cursor INTO @cStatement 
end
DEALLOCATE G_cursor
/****/


declare G_cursor CURSOR for select 'grant execute on [' + convert(varchar(128),name) + '] to PUBLIC' from sysobjects 
	where type = 'P'  

set nocount on
OPEN G_cursor
FETCH NEXT FROM G_cursor INTO @cStatement 
WHILE (@@FETCH_STATUS <> -1)
begin
	EXEC (@cStatement)
	FETCH NEXT FROM G_cursor INTO @cStatement 
end
DEALLOCATE G_cursor



/****/
declare G_cursor CURSOR for select 'GRANT VIEW DEFINITION ON [' + convert(varchar(128),name) + '] to PUBLIC' from sysobjects 
	where type = 'P' 
set nocount on
OPEN G_cursor
FETCH NEXT FROM G_cursor INTO @cStatement 
WHILE (@@FETCH_STATUS <> -1)
begin
	EXEC (@cStatement)
	FETCH NEXT FROM G_cursor INTO @cStatement 
end
DEALLOCATE G_cursor
/****/
GO
