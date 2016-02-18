using EntityFramework.Caching;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace SEGAN_POS.DAL
{
  #region Data Types

  public class ItemArticulo
  {
    public string CodigoArticulo { get; set; }

    public string DescColeccion { get; set; }

    public string DescGenero { get; set; }

    public string DescGrupo { get; set; }

    public string Descripcion { get; set; }

    public int IdArticulo { get; set; }

    public byte[] Imagen { get; set; }

    public EPK_Articulo Articulo { get; set; }
  }

  #endregion Data Types

  public class Articulos : DataAccess
  {
    #region Public Methods

    public List<ItemArticulo> Buscar(int idColeccion, int idGenero, int idGrupo, string codReferencia)
    {
      List<ItemArticulo> results;

      try {
        results = this.context.EPK_Articulo.Where(a =>
            a.EPK_Referencia.Activo &&
            (idColeccion > 0 ? a.EPK_Referencia.IdColeccion == idColeccion : true) &&
            (idGenero > 0 ? a.EPK_Referencia.IdGenero == idGenero : true) &&
            (idGrupo > 0 ? a.EPK_Referencia.IdGrupo == idGrupo : true) &&
            (string.IsNullOrEmpty(codReferencia) ?
             true : a.EPK_Referencia.CodigoReferencia.StartsWith(codReferencia)) &&
            (a.EPK_Referencia.IdColeccion.HasValue ? a.EPK_Referencia.EPK_Coleccion.Activo : true)
          ).Select(a => new ItemArticulo {
            IdArticulo = a.IdArticulo,
            CodigoArticulo = a.CodigoArticulo.Trim(),
            Descripcion = a.Descripcion.Trim(),
            DescColeccion = (a.EPK_Referencia.IdColeccion.HasValue ? a.EPK_Referencia.EPK_Coleccion.Descripcion.Trim() : ""),
            DescGenero = (a.EPK_Referencia.IdGenero.HasValue ? a.EPK_Referencia.EPK_Genero.Descripcion.Trim() : ""),
            DescGrupo = (a.EPK_Referencia.IdGrupo.HasValue ? a.EPK_Referencia.EPK_Grupo.Descripcion.Trim() : ""),
            Imagen = a.EPK_Referencia.FotoMediana,
            Articulo = a
          }).OrderBy(r => r.DescColeccion).ThenBy(r => r.DescGenero).ThenBy(r => r.DescGrupo).ThenBy(r => r.CodigoArticulo)
          .FromCache(CachePolicy.WithDurationExpiration(TimeSpan.FromSeconds(Util.ObtenerParametroEntero("TIMEOUTCACHE")))).ToList();
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);

        results = new List<ItemArticulo>();
      }

      return results;
    }

    public List<PedidoSugerido> BuscarPorColeccion(int idColeccion)
    {
      List<PedidoSugerido> results = context.EPK_Articulo.Where(r => r.EPK_Referencia.IdColeccion == idColeccion && r.Activo).
        Select(a => new PedidoSugerido {
          IdArticulo = a.IdArticulo,
          CodigoArticulo = a.CodigoArticulo,
          Descripcion = a.Descripcion.Trim(),
          IdReferencia = a.IdReferencia,
          Existencia = a.Existencia,
          ExistenciaAlmacen = a.ExistenciaAlmacen.Value == null ? 0 : a.ExistenciaAlmacen.Value,
          ExistenciaNew = 0,
          Venta = a.EPK_FacturaDetalle.Where(fd => fd.EPK_FacturaEncabezado.FechaModificacion >= a.FechaModificacion).Sum(fd => fd.Cantidad + 0),
          Pedido = 0,
          Activo = a.Activo,
          Exento = a.Exento,
          CodigoReferencia = a.EPK_Referencia.CodigoReferencia,
          Foto = a.EPK_Referencia.FotoMediana
        }).ToList();

      return results;
    }

    public IEnumerable<EPK_Articulo> BuscarPorReferencia(string Referencia)
    {
      IEnumerable<EPK_Articulo> results = context.EPK_Articulo.Where(a => a.EPK_Referencia.CodigoReferencia == Referencia /*&& a.Activo*/).
        OrderBy(a => a.EPK_Talla.Orden).
        FromCache(CachePolicy.WithDurationExpiration(TimeSpan.FromSeconds(Util.ObtenerParametroEntero("TIMEOUTCACHE")))).ToList();

      foreach (EPK_Articulo item in results) {
        item.CodigoArticulo = item.CodigoArticulo.Trim();
        item.Descripcion = item.Descripcion.Trim();
      }

      return results;
    }

    public IEnumerable<EPK_Articulo> BuscarPorReferencia(int idReferencia)
    {
      try {
        IEnumerable<EPK_Articulo> results = context.EPK_Articulo.Where(a => a.IdReferencia == idReferencia && a.Activo).
          OrderBy(a => a.EPK_Talla.Orden).
          FromCache(CachePolicy.WithDurationExpiration(TimeSpan.FromSeconds(Util.ObtenerParametroEntero("TIMEOUTCACHE")))).ToList();

        foreach (EPK_Articulo item in results) {
          item.CodigoArticulo = item.CodigoArticulo.Trim();
          item.Descripcion = item.Descripcion.Trim();
        }

        return results;
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }

      return new List<EPK_Articulo>();
    }

    public EPK_Articulo Obtener(int idArticulo)
    {
      EPK_Articulo result = context.EPK_Articulo.FirstOrDefault(a => a.IdArticulo == idArticulo);

      if (result != null) {
        result.CodigoArticulo = result.CodigoArticulo.Trim();
        result.Descripcion = result.Descripcion.Trim();
      }

      return result;
    }

    public EPK_Articulo Obtener(string Codigo)
    {
      EPK_Articulo result = context.EPK_Articulo.FirstOrDefault(a => a.CodigoArticulo == Codigo);

      if (result != null) {
        result.CodigoArticulo = result.CodigoArticulo.Trim();
        result.Descripcion = result.Descripcion.Trim();
      }

      return result;
    }

    public bool AplicaRestriccion(int idArticulo)
    {
        EPK_Articulo Art = this.context.EPK_Articulo.Where(p => p.IdArticulo == idArticulo).FirstOrDefault();

        if (Art == null)
            return false;
        else
            return Art.EPK_Referencia.EPK_Grupo.EPK_TipoPrenda.RestriccionVenta;        
    }

    #endregion Public Methods
  }
}