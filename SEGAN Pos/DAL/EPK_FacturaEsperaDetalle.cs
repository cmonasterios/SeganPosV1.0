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
    
    public partial class EPK_FacturaEsperaDetalle
    {
        public int IdFacturaEspera { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public bool Descuento { get; set; }
        public decimal MontoDescuento { get; set; }
        public bool Exento { get; set; }
        public decimal MontoImpuesto { get; set; }
        public decimal PrecioNeto { get; set; }
        public bool Cambio { get; set; }
        public byte[] TStamp { get; set; }
    
        public virtual EPK_FacturaEsperaEncabezado EPK_FacturaEsperaEncabezado { get; set; }
        public virtual EPK_Articulo EPK_Articulo { get; set; }
    }
}
