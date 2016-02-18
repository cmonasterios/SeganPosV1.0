using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmAprobarAlivio : Form
  {

    #region Private Properties

    private EPK_AlivioEfectivoEncabezado _alivio { get; set; }
    private EPK_Usuario _cajero { get; set; }

    #endregion

    #region Constructor

    public frmAprobarAlivio()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void frmAprobarAlivio_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarDatos();
    }

    private void grdAlivios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      AlivioAprobacion itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as AlivioAprobacion);

      if (itemSel == null)
        return;

      frmAutorizarAlivio fAutorizarAlivio = new frmAutorizarAlivio(itemSel.IdAlivio);

      if (fAutorizarAlivio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        this.CargarDatos();
    }

    private void grdAlivios_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void frmAprobarAlivio_Shown(object sender, EventArgs e)
    {
      if (new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name))
        return;

      MessageBox.Show(Properties.Resources.ErrorSinAcceso, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      // TODO: Agregar log? o mover la validación a otro sitio?
      this.Close();
    }

    private void frmAprobarAlivio_Activated(object sender, EventArgs e)
    {
      this.Text = "Aprobación de Alivio de Efectivo de " + EstadoAplicacion.UsuarioActual.Identificacion + " - " +
        Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods

    private void CargarDatos()
    {
      List<EPK_AlivioEfectivoEncabezado> _alivios = new AlivioEfectivo().ObtenerPorAprobar();
      List<AlivioAprobacion> _alivioAprobar = this.GenerarAliviosAprobar(_alivios);

      alivioAprobacionBindingSource.DataSource = _alivioAprobar;
    }

    private List<AlivioAprobacion> GenerarAliviosAprobar(List<EPK_AlivioEfectivoEncabezado> _alivios)
    {
      List<AlivioAprobacion> _listAlivioAprobar = new List<AlivioAprobacion>();

      foreach (EPK_AlivioEfectivoEncabezado item in _alivios) {
        _listAlivioAprobar.Add(new AlivioAprobacion {
          IdAlivio = item.IdAlivioEfectivo,
          FechaAlivio = (item.FechaAlivio + item.HoraAlivio),
          HoraAlivio = item.HoraAlivio,
          IdCaja = item.IdCaja,
          Caja = item.EPK_Caja.Descripcion,
          Cajero = item.EPK_Usuario.Identificacion
        });
      }

      return _listAlivioAprobar;
    }

    #endregion

  }
}
