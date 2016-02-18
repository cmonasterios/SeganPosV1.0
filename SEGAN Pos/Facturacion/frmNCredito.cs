using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SEGAN_POS.DAL;
using System.Text.RegularExpressions;

namespace SEGAN_POS
{
  public partial class frmNCredito : Form
  {

    #region Public Properties

    public int idFactura { get; set; }

    #endregion

    #region Private Properties

    private EPK_FacturaEncabezado _facturaOrig { get; set; }
    private EPK_FacturaEncabezado _facturaSust { get; set; }
    private BindingList<ItemNC> _itemsNC { get; set; }

    private string _fileName { get; set; }
    private string _mimeType { get; set; }
    private byte[] _imagen { get; set; }

    private decimal _totEx { get; set; }
    private decimal _baseImp { get; set; }
    private decimal _totDescuento { get; set; }
    private decimal _totIVA { get; set; }
    private decimal _totalNC { get; set; }

    #endregion

    #region Constructor

    public frmNCredito()
    {
      InitializeComponent();

      this._facturaSust = null;
    }

    public frmNCredito(int idFactura)
    {
      InitializeComponent();

      this.idFactura = idFactura;
      this._itemsNC = new BindingList<ItemNC>();

      this._fileName = this._mimeType = null;
      this._imagen = null;
    }

    #endregion

    #region Events

    private void frmNCredito_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarDatos();
      this.CalcularTotal();
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.errorProvider1.SetError(this.txNombre, "");

      this.errorProvider1.SetError(this.btImagen, "");
      this.errorProvider1.SetError(this.txObs, "");

      this.txObs.Text = this.txObs.Text.Trim();

      if (this.txNombre.Text.Trim().Length < 3) {
        this.errorProvider1.SetError(this.txNombre, Properties.Resources.ValIngreseNombre);
        this.txNombre.Focus();
        return;
      }

      if (this._imagen == null) {
        this.errorProvider1.SetError(this.btImagen, Properties.Resources.ValImagenTicket);
        return;
      }

      if (string.IsNullOrEmpty(this.txObs.Text)) {
        this.errorProvider1.SetError(this.txObs, Properties.Resources.ValMotivoSolNC);
        return;
      }

      if (this._itemsNC.Any(p => p.Devolucion) && this._itemsNC.Sum(p=>p.CantidadNC) != this._facturaOrig.EPK_FacturaDetalle.Sum(p=>p.Cantidad))
      {
          MessageBox.Show(Properties.Resources.ValNotaConDev, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
      }

      if (this._facturaSust == null) {
        if (MessageBox.Show(Properties.Resources.MsgConfirmSolNCNoSust, "Confirmación " + this.Text,
          MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
          return;
      }
      else {
        if (MessageBox.Show(Properties.Resources.MsgConfirmSolNC, "Confirmación " + this.Text,
          MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
          return;
      }

      try {
        this.Cursor = Cursors.WaitCursor;

        decimal porcDescuento = this._facturaOrig.PorcDescuento;

        EPK_NotaCreditoEsperaEncabezado nuevaNCEsp = new EPK_NotaCreditoEsperaEncabezado {
          IdFactura = this._facturaOrig.IdFactura,
          PorcDescuento = porcDescuento,
          MontoBase = this._baseImp,
          MontoDescuento = this._totDescuento,
          MontoIVA = this._totIVA,
          MontoTotal = this._totalNC,
          SerialMF = this._facturaOrig.SerialMF,
          Motivo = this.txObs.Text,
          Imagen = this._imagen,
          MimeType = this._mimeType,
          FileName = this._fileName,
          NombreCliente = this.txNombre.Text.Trim(),
          OrigenTienda = true
        };

        nuevaNCEsp.IdFacturaSust = null;
        if (this._facturaSust != null)
          nuevaNCEsp.IdFacturaSust = this._facturaSust.IdFactura;

        nuevaNCEsp.EPK_NotaCreditoEsperaDetalle = this._itemsNC.Where(i => i.CantidadNC > 0).
          Select(i => new EPK_NotaCreditoEsperaDetalle {
            IdArticulo = i.IdArticulo,
            Cantidad = i.CantidadNC,
            Precio = i.PrecioBase,
            Descuento = i.Descuento,
            MontoDescuento = Util.TruncarDecimal(Util.TruncarDecimal(i.PrecioBase * porcDescuento / 100, 2) * i.CantidadNC, 2),
            Exento = i.Exento,
            MontoImpuesto = i.MontoIVA,
            PrecioNeto = i.PrecioNeto,
            Cambio = i.Devolucion
          }).ToList();

        int idNCEsp = new NotasCredito().NuevaSolicitud(nuevaNCEsp);

        if (idNCEsp <= 0) {
          MessageBox.Show(Properties.Resources.ErrorGenSolNC, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          return;
        }

        MessageBox.Show(string.Format(Properties.Resources.ExitoSolNC, idNCEsp), this.Text,
          MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception ex) {
        this.Cursor = Cursors.Default;
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
        MessageBox.Show(Properties.Resources.ErrorGenSolNC, "Error " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }

      this.Cursor = Cursors.Default;
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }

    private void dgItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void frmNCredito_Activated(object sender, EventArgs e)
    {
      this.Text = "Solicitar Nota de Crédito - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void btImagen_Click(object sender, EventArgs e)
    {
      frmImagen fImg = new frmImagen();

      fImg.Titulo = this.btImagen.Text;
      fImg.Imagen = this._imagen;
      fImg.FileName = this._fileName;
      fImg.MimeType = this._mimeType;

      if (fImg.ShowDialog() == DialogResult.OK) {
        this._imagen = fImg.Imagen;
        this._fileName = fImg.FileName;
        this._mimeType = fImg.MimeType;
      }
    }

    private void dgItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dgItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      ItemNC itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as ItemNC);

      if (itemSel == null)
        return;

      if (itemSel.Cantidad == itemSel.CantidadNCProc)
        return;

      frmCantidad fCant = new frmCantidad();
      fCant.Titulo = "Cantidad N/C";
      fCant.ValorMinimo = 0;
      fCant.ValorMaximo = itemSel.Cantidad - itemSel.CantidadNCProc;
      fCant.Cantidad = itemSel.CantidadNC;
      fCant.ShowDialog();

      if (fCant.DialogResult != System.Windows.Forms.DialogResult.OK)
        return;

      if (fCant.Cantidad == itemSel.CantidadNC)
        return;

      ItemNC item = this._itemsNC.FirstOrDefault(i => i.IdArticulo == itemSel.IdArticulo && i.Devolucion == itemSel.Devolucion);

      if (item == null)
        return;

      item.CantidadNC = fCant.Cantidad;

      ((DataGridView)sender).Refresh();
      this.CalcularTotal();
    }

    private void btBuscarFact_Click(object sender, EventArgs e)
    {
      frmBuscarFact fBuscarFact = new frmBuscarFact();

      fBuscarFact.idFacturaOrig = this.idFactura;

      if (fBuscarFact.ShowDialog() != DialogResult.OK)
        return;

      this.lbNombre2.Text = this.lbDoc2.Text = this.lbNroFactura2.Text = this.lbTicketFiscal2.Text =
        this.lbTotal2.Text = string.Empty;

      int idFactSust = fBuscarFact.idFacturaSust;

      if (idFactSust <= 0)
        return;

      this._facturaSust = new Facturas().Obtener(idFactSust);

      if (this._facturaSust == null)
        return;

      string rifCliente = Util.GenDocCliente(this._facturaSust.EPK_Cliente);
      string nombreCliente = Util.GenNomCliente(this._facturaSust.EPK_Cliente);

      this.lbNombre2.Text = nombreCliente;
      this.lbDoc2.Text = rifCliente;
      this.lbNroFactura2.Text = this._facturaSust.IdFactura.ToString();
      this.lbTicketFiscal2.Text = this._facturaSust.TicketFiscal;
      this.lbTotal2.Text = string.Format("{0:c}", this._facturaSust.MontoTotal);
    }

    private void cbTodos_Click(object sender, EventArgs e)
    {
      if (((CheckBox)sender).Checked)
        foreach (ItemNC item in this._itemsNC)
          item.CantidadNC = item.Cantidad - item.CantidadNCProc;
      else
        foreach (ItemNC item in this._itemsNC)
          item.CantidadNC = 0;

      this.dgItems.Refresh();
      this.CalcularTotal();
    }

    #endregion

    #region Private Methods

    private void CargarDatos()
    {
      if (this.idFactura <= 0)
        return;

      this._facturaOrig = new Facturas().Obtener(this.idFactura);

      if (this._facturaOrig == null)
        return;

      int idNCRechazada = EstadoAplicacion.EstadosNC["NCRechazada"];
      int idNCEmitida = EstadoAplicacion.EstadosNC["NCEmitida"];
      int idNCAnulada = EstadoAplicacion.EstadosNC["NCAnulada"];

      this.lbDocumento.Text = Util.GenDocCliente(this._facturaOrig.EPK_Cliente);
      this.txNombre.Text = Util.GenNomCliente(this._facturaOrig.EPK_Cliente);
      this.lbDireccion.Text = this._facturaOrig.EPK_Cliente.Direccion;
      this.lbEmail.Text = this._facturaOrig.EPK_Cliente.Email;

      if (this._facturaOrig.EPK_Cliente.EPK_ClienteTelefono != null &&
        this._facturaOrig.EPK_Cliente.EPK_ClienteTelefono.Where(ct => ct.Principal).Count() > 0)
        this.lbTelefono.Text = this._facturaOrig.EPK_Cliente.EPK_ClienteTelefono.FirstOrDefault(ct => ct.Principal).Numero;

      decimal totExento = this._facturaOrig.EPK_FacturaDetalle.Where(fd => !fd.Cambio && fd.Exento).Sum(fd => fd.Cantidad * fd.PrecioNeto) -
        this._facturaOrig.EPK_FacturaDetalle.Where(fd => fd.Cambio && fd.Exento).Sum(fd => fd.Cantidad * fd.PrecioNeto);

      // Datos de la Factura
      this.lbNroFactura.Text = this._facturaOrig.IdFactura.ToString();
      this.lbSubtotal.Text = string.Format("{0:c}", this._facturaOrig.MontoBase + totExento);
      this.lbTotIVA.Text = string.Format("{0:c}", this._facturaOrig.MontoIVA);
      this.lbTotal.Text = string.Format("{0:c}", this._facturaOrig.MontoTotal);
      this.lbEstatusFact.Text = this._facturaOrig.EPK_Estatus.Descripcion;
      this.lbFechaFact.Text = this._facturaOrig.FechaCreacion.ToString();
      this.lbNombreCaja.Text = this._facturaOrig.EPK_Caja.Descripcion;
      this.lbNombreCajero.Text = this._facturaOrig.EPK_Usuario.Identificacion.Trim();

      if (this._facturaOrig.IdVendedor.HasValue) {
        this.lbVend.Text = this._facturaOrig.EPK_Empleados.Nombre + " " + this._facturaOrig.EPK_Empleados.Apellido;
        this.lbVendedor.Visible = true;
      }

      this.lbNroCOO.Text = this._facturaOrig.COO;
      this.lbImpresora.Text = this._facturaOrig.SerialMF;
      this.lbZ.Text = this._facturaOrig.NroReporteZ;
      this.lbTicketFiscal.Text = this._facturaOrig.TicketFiscal;

      // Articulos de la factura
      foreach (EPK_FacturaDetalle itemDetalle in this._facturaOrig.EPK_FacturaDetalle) {
        this._itemsNC.Add(new ItemNC {
          IdArticulo = itemDetalle.IdArticulo,
          CodigoArticulo = itemDetalle.EPK_Articulo.CodigoArticulo.Trim(),
          Descripcion = itemDetalle.EPK_Articulo.Descripcion.Trim(),
          IdReferencia = itemDetalle.EPK_Articulo.IdReferencia,
          DescRef = itemDetalle.EPK_Articulo.EPK_Referencia.Descripcion.Trim(),
          Cantidad = itemDetalle.Cantidad,

          PrecioBase = itemDetalle.Precio,
          PrecioNeto = itemDetalle.PrecioNeto,
          MontoDescuento = itemDetalle.MontoDescuento,
          PrecioVenta = Util.TruncarDecimal(itemDetalle.PrecioNeto * itemDetalle.Cantidad, 2),
          MontoIVA = itemDetalle.MontoImpuesto,

          Descuento = itemDetalle.Descuento,
          Exento = itemDetalle.Exento,

          Devolucion = itemDetalle.Cambio,
          CantidadNC = 0,
          CantidadNCProc = (itemDetalle.EPK_FacturaEncabezado.EPK_NotaCreditoEncabezado.Where(nc => nc.IdEstatus != idNCAnulada).Sum(
                              nc => nc.EPK_NotaCreditoDetalle.Where(nd => nd.IdArticulo == itemDetalle.IdArticulo && nd.Cambio == itemDetalle.Cambio).Sum(nd => nd.Cantidad)) +
                            itemDetalle.EPK_FacturaEncabezado.EPK_NotaCreditoEsperaEncabezado.Where(
                              nc => nc.IdEstatus != idNCRechazada && nc.IdEstatus != idNCEmitida && nc.IdEstatus != idNCAnulada
                            ).Sum(nc => nc.EPK_NotaCreditoEsperaDetalle.Where(nd => nd.IdArticulo == itemDetalle.IdArticulo && nd.Cambio == itemDetalle.Cambio).Sum(nd => nd.Cantidad)))
        });
      }

      this.dgItems.DataSource = this._itemsNC;
      this.dgItems.Refresh();
    }

    private void CalcularTotal()
    {
      this.btOK.Enabled = false;

      this._totEx = this._baseImp = this._totDescuento = this._totIVA = this._totalNC = 0;

      this.txDesc.Text = this.txTotExento.Text = this.txSubtotal.Text = this.txIVA.Text =
        this.txTotalNC.Text = string.Format("{0:C2}", 0);

      decimal porcDescuento = this._facturaOrig.PorcDescuento;

      foreach (ItemNC item in (this._itemsNC.Where(i => i.CantidadNC > 0).ToList())) {
        if (item.Devolucion) {
          if (item.Exento)
            this._totEx -= (Util.TruncarDecimal(item.PrecioBase * item.CantidadNC, 2) - Util.TruncarDecimal((item.PrecioBase * item.CantidadNC) * porcDescuento / 100, 2));
          else
            this._baseImp -= (item.PrecioBase * item.CantidadNC) - Util.TruncarDecimal((item.PrecioBase * item.CantidadNC) * porcDescuento / 100, 2);

          this._totDescuento -= Util.TruncarDecimal((item.PrecioBase * item.CantidadNC) * porcDescuento / 100, 2);
        }
        else {
          if (item.Exento)
            this._totEx += (Util.TruncarDecimal(item.PrecioBase * item.CantidadNC, 2) - Util.TruncarDecimal((item.PrecioBase * item.CantidadNC) * porcDescuento / 100, 2));
          else
            this._baseImp += (item.PrecioBase * item.CantidadNC) - Util.TruncarDecimal((item.PrecioBase * item.CantidadNC) * porcDescuento / 100, 2);

          this._totDescuento += Util.TruncarDecimal((item.PrecioBase * item.CantidadNC) * porcDescuento / 100, 2);
        }
      }

      decimal valorIVA = EstadoAplicacion.AplicaImpuesto? Util.ObtenerParametroDecimal("IVA", this._facturaOrig.FechaCreacion) : 0;

      this._totIVA = Math.Round(this._baseImp * valorIVA / 100, 2);
      this._totalNC = Math.Round(this._baseImp + this._totEx + this._totIVA, 2);

      decimal subTot = Math.Round(this._baseImp + this._totEx, 2);

      this.txDesc.Text = string.Format("{0:C2}", this._totDescuento);
      this.txTotExento.Text = string.Format("{0:C2}", this._totEx);
      this.txIVA.Text = string.Format("{0:C2}", this._totIVA);
      this.txSubtotal.Text = string.Format("{0:C2}", subTot);
      this.txTotalNC.Text = string.Format("{0:C2}", this._totalNC);

      int cantFact = this._itemsNC.Sum(i => i.Cantidad - i.CantidadNCProc);
      int cantNC = this._itemsNC.Sum(i => i.CantidadNC);

      this.btOK.Enabled = (this._totalNC > 0);
      this.cbTodos.Checked = (cantFact == cantNC);
    }

    #endregion

  }
}
