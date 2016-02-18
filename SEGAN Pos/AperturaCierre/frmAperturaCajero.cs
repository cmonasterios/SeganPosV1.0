using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SEGAN_POS.ServicioEPK;
using SEGAN_POS.DAL;
using System.Text;
using DisplayManager.Providers;
//using System.Timers;

namespace SEGAN_POS
{
  public partial class frmAperturaCajero : Form
  {

    #region Private Properties

    private BindingList<DenominacionAlivio> _denominacionesAlivio { get; set; }

    #endregion

    #region Constructor

    public frmAperturaCajero()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmAperturaCajero_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarDatos();
    }

    public void btOK_Click(object sender, EventArgs e)
    {
      ((Button)sender).Enabled = false;
      Cursor.Current = Cursors.WaitCursor;

      if (new AperturaCajero().ObtenerActiva(EstadoAplicacion.UsuarioActual.IdUsuario) != null)
      {
          MessageBox.Show(Properties.Resources.MsgCajaYaAbierta, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Close();
          return;
      }

      EPK_AperturaCajeroEncabezado nuevaApertura = new EPK_AperturaCajeroEncabezado();

      nuevaApertura.IdCaja = EstadoAplicacion.CajaActual.IdCaja;
      nuevaApertura.IdCajero = EstadoAplicacion.UsuarioActual.IdUsuario;

      nuevaApertura.EPK_AperturaCajeroDenominacion = this._denominacionesAlivio.Where(da => da.Cantidad > 0).Select(da => new EPK_AperturaCajeroDenominacion {
        IdDenominacion = da.IdDenominacion,
        Cantidad = (byte)da.Cantidad
      }).ToList();

       long idApertura = new AperturaCajero().Nuevo(nuevaApertura);

      Util.ClearMessages();
      Cursor.Current = Cursors.Default;

      if (idApertura <= 0)
      {
          MessageBox.Show("Se produjo un error creando la apertura", Application.ProductName);
          ((Button)sender).Enabled = true;
          return;
      }
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
      }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void dgDenominaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      DenominacionAlivio itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as DenominacionAlivio);

      if (itemSel == null)
        return;

      frmCantidad fCant = new frmCantidad();
      fCant.ValorMinimo = 0;
      fCant.ValorMaximo = byte.MaxValue;
      fCant.Cantidad = itemSel.Cantidad;
      fCant.ShowDialog();

      if (fCant.DialogResult != System.Windows.Forms.DialogResult.OK)
        return;

      if (fCant.Cantidad == itemSel.Cantidad)
        return;

    
        itemSel.Cantidad = (byte)fCant.Cantidad;
        itemSel.TotalXDenominacion = itemSel.Cantidad * itemSel.Denominacion;       

      ((DataGridView)sender).Refresh();

      this.CalcularTotal();
    }

    private void frmAperturaCajero_Shown(object sender, EventArgs e)
    {
      if (new CierreVentas().Obtener() != null) {
        MessageBox.Show(Properties.Resources.MsgCierreVentaExiste, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.Close();
        return;
      }

      EPK_AperturaCajeroEncabezado aperturaPrevia = new AperturaCajero().ObtenerActiva(EstadoAplicacion.UsuarioActual.IdUsuario);

      if (aperturaPrevia != null) {
        MessageBox.Show(Properties.Resources.MsgCajaYaAbierta, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.Close();
      }
    }

    // En caso de que una imagen sea invalida, esto evita que se muestre un mensaje de error al usuario.
    private void dgDenominaciones_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void dgDenominaciones_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void frmAperturaCajero_Activated(object sender, EventArgs e)
    {
      this.Text = "Apertura de cajero de " + EstadoAplicacion.UsuarioActual.Identificacion + " - " +
        Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods

    private void CalcularTotal()
    {
      decimal total = this._denominacionesAlivio.Sum(da => da.Cantidad * da.Denominacion);

      this.txtMontoApertura.Text = string.Format("{0:C2}", total);

      this.btOK.Enabled = (total > 0 && total <= EstadoAplicacion.TiendaActual.TopeApertura);
    }

    private void CargarDatos()
    {
      DateTime currDate = new DataAccess(true).FechaDB();

      this.txCajero.Text = EstadoAplicacion.UsuarioActual.Identificacion;
      this.txCaja.Text = EstadoAplicacion.CajaActual.Descripcion;
      this.txtFecha.Text = currDate.ToString();

      IEnumerable<EPK_Denominacion> denominaciones = new Denominacion().ObtenerTodas();

      this._denominacionesAlivio = new BindingList<DenominacionAlivio>(
        denominaciones.Select(d => new DenominacionAlivio {
          IdDenominacion = d.IdDenominacion,
          Denominacion = d.Denominacion,
          Logo = d.Logo,
          Cantidad = 0,
          TotalXDenominacion = 0
        }).ToList());

      this.dgDenominaciones.DataSource = this._denominacionesAlivio;

      if (EstadoAplicacion.TiendaActual.TopeApertura > 0) {
        this.lbMaximo.Text = string.Format(Properties.Resources.MsgMaxApertura, EstadoAplicacion.TiendaActual.TopeApertura);
        this.lbMaximo.Visible = true;
      }
    }

    #endregion     
  

  }
}
