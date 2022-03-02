using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Entrega
    {
        #region Atributos
        private string _Accion;
        private int _IDEntrega;
        private int _IDProyecto;
        private int _Version;
        private string _Concepto;
        private string _NombreEntrega;
        private string _TipoEntrega;
        private byte[] _Entrega;
        private string _Estado;
        private string _Comentarios;
        private int _IDUsuario;
        #endregion

        #region Constructores
        public E_Entrega(string accion, int iDEntrega, int iDProyecto, int version, string concepto, string nombreEntrega, string tipoEntrega, byte[] entrega, string estado, string comentarios, int iDUsuario)
        {
            _Accion = accion;
            _IDEntrega = iDEntrega;
            _IDProyecto = iDProyecto;
            _Version = version;
            _Concepto = concepto;
            _NombreEntrega = nombreEntrega;
            _TipoEntrega = tipoEntrega;
            _Entrega = entrega;
            _Estado = estado;
            _Comentarios = comentarios;
            _IDUsuario = iDUsuario;
        }

        public E_Entrega()
        {
            _Accion = string.Empty;
            _IDEntrega = 0;
            _IDProyecto = 0;
            _Version = 0;
            _Concepto = string.Empty;
            _NombreEntrega = string.Empty;
            _TipoEntrega = string.Empty;
            _Entrega = new byte[4096];
            _Estado = string.Empty;
            _Comentarios = string.Empty;
            _IDUsuario = 0;
        }
    #endregion

    #region Encapsulamientos
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IDEntrega { get => _IDEntrega; set => _IDEntrega = value; }
        public int IDProyecto { get => _IDProyecto; set => _IDProyecto = value; }
        public int Version { get => _Version; set => _Version = value; }
        public string Concepto { get => _Concepto; set => _Concepto = value; }
        public string NombreEntrega { get => _NombreEntrega; set => _NombreEntrega = value; }
        public string TipoEntrega { get => _TipoEntrega; set => _TipoEntrega = value; }
        public byte[] Entrega { get => _Entrega; set => _Entrega = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string Comentarios { get => _Comentarios; set => _Comentarios = value; }
        public int IDUsuario { get => _IDUsuario; set => _IDUsuario = value; }
        #endregion
    }
}
