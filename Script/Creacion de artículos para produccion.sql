----DECLARE @IDCOLECCION INT 
--drop table Articulos_2014_2
--drop table Referencias_2014_2

/*RESEED DE ID'S*/
DECLARE @ID INT 
SELECT @ID = MAX (IdArticulo) FROM EPK_Articulo 
DBCC CHECKIDENT (EPK_Articulo, RESEED, @ID)
SELECT @ID = MAX (IdReferencia) FROM EPK_Referencia
DBCC CHECKIDENT (EPK_Referencia, RESEED, @ID)
SELECT @ID = MAX (IdColeccion) FROM EPK_Coleccion 
DBCC CHECKIDENT (EPK_Coleccion, RESEED, @ID)
SELECT @ID = MAX (IdColor) FROM EPK_Color  
DBCC CHECKIDENT (EPK_Color, RESEED, @ID)
SELECT @ID = MAX (IdTema) FROM EPK_Tema  
DBCC CHECKIDENT (EPK_Tema, RESEED, @ID)
SELECT @ID = MAX (IdGrupo ) FROM EPK_Grupo
DBCC CHECKIDENT (EPK_Grupo, RESEED, @ID)
SELECT @ID = MAX (IdTalla) FROM EPK_Talla
DBCC CHECKIDENT (EPK_Talla, RESEED, @ID)
SELECT @ID = MAX (IdGenero) FROM EPK_Genero 
DBCC CHECKIDENT (EPK_Genero , RESEED, @ID)

/*VARIABLES*/
DECLARE @FCreacion DATETIME = GETDATE ()
DECLARE @CodReferencia VARCHAR(13)='215%'

BEGIN TRAN

/* CREACIÓN DE TABLA CON EL GRUPO DE ARTÍCULOS A MIGRAR */
SELECT DISTINCT ITEMNMBR Articulo,
      ITEMDESC Descripcion,
      ITMSHNAM NombreCorto,  
      ITMCLSCD Genero, 
      USCATVLS_1 Referencia,  
      USCATVLS_2 Coleccion,   
      USCATVLS_3 Color,
      USCATVLS_4 Talla,
      USCATVLS_5 Grupo,
      USCATVLS_6 Tema
INTO Articulos_2014_2 --ARTICULOS A MIGRAR
FROM EPKDGP04.epk.dbo.IV00101
WHERE    (USCATVLS_1 like @CodReferencia) AND --REFERENCIA
           (ITEMTYPE <> 2) AND--ACTIVOS
           (ITEMNMBR NOT IN (SELECT CodigoArticulo FROM EPK_Articulo))AND --NO EXISTENTE EN SEGAN
           (ltrim(rtrim(USCATVLS_2)) <> 'UNIFORMES' AND ltrim(rtrim(USCATVLS_2)) <> 'UNIFORME') --SE EXCLUYEN LA COLECCION DE UNIFORMES PARA EMPLEADOS
           

/* CREACIÓN DE TABLA CON EL GRUPO DE REFERENCIAS A MIGRAR */
SELECT DISTINCT Referencia,  Coleccion,  Grupo,  Tema, Genero, NombreCorto
INTO Referencias_2014_2 --REFERENCIAS A CREAR
FROM Articulos_2014_2   --ARTICULOS A MIGRAR


/* MUESTRA LOS ARTÍCULOS QUE PRODUCIRAN DUPLICIDAD POR LAS REFERENCIAS ASIGNADAS */
SELECT Articulo, Referencia, NombreCorto, Coleccion,  Grupo, Tema, Genero
FROM Articulos_2014_2 
WHERE Referencia IN (
                                   SELECT Referencia--, COUNT (1)
                        FROM Referencias_2014_2 
                        GROUP BY Referencia
                        HAVING COUNT (1)> 1 --REFERENCIAS DUPLICADAS
                     )
ORDER BY Referencia DESC 


/* EXCLUYE LOS ARTÍCULOS QUE GENERAN DUPLICIDAD DE REFERENCIAS */
DELETE Articulos_2014_2 
WHERE Referencia IN (
                                   SELECT Referencia--, COUNT (1)
                        FROM Referencias_2014_2 
                        GROUP BY Referencia
                        HAVING COUNT (1)> 1 --REFERENCIAS DUPLICADAS
                     )

/* EXCLUYE LAS REFERENCIAS DUPLICADAS */
DELETE Referencias_2014_2 
WHERE referencia IN (
                       SELECT Referencia--, COUNT (1)
                       FROM Referencias_2014_2 
                       GROUP BY Referencia
                       HAVING COUNT (1)> 1 --REFERENCIAS DUPLICADAS
                     )


/****************/
/*  COLECCIÓN   */
/****************/
SELECT USCATVAL Coleccion, Image_URL Descripcion
FROM EPKDGP04.epk.dbo.IV40600 
WHERE USCATNUM = 2                      --Posición de la categoría a la que corresponde en Dynamics
AND USCATVAL IN (SELECT Coleccion FROM Referencias_2014_2)
AND USCATVAL NOT IN (SELECT CodigoColeccion FROM EPK_Coleccion)

INSERT INTO EPK_Coleccion (CodigoColeccion,    Descripcion,      FechaCreacion,    Activo,   Actual)
SELECT USCATVAL, Image_URL, GETDATE (),1,0
FROM EPKDGP04.epk.dbo.IV40600 
WHERE USCATNUM = 2
AND USCATVAL IN (SELECT Coleccion FROM Referencias_2014_2)
AND USCATVAL NOT IN (SELECT CodigoColeccion FROM EPK_Coleccion)

SELECT * FROM EPK_Coleccion ORDER BY FechaCreacion DESC 


/************/
/*  COLOR   */
/************/
SELECT USCATVAL Color, Image_URL Descripcion 
FROM EPKDGP04.epk.dbo.IV40600 
WHERE USCATNUM = 3
AND USCATVAL IN (SELECT Color FROM Articulos_2014_2)
AND USCATVAL NOT IN (SELECT CodigoColor FROM EPK_Color)

INSERT INTO EPK_Color (CodigoColor,Descripcion)
SELECT USCATVAL Color, Image_URL Descripcion 
FROM EPKDGP04.epk.dbo.IV40600 
WHERE USCATNUM = 3
AND USCATVAL IN (SELECT Color FROM Articulos_2014_2)
AND USCATVAL NOT IN (SELECT CodigoColor FROM EPK_Color)

SELECT * FROM EPK_Color  ORDER BY FechaCreacion DESC 


/************/
/*  TALLA   */
/************/
SELECT USCATVAL Talla, Image_URL Descripcion 
FROM EPKDGP04.epk.dbo.IV40600 
WHERE USCATNUM = 4
AND USCATVAL IN (SELECT Talla FROM Articulos_2014_2)
AND USCATVAL NOT IN (SELECT CodigoTalla FROM EPK_Talla)

INSERT INTO EPK_Talla (CodigoTalla, Descripcion, Orden )
SELECT USCATVAL Talla, Image_URL Descripcion, 1
FROM EPKDGP04.epk.dbo.IV40600 
WHERE USCATNUM = 4
AND USCATVAL IN (SELECT Talla FROM Articulos_2014_2)
AND USCATVAL NOT IN (SELECT CodigoTalla FROM EPK_Talla)

SELECT * FROM EPK_Talla  ORDER BY FechaCreacion DESC 


/************/
/*  GRUPOS  */
/************/
SELECT USCATVAL Grupo, Image_URL Descripcion 
FROM EPKDGP04.epk.dbo.IV40600 
WHERE USCATNUM = 5
AND USCATVAL IN (SELECT Grupo FROM Referencias_2014_2)
AND USCATVAL NOT IN (SELECT CodigoGrupo FROM EPK_Grupo)

INSERT INTO EPK_Grupo (CodigoGrupo, Descripcion,      IdTipoPrenda,     FechaCreacion)
SELECT USCATVAL, Image_URL, 1,GETDATE ()
FROM EPKDGP04.epk.dbo.IV40600 
WHERE USCATNUM = 5
AND USCATVAL IN (SELECT Grupo FROM Referencias_2014_2)
AND USCATVAL NOT IN (SELECT CodigoGrupo FROM EPK_Grupo)

SELECT * FROM EPK_Grupo ORDER BY FechaCreacion DESC 


/************/
/*   TEMAS  */
/************/
SELECT USCATVAL Tema, Image_URL Descripcion
FROM EPKDGP04.epk.dbo.IV40600 
WHERE USCATNUM = 6
AND USCATVAL IN (SELECT Tema FROM Referencias_2014_2)
AND USCATVAL NOT IN (SELECT CodigoTema  FROM EPK_Tema)

INSERT INTO EPK_Tema (CodigoTema,  Descripcion,      FechaCreacion)
SELECT USCATVAL , Image_URL, GETDATE ()
FROM EPKDGP04.epk.dbo.IV40600 
WHERE USCATNUM = 6
AND USCATVAL IN (SELECT Tema FROM Referencias_2014_2)
AND USCATVAL NOT IN (SELECT CodigoTema  FROM EPK_Tema)

SELECT * FROM EPK_Tema ORDER BY FechaCreacion DESC 


/**************/
/* REFERENCIA */
/**************/
SELECT R.USCATVAL, A.ITMSHNAM
FROM EPKDGP04.epk.dbo.IV40600 AS R
LEFT JOIN EPKDGP04.epk.dbo.IV00101 A ON R.USCATVAL=A.USCATVLS_1
WHERE R.USCATVAL LIKE @CodReferencia 
      AND R.USCATNUM=1
      AND USCATVAL IN (SELECT Referencia FROM Referencias_2014_2)
      AND USCATVAL NOT IN (SELECT CodigoReferencia  FROM EPK_Referencia)
GROUP BY R.USCATVAL, A.ITMSHNAM

INSERT INTO EPK_Referencia (CodigoReferencia,  Descripcion,      Activo,     IdGrupo,      IdGenero,   IdColeccion, IdTema)
SELECT MR.Referencia , MR.NombreCorto, 1, G.IdGrupo, GE.IdGenero, C.IdColeccion, T.IdTema  
FROM  Referencias_2014_2 MR 
INNER JOIN EPK_Grupo  G
      ON MR.Grupo  = G.CodigoGrupo 
INNER JOIN EPK_Coleccion C
      ON MR.Coleccion = C.CodigoColeccion
INNER JOIN EPK_Genero GE
      ON MR.Genero = GE.CodigoGenero 
INNER JOIN EPK_Tema T
      ON MR.Tema = T.CodigoTema 
WHERE MR.Referencia NOT IN (SELECT CodigoReferencia  FROM EPK_Referencia)

SELECT TOP 10000 * FROM EPK_Referencia 
WHERE FechaCreacion BETWEEN @FCreacion AND getdate ()
ORDER BY FechaCreacion  DESC 


/**************/
/* ARTICULO */
/**************/
INSERT INTO EPK_Articulo  (CodigoArticulo,     IdReferencia,     Descripcion,      IdColor,      IdTalla,    Activo,     Exento,     FechaCreacion, PrecioGravable, PrecioGravableInicial, PrecioExento, PrecioExentoInicial, Existencia, ExistenciaAlmacen)
SELECT A.Articulo, R.IdReferencia, A.Descripcion, C.IdColor, T.IdTalla, 1, 0, GETDATE(), 0, 0, 0, 0,0,0 
FROM Articulos_2014_2 A
INNER JOIN EPK_Referencia R
      ON A.Referencia = R.CodigoReferencia 
INNER JOIN EPK_Color C
      ON A.Color = C.CodigoColor 
INNER JOIN EPK_Talla T
      ON A.Talla = T.CodigoTalla 
INNER JOIN EPK_Grupo  G
      ON R.IdGrupo = G.IdGrupo

/* PRECIOS */
--UPDATE A
--SET A.PrecioGravable = I.PRECIO, a.PrecioGravableInicial = I.PRECIO, a.Exento = i.EXENTO_IVA 
--FROM EPK_Articulo A
--INNER JOIN WS6628.almacensifa.dbo.INVENTARIO_SIFA I
--      ON A.CodigoArticulo = I.CODIGO_ARTICULO COLLATE SQL_Latin1_General_CP1_CI_AS
--      AND I.NUMERO_REFERENCIA IN (SELECT NUMERO_REFERENCIA FROM WS6628.almacensifa.dbo.REFERENCIA_SIFA
--                                               WHERE CODIGO_COLECCION =72)
--      AND I.PRECIO>0


/* INACTIVA ARTÍCULOS SIN PRECIO */
UPDATE A
SET A.Activo = 0
FROM EPK_Articulo A
WHERE Activo = 1 AND PrecioGravable = 0

SELECT * FROM EPK_Articulo WHERE FechaCreacion BETWEEN @FCreacion AND GETDATE()

DROP TABLE Articulos_2014_2
DROP TABLE Referencias_2014_2

--COMMIT TRAN
--ROLLBACK TRAN
--DELETE EPK_Referencia WHERE cast(FechaCreacion as date)='20141001'

--SELECT * FROM EPK_Referencia 
--WHERE cast (FechaCreacion as date)='20150918'

--SELECT * FROM EPK_Articulo 
--WHERE cast (FechaCreacion as date)='20150918'
----BETWEEN @FCreacion AND GETDATE()

----71876
----11339