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
    
    public partial class EPK_HistoricoNotaCreditoDetalle
    {
        public int IdNota { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public bool Descuento { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public byte[] TStamp { get; set; }
    
        public virtual EPK_HistoricoNotaCreditoEncabezado EPK_HistoricoNotaCreditoEncabezado { get; set; }
        public virtual EPK_Articulo EPK_Articulo { get; set; }
    }
}
