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
    
    public partial class EPK_AperturaCajeroDenominacion
    {
        public long IdApertura { get; set; }
        public byte IdDenominacion { get; set; }
        public byte Cantidad { get; set; }
    
        public virtual EPK_AperturaCajeroEncabezado EPK_AperturaCajeroEncabezado { get; set; }
        public virtual EPK_Denominacion EPK_Denominacion { get; set; }
    }
}
