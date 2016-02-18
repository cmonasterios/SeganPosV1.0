using EntityFramework.Audit;
using NLog;
using System;
using System.IO;
using System.Xml;

namespace SEGAN_POS
{
  public class LogUtility
  {
    public static string BuildExceptionMessage(Exception x)
    {
      Exception logException = x;
      if (x.InnerException != null)
        logException = x.InnerException;

      // Get the error message
      string strErrorMsg = Environment.NewLine + "Message :" + logException.Message;

      // Source of the message
      strErrorMsg += Environment.NewLine + "Source :" + logException.Source;

      // Stack Trace of the error

      strErrorMsg += Environment.NewLine + "Stack Trace :" + logException.StackTrace;

      // Method where the error occurred
      strErrorMsg += Environment.NewLine + "TargetSite :" + logException.TargetSite;
      return strErrorMsg;
    }
  }

  internal class NLogLogger
  {
    public NLogLogger()
    {
      _logger = LogManager.GetCurrentClassLogger();
    }

    private Logger _logger { get; set; }
    public void Debug(string message)
    {
      LogEventInfo theEvent = new LogEventInfo(LogLevel.Debug, "", message);

      theEvent.Properties["idApp"] = EstadoAplicacion.IDApp;
      if (EstadoAplicacion.UsuarioActual != null)
        theEvent.Properties["idUsr"] = EstadoAplicacion.UsuarioActual.IdUsuario;

      theEvent.Properties["IPAdd"] = Util.GetIP();

      _logger.Log(theEvent);
    }

    public void Debug(string message, Exception x)
    {
      LogEventInfo theEvent = new LogEventInfo(LogLevel.Debug, "", message);
      theEvent.Exception = x;

      theEvent.Properties["idApp"] = EstadoAplicacion.IDApp;
      if (EstadoAplicacion.UsuarioActual != null)
        theEvent.Properties["idUsr"] = EstadoAplicacion.UsuarioActual.IdUsuario;

      theEvent.Properties["IPAdd"] = Util.GetIP();

      _logger.Log(theEvent);
    }

    public void Error(string message)
    {
      LogEventInfo theEvent = new LogEventInfo(LogLevel.Error, "", message);

      theEvent.Properties["idApp"] = EstadoAplicacion.IDApp;
      if (EstadoAplicacion.UsuarioActual != null)
        theEvent.Properties["idUsr"] = EstadoAplicacion.UsuarioActual.IdUsuario;

      theEvent.Properties["IPAdd"] = Util.GetIP();

      _logger.Log(theEvent);
    }

    public void Error(Exception x)
    {
      this.Error(LogUtility.BuildExceptionMessage(x));
    }

    public void Error(string message, Exception x)
    {
      LogEventInfo theEvent = new LogEventInfo(LogLevel.Error, "", message);
      theEvent.Exception = x;

      theEvent.Properties["idApp"] = EstadoAplicacion.IDApp;
      if (EstadoAplicacion.UsuarioActual != null)
        theEvent.Properties["idUsr"] = EstadoAplicacion.UsuarioActual.IdUsuario;

      theEvent.Properties["IPAdd"] = Util.GetIP();

      _logger.Log(theEvent);
    }

    public void Fatal(string message)
    {
      LogEventInfo theEvent = new LogEventInfo(LogLevel.Fatal, "", message);

      theEvent.Properties["idApp"] = EstadoAplicacion.IDApp;
      if (EstadoAplicacion.UsuarioActual != null)
        theEvent.Properties["idUsr"] = EstadoAplicacion.UsuarioActual.IdUsuario;

      theEvent.Properties["IPAdd"] = Util.GetIP();

      _logger.Log(theEvent);
    }

    public void Fatal(Exception x)
    {
      LogEventInfo theEvent = new LogEventInfo(LogLevel.Fatal, "", LogUtility.BuildExceptionMessage(x));

      theEvent.Properties["idApp"] = EstadoAplicacion.IDApp;
      if (EstadoAplicacion.UsuarioActual != null)
        theEvent.Properties["idUsr"] = EstadoAplicacion.UsuarioActual.IdUsuario;

      theEvent.Properties["IPAdd"] = Util.GetIP();

      _logger.Log(theEvent);
    }

    public void Info(string message)
    {
      LogEventInfo theEvent = new LogEventInfo(LogLevel.Info, "", message);

      theEvent.Properties["idApp"] = EstadoAplicacion.IDApp;
      if (EstadoAplicacion.UsuarioActual != null)
        theEvent.Properties["idUsr"] = EstadoAplicacion.UsuarioActual.IdUsuario;

      theEvent.Properties["IPAdd"] = Util.GetIP();

      _logger.Log(theEvent);
    }

    public void Trace(string message)
    {
      LogEventInfo theEvent = new LogEventInfo(LogLevel.Trace, "", message);

      theEvent.Properties["idApp"] = EstadoAplicacion.IDApp;
      if (EstadoAplicacion.UsuarioActual != null)
        theEvent.Properties["idUsr"] = EstadoAplicacion.UsuarioActual.IdUsuario;

      theEvent.Properties["IPAdd"] = Util.GetIP();

      _logger.Log(theEvent);
    }

    public void Trace(AuditLog auditLog)
    {
      string logData;
      using (var sw = new StringWriter()) {
        using (var xw = XmlWriter.Create(sw)) {
          auditLog.ToXml(xw);
        }
        logData = sw.ToString().Trim();
      }

      LogEventInfo theEvent = new LogEventInfo(LogLevel.Trace, "", logData);

      theEvent.Properties["idApp"] = EstadoAplicacion.IDApp;
      if (EstadoAplicacion.UsuarioActual != null)
        theEvent.Properties["idUsr"] = EstadoAplicacion.UsuarioActual.IdUsuario;

      theEvent.Properties["IPAdd"] = Util.GetIP();

      _logger.Log(theEvent);
    }

    public void Warn(string message)
    {
      LogEventInfo theEvent = new LogEventInfo(LogLevel.Warn, "", message);

      theEvent.Properties["idApp"] = EstadoAplicacion.IDApp;
      if (EstadoAplicacion.UsuarioActual != null)
        theEvent.Properties["idUsr"] = EstadoAplicacion.UsuarioActual.IdUsuario;

      theEvent.Properties["IPAdd"] = Util.GetIP();

      _logger.Log(theEvent);
    }
  }
}