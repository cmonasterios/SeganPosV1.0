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
    
    public partial class EPK_Accion
    {
        public EPK_Accion()
        {
            this.EPK_ObjetoAccion = new HashSet<EPK_ObjetoAccion>();
            this.EPK_PerfilAccion = new HashSet<EPK_PerfilAccion>();
        }
    
        public int IdAccion { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitada { get; set; }
        public Nullable<int> IdUsuarioEliminacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public byte[] TStamp { get; set; }
    
        public virtual ICollection<EPK_ObjetoAccion> EPK_ObjetoAccion { get; set; }
        public virtual ICollection<EPK_PerfilAccion> EPK_PerfilAccion { get; set; }
    }
}
