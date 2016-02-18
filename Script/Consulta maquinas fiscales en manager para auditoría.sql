/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [IdCajaDispositivo] CaDi
      ,ch.[IdDispositivo] Di
      ,ch.[IdCaja]
      ,[FechaInicio]
      ,[FechaFin]
      , d.Serial 
      ,d.IdTipoDispositivo TiDi
      ,c.IdTienda Tie
      , c.Descripcion 
  FROM [EPKSystem].[dbo].[EPK_CajaDispositivo] ch
  inner join EPK_Dispositivo d
	on ch.IdDispositivo = d.IdDispositivo 
	and IdTipoDispositivo = 1 
  inner join EPK_Caja c
	on ch.IdCaja = c.IdCaja 
	and IdTienda =2
  order by Descripcion  
  
  update epk_cajadispositivo
set idcaja = 30
where iddispositivo =46 

update epk_cajadispositivo
set idcaja = 31
where iddispositivo =45

update epk_cajadispositivo
set idcaja = 29
where iddispositivo =40
  