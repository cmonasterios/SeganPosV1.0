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
    
    public partial class EPK_PerfilObjetos
    {
        public int IdPerfil { get; set; }
        public int IdObjeto { get; set; }
        public bool Habilitado { get; set; }
        public byte[] TStamp { get; set; }
    
        public virtual EPK_Objeto EPK_Objeto { get; set; }
        public virtual EPK_Perfil EPK_Perfil { get; set; }
    }
}
