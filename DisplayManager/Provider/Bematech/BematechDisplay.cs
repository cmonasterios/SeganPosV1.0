using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.IO.Ports;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DisplayManager.Providers
{
  public class BematechDisplay : DisplayManagerBase
  {
    private Thread thread;

    private string portName;
    private SerialPort Internalport;
    private string InternalLinea1;
    private string InternalLinea2;
    private int InternalDireccion = 0;
    private int InternalInterval;
    private bool scrolling;

    public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
    {
      #region Attributes check
      if ((config == null) || (config.Count == 0))
        throw new ArgumentNullException("You must supply a valid configuration parameters.");
      this._name = name;
      #endregion

      #region Description
      if (string.IsNullOrEmpty(config["description"])) {
        throw new ProviderException("You must specify a description attribute.");
      }
      this._description = config["description"];
      config.Remove("description");
      #endregion

      #region Port
      if (String.IsNullOrEmpty(config["port"]))
        throw new ProviderException("The Port COM is invalid.");
      this.portName = config["port"];
      config.Remove("port");
      #endregion

      #region Extra Attributes validations
      if (config.Count > 0) {
        string extraAttribute = config.GetKey(0);
        if (!String.IsNullOrEmpty(extraAttribute))
          throw new ProviderException("The following unrecognized attribute was found in " + Name + "'s configuration: '" +
                                      extraAttribute + "'");
        else
          throw new ProviderException("An unrecognized attribute was found in the provider's configuration.");
      }
      #endregion
    }

    /// <summary>
    /// Se utiliza para realizar la configuracion del puerto con valores por defecto de 
    /// parida, Baud ratio, Databits y bit de parada
    /// </summary>
    /// <param name="Puerto"></param>
    /// <returns>Puerto serial con estatus abierto</returns>
    public override System.IO.Ports.SerialPort InicializeComponent()
    {
      SerialPort port;

      port = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
      port.Handshake = Handshake.None;
      if (!port.IsOpen)
        port.Open();

      return port;
    }

    /// <summary>
    /// Realiza el cierre de conexion con el puerto serial que se le envía
    /// </summary>
    /// <param name="port">Puerto Serial</param>
    public override void FinalizeComponent(SerialPort port)
    {
      port.Dispose();
      port.Close();
    }

    /// <summary>
    /// Permite limpiar la pantalla del Pole Display
    /// </summary>
    /// <param name="port">Puerto Serial</param>
    public override void ClearDisplay(SerialPort port)
    {
      if (!port.IsOpen)
        port.Open();

      port.Write(Convert.ToChar(12).ToString());
    }

    /// <summary>
    /// Se encarga de escribir el articulo con su precio y subtotal en el Pole Display
    /// </summary>
    /// <param name="port">Puerto Serial</param>
    /// <param name="producto">Nombre del Producto</param>
    /// <param name="precioUnit">Precio Unitario</param>
    /// <param name="precioTotal">SubTotal</param>
    public override void EscribirArticulo(SerialPort port, string producto, string precioUnit, string precioTotal)
    {
      string linea1 = string.Empty;
      string linea2 = string.Empty;

      linea1 = AlinearTexto(producto, DisplayManagerEnum.Alineacion.Izquierda);
      linea2 = AlinearTexto(precioUnit, DisplayManagerEnum.Alineacion.Izquierda).Substring(0, 20 - (precioTotal.Length + 2)) + "<" + precioTotal + ">";
      EscribirLinea(port, DisplayManagerEnum.Linea.Primera, linea1, DisplayManagerEnum.Alineacion.Izquierda);
      EscribirLinea(port, DisplayManagerEnum.Linea.Segunda, linea2, DisplayManagerEnum.Alineacion.Centrado);
    }

    /// <summary>
    /// Se utiliza para escribir lineas en el Pole Display, con la alineacion que se quiera
    /// </summary>
    /// <param name="port">Puerto Serial</param>
    /// <param name="nroLinea">Nro de Linea en la que se escribira</param>
    /// <param name="linea">Texto a escribir</param>
    /// <param name="alineacion">Tipo de alineacion a utilizar</param>
    public override void EscribirLinea(SerialPort port, DisplayManagerEnum.Linea nroLinea, string linea, DisplayManagerEnum.Alineacion alineacion)
    {
      linea = this.AlinearTexto(linea, alineacion);

      if (nroLinea == DisplayManagerEnum.Linea.Primera)
        port.Write(linea);
      else
        port.WriteLine(linea);
    }

    /// <summary>
    /// Se utiliza para estructurar el texto con el formato de 20 caracteres y alineacion deseada
    /// </summary>
    /// <param name="linea">texto a esxribir</param>
    /// <param name="alineacion">Tipo de alineacion a utilizar</param>
    /// <returns>Devuelve una cadena de 20 caracteres con la alineacion requerida</returns>
    public override string AlinearTexto(string linea, DisplayManagerEnum.Alineacion alineacion)
    {
      string retorno = string.Empty;

      if (linea.Length == 20)
        return linea;

      if (linea.Length > 20)
        return linea.Substring(0, 20);

      switch (alineacion) {
        case DisplayManagerEnum.Alineacion.Izquierda:
          retorno = String.Format("{0,-20}", linea);
          break;
        case DisplayManagerEnum.Alineacion.Derecha:
          retorno = String.Format("{0,20}", linea);
          break;
        case DisplayManagerEnum.Alineacion.Centrado: {
            retorno = (String.Format("{0," + ((20 - linea.Length) / 2 + (linea.Length)).ToString() + "}", linea));
            retorno = retorno + Indent((20 - retorno.Length), ' ');
            break;
          }
        default:
          retorno = String.Format("{0,-20}", linea);
          break;
      }
      return retorno;
    }

    /// <summary>
    /// se utiliza solo para para la alineacion centrado, devuelve una cadena repetida del caracter "pad"
    /// </summary>
    /// <param name="count">tamaño de la cadena</param>
    /// <param name="pad">Caracter a repetir</param>
    /// <returns></returns>
    private static string Indent(int count, char pad)
    {
      return String.Empty.PadLeft(count, pad);
    }

    /// <summary>
    /// Se Utiliza para realizar el scrolling del texto en el Pole Display
    /// </summary>
    /// <param name="port">Puerto Serial</param>
    /// <param name="direccion">Direccion de la animacion</param>
    /// <param name="IntervalTime">Tiempo de delay de la animacion en milisegundos</param>
    /// <param name="pLinea1">Primera linea</param>
    /// <param name="pLinea2">Segunda linea</param>
    public override void BeginScroll(SerialPort port, int direccion, int IntervalTime, string pLinea1, string pLinea2)
    {
      ClearDisplay(port);
      scrolling = true;
      Internalport = port;
      InternalDireccion = direccion;
      InternalLinea1 = pLinea1;
      InternalLinea2 = pLinea2;
      InternalInterval = IntervalTime;

      thread = new Thread(BeginStandBy); //(BeginStandBy(port, direccion, pLinea1, pLinea2));
      thread.Start();
    }

    /// <summary>
    /// Se utiliza para cuando se va a modo stand by del pole display
    /// </summary>
    private void BeginStandBy(object obj)
    {
      while (scrolling) {
        if (InternalLinea1.Length < 20)
          InternalLinea1 = AlinearTexto(InternalLinea1, DisplayManagerEnum.Alineacion.Centrado);

        if (InternalLinea2.Length < 20)
          InternalLinea2 = AlinearTexto(InternalLinea2, DisplayManagerEnum.Alineacion.Centrado);

        string[] retorno = timer_Elapsed(Internalport, InternalLinea1, InternalLinea2, InternalDireccion);

        InternalLinea1 = retorno[0];
        InternalLinea2 = retorno[1];
        Thread.Sleep(100);
        if (!scrolling)
          break;
      }
    }

    /// <summary>
    /// Realiza la escritura de las cadenas y las modifica para la proxima escritura
    /// </summary>
    /// <param name="port">Puerti Serial</param>
    /// <param name="direccion">Direccion de la animacion</param>
    /// <param name="pLinea1">Primera linea</param>
    /// <returns>El retorno es un arreglo con las dos lineas que van cambiando mientras se esta en modo standby</returns>
    private string[] timer_Elapsed(SerialPort port, string pLinea1, string pLinea2, int pDireccion)
    {
      string newLinea1 = string.Empty;
      string newLinea2 = string.Empty;
      if (pDireccion == 0) {
        newLinea1 = pLinea1.Substring(pLinea1.Length - 1, 1) + pLinea1.Substring(0, pLinea1.Length - 1);
        newLinea2 = pLinea2.Substring(pLinea2.Length - 1, 1) + pLinea2.Substring(0, pLinea2.Length - 1);
      }
      else {
        newLinea1 = pLinea1.Substring(1, pLinea2.Length - 1) + pLinea1.Substring(0, 1);
        newLinea2 = pLinea2.Substring(1, pLinea2.Length - 1) + pLinea2.Substring(0, 1);
      }
      EscribirLinea(port, DisplayManagerEnum.Linea.Primera, newLinea1, DisplayManagerEnum.Alineacion.Ninguna);
      EscribirLinea(port, DisplayManagerEnum.Linea.Primera, newLinea2, DisplayManagerEnum.Alineacion.Ninguna);

      return new string[] { newLinea1, newLinea2 };
    }

    /// <summary>
    /// Se Utiliza para detener el scrolling
    /// </summary>
    [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
    public override void EndScroll()
    {
      thread.Abort();
      ClearDisplay(Internalport);
    }



  }
}
