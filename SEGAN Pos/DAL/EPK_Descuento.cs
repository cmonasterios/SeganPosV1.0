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
    
    public partial class EPK_Descuento
    {
        public int IdDescuento { get; set; }
        public byte IdTipoDescuento { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
        public Nullable<decimal> PorcDescuento { get; set; }
        public Nullable<decimal> MontoLimite { get; set; }
        public byte[] TStamp { get; set; }
    
        public virtual EPK_TipoDescuento EPK_TipoDescuento { get; set; }
    }
}
