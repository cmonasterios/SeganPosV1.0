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
  public partial class frmConciliarAlivio : Form
  {

    #region Private Properties

    private EPK_AlivioEfectivoEncabezado _alivio { get; set; }

    #endregion

    #region Public Properties

    public bool Conciliado { get; set; }

    #endregion

    #region Constructor

    public frmConciliarAlivio(long idAlivio)
    {
      InitializeComponent();

      this._alivio = new AlivioEfectivo().Obtener(idAlivio);
    }

    #endregion

    #region Events

    private void ConciliarAlivio_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarCombos();
      this.CargarDatos();

      this.Conciliado = false;
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.errorProvider1.SetError(this.cbMotivoDesc, "");
      this.errorProvider1.SetError(this.txtObservacion, "");

      if (string.IsNullOrEmpty(this.cbMotivoDesc.Text.Trim())) {
        this.errorProvider1.SetError(this.cbMotivoDesc, "Debe indicar el motivo del descuento");
        this.cbMotivoDesc.Focus();
        return;
      }

      if (string.IsNullOrEmpty(this.txtObservacion.Text.Trim())) {
        this.errorProvider1.SetError(this.txtObservacion, "Debe incicar una observación para el descuento");
        this.txtObservacion.Focus();
        return;
      }

      this.Cursor = Cursors.WaitCursor;
      Conciliado = GuardarAlivio();
      this.Cursor = Cursors.Default;
    }

    private void frmConciliarAlivio_Shown(object sender, EventArgs e)
    {
      if (new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name))
        return;

      MessageBox.Show(Properties.Resources.ErrorSinAcceso, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      // TODO: Agregar log? o mover la validación a otro sitio?
      this.Close();
    }

    private void frmConciliarAlivio_Activated(object sender, EventArgs e)
    {
      this.Text = "Conciliar de Alivio de Efectivo de " + EstadoAplicacion.UsuarioActual.Identificacion + " - " +
        Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods
    private void CargarDatos()
    {
      this.txCajero.Text = _alivio.EPK_Usuario.Identificacion;
      this.txCaja.Text = _alivio.EPK_Caja.Descripcion;
      this.txMontoSistema.Text = _alivio.TotalPagosEfectivo.ToString();
      this.txMontoAlivio.Text = _alivio.TotalAlivio.ToString();
      this.txDiferencia.Text = (_alivio.TotalAlivio - _alivio.TotalAprobado).ToString();

    }

    private void CargarCombos()
    {
      this.cbMotivoDesc.Focus();

      List<EPK_MotivoDescuento> motivosDesc = new MotivosDescuento().ObtenerTodos().ToList();

      this.cbMotivoDesc.DataSource = motivosDesc;
      this.cbMotivoDesc.ValueMember = "IdMotivoDesc";
      this.cbMotivoDesc.DisplayMember = "Motivo";

      if (motivosDesc.Count() == 1) {
        this.cbMotivoDesc.SelectedIndex = 0;
        this.cbMotivoDesc.Enabled = false;
      }
    }

    private bool GuardarAlivio()
    {
      _alivio.IdMotivoDesc = Convert.ToByte(this.cbMotivoDesc.SelectedValue.ToString());
      _alivio.Observacion = this.txtObservacion.Text;

      return new AlivioEfectivo().Actualizar(_alivio);

    }
    #endregion

  }
}
