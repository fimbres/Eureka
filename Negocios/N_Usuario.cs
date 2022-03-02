using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using StrDatosSQL;

namespace Negocios
{
    public class N_Usuario
    {
        readonly D_SQL_Datos sqld = new D_SQL_Datos();
        public string InsertaUsuario(E_Usuario pUsuario)
        {
            pUsuario.Accion = "INSERTAR";
            string R = sqld.IBM_Entidad<E_Usuario>("IBM_Usuario", pUsuario);
            if (R.Contains("Exito"))
            {
                return "Exito: el Usuario se registró correctamente";
            }
            else
            {
                return "Error: el Usuario no se registró correctamente";
            }
        }
        public string BorraUsuario(int ID)
        {
            E_Usuario pUsuario = new E_Usuario();
            pUsuario.Accion = "BORRAR";
            pUsuario.IDUsuario = ID;
            string R = sqld.IBM_Entidad<E_Usuario>("IBM_Usuario", pUsuario);
            if (R.Contains("Exito"))
            {
                return "Exito: el Usuario se eliminó correctamente";
            }
            else
            {
                return "Error: el Usuario no se eliminó correctamente";
            }
        }
        public string ModificaUsuario(E_Usuario pUsuario)
        {
            pUsuario.Accion = "MODIFICAR";
            string R = sqld.IBM_Entidad<E_Usuario>("IBM_Usuario", pUsuario);
            if (R.Contains("Exito"))
            {
                return "Exito: el Usuario se modificó correctamente";
            }
            else
            {
                return "Error: el Usuario no se modificó correctamente";
            }
        }
        public DataTable DT_LstUsuarios() { return sqld.DT_ListadoGeneral("Usuarios", "NombreUsuario"); }
        public List<E_Usuario> LstUsuarios() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Usuario>(DT_LstUsuarios()); }
        public E_Usuario BuscarUsuario(int ID) { return (from Usuario in LstUsuarios() where Usuario.IDUsuario == ID select Usuario).SingleOrDefault(); }
        public List<E_Usuario> BuscaUsuarios(string pCriterioBusqueda) { return (from Usuario in LstUsuarios() where Usuario.NombreUsuario.Contains(pCriterioBusqueda) || Usuario.Login.Contains(pCriterioBusqueda) || Usuario.Rol.Contains(pCriterioBusqueda) select Usuario).ToList<E_Usuario>(); }
        public E_Usuario validaUsuario(string Pusuario, string pContra)
        {
            { return (from Usuario in LstUsuarios() where Usuario.Login == Pusuario && Usuario.Password == pContra select Usuario).SingleOrDefault(); }
        }
    }
}