using SEGAN_POS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data;
using System.Configuration;

namespace SEGAN_POS.DAL
{
    class Biometrico
    {
        #region Atributos
        private int _IdRegion;
        private int _IdLocalidad;
        private int _IdTerminal;
        private string _DirIP;
        private string _Descripcion;
        private int _Puerto;
        private string _DirMac;
        private string _VersionFirmware;
        private string _Serial;
        private string _VersionSDK;
        private DateTime _FechaHoraDispo;
        private DateTime _FechaUltAct;
        private DateTime _FechaHoraServer;
        private bool _Activo;
        private int _Modelo;
        private int _NumeroMaquina;
        private bool Valido;
        private string _ProductCode;
        private string _Plataforma;
        private int _CardFun;
        private int _Estatus;
        private bool _Conectado;
        private int _CodigoDeError;
        private  zkemkeeper.CZKEM SDKBiotrack;
        private int _NumeroUsuarios;
        private int _NumeroDeHuellas;
        private int _NumeroDeClaves;
        private int _NumeroDeLecturas;
        private int _CapacidadDeUsuarios;
        private int _CapacidadDeHuellas;
        private int _CapacidadDeLecturas;
        #endregion

        #region Métodos Básicos

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Biometrico()
        {
            _IdTerminal = -1;
            _DirIP = string.Empty;
            _Puerto = -1;
            _DirMac = string.Empty;
            _Descripcion = string.Empty;
            _VersionFirmware = string.Empty;
            _Serial = string.Empty;
            _VersionSDK = string.Empty;
            _FechaHoraDispo = DateTime.MinValue;
            _FechaHoraServer = DateTime.MinValue;
            _Activo = false;
            _Modelo = 0;
            _NumeroMaquina = -1;
            Valido = true;
            _ProductCode = string.Empty;
            _Conectado = false;
            _CodigoDeError = 0;
            _Plataforma = string.Empty;
            _CardFun = -1;
            _NumeroUsuarios = 0;
            _NumeroDeHuellas = 0;
            _NumeroDeClaves = 0;
            _NumeroDeLecturas = 0;
            _CapacidadDeHuellas = 0;
            _CapacidadDeUsuarios = 0;
            _CapacidadDeLecturas = 0;
            SDKBiotrack = new zkemkeeper.CZKEM();
        }

        /// <summary>
        /// Permite obtener todas las caracteristicas básicas del dispositivo biomerico
        /// </summary>
        public void ObtenerCaracteristicas()
        {
            int idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond;

            idwYear = idwMonth = idwDay = idwHour = idwMinute = idwSecond = 0;
            Valido = SDKBiotrack.GetDeviceMAC(_NumeroMaquina, ref _DirMac);
            Valido = SDKBiotrack.GetFirmwareVersion(_NumeroMaquina, ref _VersionFirmware);
            Valido = SDKBiotrack.GetSDKVersion(ref _VersionSDK);
            Valido = SDKBiotrack.GetSerialNumber(_NumeroMaquina, out _Serial);
            Valido = SDKBiotrack.GetDeviceTime(_NumeroMaquina, ref idwYear, ref idwMonth, ref idwDay, ref idwHour, ref idwMinute, ref idwSecond);
            Valido = SDKBiotrack.GetProductCode(_NumeroMaquina, out _ProductCode);
            Valido = SDKBiotrack.GetPlatform(_NumeroMaquina, ref _Plataforma);
            Valido = SDKBiotrack.GetCardFun(_NumeroMaquina, ref _CardFun);
            Valido = SDKBiotrack.QueryState(ref _Estatus);
            _CapacidadDeHuellas = ConsultarEstatus(7);
            _CapacidadDeUsuarios = ConsultarEstatus(8);
            _CapacidadDeLecturas = ConsultarEstatus(9);
            _NumeroDeLecturas = ConsultarEstatus(6);
            _FechaHoraDispo = new DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
        }
        #endregion

        #region Métodos de Acceso
        public int IdRegion
        {
            set
            {
                _IdRegion = value;
            }
            get
            {
                return _IdRegion;
            }
        }
        public int IdTerminal
        {
            set
            {
                _IdTerminal = value;
            }
            get
            {
                return _IdTerminal;
            }
        }

        public int IdLocalidad
        {
            get
            {
                return
                    _IdLocalidad;
            }
            set
            {
                _IdLocalidad = value;
            }
        }

        public string DireccionIP
        {
            set
            {
                _DirIP = value;
            }
            get
            {
                return _DirIP;
            }
        }

        public string Descripcion
        {
            set
            {
                _Descripcion = value;
            }
            get
            {
                return _Descripcion;
            }
        }


        public int Puerto
        {
            set
            {
                _Puerto = value;
            }
            get
            {
                return _Puerto;
            }
        }

        public int NumeroDeMaquina
        {
            set
            {
                _NumeroMaquina = value;
            }
            get
            {
                return _NumeroMaquina;
            }
        }

        public bool Activo
        {
            get
            {
                return _Activo;
            }
            set
            {
                _Activo = value;
            }
        }

        public int Modelo
        {
            get
            {
                return _Modelo;
            }
            set
            {
                _Modelo = value;
            }
        }

        public string VersionFirmware
        {
            get
            {
                return _VersionFirmware;
            }

        }

        public bool Conectado
        {
            get
            {
                return _Conectado;
            }
        }

        public string DirreccionMac
        {
            get
            {
                return _DirMac;
            }
        }

        public string Serial
        {
            get
            {
                return _Serial;
            }
        }


        public string VersionSDK
        {
            get
            {
                return _VersionSDK;
            }
        }

        public DateTime FechaHoraDispositivo
        {
            get
            {
                return _FechaHoraDispo;
            }
        }


        public DateTime FechaUltAct
        {
            get
            {
                return _FechaUltAct;
            }
            set 
            {
                _FechaUltAct = value;
            }
        }


        public int Estatus
        {
            get
            {
                return _Estatus;
            }
        }

        public int CardFun
        {
            get
            {
                return _CardFun;
            }
        }

        public string Plataforma
        {
            get
            {
                return _Plataforma;
            }
        }

        public int NumeroUsuarios
        {
            get
            {
                _NumeroUsuarios = ConsultarEstatus(2);
                return _NumeroUsuarios;
            }
        }

        public int NumeroDeHuellas
        {
            get
            {
                _NumeroDeHuellas = ConsultarEstatus(3);
                return _NumeroDeHuellas;
            }
        }

        public int NumeroDeClaves
        {
            get
            {
                _NumeroDeClaves = ConsultarEstatus(4);
                return _NumeroDeClaves;
            }
        }

        public int NumeroDeLecturas
        {
            get
            {
                _NumeroDeLecturas = ConsultarEstatus(6);
                return _NumeroDeLecturas;
            }
        }
        public int CapacidadDeUsuarios
        {
            get
            {
                return _CapacidadDeUsuarios;
            }
        }

        public int CapacidadDeHuellas
        {
            get
            {
                return _CapacidadDeHuellas;
            }
        }

        public int CapacidadDeLecturas
        {
            get
            {
                return _CapacidadDeLecturas;
            }
        }
        #endregion

        #region Lecturas
        /// <summary>
        /// Permite obtener todas las lecturas registrada pos los dispositivos 
        /// BioClockPlus o el BioAccessIP
        /// </summary>
//        public void GetLecturas(DateTime UltimaLectura)
        public void GetLecturas()
        { 
            
            
            DateTime LecturaActual;
            string TIdenUsuario;
            int IdenUsuario = 0;
            int TModoVerificacionAcceso = 0;
            int TBanderaEntrada = 0;
            int Tanos = 0;
            int TMeses = 0;
            int TDias = 0;
            int THoras = 0;
            int TMinutos = 0;
            int TSegundos = 0;
            int TCodigoTrabajo = 0;
            int Reservado = 0;
            Reportes Reporte =new Reportes();
            if (SDKBiotrack.ReadGeneralLogData(_NumeroMaquina))
            {
                if (_Modelo == 1)
                {
                    while (SDKBiotrack.SSR_GetGeneralLogData(_NumeroMaquina, out TIdenUsuario, out TModoVerificacionAcceso,
                                out TBanderaEntrada, out Tanos, out TMeses, out TDias, out THoras,
                                out TMinutos, out TSegundos, ref TCodigoTrabajo))
                    {
                        LecturaActual = new DateTime(Tanos, TMeses, TDias, THoras, TMinutos, TSegundos);

                        if (LecturaActual.CompareTo(_FechaUltAct) > 0)
                        {
                            DateTime FechaHora= new DateTime(Tanos,TMeses,TDias,THoras,TMinutos,TSegundos);
                            int result = Reporte.EPK_LecturasActualizar(_IdRegion, _IdLocalidad, Convert.ToInt32(TIdenUsuario), _IdTerminal, FechaHora.ToString("yyyy-MM-dd"), FechaHora.ToString("HH:mm:ss"), Convert.ToInt16(TBanderaEntrada), 0, Convert.ToInt16(TModoVerificacionAcceso), Convert.ToInt16(TCodigoTrabajo));
                        }
                    }
                }
                else
                {
                    // cuando en caso de ser un dispositivo BioAccessIP
                    while (SDKBiotrack.GetGeneralExtLogData(_NumeroMaquina, ref IdenUsuario, ref TModoVerificacionAcceso, ref TBanderaEntrada,
                        ref Tanos, ref TMeses, ref TDias, ref THoras, ref TMinutos, ref TSegundos, ref TCodigoTrabajo, ref Reservado))
                    {
                        LecturaActual = new DateTime(Tanos, TMeses, TDias, THoras, TMinutos, TSegundos);
                        // LecturaActual = Convert.ToDateTime(LecturaActual.ToString("MM/dd/yyyy HH:mm:ss"));
                        if (LecturaActual.CompareTo(_FechaUltAct) > 0)
                        {
                            DateTime FechaHora = new DateTime(Tanos, TMeses, TDias, THoras, TMinutos, TSegundos);
                            int result = Reporte.EPK_LecturasActualizar(_IdRegion, _IdLocalidad, IdenUsuario, _IdTerminal, FechaHora.ToString("yyyy-MM-dd"), FechaHora.ToString("HH:mm:ss"), Convert.ToInt16(TBanderaEntrada), 0, Convert.ToInt16(TModoVerificacionAcceso), Convert.ToInt16(TCodigoTrabajo));
       
                        }
                    }
                }
            }
            /// ir a base de datos verificar la nuevas lecturas
        }
        /// <summary>
        /// Permite eliminar el log de 
        /// </summary>
        public void BorrarLog()
        {
            if (_Conectado == false)
            {
                return;
            }

            SDKBiotrack.EnableDevice(_NumeroMaquina, false);//disable the device


            if (SDKBiotrack.ClearGLog(_NumeroMaquina))
            {
                SDKBiotrack.RefreshData(_NumeroMaquina);//the data in the device should be refreshed
            }
            else
            {
                SDKBiotrack.GetLastError(ref _CodigoDeError);
            }
            SDKBiotrack.EnableDevice(_NumeroMaquina, true);//enable the device
        }
        #endregion
   
        #region Conexión
        /// <summary>
        /// Este método permite conectar la aplicación con el dispositivo
        /// </summary>
        /// <returns>
        ///  True: Conexión exitosa con el Dispisivo
        ///  False: Fallo de Conexión
        /// </returns>
        public bool ConectarBioTrack()
        {
            if (SDKBiotrack == null)
            {
                SDKBiotrack = new zkemkeeper.CZKEM();
            }

            _Conectado = SDKBiotrack.Connect_Net(_DirIP, _Puerto);

            if (_Conectado)
                SDKBiotrack.RegEvent(_NumeroMaquina, 65535);
            else
                SDKBiotrack.GetLastError(ref _CodigoDeError);

            return _Conectado;
        }

        /// <summary>
        /// Desconectar el Biotrack actual.
        /// </summary>
        public void DesconectarBioTrack()
        {
            SDKBiotrack.Disconnect();
        }
        /// <summary>
        /// permite habilitar o inhabilitar el dispositivo para operaciones de acuerdo al parámetro valor
        /// </summary>
        /// <param name="valor">
        /// true: habilitado 
        /// false: inhabilitado
        /// </param>
        public bool HabilitarBioTrack(bool valor)
        {
            return SDKBiotrack.EnableDevice(_NumeroMaquina, valor);
        }

        /// <summary>
        /// Permite reiniciar el dispositivo 
        /// </summary>
        public bool Reiniciar()
        {
            return (SDKBiotrack.RestartDevice(_NumeroMaquina));
        }
        /// <summary>
        ///  Permite consultar el estatus del terminal de acuerdo al parámetro opción
        /// </summary>
        /// <param name="Opcion">
        /// Valores permitidos por 
        /// 2-  Número de usuarios almacenados en el terminal 
        /// 3-  Número de Huellas  almacenados en el terminal 
        /// 4-  Número de claves registradas en el terminal
        /// 6-  Número de Lecturas almacenadas en el terminal 
        /// 7-  Número de Huellas  que puede almacenar el terminal 
        /// 8-  Número de usuarios que puede almacenar el terminal 
        /// </param>
        /// <returns>
        ///   El valor asociado a la acción 
        /// </returns>
        public int ConsultarEstatus(int Opcion)
        {
            int Resultado = 0;
            SDKBiotrack.GetDeviceStatus(_NumeroMaquina, Opcion, ref Resultado);
            return Resultado;
        }
        #endregion
    }
}