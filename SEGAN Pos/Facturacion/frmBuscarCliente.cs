using DisplayManager.Providers;
using SEGAN_POS.DAL;
using SEGAN_POS.ServicioEPK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace SEGAN_POS
{
  public partial class frmBuscarCliente : Form
  {
    #region Private Properties

    private string _regExVal { get; set; }

    private IEnumerable<EPK_TipoDocumento> _tiposDoc { get; set; }

    #endregion Private Properties

    #region Public Properties

    public EPK_Cliente Cliente { get; set; }

    public bool SinBusqueda { get; set; }

    public List<EPK_ClienteCompra> ListClienteCompra { get; set; }

    #endregion Public Properties

    #region Constructor

    public frmBuscarCliente()
    {
      InitializeComponent();
    }

    public frmBuscarCliente(EPK_Cliente cliente, bool sinBusqueda)
    {
      InitializeComponent();

      this.Cliente = cliente;
      this.SinBusqueda = sinBusqueda;

      if (!this.SinBusqueda)
        this.Cliente = null;
    }

    #endregion Constructor

    #region Events

    private void btBuscar_Click(object sender, EventArgs e)
    {
      this.Buscar();
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      this.Cliente = null;
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void btContinuar_Click(object sender, EventArgs e)
    {
      if (!this.Validar())
        return;

      this.Continuar();
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void cbTipoDoc_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != (char)Keys.Return)
        return;

      this.txDocNum.Focus();
    }

    private void cbTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.SinBusqueda)
        return;

      if (this._tiposDoc == null)
        return;

      if (((ComboBox)sender).SelectedIndex < 0)
        return;

      int idTipoDoc;
      int.TryParse(((ComboBox)sender).SelectedValue.ToString(), out idTipoDoc);

      if (idTipoDoc <= 0)
        return;

      EPK_TipoDocumento tipoDocSel = this._tiposDoc.FirstOrDefault(td => td.IdTipoDocumento == idTipoDoc);

      if (tipoDocSel == null)
        return;

      this.txDocNum.Text = string.Empty;

      this._regExVal = tipoDocSel.Validacion;

      if (tipoDocSel.PersonaNatural) {
        this.lbNombre.Text = "Nombre y Apellidos";
        this.txNombre.Visible = this.txApellido.Visible = true;
        this.txRazonSoc.Visible = false;
        this.txTelef.Text = txEmail.Text = string.Empty;
        this.txDireccion.Text = string.Empty;
        this.txEstatus.Text = this.txNombre.Text = this.txApellido.Text = string.Empty;
      }
      else {
        this.lbNombre.Text = "Razón Social";
        this.txNombre.Visible = this.txApellido.Visible = false;
        this.txRazonSoc.Visible = true;
        this.txRazonSoc.Text = txEmail.Text = this.txTelef.Text = this.txDireccion.Text = string.Empty;
        this.txEstatus.Text = this.txNombre.Text = this.txApellido.Text = string.Empty;
      }
    }

    private void frmBuscarCliente_Activated(object sender, EventArgs e)
    {
      this.Text = "Buscar Cliente - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void frmBuscarCliente_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarCombo();
      this.CargarCliente();

      if (this.SinBusqueda)
        this.cbTipoDoc.Enabled = this.txDocNum.Enabled = this.btBuscar.Enabled = false;
    }

    private void frmBuscarCliente_Shown(object sender, EventArgs e)
    {
      foreach (Control controlItem in this.Controls) {
        if (controlItem.GetType() != typeof(TextBox) || !controlItem.Enabled)
          continue;

        ((TextBox)controlItem).LostFocus += this.OnDefocus;
      }

      if (this.SinBusqueda) {
        if (this.txNombre.Visible)
          this.txNombre.Focus();

        if (this.txRazonSoc.Visible)
          this.txRazonSoc.Focus();
      }
      else
        this.txDocNum.Focus();
    }

    private void OnDefocus(object sender, EventArgs e)
    {
      this.btContinuar.Enabled = this.BotonContinuar();
    }

    private void txApellido_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (e.KeyChar == (char)Keys.Return) {
        this.errorProvider1.SetError((TextBox)sender, "");

        ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

        if (string.IsNullOrEmpty(((TextBox)sender).Text)) {
          this.errorProvider1.SetError((TextBox)sender, Properties.Resources.ValIngreseApellido);
          return;
        }

        this.txDireccion.Focus();
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), @"^[\p{L}\s]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txDireccion_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != (char)Keys.Return)
        return;

      this.errorProvider1.SetError((TextBox)sender, "");

      ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

      if (((TextBox)sender).Text.Length < EstadoAplicacion.MinimaLongitud["MinLengthAddress"])
      {
        this.errorProvider1.SetError((TextBox)sender, Properties.Resources.ValIngreseDirecc);
        return;
      }

      this.txTelef.Focus();
    }

    private void txDocNum_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Tab) {
        base.OnKeyPress(e);
        return;
      }

      if (e.KeyChar == (char)Keys.Return) {
        ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

        if (string.IsNullOrEmpty(((TextBox)sender).Text))
          return;

        if (((TextBox)sender).Text.Length < EstadoAplicacion.MinimaLongitud["MinLengthID"])
        {
          this.errorProvider1.SetError(((TextBox)sender), string.Format(Properties.Resources.ValMinCar, 6));
          e.Handled = true;
          return;
        }

        this.Buscar();

        e.Handled = true;
        return;
      }

      if (string.IsNullOrEmpty(this._regExVal)) {
        base.OnKeyPress(e);
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), this._regExVal))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txEmail_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != (char)Keys.Return)
        return;

      ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

      if (!this.Validar())
        return;

      this.Continuar();
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void txNombre_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (e.KeyChar == (char)Keys.Return) {
        this.errorProvider1.SetError((TextBox)sender, "");

        ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

        if (string.IsNullOrEmpty(((TextBox)sender).Text)) {
          this.errorProvider1.SetError((TextBox)sender, Properties.Resources.ValIngreseNombre);
          return;
        }

        this.txApellido.Focus();
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), @"^[\p{L}\s]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txRazonSoc_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar != (char)Keys.Return)
        return;

      this.errorProvider1.SetError((TextBox)sender, "");

      ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

      if (string.IsNullOrEmpty(((TextBox)sender).Text)) {
        this.errorProvider1.SetError((TextBox)sender, Properties.Resources.ValIngreseRazonSoc);
        return;
      }

      this.txDireccion.Focus();
    }

    private void txTelef_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Back) {
        base.OnKeyPress(e);
        return;
      }

      if (e.KeyChar == (char)Keys.Return) {
        this.errorProvider1.SetError((TextBox)sender, "");

        ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();

        if (((TextBox)sender).Text.Trim().Length < EstadoAplicacion.MinimaLongitud["MinLengthAddress"])
        {
          this.errorProvider1.SetError((TextBox)sender, string.Format(Properties.Resources.ValMinCar, 11));
          return;
        }

        this.txEmail.Focus();
        return;
      }

      if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar.ToString(), @"^[0-9]+$"))
        e.Handled = true;
      else
        base.OnKeyPress(e);
    }

    private void txDocNum_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.txDocNum.Text))
            return;

        if (this.txDocNum.Text.Length < EstadoAplicacion.MinimaLongitud["MinLengthID"])
        {
            this.errorProvider1.SetError(this.txDocNum, string.Format(Properties.Resources.ValMinCar, 6));
            return;
        }

        if (!string.IsNullOrEmpty(this.txDocNum.Text))
        {
            if (this.Cliente == null)
                this.Buscar();
            else
                if (this.Cliente.NumeroDocumento.Trim() != this.txDocNum.Text.Trim())
                    this.Buscar();
        }
    }

    #endregion Events

    #region Private Methods

    public bool BotonContinuar()
    {
      this.LimpiarErrores();

      if (this.txDocNum.Text.Length < 6)
        return false;

      if (this.txNombre.Visible)
        if (string.IsNullOrEmpty(this.txNombre.Text.Trim()))
          return false;

      if (this.txApellido.Visible)
        if (string.IsNullOrEmpty(this.txApellido.Text.Trim()))
          return false;

      if (this.txRazonSoc.Visible)
        if (string.IsNullOrEmpty(this.txRazonSoc.Text.Trim()))
          return false;

      if (this.txDireccion.Text.Trim().Length < 5)
        return false;

      if (this.txTelef.Text.Trim().Length < 11)
        return false;

      return true;
    }

    public void CargarCliente()
    {
      if (this.Cliente == null)
        return;

      this.cbTipoDoc.SelectedValue = this.Cliente.IdTipoDocumento;
      this.txDocNum.Text = this.Cliente.NumeroDocumento.Trim();

      if (this.Cliente.EPK_TipoDocumento.PersonaNatural) {
        this.lbNombre.Text = "Nombre y Apellidos";
        this.txNombre.Visible = this.txApellido.Visible = true;
        this.txRazonSoc.Visible = false;
        this.txTelef.Text = txEmail.Text = string.Empty;
        this.txDireccion.Text = string.Empty;
        this.txEstatus.Text = this.txNombre.Text = this.txApellido.Text = string.Empty;
      }
      else {
        this.lbNombre.Text = "Razón Social";
        this.txNombre.Visible = this.txApellido.Visible = false;
        this.txRazonSoc.Visible = true;
        this.txRazonSoc.Text = txEmail.Text = this.txTelef.Text = this.txDireccion.Text = string.Empty;
        this.txEstatus.Text = this.txNombre.Text = this.txApellido.Text = string.Empty;
      }

      // Se encontró el cliente, se cargan los datos
      if (this.txNombre.Visible) {
        this.txNombre.Text = this.Cliente.Nombre;
        this.txApellido.Text = this.Cliente.Apellido;
      }
      if (this.txRazonSoc.Visible)
        this.txRazonSoc.Text = this.Cliente.Nombre;

      this.txDireccion.Text = this.Cliente.Direccion;
      this.txEmail.Text = this.Cliente.Email;

      if (this.Cliente.EPK_ClienteTelefono != null && this.Cliente.EPK_ClienteTelefono.Where(ct => ct.Principal).Count() > 0)
        this.txTelef.Text = this.Cliente.EPK_ClienteTelefono.FirstOrDefault(ct => ct.Principal).Numero;

      if (this.Cliente.IdEstatus.HasValue)
        this.txEstatus.Text = this.Cliente.EPK_Estatus.Descripcion;

      if (this.Validar())
        this.btContinuar.Focus();

      if (!EstadoAplicacion.TieneVisor)
        return;

      string nombreCliente = string.Empty;
      nombreCliente = Util.GenNomCliente(this.Cliente);

      try {
        BematechDisplay visorManager = new BematechDisplay();

        using (SerialPort serialPort = new SerialPort(EstadoAplicacion.PuertoVisor)) {
          visorManager.ClearDisplay(serialPort);
          visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Primera, "Bienvenido", DisplayManagerEnum.Alineacion.Centrado);
          visorManager.EscribirLinea(serialPort, DisplayManagerEnum.Linea.Segunda, Util.StripAccents("Sr(a). " + nombreCliente), DisplayManagerEnum.Alineacion.Centrado);
        }
      }
      catch (Exception ex) {
        MessageBox.Show(Properties.Resources.ErrorVisor, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

        new NLogLogger().Error(string.Format(Properties.Resources.ErrorVisor + " en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    public bool Validar()
    {
        this.LimpiarErrores();

        if (this.txDocNum.Text.Trim().Length < EstadoAplicacion.MinimaLongitud["MinLengthID"])
        {
            this.errorProvider1.SetError(this.txDocNum, string.Format(Properties.Resources.ValMinCar, 6));
            this.txDocNum.Focus();
            return false;
        }

        if (this.txNombre.Visible)
            if (this.txNombre.Text.Trim().Length < EstadoAplicacion.MinimaLongitud["MinLengthName"])
            {
                this.errorProvider1.SetError(this.txNombre, Properties.Resources.ValIngreseNombre);
                this.txNombre.Focus();
                return false;
            }

        if (this.txApellido.Visible)
            if (this.txApellido.Text.Trim().Length < EstadoAplicacion.MinimaLongitud["MinLengthLastName"])
            {
                this.errorProvider1.SetError(this.txApellido, Properties.Resources.ValIngreseApellido);
                this.txApellido.Focus();
                return false;
            }

        if (this.txRazonSoc.Visible)
            if (this.txRazonSoc.Text.Trim().Length < EstadoAplicacion.MinimaLongitud["MinLengthName"])
            {
                this.errorProvider1.SetError(this.txRazonSoc, Properties.Resources.ValIngreseRazonSoc);
                this.txRazonSoc.Focus();
                return false;
            }

        if (this.txDireccion.Text.Trim().Length < EstadoAplicacion.MinimaLongitud["MinLengthAddress"])
        {
            this.errorProvider1.SetError(this.txDireccion, Properties.Resources.ValIngreseDirecc);
            this.txDireccion.Focus();
            return false;
        }

        if (this.txTelef.Text.Trim().Length < EstadoAplicacion.MinimaLongitud["MinLengthPhone"])
        {
            this.errorProvider1.SetError(this.txTelef, string.Format(Properties.Resources.ValMinCar, 11));
            this.txTelef.Focus();
            return false;
        }

        if (EstadoAplicacion.RestriccionVentasMayor)
        {
            this.ListClienteCompra = new ClienteCompra().GetCompras(this.txDocNum.Text, int.Parse(cbTipoDoc.SelectedValue.ToString()));

            int MaximoPiezas = Util.ObtenerParametroEntero("MaximoPiezas");

            if (this.ListClienteCompra.Sum(p => p.Cantidad) >= MaximoPiezas)
            {
                NotificationManager.Show(this, string.Format(Properties.Resources.MsgMaximoPiezas,
                                         Util.GenDocCliente(this.Cliente),
                                         MaximoPiezas), Color.Red, EstadoAplicacion.ToastTimeout);
            }
        }

        return true;
    }

    private void Buscar()
    {
      this.Limpiar(false);

      this.Refresh();

      if (this.cbTipoDoc.SelectedIndex < 0)
        return;

      if (string.IsNullOrEmpty(this.txDocNum.Text.Trim()))
        return;

      this.btContinuar.Enabled = true;

      int idTipoDoc = 0;
      int.TryParse(this.cbTipoDoc.SelectedValue.ToString(), out idTipoDoc);

      this.Cliente = new Clientes().BuscarPorNumDoc(idTipoDoc, this.txDocNum.Text.Trim());

      if (this.Cliente == null) {
        EstadoAplicacion.RefrescarTienda();

        // No se encontró el cliente, se busca en clientes centralizados
        if (EstadoAplicacion.TiendaActual.ClientesCentralizados && Util.IsConnectedToInternet())
          try {
            ServiceEPKSoapClient servicio = new ServiceEPKSoapClient();

            servicio.Endpoint.Binding.OpenTimeout = new TimeSpan(0, 0, 2);
            servicio.Endpoint.Binding.CloseTimeout = new TimeSpan(0, 0, 2);
            servicio.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 5);
            servicio.Endpoint.Binding.ReceiveTimeout = new TimeSpan(0, 0, 10);

            string result = string.Empty;

            result = servicio.EPK_ConsultarCliente(null, idTipoDoc, this.txDocNum.Text.Trim(), null, null);

            if (!string.IsNullOrEmpty(result)) {
              DataSet Datos = new DataSet();

              XmlReader reader = XmlReader.Create(new System.IO.StringReader(result));

              Datos.ReadXml(reader);

              string nombre = Datos.Tables[0].DefaultView[0]["Nombre"] != null ? Datos.Tables[0].DefaultView[0]["Nombre"].ToString().Trim() : "";
              string apellido = Datos.Tables[0].DefaultView[0]["Apellido"] != null ? Datos.Tables[0].DefaultView[0]["Apellido"].ToString().Trim() : "";
              string direccion = Datos.Tables[0].DefaultView[0]["Direccion"] != null ? Datos.Tables[0].DefaultView[0]["Direccion"].ToString().Trim() : "";
              string email = Datos.Tables[0].DefaultView[0]["Email"] != null ? Datos.Tables[0].DefaultView[0]["Email"].ToString().Trim() : "";

              string telefono = string.Empty;
              if (Datos.Tables[0].Columns.Contains("Telefono"))
                telefono = Datos.Tables[0].DefaultView[0]["Telefono"] != null ? Datos.Tables[0].DefaultView[0]["Telefono"].ToString().Trim() : "";

              if (this.txNombre.Visible) {
                this.txNombre.Text = nombre;
                this.txApellido.Text = apellido;
              }
              if (this.txRazonSoc.Visible)
                this.txRazonSoc.Text = nombre;

              this.txDireccion.Text = direccion;
              this.txEmail.Text = email;

              this.txTelef.Text = telefono;

              if (this.Validar())
                this.btContinuar.Focus();

              return;
            }
          }
          catch (Exception ex) {
            new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
              "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
            this.Cliente = null;
          }
      }

      // No se encontró el cliente
      if (this.Cliente == null) {
        if (this.txNombre.Visible)
          this.txNombre.Focus();
        if (this.txRazonSoc.Visible)
          this.txRazonSoc.Focus();
        this.btContinuar.Enabled = false;
        return;
      }

      this.CargarCliente();
    }

    private void CargarCombo()
    {
      this._tiposDoc = new Clientes().ObtenerTiposDoc();

      if (this._tiposDoc == null)
        return;

      this.cbTipoDoc.DataSource = this._tiposDoc;
      this.cbTipoDoc.ValueMember = "IdTipoDocumento";
      this.cbTipoDoc.DisplayMember = "Descripcion";

      EPK_TipoDocumento principal = this._tiposDoc.FirstOrDefault(td => td.Principal);

      if (principal != null)
        this.cbTipoDoc.SelectedValue = principal.IdTipoDocumento;
    }

    private void Continuar()
    {
      string nombre = string.Empty, apellido = string.Empty;

      if (this.txNombre.Visible) {
        nombre = this.txNombre.Text;
        apellido = this.txApellido.Text;
      }
      if (this.txRazonSoc.Visible) {
        nombre = this.txRazonSoc.Text.Trim();
        if (nombre.Length > 50) {
          apellido = nombre.Substring(50, nombre.Length - 50);
          nombre = nombre.Substring(0, 50);
        }
      }

      if (this.Cliente == null) { // Nuevo cliente.
        int idTipoDoc = 0;
        int.TryParse(this.cbTipoDoc.SelectedValue.ToString(), out idTipoDoc);

        EPK_Cliente nuevoCliente = new EPK_Cliente {
          IdTipoDocumento = (byte)idTipoDoc,
          NumeroDocumento = this.txDocNum.Text.Trim(),
          Nombre = nombre,
          Apellido = apellido,
          Direccion = this.txDireccion.Text,
          IdUsuarioCreacion = EstadoAplicacion.UsuarioActual.IdUsuario,
          Email = this.txEmail.Text,
          IdEstatus = (short?)Util.ObtenerParametroEntero("ESTActivo")
        };

        nuevoCliente.EPK_ClienteTelefono.Add(new EPK_ClienteTelefono { Numero = this.txTelef.Text, Principal = true });

        int newId = new Clientes().Nuevo(nuevoCliente);

        if (newId > 0)
          this.Cliente = new Clientes().Obtener(newId);
        else {
          MessageBox.Show("Error al guardar el cliente", "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.Buscar();
        }

        return;
      }

      bool pendingChanges = false;

      if (this.Cliente.Nombre != nombre || this.Cliente.Apellido != apellido ||
          this.Cliente.Direccion != this.txDireccion.Text || this.Cliente.Email != this.txEmail.Text)
        pendingChanges = true;

      if (this.Cliente.EPK_ClienteTelefono.Where(ct => ct.Principal && ct.Numero == this.txTelef.Text).Count() == 0)
        pendingChanges = true;

      if (pendingChanges) {
        this.Cliente.Nombre = nombre;
        this.Cliente.Apellido = apellido;
        this.Cliente.Direccion = this.txDireccion.Text;
        this.Cliente.Email = this.txEmail.Text;

        if (this.Cliente.EPK_ClienteTelefono.Where(ct => ct.Principal).Count() > 0) {
          this.Cliente.EPK_ClienteTelefono.FirstOrDefault(ct => ct.Principal).Numero = this.txTelef.Text;
        }
        else
          this.Cliente.EPK_ClienteTelefono.Add(new EPK_ClienteTelefono { Numero = this.txTelef.Text, Principal = true });

        new Clientes().Actualizar(this.Cliente.IdCliente, this.Cliente);

        this.Cliente = new Clientes().Obtener(this.Cliente.IdCliente);
      }
    }

    private void Limpiar(bool full = true)
    {
      this.LimpiarErrores();

      this.txNombre.Text = this.txApellido.Text = this.txDireccion.Text = this.txDireccion.Text =
        this.txEmail.Text = this.txTelef.Text = this.txEstatus.Text = string.Empty;

      this.btContinuar.Enabled = false;

      if (full) {
        EPK_TipoDocumento principal = this._tiposDoc.FirstOrDefault(td => td.Principal);

        if (principal != null)
          this.cbTipoDoc.SelectedValue = principal.IdTipoDocumento;

        this.txDocNum.Text = string.Empty;
        this.txDocNum.Focus();
      }
    }

    private void LimpiarErrores()
    {
      this.errorProvider1.SetError(this.txDocNum, "");
      this.errorProvider1.SetError(this.txNombre, "");
      this.errorProvider1.SetError(this.txApellido, "");
      this.errorProvider1.SetError(this.txRazonSoc, "");
      this.errorProvider1.SetError(this.txDireccion, "");
      this.errorProvider1.SetError(this.txTelef, "");
    }

    #endregion Private Methods
  }
}