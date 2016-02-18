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
    
    public partial class EPK_Grupo
    {
        public EPK_Grupo()
        {
            this.EPK_Referencia = new HashSet<EPK_Referencia>();
            this.EPK_TemporadaGrupo = new HashSet<EPK_TemporadaGrupo>();
        }
    
        public int IdGrupo { get; set; }
        public string CodigoGrupo { get; set; }
        public string Descripcion { get; set; }
        public byte IdTipoPrenda { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public byte[] TStamp { get; set; }
    
        public virtual ICollection<EPK_Referencia> EPK_Referencia { get; set; }
        public virtual ICollection<EPK_TemporadaGrupo> EPK_TemporadaGrupo { get; set; }
        public virtual EPK_TipoPrenda EPK_TipoPrenda { get; set; }
    }
}
