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
    
    public partial class EPK_DepositoCheque
    {
        public long IdDeposito { get; set; }
        public int IdTienda { get; set; }
        public int IdPago { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public byte[] tStamp { get; set; }
    
        public virtual EPK_FacturaPago EPK_FacturaPago { get; set; }
        public virtual EPK_Tienda EPK_Tienda { get; set; }
        public virtual EPK_DepositoEncabezado EPK_DepositoEncabezado { get; set; }
    }
}
