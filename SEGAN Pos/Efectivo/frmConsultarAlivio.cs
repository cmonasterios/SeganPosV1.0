using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SEGAN_POS.DAL;
using System.Threading;

namespace SEGAN_POS
{
  public partial class frmConsultarAlivio : Form
  {

    #region Private Properties

    private int IdUsuarioSelected { get; set; }
    private string SelectDate { get; set; }
    private EPK_AlivioEfectivoEncabezado _alivio { get; set; }
    private EPK_Usuario _cajero { get; set; }
    private List<EPK_Denominacion> _denominacion { get; set; }

    #endregion

    #region Constructor

    public frmConsultarAlivio()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void frmConsultarAlivio_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.dtpDesde.Format = DateTimePickerFormat.Custom;
      this.dtpDesde.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.dtpHasta.Format = DateTimePickerFormat.Custom;
      this.dtpHasta.CustomFormat = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;

      this.CargarCombos();
      this.Limpiar();
    }

    private void grdAlivios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

      this.IdUsuarioSelected = Convert.ToInt32(grdAlivios.Rows[e.RowIndex].Cells[0].Value);
      this.tbAlivios.SelectedTab = this.tbAlivios.TabPages[1];
    }

    private void tbAlivios_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.IdUsuarioSelected == 0)
        this.tbAlivios.SelectedTab = this.tbAlivios.TabPages[0];
      else
        this.CargarDatosDetalle(this.IdUsuarioSelected);
    }

    private void grdAlivios_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void frmConsultarAlivio_Shown(object sender, EventArgs e)
    {
      if (new Accesos().VerificarAccesoObjeto(EstadoAplicacion.UsuarioActual.IdUsuario, this.Name))
        return;

      MessageBox.Show(Properties.Resources.ErrorSinAcceso, "Error - " + this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      // TODO: Agregar log? o mover la validación a otro sitio?
      this.Close();
    }

    private void grdAlivios_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void grdAliviosDet_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void grdAliviosDet_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void btLimpiar_Click(object sender, EventArgs e)
    {
      this.Limpiar();
      this.alivioConsultaBindingSource.Clear();
      this.dsAlivioConsultaDet.Clear();
      this.tbAlivios.SelectedTab = this.tbAlivios.TabPages[0];
      this.LimpiarColumnas();
      this.grdAlivios.Refresh();
    }

    private void btBuscar_Click(object sender, EventArgs e)
    {
      this.Buscar();
    }

    private void dtpDesde_ValueChanged(object sender, EventArgs e)
    {
      if (this.dtpHasta.Value < ((DateTimePicker)sender).Value)
        this.dtpHasta.Value = ((DateTimePicker)sender).Value;

      this.dtpHasta.MinDate = ((DateTimePicker)sender).Value;
    }

    private void frmConsultarAlivio_Activated(object sender, EventArgs e)
    {
      this.Text = "Consultar Alivios de Efectivo - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods

    private void CargarDatosDetalle(int idUsuario)
    {
      int? idEstatus = null;
      switch (this.cbEstatus.SelectedIndex) {
        case 0:
          idEstatus = EstadoAplicacion.EstadosAlivio["ALICreacion"];
          break;

        case 1:
          idEstatus = EstadoAplicacion.EstadosAlivio["ALIAprobacion"];
          break;
      }

      DateTime fechaIni = this.dtpDesde.Value;
      DateTime fechaFin = this.dtpHasta.Value;

      //Se agrega un día para que considere la fecha fin Completa y no genere diefencias por las horas
      fechaFin = fechaFin.AddDays(1);

      List<EPK_AlivioEfectivoEncabezado> aliviosDetalle = new AlivioEfectivo().ObtenerTodos(idUsuario, idEstatus, fechaIni, fechaFin).ToList();

      this._denominacion.Clear();

      List<AlivioConsulta> _alivioConsultaDet = this.GenerarAliviosConsultaDet(aliviosDetalle);

      this.dsAlivioConsultaDet.DataSource = _alivioConsultaDet;

      decimal totalAlivio = 0, totalAlivioApro = 0;
      totalAlivio = _alivioConsultaDet.Sum(d => d.MontoConsolidado);
      totalAlivioApro = _alivioConsultaDet.Sum(d => d.MontoAprobado);

      this.txTotalAlivio.Text = totalAlivio.ToString("C2");
      this.txTotalAlivioApro.Text = totalAlivioApro.ToString("C2");

      this.AgregarColumnasDetalle(aliviosDetalle);
    }

    private void Buscar()
    {
      int? idCajero = null;
      if (this.cbCajero.SelectedIndex > -1) {
        int tempInt;
        int.TryParse(this.cbCajero.SelectedValue.ToString(), out tempInt);
        if (tempInt > 0)
          idCajero = tempInt;
      }

      int? idEstatus = null;
      switch (this.cbEstatus.SelectedIndex) {
        case 0:
          idEstatus = EstadoAplicacion.EstadosAlivio["ALICreacion"];
          break;

        case 1:
          idEstatus = EstadoAplicacion.EstadosAlivio["ALIAprobacion"];
          break;
      }

      DateTime fechaIni = this.dtpDesde.Value;
      DateTime fechaFin = this.dtpHasta.Value;

      //Se agrega un día para que considere la fecha fin Completa y no genere diefencias por las horas
      fechaFin = fechaFin.AddDays(1);

      List<EPK_AlivioEfectivoEncabezado> alivios = new AlivioEfectivo().ObtenerTodos(idCajero, idEstatus, fechaIni.Date, fechaFin.Date).ToList();

      this._denominacion = new List<EPK_Denominacion>();

      foreach (EPK_AlivioEfectivoEncabezado item in alivios)
        this.CrearDenominaciones(item.EPK_AlivioEfectivoDetalle);

      List<AlivioConsulta> alivioConsulta = alivios.GroupBy(a => new {
        a.IdUsuarioCajero,
        Cajero = a.EPK_Usuario.Identificacion
      }).Select(g => new AlivioConsulta {
        Id = g.Key.IdUsuarioCajero,
        Cajero = g.Key.Cajero,
        CantidadAlivios = g.Count(),
        MontoConsolidado = g.Sum(d => d.TotalAlivio),
        MontoAprobado = g.Sum(d => d.TotalAprobado ?? 0),
        Pendientes = g.Any(p => p.IdEstatus == Util.ObtenerParametroEntero("ALICreacion"))
      }).ToList();

      foreach (AlivioConsulta item in alivioConsulta)
        item.Semaforo = this.BuscarImagenSemaforo(ValidarDiferencia(item.MontoConsolidado, item.MontoAprobado, item.Pendientes));

      this.alivioConsultaBindingSource.DataSource = alivioConsulta;

      this.AgregarColumnas(alivios);
    }

    private void AgregarColumnas(List<EPK_AlivioEfectivoEncabezado> alivio)
    {
      int indexCol = 6;

      //Se eliminan las columnas de denominaciones
      LimpiarColumnas();

      foreach (EPK_Denominacion item in this._denominacion.OrderByDescending(p => p.Denominacion))
      {
          DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
          col.Name = item.Denominacion.ToString();
          col.HeaderText = item.Denominacion.ToString();
          col.Width = 60;
          grdAlivios.Columns.Insert(indexCol, col);
          indexCol++;
      }

      /*List<EPK_AlivioEfectivoEncabezado> resumen = new List<EPK_AlivioEfectivoEncabezado>();
      foreach (EPK_AlivioEfectivoEncabezado item in alivio) {
        if ((resumen.Count == 0) || (resumen.Count(p => p.IdUsuarioCajero == item.IdUsuarioCajero)) == 0) {
          resumen.Add(new EPK_AlivioEfectivoEncabezado {
            IdUsuarioCajero = item.IdUsuarioCajero,
            EPK_AlivioEfectivoDetalle = item.EPK_AlivioEfectivoDetalle
          });
        }
        else {
          if ((resumen.Count(p => p.IdUsuarioCajero == item.IdUsuarioCajero)) == 0) {
            resumen.Add(new EPK_AlivioEfectivoEncabezado {
              IdUsuarioCajero = item.IdUsuarioCajero,
              EPK_AlivioEfectivoDetalle = item.EPK_AlivioEfectivoDetalle
            });
          }
          else {
            EPK_AlivioEfectivoEncabezado resumenEnc = resumen.First(q => q.IdUsuarioCajero == item.IdUsuarioCajero);
            foreach (EPK_AlivioEfectivoDetalle itemDetalle in resumenEnc.EPK_AlivioEfectivoDetalle) {
              if (resumen.First(q => q.IdUsuarioCajero == item.IdUsuarioCajero).EPK_AlivioEfectivoDetalle.Count(a => a.IdDenominacion == itemDetalle.IdDenominacion) != 0) {
                resumen.First(q => q.IdUsuarioCajero == item.IdUsuarioCajero).EPK_AlivioEfectivoDetalle.First(a => a.IdDenominacion == itemDetalle.IdDenominacion).CantidadCajero += itemDetalle.CantidadCajero;
                resumen.First(q => q.IdUsuarioCajero == item.IdUsuarioCajero).EPK_AlivioEfectivoDetalle.First(a => a.IdDenominacion == itemDetalle.IdDenominacion).CantidadAprobador += itemDetalle.CantidadAprobador;
              }
              else
                resumen.First(q => q.IdUsuarioCajero == item.IdUsuarioCajero).EPK_AlivioEfectivoDetalle.Add(itemDetalle);
            }
          }
        }
      }*/

      foreach (DataGridViewRow row in grdAlivios.Rows) {
        int idUsuario = 0;
        int.TryParse(row.Cells[0].Value.ToString(), out idUsuario);

        foreach (EPK_Denominacion item in this._denominacion.OrderByDescending(p => p.Denominacion)) {
          int col = row.Cells[item.Denominacion.ToString()].ColumnIndex;

          int? cantidad = alivio.Where(r => r.IdUsuarioCajero == idUsuario).
            Sum(r => r.EPK_AlivioEfectivoDetalle.Where(ad => ad.IdDenominacion == item.IdDenominacion).
              Sum(ad => ad.CantidadAprobador ?? 0));

          row.Cells[col].Value = cantidad ?? 0;
        }
      }

      grdAlivios.Refresh();
    }

    private void AgregarColumnasDetalle(List<EPK_AlivioEfectivoEncabezado> _alivioDetalle)
    {
      int nonDataBoundCount = 0;

      do {
        for (int i = 0; i < this.grdAliviosDet.ColumnCount; i++) {
          if (this.grdAliviosDet.Columns[i].IsDataBound)
            continue;

          this.grdAliviosDet.Columns.RemoveAt(i);
        }

        nonDataBoundCount = 0;

        foreach (DataGridViewColumn columnItem in this.grdAliviosDet.Columns)
          if (!columnItem.IsDataBound)
            nonDataBoundCount++;
      }
      while (nonDataBoundCount > 0);

      int indexCol = 6;

      foreach (EPK_Denominacion item in this._denominacion.OrderByDescending(p => p.Denominacion)) {
        DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
        col.Name = item.Denominacion.ToString();
        col.HeaderText = item.Denominacion.ToString();
        col.Width = 60;
        grdAliviosDet.Columns.Insert(indexCol, col);
        indexCol++;
      }

      foreach (DataGridViewRow row in grdAliviosDet.Rows) {
        EPK_AlivioEfectivoEncabezado encResumen = _alivioDetalle.First(a => a.IdAlivioEfectivo == Convert.ToInt32(row.Cells[1].Value));
        foreach (EPK_AlivioEfectivoDetalle itemDetalle in encResumen.EPK_AlivioEfectivoDetalle) {
          Int32 totDef = 0;
          int col = row.Cells[itemDetalle.EPK_Denominacion.Denominacion.ToString()].ColumnIndex;
          if (row.Cells[col].Value != null)
            Int32.TryParse(row.Cells[col].Value.ToString(), out totDef);

          row.Cells[col].Value = totDef + itemDetalle.CantidadAprobador;
        }
      }

      grdAliviosDet.Refresh();
    }

    private List<AlivioConsulta> GenerarAliviosConsultaDet(List<EPK_AlivioEfectivoEncabezado> _alivios)
    {
      this._denominacion = new List<EPK_Denominacion>();
      List<AlivioConsulta> listAlivioConsulta = new List<AlivioConsulta>();
      foreach (EPK_AlivioEfectivoEncabezado item in _alivios) {
        this.CrearDenominaciones(item.EPK_AlivioEfectivoDetalle);

        if (listAlivioConsulta.Count(a => a.Id == item.IdAlivioEfectivo) == 0) {
          listAlivioConsulta.Add(new AlivioConsulta {
            Id = item.IdAlivioEfectivo,
            Caja = item.EPK_Caja.Descripcion,
            Cajero = item.EPK_Usuario.Identificacion,
            CantidadAlivios = 1,
            MontoConsolidado = item.TotalAlivio,
            MontoAprobado = item.TotalAprobado ?? 0,
            Semaforo = BuscarImagenSemaforo(ValidarDiferencia(item.TotalAlivio, item.TotalAprobado ?? 0, (item.IdEstatus == Util.ObtenerParametroEntero("ALICreacion")? true : false))),
            FechaAlivio = item.FechaCreacion,
            FechaVenta = item.FechaAlivio + item.HoraAlivio,
            FechaAprobación = item.FechaHoraAprobacion,

          });
        }
      }
      return listAlivioConsulta;
    }

    private void CrearDenominaciones(ICollection<EPK_AlivioEfectivoDetalle> collection)
    {
      List<EPK_Denominacion> denominaciones = new Denominacion().ObtenerTodas().ToList();

      foreach (EPK_AlivioEfectivoDetalle item in collection) {
        if (this._denominacion.Exists(d => d.IdDenominacion == item.IdDenominacion))
          continue;

        this._denominacion.Add(denominaciones.FirstOrDefault(d => d.IdDenominacion == item.IdDenominacion));
      }
    }

    private byte[] BuscarImagenSemaforo(int _ligth)
    {
      string semaforo = string.Empty;

      ResourceManager rm = Properties.Resources.ResourceManager;
      switch (_ligth) {
        case 0:
          semaforo = "Amarillo";
          break;
        case 1:
          semaforo = "Verde";
          break;
        case 2:
          semaforo = "Rojo";
          break;
      };

      Bitmap myImage = (Bitmap)global::SEGAN_POS.Properties.Resources.ResourceManager.GetObject(semaforo);
      MemoryStream ms = new MemoryStream();
      myImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
      return ms.ToArray();
    }

    private int ValidarDiferencia(decimal _sumAlivios, decimal _sumAprobacion, bool Pendientes)
    {
        int result = 0;

        if (_sumAlivios != _sumAprobacion && !Pendientes)
            result = 0;
        if (_sumAlivios == _sumAprobacion && !Pendientes)
            result = 1;
        if (_sumAlivios != _sumAprobacion && Pendientes)
            result = 2;        

        return result;      
    }

    private void CargarCombos()
    {
      List<EPK_Usuario> usuarios = new Usuarios().ObtenerTodos().ToList();
      this.cbCajero.DataSource = usuarios.OrderBy(p => p.IdUsuario).ToList();
      this.cbCajero.ValueMember = "IdUsuario";
      this.cbCajero.DisplayMember = "Identificacion";
    }

    private void Limpiar()
    {
      this.dtpHasta.MinDate = DateTime.Today;
      this.dtpHasta.MaxDate = DateTime.Today;
      this.dtpDesde.MaxDate = DateTime.Today;

      this.dtpDesde.Value = DateTime.Today;
      this.dtpHasta.Value = DateTime.Today;

      this.cbCajero.SelectedIndex = this.cbEstatus.SelectedIndex = -1;

      this.IdUsuarioSelected = 0;

      this.dtpDesde.Focus();
    }


    private void LimpiarColumnas()
    {
        int MinIndex = 5;
        int MaxIndex = this.grdAlivios.Columns.Count - 1;

        for (int i = MaxIndex; i > MinIndex; i--)
        {
            this.grdAlivios.Columns.RemoveAt(i);
        }
    }

    #endregion

    private void grdAliviosDet_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }


  }
}
