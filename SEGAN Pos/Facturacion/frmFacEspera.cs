using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using SEGAN_POS.DAL;
using System.Web.UI.WebControls;

namespace SEGAN_POS
{
  public partial class frmFacEspera : Form
  {

    #region Public Properties

    public int idFacturaEspera { get; set; }
    public int itemSeleccionado { get; set; }
    public ItemsEspera itemSel { get; set; }

    #endregion

    #region Constructor

    public frmFacEspera()
    {
      InitializeComponent();

      this.idFacturaEspera = 0;
    }

    #endregion

    #region Events

    private void frmFacEspera_Load(object sender, EventArgs e)
    {
      Icon appIcon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
      this.Icon = appIcon;

      this.CargarDatos();
    }

    private void btOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.OK;

      new frmFacturar(itemSeleccionado);
    
      this.Close();
    }

    private void btCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }

    private void dgFacEspera_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
    {
      e.Cancel = true;
    }

    private void dgFacEspera_SelectionChanged(object sender, EventArgs e)
    {
      this.btOK.Enabled = false;
      this.idFacturaEspera = 0;

      if (((DataGridView)sender).SelectedRows.Count == 0)
        return;

      ItemsEspera itemSel = (((DataGridView)sender).SelectedRows[0].DataBoundItem as ItemsEspera);
    //  this.itemSeleccionado = int.Parse(dgFacEspera.CurrentRow.Index.ToString()); 
      

      if (itemSel == null)
        return;

      if (itemSel.Indicador == 1 || itemSel.Indicador == 2) {
        this.idFacturaEspera = itemSel.IdFacturaEspera;
        if (itemSel.Indicador == 1)
            this.itemSeleccionado = int.Parse(dgFacEspera.CurrentRow.Index.ToString()) ;
        if (itemSel.Indicador == 2)
            this.itemSeleccionado = int.Parse(dgFacEspera.CurrentRow.Index.ToString());
        this.btOK.Enabled = true;
      }
    }

    private void frmFacEspera_Activated(object sender, EventArgs e)
    {
      this.Text = "Facturas en Espera - " + Application.ProductName;

      if (EstadoAplicacion.Contingencia != EstadoContingencia.Normal)
        this.Text += " " + Properties.Resources.IndContingencia;
    }

    #endregion

    #region Private Methods

    private void CargarDatos()
    {
      List<EPK_FacturaEsperaEncabezado> facsEspera = new FacturasEspera().ObtenerPorCajaDia(EstadoAplicacion.CajaActual.IdCaja);

      if (facsEspera == null)
        return;

      List<ItemsEspera> listadoEspera = facsEspera.Select(fe => new ItemsEspera {
        IdFacturaEspera = fe.IdFacturaEspera,
        NombreCliente = Util.GenNomCliente(fe.EPK_Cliente),
        DocCliente = Util.GenDocCliente(fe.EPK_Cliente),
        idEstatus = fe.IdEstatus,
        Estatus = fe.EPK_Estatus.Descripcion,
        FechaCreacion = fe.FechaCreacion,
        Indicador = 0,
        Semaforo = null
      }).ToList();

      short eCreada = EstadoAplicacion.EstadosFactura["FACCreada"];
      short eExpirada = EstadoAplicacion.EstadosFactura["FACExpirada"];
      short eCancelada = EstadoAplicacion.EstadosFactura["FACCancelada"];

      DateTime currDate = new DataAccess(true).FechaDB();

      foreach (ItemsEspera item in listadoEspera) {
        if (item.idEstatus == eExpirada){
              item.Semaforo = Properties.Resources.gris;
              item.Indicador = 3;
              continue;
          }

        if (item.idEstatus == eCancelada) {
          item.Semaforo = Properties.Resources.Rojo;
          item.Indicador = 3;
          continue;
        }

        if (item.idEstatus == eCreada)
          if (Math.Abs((item.FechaCreacion - currDate).TotalSeconds) >= EstadoAplicacion.TimeoutFacturaEspera &&
            Math.Abs((item.FechaCreacion - currDate).TotalSeconds) < (EstadoAplicacion.TimeoutFacturaEspera * 2)) {
            item.Semaforo = Properties.Resources.Amarillo;
            item.Indicador = 2;
            continue;
          }
          else {
            item.Semaforo = Properties.Resources.Verde;
            item.Indicador = 1;
          }
      }

      this.dgFacEspera.DataSource = listadoEspera.OrderBy(le => le.Indicador).ThenBy(le => le.FechaCreacion).ToList();
      this.dgFacEspera.Refresh();
    }

    #endregion

    private void dgFacEspera_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        this.itemSeleccionado = int.Parse(dgFacEspera.CurrentRow.Index.ToString()); 
        //this.dgFacEspera itemSel = (dgFacEspera)DataGridView.CurrentRow.DataBoundItem;
       // ItemsEspera itemSel = (((DataGridView)sender).CurrentRow.DataBoundItem as ItemsEspera);
    }

  }
}
