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
    
    public partial class EPK_Privilegio
    {
        public EPK_Privilegio()
        {
            this.EPK_Empleados = new HashSet<EPK_Empleados>();
        }
    
        public short IdPrivilegio { get; set; }
        public string Descripcion { get; set; }
        public byte[] TStamp { get; set; }
    
        public virtual ICollection<EPK_Empleados> EPK_Empleados { get; set; }
    }
}
