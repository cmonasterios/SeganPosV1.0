using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;

namespace SEGAN_POS.DAL
{
    public class ClienteCompra : DataAccess
    {
        #region Public Class

        public class ClienteComp 
        {
            public byte IdTipoDocumento { get; set; }
            public string NumeroDocumento { get; set; }
            public int IdArticulo { get; set; }
            public int Cantidad { get; set; }
            public bool Devolucion { get; set; }
        }

        #endregion

        #region Constructor

        public ClienteCompra(bool skip = false)
        : base(skip)
        {
        }

        #endregion

        #region Public Methods

        public List<EPK_ClienteCompra> GetCompras(string NumeroDocumento, int IdTipo)
        {
            try
            {
                return this.context.EPK_ClienteCompra.Where(p => p.NumeroDocumento == NumeroDocumento && p.IdTipoDocumento == IdTipo).ToList();
            }
            catch(Exception ex)
            {
                new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
                
                return new List<EPK_ClienteCompra>();
            }
        }

        public bool SaveCompras(List<ClienteComp> ClienteCompras)
        {
            try
            {
                int MaxArt = Util.ObtenerParametroEntero("MaximoArticulo");
                int LInf = Util.ObtenerParametroEntero("LimMinBloqueo");
                int LSup = Util.ObtenerParametroEntero("LimMaxBloqueo");

                foreach (ClienteComp Item in ClienteCompras)
                {
                    EPK_ClienteCompra C = this.context.EPK_ClienteCompra.Where(p => p.NumeroDocumento == Item.NumeroDocumento &&
                                                                                    p.IdTipoDocumento == Item.IdTipoDocumento &&
                                                                                    p.IdArticulo == Item.IdArticulo).FirstOrDefault();
                    if (C == null)
                    {
                        C = new EPK_ClienteCompra();
                        C.IdTipoDocumento = Item.IdTipoDocumento;
                        C.IdArticulo = Item.IdArticulo;
                        C.NumeroDocumento = Item.NumeroDocumento;
                        C.Cantidad = (byte)(Item.Cantidad > 0 ? Item.Cantidad : 0);
                        C.FechaUltAct = DateTime.Now;

                        this.context.EPK_ClienteCompra.Add(C);
                    }
                    else
                    {
                        int Cant = C.Cantidad + Item.Cantidad;
                        C.Cantidad = Cant > 0 ? (byte)Cant : byte.MinValue;
                        this.context.Entry(C).State = EntityState.Modified;
                    }

                    //Se bloquea el articulo si se compró el máximo de Articulos de una sola vez
                    if (Item.Cantidad >= MaxArt && !Item.Devolucion)
                    {
                        int Lapso = new Random().Next(LInf, LSup);

                        EPK_Articulo Articulo = this.context.EPK_Articulo.Where(P => P.IdArticulo == Item.IdArticulo).FirstOrDefault();
                        Articulo.FechaInicioBloqueo = DateTime.Now;
                        Articulo.FechaFinBloqueo = DateTime.Now.AddMinutes(Lapso);

                        this.context.Entry(Articulo).State = EntityState.Modified;
                    }                  

                }

                this.context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
                
                return false;           
            }           
        
        }
        
        #endregion 
    }
}
