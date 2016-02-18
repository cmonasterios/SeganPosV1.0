using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGAN_POS.DAL
{
    #region Data Types

    public class EPKCierreMaquinaValidar
    {
            public int IdCaja { get; set; }
            public string DescCaja { get; set; }
            public int IdDispositivo { get; set; }
            public string Serial { get; set; }
            public bool Exclude { get; set; }
            public Nullable<decimal> MontoSistemaF { get; set; }
            public Nullable<decimal> MontoReportadoF { get; set; }
            public Nullable<decimal> DiferenciaF { get; set; }
            public Nullable<decimal> MontoSistemaNC { get; set; }
            public Nullable<decimal> MontoReportadONC { get; set; }
            public Nullable<decimal> DiferenciaNC { get; set; }
            public Nullable<System.DateTime> FechaCierre { get; set; }
    }
    #endregion
    public class CierreMaquinaValidar : DataAccess
    {
        public List<EPK_sp_CierreMaquinaFiscalValidar_Result> Obtener(DateTime FechaI, DateTime FechaF)
        {
            return context.EPK_sp_CierreMaquinaFiscalValidar(FechaI, FechaF).ToList();
            //.Join ( context.EPK_CajaDispositivo,  D => D.IdDispositivo, CD => CD.IdCajaDispositivo, (D) => new {});
        }
    }
}
