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
    
    public partial class EPK_CierreVentaPagos
    {
        public int IdCierreV { get; set; }
        public int IdTienda { get; set; }
        public byte IdFormaPago { get; set; }
        public decimal MontoPagos { get; set; }
        public decimal MontoCierre { get; set; }
        public string Observacion { get; set; }
        public string NroControl { get; set; }
        public byte[] TStamp { get; set; }
    
        public virtual EPK_CierreVentaEncabezado EPK_CierreVentaEncabezado { get; set; }
        public virtual EPK_FormaPago EPK_FormaPago { get; set; }
        public virtual EPK_Tienda EPK_Tienda { get; set; }
    }
}
