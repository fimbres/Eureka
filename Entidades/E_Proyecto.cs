using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Proyecto
    {
        #region Atributos
        private string _Accion;
        private int _IDProyecto;
        private string _NombreCliente;
        private string _CorreoCliente;
        private string _NombreProyecto;
        private string _NombreInforme;
        private string _TipoInforme;
        private byte[] _Informe;
        private string _EstadoProyecto;
        #endregion

        #region Constructores
        public E_Proyecto(string accion, int iDProyecto, string nombreCliente, string correoCliente, string nombreProyecto, string nombreInforme, string tipoInforme, byte[] informe, string estadoProyecto)
        {
            _Accion = accion;
            _IDProyecto = iDProyecto;
            _NombreCliente = nombreCliente;
            _CorreoCliente = correoCliente;
            _NombreProyecto = nombreProyecto;
            _NombreInforme = nombreInforme;
            _TipoInforme = tipoInforme;
            _Informe = informe;
            _EstadoProyecto = estadoProyecto;
        }

        public E_Proyecto()
        {
            _Accion = string.Empty;
            _IDProyecto = 0;
            _NombreCliente = string.Empty;
            _CorreoCliente = string.Empty;
            _NombreProyecto = string.Empty;
            _NombreInforme = string.Empty;
            _TipoInforme = string.Empty;
            _Informe = new byte[4096];
            _EstadoProyecto = string.Empty;
        }
        #endregion

        #region Encapsulamientos
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IDProyecto { get => _IDProyecto; set => _IDProyecto = value; }
        public string NombreCliente { get => _NombreCliente; set => _NombreCliente = value; }
        public string CorreoCliente { get => _CorreoCliente; set => _CorreoCliente = value; }
        public string NombreProyecto { get => _NombreProyecto; set => _NombreProyecto = value; }
        public string NombreInforme { get => _NombreInforme; set => _NombreInforme = value; }
        public string TipoInforme { get => _TipoInforme; set => _TipoInforme = value; }
        public byte[] Informe { get => _Informe; set => _Informe = value; }
        public string EstadoProyecto { get => _EstadoProyecto; set => _EstadoProyecto = value; }
        #endregion
    }
}
