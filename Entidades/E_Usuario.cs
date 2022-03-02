using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_Usuario
    {
        #region Atributos
        private string _Accion;
        private int _IDUsuario;
        private string _NombreUsuario;
        private string _Login;
        private string _Password;
        private string _Rol;
        #endregion

        #region Constructores
        public E_Usuario(string accion, int iDUsuario, string nombreUsuario, string login, string password, string rol)
        {
            _Accion = accion;
            _IDUsuario = iDUsuario;
            _NombreUsuario = nombreUsuario;
            _Login = login;
            _Password = password;
            _Rol = rol;
        }
        public E_Usuario()
        {
            _Accion = string.Empty;
            _IDUsuario = 0;
            _NombreUsuario = string.Empty;
            _Login = string.Empty;
            _Password = string.Empty;
            _Rol = string.Empty;
        }
        #endregion

        #region Encapsulamientos
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IDUsuario { get => _IDUsuario; set => _IDUsuario = value; }
        public string NombreUsuario { get => _NombreUsuario; set => _NombreUsuario = value; }
        public string Login { get => _Login; set => _Login = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string Rol { get => _Rol; set => _Rol = value; }
        #endregion
    }
}
