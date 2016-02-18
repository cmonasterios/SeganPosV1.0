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
    
    public partial class EPK_CierreCajeroEncabezado
    {
        public EPK_CierreCajeroEncabezado()
        {
            this.EPK_CierreCajeroDenominacion = new HashSet<EPK_CierreCajeroDenominacion>();
            this.EPK_CierreCajeroPagos = new HashSet<EPK_CierreCajeroPagos>();
            this.EPK_CierreCajeroPOS = new HashSet<EPK_CierreCajeroPOS>();
        }
    
        public long IdCierre { get; set; }
        public int IdTienda { get; set; }
        public int IdCaja { get; set; }
        public int IdCajero { get; set; }
        public Nullable<decimal> TotalAlivios { get; set; }
        public System.DateTime Fecha { get; set; }
        public System.TimeSpan Hora { get; set; }
        public byte[] tStamp { get; set; }
    
        public virtual EPK_Caja EPK_Caja { get; set; }
        public virtual ICollection<EPK_CierreCajeroDenominacion> EPK_CierreCajeroDenominacion { get; set; }
        public virtual EPK_Usuario EPK_Usuario { get; set; }
        public virtual EPK_Tienda EPK_Tienda { get; set; }
        public virtual ICollection<EPK_CierreCajeroPagos> EPK_CierreCajeroPagos { get; set; }
        public virtual ICollection<EPK_CierreCajeroPOS> EPK_CierreCajeroPOS { get; set; }
    }
}
