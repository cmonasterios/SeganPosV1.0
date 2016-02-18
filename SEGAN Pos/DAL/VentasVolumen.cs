using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SEGAN_POS.DAL
{
    public class VentasVolumen : DataAccess
    {
        public bool SaveLogVentas(EPK_VentasVolumen LogVentas)
        {
            try
            {
                this.context.EPK_VentasVolumen.Add(LogVentas);
                this.context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
                return false;
            }
        }
    }
}
