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
    
    public partial class EPK_ParametrosSistema
    {
        public int IdParametro { get; set; }
        public short IdTipoTienda { get; set; }
        public string CodParametro { get; set; }
        public short TipoParametro { get; set; }
        public string ValorCadena { get; set; }
        public Nullable<decimal> ValorNumerico { get; set; }
        public Nullable<int> ValorEntero { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public byte[] TStamp { get; set; }
    }
}
