
/*Script para borrar DB que no esten en uso por ningún esquema de Sincronización*/

--Muestra las DB de seran borradas
SELECT * FROM BaseDatos DB
WHERE DB.IdBD 
NOT IN (SELECT DISTINCT IdDBSource FROM SyncSchema) AND 
DB.IdBD 
NOT IN (SELECT DISTINCT IdBD FROM SyncSchemaBaseDatos)

--Ejecuta la limpieza de DB
BEGIN TRAN 
DELETE FROM BaseDatos
WHERE 
IdBD NOT IN (SELECT DISTINCT IdDBSource FROM SyncSchema) --ORIGEN
AND 
IdBD NOT IN (SELECT DISTINCT IdBD FROM SyncSchemaBaseDatos) --DESTINO


--ROLLBACK TRAN
--COMMIT TRAN