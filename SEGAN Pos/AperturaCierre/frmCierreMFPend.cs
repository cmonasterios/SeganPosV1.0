using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Microsoft.AspNet.Scaffolding;
//using Microsoft.AspNet.Scaffolding.EntityFramework;

using SEGAN_POS.DAL;
using System.Data.SqlClient;
using System.Data.Entity;



namespace SEGAN_POS
{
  public partial class frmCierreMFPend : Form
  {

    #region Public Properties

    public DateTime Fecha { get; set; }

    public List<DispositivoCaja> DispCaja { get; set; }

    public List<EPKCierreMaquinaValidar> CierreMaquinaValidar { get; set; }
      

    #endregion

    #region Constructor

    public frmCierreMFPend()
    {
      InitializeComponent();
    }

    public frmCierreMFPend(DateTime fecha)
    {
      InitializeComponent();

      this.Fecha = fecha;
    }

    #endregion

    #region Events

    private void frmCierreMFPend_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarDatos();
    }

    private void btRefrescar_Click(object sender, EventArgs e)
    {
      this.CargarDatos();
    }

    private void btCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void dgItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      if (e.ColumnIndex != 4)
        e.Cancel = true;
    }

    private void dgItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {

    }

    private void dgItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
      if (((DataGridView)sender).IsCurrentCellDirty)
        ((DataGridView)sender).CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void frmCierreMFPend_Activated(object sender, EventArgs e)
    {
      this.Text = "Cierres de Máquina Fiscal Pendientes - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    private void dgItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) // Header
        return;

     EPKCierreMaquinaValidar itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as EPKCierreMaquinaValidar);
     // DispositivoCaja itemSel = (((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as DispositivoCaja);

      if (itemSel == null)
        return;

      if(new frmCierreMFManual(itemSel.IdDispositivo, this.Fecha.Date).ShowDialog() == DialogResult.OK)
        this.CargarDatos();
    }

    #endregion

    #region Private Methods

    private void CargarDatos()
    {
      try {
        this.lbMensaje.Text = string.Format(this.lbMensaje.Text, this.Fecha);

        List<EPK_Dispositivo> dispPend = new Dispositivos().PendientesPorCierre(Fecha);
        //List<EPK_FacturaEncabezado> facturas = new Facturas().ObtenerTodas(EstadoAplicacion.UsuarioActual.IdUsuario, this._fechaIniNuevoCierre);

        //BindingList<CierreCajeroEntidad> tempList = new BindingList<CierreCajeroEntidad>();
        //this.DispCaja = dispPend.Select(d => new DispositivoCaja
        //{
        //    IdCaja = d.EPK_CajaDispositivo.Where(p => p.FechaFin == null).FirstOrDefault() != null ? d.EPK_CajaDispositivo.Where(p => p.FechaFin == null).FirstOrDefault().EPK_Caja.IdCaja : 0,
        //    DescCaja = d.EPK_CajaDispositivo.Where(p => p.FechaFin == null).FirstOrDefault() != null ? d.EPK_CajaDispositivo.Where(p => p.FechaFin == null).FirstOrDefault().EPK_Caja.Descripcion : "",
        //    IdDispositivo = d.EPK_CajaDispositivo.Where(p => p.FechaFin == null).FirstOrDefault() != null ? d.IdDispositivo : 0,
        //    Serial = d.EPK_CajaDispositivo.Where(p => p.FechaFin == null).FirstOrDefault() != null ? d.Serial : "",
        //    Exclude = false
        //}).ToList();
        //this.dgItems.DataSource = this.DispCaja;
        BindingList<EPKCierreMaquinaValidar> query = new BindingList<EPKCierreMaquinaValidar>(); ;
         using (var entities = new SEGANPOSEntities())
        {
          var dispPend1 = new CierreMaquinaValidar().Obtener(this.Fecha, this.Fecha).ToList();
          foreach (var item in dispPend1.ToList())
          {
              var SerialMF = item.SerialMF;
              var FechaCierre = item.Fecha;
              var MontoSistemaF = item.MontoSistemaF;
              var MontoReportadoF = item.MontoReportadoF;
              var DiferenciaF = item.DiferenciaF;
              var MontoSistemaNC = item.MontoSistemaNC;
              var MontoReportadONC = item.MontoReportadONC;
              var DiferenciaNC = item.DiferenciaNC;
             var resultado = (from d in entities.EPK_Dispositivo
             join t in entities.EPK_CajaDispositivo on d.IdDispositivo equals t.IdDispositivo
             where (t.FechaFin == null)
             join x in entities.EPK_Caja on t.IdCaja equals x.IdCaja
                             where d.Serial == SerialMF
                             orderby x.Descripcion
                             select new EPKCierreMaquinaValidar
             {
                 IdCaja = t.IdCaja,
                 DescCaja = x.Descripcion,
                 IdDispositivo = d.IdDispositivo,
                 Serial = d.Serial,
                 FechaCierre = FechaCierre,
                 MontoSistemaF = MontoSistemaF,
                 MontoReportadoF = MontoReportadoF,
                 DiferenciaF = DiferenciaF,
                 MontoSistemaNC = MontoSistemaNC,
                 MontoReportadONC = MontoReportadONC,
                 DiferenciaNC = DiferenciaNC,
                 Exclude = false
             }).ToList();

             query.Add(new EPKCierreMaquinaValidar
             {
                 IdCaja = resultado.FirstOrDefault().IdCaja,
                 DescCaja = resultado.FirstOrDefault().DescCaja,
                 IdDispositivo = resultado.FirstOrDefault().IdDispositivo,
                 Serial = resultado.FirstOrDefault().Serial,
                 FechaCierre = FechaCierre,
                 MontoSistemaF = MontoSistemaF,
                 MontoReportadoF = MontoReportadoF,
                 DiferenciaF = DiferenciaF,
                 MontoSistemaNC = MontoSistemaNC,
                 MontoReportadONC = MontoReportadONC,
                 DiferenciaNC = DiferenciaNC,
                 Exclude = false});
            
          }
          this.dgItems.DataSource = query;
         
          this.CierreMaquinaValidar = query.ToList();
         }
        
        this.dgItems.Refresh();
      
      }
      catch (Exception ex) {
        new NLogLogger().Error(string.Format("Error en {0}", System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName +
          "." + System.Reflection.MethodBase.GetCurrentMethod().Name), ex);
      }
    }

    #endregion


  }
}
