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
    
    public partial class EPK_Referencia
    {
        public EPK_Referencia()
        {
            this.EPK_Articulo = new HashSet<EPK_Articulo>();
        }
    
        public int IdReferencia { get; set; }
        public string CodigoReferencia { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public Nullable<int> IdGrupo { get; set; }
        public Nullable<int> IdGenero { get; set; }
        public Nullable<int> IdColeccion { get; set; }
        public Nullable<int> IdTema { get; set; }
        public Nullable<int> IdEquivalente { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public byte[] FotoMediana { get; set; }
        public string MimeTypeMediana { get; set; }
        public string FileNameMediana { get; set; }
        public byte[] TStamp { get; set; }
        public bool Obsequio { get; set; }
    
        public virtual EPK_Coleccion EPK_Coleccion { get; set; }
        public virtual EPK_Genero EPK_Genero { get; set; }
        public virtual EPK_Grupo EPK_Grupo { get; set; }
        public virtual EPK_Tema EPK_Tema { get; set; }
        public virtual ICollection<EPK_Articulo> EPK_Articulo { get; set; }
    }
}
