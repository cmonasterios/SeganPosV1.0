declare @cierre	int 

select @Cierre=  min(idcierre)  
from EPK_CierreVentaEncabezado 
where fecha ='20150926'

select * from EPK_CierreVentaPagos where IdCierreV = @Cierre 
select * from EPK_CierreVentaPOS  where IdCierreV = @Cierre 
delete EPK_CierreVentaPagos where IdCierreV = @Cierre
delete EPK_CierreVentaPOS  where IdCierreV = @Cierre
delete EPK_CierreVentaEncabezado where IdCierreV = @Cierre