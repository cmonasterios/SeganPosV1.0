using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration.Provider;
using System.IO.Ports;

namespace DisplayManager.Providers
{
  public abstract class DisplayManagerBase : ProviderBase
  {

    protected string _name;

    public override string Name
    {
      get { return _name; }
    }
    protected string _description;

    public override string Description
    {
      get { return _description; }
    }

    public abstract SerialPort InicializeComponent();
    public abstract void FinalizeComponent(SerialPort port);
    public abstract void ClearDisplay(SerialPort port);
    public abstract void EscribirArticulo(SerialPort port, string producto, string precioUnit, string precioTotal);
    public abstract void EscribirLinea(SerialPort port, DisplayManagerEnum.Linea nroLinea, string linea, DisplayManagerEnum.Alineacion alineacion);
    public abstract string AlinearTexto(string linea, DisplayManagerEnum.Alineacion alineacion);
    public abstract void BeginScroll(SerialPort port, int direccion, int IntervalTime, string pLinea1, string pLinea2);
    public abstract void EndScroll();

  }
}
