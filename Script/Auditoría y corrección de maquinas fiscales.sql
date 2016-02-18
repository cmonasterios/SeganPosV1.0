--IdDispositivo	IdCaja	Serial	IdEstatus	Descripcion
--146			54	1FC2309521	1	ADMINSTRATIVA
--148			55	1FC2309526	1	ESTACION 02
--149			56	1FC2309531	1	ESTACION 03
--150			57	1FC2307123	1	ESTACION 04
--145			58	1FC2309502	1	ESTACION 05
--147			59	1FC2309514	1	ESTACION 06


--DELETE 208, 152, 156, 207

--INSERT INTO epk_cajadispositivoHISTORICO 
--(IDCAJADISPOSITIVO,  IDDISPOSITIVO, IDCAJA, FECHAINICIO, FECHAFIN)
--SELECT IDCAJADISPOSITIVO,  IDDISPOSITIVO, IDCAJA, FECHAINICIO, GETDATE ()
--FROM EPK_CAJADISPOSITIVO WHERE IDCAJADISPOSITIVO IN (45, 48) 

--SELECT * FROM epk_cajadispositivoHISTORICO

select CD.IDCAJADISPOSITIVO,  CD.IdDispositivo,	CD.IdCaja,	Serial	,IdEstatus	,Descripcion
from epk_cajadispositivo cd
inner join epk_dispositivo d
	on cd.iddispositivo = d.iddispositivo  
inner join EPK_Caja c
	on cd.IdCaja = c.IdCaja  
where IdTipoDispositivo = 1 
and FechaFin is null 
ORDER BY DESCRIPCION 


update epk_cajadispositivo
set idcaja = 30
where iddispositivo =46 

update epk_cajadispositivo
set idcaja = 31
where iddispositivo =45

update epk_cajadispositivo
set idcaja = 29
where iddispositivo =40

--46	30
--45	31
--40	29

--select * from epk_caja

--46	29	1FC2309744	1	ADMINISTRATIVA
--45	30	1FC2309516	1	ESTACIÓN 02
--40	31	1FC2309735	1	ESTACIÓN 03
--49	32	1FC2309447	1	ESTACIÓN 04
--52	33	1FC2309573	1	ESTACIÓN 05
