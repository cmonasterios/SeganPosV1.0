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
    
    public partial class EPK_TipoFuncionalidad
    {
        public EPK_TipoFuncionalidad()
        {
            this.EPK_Funcionalidad = new HashSet<EPK_Funcionalidad>();
        }
    
        public int IdTipoFuncionalidad { get; set; }
        public string Descripcion { get; set; }
        public byte[] TStamp { get; set; }
    
        public virtual ICollection<EPK_Funcionalidad> EPK_Funcionalidad { get; set; }
    }
}
