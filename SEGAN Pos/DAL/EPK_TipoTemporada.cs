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
    
    public partial class EPK_TipoTemporada
    {
        public EPK_TipoTemporada()
        {
            this.EPK_Temporada = new HashSet<EPK_Temporada>();
        }
    
        public byte IdTipoTemporada { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<EPK_Temporada> EPK_Temporada { get; set; }
    }
}
