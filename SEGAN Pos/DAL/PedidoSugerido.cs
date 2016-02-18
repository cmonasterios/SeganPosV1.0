using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SEGAN_POS.DAL
{
  public class PedidoSugerido
  {

    public int IdArticulo { get; set; }
    public string CodigoArticulo { get; set; }
    public string Descripcion { get; set; }
    public int IdReferencia { get; set; }
    public short Existencia { get; set; }
    public int ExistenciaAlmacen { get; set; }
    public int ExistenciaNew { get; set; }
    public int? Venta { get; set; }
    public int Pedido { get; set; }
    public bool Activo { get; set; }
    public bool Exento { get; set; }
    public string CodigoReferencia { get; set; }
    public byte[] Foto { get; set; }

  }
}
