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
    public class N_Proyecto
    {
        readonly D_SQL_Datos sqld = new D_SQL_Datos();
        public string InsertaProyecto(E_Proyecto pProyecto)
        {
            pProyecto.Accion = "INSERTAR";
            string R = sqld.IBM_Entidad<E_Proyecto>("IBM_Proyecto", pProyecto);
            if(R.Contains("Exito"))
            {
                return "Exito: el proyecto se registró correctamente";
            }
            else
            {
                return "Error: el proyecto no se registró correctamente";
            }
        }
        public string BorraProyecto(int ID)
        {
            E_Proyecto pProyecto = new E_Proyecto();
            pProyecto.Accion = "BORRAR";
            pProyecto.IDProyecto = ID;
            string R = sqld.IBM_Entidad<E_Proyecto>("IBM_Proyecto", pProyecto);
            if (R.Contains("Exito"))
            {
                return "Exito: el proyecto se registró correctamente";
            }
            else
            {
                return "Error: el proyecto no se registró correctamente";
            }
        }
        public string ModificaProyecto(E_Proyecto pProyecto)
        {
            pProyecto.Accion = "MODIFICAR";
            string R = sqld.IBM_Entidad<E_Proyecto>("IBM_Proyecto", pProyecto);
            if (R.Contains("Exito"))
            {
                return "Exito: el proyecto se registró correctamente";
            }
            else
            {
                return "Error: el proyecto no se registró correctamente";
            }
        }
        public DataTable DT_LstProyectos() { return sqld.DT_ListadoGeneral("Proyectos","NombreProyecto"); }
        public List<E_Proyecto> LstProyectos() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Proyecto>(DT_LstProyectos()); }
        public E_Proyecto BuscarProyecto(int ID) { return (from Proyecto in LstProyectos() where Proyecto.IDProyecto == ID select Proyecto).SingleOrDefault(); }
        public List<E_Proyecto> BuscaProyectos(string pCriterioBusqueda) { return (from Proyecto in LstProyectos() where Proyecto.EstadoProyecto.Contains(pCriterioBusqueda) || Proyecto.NombreProyecto.Contains(pCriterioBusqueda) select Proyecto).ToList<E_Proyecto>(); }
    }
}
