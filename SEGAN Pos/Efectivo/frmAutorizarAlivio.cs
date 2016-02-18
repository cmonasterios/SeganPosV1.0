using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SEGAN_POS.DAL;

namespace SEGAN_POS
{
  public partial class frmAutorizarAlivio : Form
  {

    #region Private Properties

    private decimal _montoAlivio { get; set; }
    private decimal _montoAprobado { get; set; }

    private EPK_AlivioEfectivoEncabezado _alivio { get; set; }

    #endregion

    #region Constructor

    public frmAutorizarAlivio(long idAlivio)
    {
      InitializeComponent();

      this._montoAlivio = this._montoAprobado = 0;
      this._alivio = new AlivioEfectivo().Obtener(idAlivio);
    }

    #endregion

    #region Events

    private void frmAutorizarAlivio_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarDatos();
    }

    private void grdAlivio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      if (e.ColumnIndex != 3 && e.ColumnIndex != 5)
        return;

      AlivioAutorizacion itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as AlivioAutorizacion);

      if (itemSel == null)
        return;

      frmCantidad fCant = new frmCantidad();

      switch (e.ColumnIndex) {
        case 3:
          string login = _alivio.EPK_Usuario.Login;
          frmAutorizar fAut = new frmAutorizar();
          fAut.Login = _alivio.EPK_Usuario.Login;
          fAut.Mensaje = "¿ Permitir cambio de cantidad del alivio ?"; // TODO: Reemplazar este mensaje.
          fAut.ShowDialog();

          if (fAut.DialogResult != System.Windows.Forms.DialogResult.OK || !fAut.Autorizado)
            return; // TODO: que hacer cuando la autorización falla ?

          fCant.ValorMinimo = 0;
          fCant.Cantidad = itemSel.CantidadCajero;
          fCant.ShowDialog();

          if (fCant.DialogResult != System.Windows.Forms.DialogResult.OK)
            return;

          if (fCant.Cantidad == itemSel.CantidadCajero)
            return;

          itemSel.CantidadCajero = fCant.Cantidad;
          itemSel.MontoCajero = itemSel.CantidadCajero * Convert.ToDecimal(itemSel.Denominacion);
          itemSel.Diferencia = itemSel.MontoCajero - itemSel.MontoAprobado;

          //Si edita la cantidad reportada debe ingresar la cantidad aprobada nuevamente
          itemSel.CantidadAprobada = 0;
          itemSel.MontoAprobado = 0;
          itemSel.Diferencia = itemSel.MontoCajero - itemSel.MontoAprobado;
          break;

        case 5:
          fCant.ValorMinimo = 0;
          fCant.ValorMaximo = itemSel.CantidadCajero;
          fCant.Cantidad = itemSel.CantidadAprobada;
          fCant.ShowDialog();

          if (fCant.DialogResult != System.Windows.Forms.DialogResult.OK)
            return;

          if (fCant.Cantidad == itemSel.CantidadAprobada)
            return;

          itemSel.CantidadAprobada = fCant.Cantidad;
          itemSel.MontoAprobado = itemSel.CantidadAprobada * Convert.ToDecimal(itemSel.Denominacion);
          itemSel.Diferencia = itemSel.MontoCajero - itemSel.MontoAprobado;
          break;
      }

      this.CalcularTotales();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      bool advertencia = false;

      foreach (DataGridViewRow row in this.grdAlivio.Rows) {
        int cantRep = Convert.ToInt32(row.Cells[3].Value);
        int cantidad = Convert.ToInt32(row.Cells[5].Value);

        if (cantRep > 0 && cantidad == 0) {
          advertencia = true;
          break;
        }
      }

      if (advertencia)
        if (MessageBox.Show(Properties.Resources.MsgAproAliCero, "Advertencia " + this.Text,
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
          return;

      if (MessageBox.Show(string.Format(Properties.Resources.MsgConfApAlivio, this._alivio.EPK_Usuario.Identificacion,
        this._montoAlivio, this._montoAprobado), "Confirmación " + this.Text, MessageBoxButtons.YesNo,
        MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
        return;

      this._alivio.IdUsuarioAprobador = EstadoAplicacion.UsuarioActual.IdUsuario;
      this._alivio.TotalAprobado = Convert.ToDecimal(this.txMontoAprobado.Tag);
      this._alivio.IdEstatus = EstadoAplicacion.EstadosAlivio["ALIAprobacion"];

      this._alivio.EPK_AlivioEfectivoDetalle = this.GenerarDetalleAlivio().ToList();

      if (!new AlivioEfectivo().Actualizar(this._alivio)) {
        MessageBox.Show("Se produjo un error actualizando el alivio de efectivo", Application.ProductName);
        return;
      }

      new EfectivoRemanente().Guardar(this._alivio.IdAlivioEfectivo);

      MessageBox.Show(string.Format("Se realizó la autorización del alivio número {0} con éxito", _alivio.IdAlivioEfectivo),
        Application.ProductName);

      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void grdAlivio_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      if (e.ColumnIndex != 5)
        e.Cancel = true;
    }

    private void frmAutorizarAlivio_Shown(object sender, EventArgs e)
    {
      if (new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name))
        return;

      MessageBox.Show(Properties.Resources.ErrorSinAcceso, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      // TODO: Agregar log? o mover la validación a otro sitio?
      this.Close();
    }

    private void grdAlivio_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void frmAutorizarAlivio_Activated(object sender, EventArgs e)
    {
      this.Text = "Aprobación de Alivio de Efectivo de " + EstadoAplicacion.UsuarioActual.Identificacion + " - " +
        Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods

    private void CalcularTotales()
    {
      decimal totalporDenominacion = 0, totalAprobado = 0, totalAlivio = 0, diferencia = 0;

      foreach (DataGridViewRow row in this.grdAlivio.Rows) {
        totalporDenominacion = 0;
        int cantidad = Convert.ToInt32(row.Cells[5].Value);
        decimal denominacion = Convert.ToDecimal(row.Cells[2].Value);
        decimal total = cantidad * denominacion;
        decimal alivio = Convert.ToDecimal(row.Cells[3].Value) * denominacion;

        decimal.TryParse(total.ToString(), out totalporDenominacion);

        row.Cells[6].Value = totalporDenominacion;
        row.Cells[7].Value = Convert.ToDecimal(row.Cells[4].Value) - Convert.ToDecimal(row.Cells[6].Value);
        totalAprobado += totalporDenominacion;
        totalAlivio += alivio;

        diferencia += Convert.ToDecimal(row.Cells[7].Value);

        row.DefaultCellStyle.ForeColor = this.grdAlivio.DefaultCellStyle.ForeColor;

        if (row.Index >= 0) {
          int cantRep = Convert.ToInt32(row.Cells[3].Value);

          if (cantRep != 0)
            row.DefaultCellStyle.Font = new Font(this.grdAlivio.DefaultCellStyle.Font, FontStyle.Bold);

          if (cantRep != 0 || cantidad != 0) {
            if (cantRep == cantidad)
              row.DefaultCellStyle.ForeColor = Color.Green;
            else
              row.DefaultCellStyle.ForeColor = Color.Red;
          }
        }
      }

      if (totalAprobado > 0)
        this.btOK.Enabled = true;
      else
        this.btOK.Enabled = false;

      this._montoAlivio = totalAlivio;
      this._montoAprobado = totalAprobado;

      this.txMontoAlivio.Text = totalAlivio.ToString("C2");
      this.txMontoAprobado.Text = totalAprobado.ToString("C2");
      this.txMontoAprobado.Tag = totalAprobado.ToString();
      this.txDiferencia.Text = diferencia.ToString("C2");

      if (diferencia > 0)
          this.txDiferencia.ForeColor = Color.Red;
      else
          this.txDiferencia.ForeColor = Color.Black;
    }

    private IEnumerable<EPK_AlivioEfectivoDetalle> GenerarDetalleAlivio()
    {
      List<EPK_AlivioEfectivoDetalle> listAlivioEfectivoDetalle = new List<EPK_AlivioEfectivoDetalle>();

      foreach (DataGridViewRow row in this.grdAlivio.Rows) {
        int cantidad = 0;
        int.TryParse(row.Cells[5].Value.ToString(), out cantidad);
        if (cantidad != 0) {
          listAlivioEfectivoDetalle.Add(new EPK_AlivioEfectivoDetalle {
            IdDenominacion = Convert.ToByte(Convert.ToDecimal(row.Cells[0].Value)),
            CantidadAprobador = (short)cantidad
          });
        }
      }

      return listAlivioEfectivoDetalle;
    }

    private void CargarDatos()
    {
      this.txCajero.Text = _alivio.EPK_Usuario.Identificacion;
      this.txCaja.Text = _alivio.EPK_Caja.Descripcion;
      this.txIdAlivio.Text = _alivio.IdAlivioEfectivo.ToString();
      this.txFechaAlivio.Text = _alivio.FechaAlivio.ToString("d") + " " + _alivio.HoraAlivio.ToString(@"hh\:mm\:ss");
      this.txMontoSistema.Text = _alivio.TotalPagosEfectivo.ToString("C2");
      this.txMontoSistema.Tag = _alivio.TotalPagosEfectivo.ToString();
      this.txMontoAlivio.Text = _alivio.TotalAlivio.ToString("C2");

      List<AlivioAutorizacion> _AlivioDetalle = GenerarDetalleAutorizacion(_alivio.EPK_AlivioEfectivoDetalle);

      this.alivioAutorizacionBindingSource.DataSource = _AlivioDetalle.OrderByDescending(a => Convert.ToDecimal(a.Denominacion));

      this.CalcularTotales();
    }

    private List<AlivioAutorizacion> GenerarDetalleAutorizacion(ICollection<EPK_AlivioEfectivoDetalle> epkAlivioEfectivoDetalle)
    {
      List<AlivioAutorizacion> _listAlivioAutorizacion = new List<AlivioAutorizacion>();
      foreach (EPK_AlivioEfectivoDetalle item in epkAlivioEfectivoDetalle) {
        _listAlivioAutorizacion.Add(new AlivioAutorizacion {
          IdDenominacion = item.IdDenominacion,
          Logo = item.EPK_Denominacion.Logo,
          Denominacion = item.EPK_Denominacion.Denominacion.ToString(),
          CantidadCajero = item.CantidadCajero,
          MontoCajero = (item.CantidadCajero * item.EPK_Denominacion.Denominacion),
          CantidadAprobada = 0,
          MontoAprobado = 0,
          Diferencia = 0
        });
      }

      return _listAlivioAutorizacion;
    }

    #endregion


  }
}
