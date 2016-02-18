--SELECT * FROM SyncSchema

/*SCRIPT PARA BORRAR ESQUEMAS DE SINCRONIZACION*/

BEGIN TRAN

DECLARE @IdSyncSchema INT = 0

--BORRA LAS EJECUCIONES DEL SCHEDULER
DELETE FROM SchedulerTask
WHERE IdScheduler IN (SELECT IdScheduler FROM Scheduler WHERE IdSyncSchema = @IdSyncSchema)

--BORRA EL SCHEDULER
DELETE FROM Scheduler
WHERE IdScheduler IN (SELECT IdScheduler FROM Scheduler WHERE IdSyncSchema = @IdSyncSchema)

--BORRA LAS EXPRESIONES
DELETE Expresiones
WHERE IdSyncSchemaBD IN (SELECT IdSyncSchemaBD FROM SyncSchemaBaseDatos WHERE IdSyncSchema = @IdSyncSchema)

--BORRA LA BASE DE DATOS
DELETE FROM SyncSchemaBaseDatos
WHERE IdSyncSchema =@IdSyncSchema

--BORRA LOS CAMPOS DE LAS TABLAS
DELETE FROM SyncField 
WHERE IdSyncTable in (SELECT IdSyncTable FROM SyncTable WHERE IdSyncSchema=@IdSyncSchema)

--BORRA LAS TABLAS
DELETE FROM SyncTable
where IdSyncSchema = @IdSyncSchema

--BORRA EL ESQUEMA
DELETE FROM SyncSchema
WHERE IdSyncSchema = @IdSyncSchema

--CONSULTA EL ESQUEMA
SELECT * FROM SyncSchema

--COMMIT TRAN 

--ROLLBACK TRAN
