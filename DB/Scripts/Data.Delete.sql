DELETE EPK_Auditoria
PRINT 'DELETE EPK_Auditoria ' + cast(@@rowcount as varchar)

/* Limpieza de tablas para actualización masiva */
DELETE  EPK_ActualizacionColeccion 
PRINT 'DELETE EPK_ActualizacionColeccion ' + cast(@@rowcount as varchar)

DELETE  EPK_ActualizacionArticulo
PRINT 'DELETE EPK_ActualizacionArticulo ' + cast(@@rowcount as varchar)

DELETE EPK_LogActualizacion
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_LogActualizacion') BEGIN
  DBCC CHECKIDENT (EPK_LogActualizacion , RESEED, 0)
END
PRINT 'DELETE EPK_LogActualizacion ' + cast(@@rowcount as varchar)

DELETE  EPK_ActualizacionEncabezado 
--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_ActualizacionEncabezado') BEGIN
--  DBCC CHECKIDENT (EPK_ActualizacionEncabezado, RESEED, 0)
--END
PRINT 'DELETE EPK_ActualizacionEncabezado ' + cast(@@rowcount as varchar)


/* Limpieza de tablas para facturas y NC */
DELETE  EPK_NotaCreditoDetalle 
PRINT 'DELETE EPK_NotaCreditoDetalle ' + cast(@@rowcount as varchar)

DELETE  EPK_NotaCreditoEncabezado 
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_NotaCreditoEncabezado') BEGIN
  DBCC CHECKIDENT (EPK_NotaCreditoEncabezado, RESEED, 0)
END
PRINT 'DELETE EPK_NotaCreditoEncabezado ' + cast(@@rowcount as varchar)

DELETE  EPK_FacturaPago 
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_FacturaPago') BEGIN
  DBCC CHECKIDENT (EPK_FacturaPago, RESEED, 0)
END
PRINT 'DELETE EPK_FacturaPago ' + cast(@@rowcount as varchar)

DELETE  EPK_FacturaDetalle 
PRINT 'DELETE EPK_FacturaDetalle ' + cast(@@rowcount as varchar)

DELETE  EPK_FacturaEncabezado 
PRINT 'DELETE EPK_FacturaEncabezado ' + cast(@@rowcount as varchar)


/*  Limpieza de tablas financieras */
DELETE  EPK_POSTienda  
PRINT 'DELETE EPK_POSTienda ' + cast(@@rowcount as varchar)

DELETE EPK_AperturaCajeroDenominacion 
PRINT 'DELETE EPK_AperturaCajeroDenominacion ' + cast(@@rowcount as varchar)

DELETE EPK_AperturaCajeroEncabezado
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_AperturaCajeroEncabezado') BEGIN
  DBCC CHECKIDENT (EPK_AperturaCajeroEncabezado, RESEED, 0)
END
PRINT 'DELETE EPK_AperturaCajeroEncabezado ' + cast(@@rowcount as varchar)

DELETE  EPK_CierreCajeroPOS 
PRINT 'DELETE EPK_CierreCajeroPOS ' + cast(@@rowcount as varchar)

DELETE EPK_CierreCajeroPagos
PRINT 'DELETE EPK_CierreCajeroPagos ' + cast(@@rowcount as varchar)

DELETE EPK_CierreCajeroDenominacion
PRINT 'DELETE EPK_CierreCajeroDenominacion ' + cast(@@rowcount as varchar)

DELETE EPK_CierreCajeroEncabezado 
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_CierreCajeroEncabezado') BEGIN
  DBCC CHECKIDENT (EPK_CierreCajeroEncabezado, RESEED, 0)
END
PRINT 'DELETE EPK_CierreCajeroEncabezado ' + cast(@@rowcount as varchar)

DELETE  EPK_POS 
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_POS') BEGIN
  DBCC CHECKIDENT (EPK_POS, RESEED, 0)
END
PRINT 'DELETE EPK_POS ' + cast(@@rowcount as varchar)

DELETE dbo.EPK_Depositodetalle 
PRINT 'DELETE EPK_Depositodetalle ' + cast(@@rowcount as varchar)

DELETE dbo.EPK_DepositoEncabezado
PRINT 'DELETE EPK_DepositoEncabezado ' + cast(@@rowcount as varchar)

DELETE  EPK_EntidadFinanciera 
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_EntidadFinanciera') BEGIN
  DBCC CHECKIDENT (EPK_EntidadFinanciera, RESEED, 0)
END
PRINT 'DELETE EPK_EntidadFinanciera ' + cast(@@rowcount as varchar)

DELETE EPK_TipoTiendaFormaPago 
PRINT 'DELETE EPK_TipoTiendaFormaPago ' + cast(@@rowcount as varchar)

DELETE EPK_FormaPago
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_FormaPago') BEGIN
  DBCC CHECKIDENT (EPK_FormaPago, RESEED, 0)
END
PRINT 'DELETE EPK_FormaPago ' + cast(@@rowcount as varchar)

DELETE EPK_AlivioEfectivoDetalle
PRINT 'DELETE EPK_AlivioEfectivoDetalle ' + cast(@@rowcount as varchar)

DELETE EPK_AlivioEfectivoEncabezado 
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_AlivioEfectivoEncabezado') BEGIN
  DBCC CHECKIDENT (EPK_AlivioEfectivoEncabezado, RESEED, 0)
END
PRINT 'DELETE EPK_AlivioEfectivoEncabezado ' + cast(@@rowcount as varchar)

DELETE EPK_EfectivoRemanenteDetalle
PRINT 'DELETE EPK_EfectivoRemanenteDetalle ' + cast(@@rowcount as varchar)

DELETE EPK_EfectivoRemanenteEncabezado 
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_EfectivoRemanenteEncabezado') BEGIN
  DBCC CHECKIDENT (EPK_EfectivoRemanenteEncabezado, RESEED, 0)
END
PRINT 'DELETE EPK_EfectivoRemanenteEncabezado ' + cast(@@rowcount as varchar)

DELETE EPK_Denominacion  
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Denominacion') BEGIN
  DBCC CHECKIDENT (EPK_Denominacion, RESEED, 0)
END
PRINT 'DELETE EPK_Denominacion ' + cast(@@rowcount as varchar)


/*  Limpieza de tablas para tiendas */
UPDATE EPK_Tienda SET IdTipoTienda = 1
DELETE EPK_TipoTienda WHERE IdTipoTienda > 1
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_TipoTienda') BEGIN
  DBCC CHECKIDENT (EPK_TipoTienda, RESEED, 1)
END
PRINT 'DELETE EPK_TipoTienda ' + cast(@@rowcount as varchar)

DELETE EPK_CajaDispositivo
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_CajaDispositivo') BEGIN
  DBCC CHECKIDENT (EPK_CajaDispositivo, RESEED, 0)
END
PRINT 'DELETE EPK_CajaDispositivo ' + cast(@@rowcount as varchar)

DELETE EPK_CierreMaquinaFiscal
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_CierreMaquinaFiscal') BEGIN
  DBCC CHECKIDENT (EPK_CierreMaquinaFiscal, RESEED, 0)
END
PRINT 'DELETE EPK_CierreMaquinaFiscal ' + cast(@@rowcount as varchar)

DELETE EPK_Dispositivo  
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Dispositivo') BEGIN
  DBCC CHECKIDENT (EPK_Dispositivo, RESEED, 0)
END
PRINT 'DELETE EPK_Dispositivo ' + cast(@@rowcount as varchar)

DELETE EPK_TipoDispositivo
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_TipoDispositivo') BEGIN
  DBCC CHECKIDENT (EPK_TipoDispositivo, RESEED, 0)
END
PRINT 'DELETE EPK_TipoDispositivo ' + cast(@@rowcount as varchar)

DELETE EPK_MarcaDispositivo  
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_MarcaDispositivo') BEGIN
  DBCC CHECKIDENT (EPK_MarcaDispositivo, RESEED, 0)
END
PRINT 'DELETE EPK_MarcaDispositivo ' + cast(@@rowcount as varchar)


/* Limpieza de tablas de inventario */
DELETE EPK_Articulo     
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Articulo') BEGIN
  DBCC CHECKIDENT (EPK_Articulo, RESEED, 0)
END
PRINT 'DELETE EPK_Articulo ' + cast(@@rowcount as varchar)

DELETE EPK_Referencia    
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Referencia') BEGIN
  DBCC CHECKIDENT (EPK_Referencia, RESEED, 0)
END
PRINT 'DELETE EPK_Referencia ' + cast(@@rowcount as varchar)

DELETE EPK_Tema   
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Tema') BEGIN
  DBCC CHECKIDENT (EPK_Tema, RESEED, 0)
END
PRINT 'DELETE EPK_Tema ' + cast(@@rowcount as varchar)

TRUNCATE TABLE  EPK_HistoricoArticuloExistencia 

DELETE EPK_TemporadaGrupo
PRINT 'DELETE EPK_TemporadaGrupo ' + cast(@@rowcount as varchar)

DELETE EPK_Grupo   
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Grupo') BEGIN
  DBCC CHECKIDENT (EPK_Grupo, RESEED, 0)
END
PRINT 'DELETE EPK_Grupo ' + cast(@@rowcount as varchar)

DELETE EPK_Genero    
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Genero') BEGIN
  DBCC CHECKIDENT (EPK_Genero, RESEED, 0)
END
PRINT 'DELETE EPK_Genero ' + cast(@@rowcount as varchar)

DELETE EPK_Coleccion    
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Coleccion') BEGIN
  DBCC CHECKIDENT (EPK_Coleccion, RESEED, 0)
END
PRINT 'DELETE EPK_Coleccion ' + cast(@@rowcount as varchar)

DELETE EPK_Color    
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Color') BEGIN
  DBCC CHECKIDENT (EPK_Color, RESEED, 0)
END
PRINT 'DELETE EPK_Color ' + cast(@@rowcount as varchar)

DELETE EPK_Talla   
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Talla') BEGIN
  DBCC CHECKIDENT (EPK_Talla, RESEED, 0)
END
PRINT 'DELETE EPK_Talla ' + cast(@@rowcount as varchar)

--sp_fkeys  EPK_Tienda 
/*de tablas de Tienda */
DELETE EPK_Caja
PRINT 'DELETE EPK_Caja ' + cast(@@rowcount as varchar)

DELETE EPK_TiendaTelefono
PRINT 'DELETE EPK_TiendaTelefono ' + cast(@@rowcount as varchar)

DELETE EPK_UsuarioTienda
PRINT 'DELETE EPK_UsuarioTienda ' + cast(@@rowcount as varchar)

DELETE EPK_Tienda   
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Tienda') BEGIN
  DBCC CHECKIDENT (EPK_Tienda, RESEED, 0)
END
PRINT 'DELETE EPK_Tienda ' + cast(@@rowcount as varchar)

/*  Limpieza de tablas de seguridad */
--SELECT * FROM EPK_EMPLEADOS
UPDATE EPK_EMPLEADOS SET IDUSUARIO = NULL
DELETE EPK_UsuarioApp WHERE IdUsuario >2  or IdApp >2 
PRINT 'DELETE EPK_UsuarioApp ' + cast(@@rowcount as varchar)

delete EPK_ObjetoAccion
PRINT 'DELETE EPK_ObjetoAccion ' + cast(@@rowcount as varchar)

delete EPK_PerfilAccion
PRINT 'DELETE EPK_PerfilAccion ' + cast(@@rowcount as varchar)

delete EPK_Accion
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Accion') BEGIN
  dbcc checkident (EPK_Accion, reseed, 0)
END
PRINT 'DELETE EPK_Accion ' + cast(@@rowcount as varchar)

DELETE EPK_Usuario WHERE IdUsuario >2  
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Usuario') BEGIN
  DBCC CHECKIDENT (EPK_Usuario, RESEED, 2)
END
PRINT 'DELETE EPK_Usuario ' + cast(@@rowcount as varchar)

DELETE EPK_PerfilAccion WHERE IdPerfil not in (1, 24, 40)
PRINT 'DELETE EPK_PerfilAccion ' + cast(@@rowcount as varchar)

DELETE EPK_PerfilObjetos WHERE IdPerfil not in (1, 24, 40)
PRINT 'DELETE EPK_PerfilObjetos ' + cast(@@rowcount as varchar)

DELETE EPK_Perfil		WHERE IdPerfil not in (1, 24, 40) 
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Perfil') BEGIN
  DBCC CHECKIDENT (EPK_Perfil, RESEED, 40)
END
PRINT 'DELETE EPK_Perfil ' + cast(@@rowcount as varchar)

DELETE EPK_ObjetoAccion WHERE IdObjeto IN (SELECT IdObjeto FROM EPK_OBJETO WHERE IDMODULO IN (SELECT IDMODULO FROM  EPK_MODULO WHERE IdApp >2))
PRINT 'DELETE EPK_ObjetoAccion ' + cast(@@rowcount as varchar)

DELETE EPK_PerfilObjetos WHERE IdObjeto IN (SELECT IdObjeto FROM EPK_OBJETO WHERE IDMODULO IN (SELECT IDMODULO FROM  EPK_MODULO WHERE IdApp >2))
PRINT 'DELETE EPK_PerfilObjetos ' + cast(@@rowcount as varchar)

DELETE EPK_OBJETO WHERE IDMODULO IN (SELECT IDMODULO FROM  EPK_MODULO WHERE IdApp >2)
PRINT 'DELETE EPK_OBJETO ' + cast(@@rowcount as varchar)

DELETE EPK_MODULO WHERE IdApp >2
PRINT 'DELETE EPK_MODULO ' + cast(@@rowcount as varchar)

DELETE EPK_APP  WHERE IdApp >2
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_APP') BEGIN
  DBCC CHECKIDENT (EPK_APP, RESEED, 2)
END
PRINT 'DELETE EPK_APP ' + cast(@@rowcount as varchar)

truncate table [dbo].[EPK_Auditoria]

delete EPK_ClienteTelefono 
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_ClienteTelefono') BEGIN
  dbcc checkident (EPK_ClienteTelefono, reseed, 0)
END
PRINT 'DELETE EPK_ClienteTelefono ' + cast(@@rowcount as varchar)

delete EPK_Cliente
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Cliente') BEGIN
  dbcc checkident (EPK_Cliente, reseed, 0)
END
PRINT 'DELETE EPK_Cliente ' + cast(@@rowcount as varchar)

delete EPK_Estatus
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Estatus') BEGIN
  dbcc checkident (EPK_Estatus, reseed, 0)
END
PRINT 'DELETE EPK_Estatus ' + cast(@@rowcount as varchar)

delete EPK_MaquinaFiscal
PRINT 'DELETE EPK_MaquinaFiscal ' + cast(@@rowcount as varchar)

delete EPK_MotivoDevolucion
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_MotivoDevolucion') BEGIN
  dbcc checkident (EPK_MotivoDevolucion, reseed, 0)
END
PRINT 'DELETE EPK_MotivoDevolucion ' + cast(@@rowcount as varchar)

delete EPK_ParametrosSistema
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_ParametrosSistema') BEGIN
  dbcc checkident (EPK_ParametrosSistema, reseed, 0)
END
PRINT 'DELETE EPK_ParametrosSistema ' + cast(@@rowcount as varchar)

delete EPK_Perfil
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Perfil') BEGIN
  dbcc checkident (EPK_Perfil, reseed, 0)
END
PRINT 'DELETE EPK_Perfil ' + cast(@@rowcount as varchar)

delete EPK_Politica
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_Politica') BEGIN
  dbcc checkident (EPK_Politica, reseed, 0)
END
PRINT 'DELETE EPK_Politica ' + cast(@@rowcount as varchar)

delete EPK_TipoDocumento
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'EPK_TipoDocumento') BEGIN
  dbcc checkident (EPK_TipoDocumento, reseed, 0)
END
PRINT 'DELETE EPK_TipoDocumento ' + cast(@@rowcount as varchar)