//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SEGAN_POS.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class EPK_Contingencia
    {
        public int IdCaja { get; set; }
        public int IdFactura { get; set; }
        public int IdPago { get; set; }
        public int IdNotaC { get; set; }
        public int IdCliente { get; set; }
        public long IdApertura { get; set; }
        public long IdAlivioEfectivo { get; set; }
        public long IdCierre { get; set; }
        public int IdCierreV { get; set; }
        public System.DateTime FechaModificacion { get; set; }
        public byte[] tStamp { get; set; }
    
        public virtual EPK_Caja EPK_Caja { get; set; }
    }
}
