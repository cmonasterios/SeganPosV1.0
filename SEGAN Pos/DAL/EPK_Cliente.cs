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
    
    public partial class EPK_Cliente
    {
        public EPK_Cliente()
        {
            this.EPK_ClienteFormaPago = new HashSet<EPK_ClienteFormaPago>();
            this.EPK_ClienteTelefono = new HashSet<EPK_ClienteTelefono>();
            this.EPK_FacturaEncabezado = new HashSet<EPK_FacturaEncabezado>();
            this.EPK_FacturaEsperaEncabezado = new HashSet<EPK_FacturaEsperaEncabezado>();
            this.EPK_HistoricoFacturaEncabezado = new HashSet<EPK_HistoricoFacturaEncabezado>();
        }
    
        public int IdCliente { get; set; }
        public string NumeroDocumento { get; set; }
        public byte IdTipoDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public Nullable<int> IdEstadoNacimiento { get; set; }
        public string Credito { get; set; }
        public Nullable<short> IdEstatus { get; set; }
        public Nullable<bool> Especial { get; set; }
        public Nullable<byte> IdTipoDescuento { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuarioModificacion { get; set; }
        public byte[] TStamp { get; set; }
    
        public virtual EPK_Estado EPK_Estado { get; set; }
        public virtual EPK_Estatus EPK_Estatus { get; set; }
        public virtual EPK_TipoDescuento EPK_TipoDescuento { get; set; }
        public virtual EPK_TipoDocumento EPK_TipoDocumento { get; set; }
        public virtual ICollection<EPK_ClienteFormaPago> EPK_ClienteFormaPago { get; set; }
        public virtual ICollection<EPK_ClienteTelefono> EPK_ClienteTelefono { get; set; }
        public virtual ICollection<EPK_FacturaEncabezado> EPK_FacturaEncabezado { get; set; }
        public virtual ICollection<EPK_FacturaEsperaEncabezado> EPK_FacturaEsperaEncabezado { get; set; }
        public virtual ICollection<EPK_HistoricoFacturaEncabezado> EPK_HistoricoFacturaEncabezado { get; set; }
    }
}
