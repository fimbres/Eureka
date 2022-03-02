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
    public class N_Entrega
    {
        readonly D_SQL_Datos sqld = new D_SQL_Datos();
        public string InsertaEntrega(E_Entrega pEntrega)
        {
            pEntrega.Accion = "INSERTAR";
            string R = sqld.IBM_Entidad<E_Entrega>("IBM_Entrega", pEntrega);
            if (R.Contains("Exito"))
            {
                return "Exito: la Entrega se registró correctamente";
            }
            else
            {
                return "Error: la Entrega no se registró correctamente";
            }
        }
        public string BorraEntrega(int ID)
        {
            E_Entrega pEntrega = new E_Entrega();
            pEntrega.Accion = "BORRAR";
            pEntrega.IDEntrega = ID;
            string R = sqld.IBM_Entidad<E_Entrega>("IBM_Entrega", pEntrega);
            if (R.Contains("Exito"))
            {
                return "Exito: la Entrega se registró correctamente";
            }
            else
            {
                return "Error: la Entrega no se registró correctamente";
            }
        }
        public string ModificaEntrega(E_Entrega pEntrega)
        {
            pEntrega.Accion = "MODIFICAR";
            string R = sqld.IBM_Entidad<E_Entrega>("IBM_Entrega", pEntrega);
            if (R.Contains("Exito"))
            {
                return "Exito: la Entrega se registró correctamente";
            }
            else
            {
                return "Error: la Entrega no se registró correctamente";
            }
        }
        public DataTable DT_LstEntregas() { return sqld.DT_ListadoGeneral("Entregas", "NombreEntrega"); }
        public List<E_Entrega> LstEntregas() { return StrDatosSQL.D_ConvierteDatos.ConvertirDTALista<E_Entrega>(DT_LstEntregas()); }
        public E_Entrega BuscarEntrega(int ID) { return (from Entrega in LstEntregas() where Entrega.IDEntrega == ID select Entrega).SingleOrDefault(); }
        public List<E_Entrega> BuscaEntregaP(int ID) { return (from Entrega in LstEntregas() where Entrega.IDProyecto == ID select Entrega).ToList<E_Entrega>(); }
        public List<E_Entrega> BuscaEntregaU(int ID) { return (from Entrega in LstEntregas() where Entrega.IDUsuario == ID select Entrega).ToList<E_Entrega>(); }
        public List<E_Entrega> BuscaEntregaDos(int ID, string pCriterioBusqueda) { return (from Entrega in LstEntregas() where Entrega.IDUsuario == ID && (Entrega.Concepto.Contains(pCriterioBusqueda) || Entrega.Estado.Contains(pCriterioBusqueda)) select Entrega).ToList<E_Entrega>(); }
        public List<E_Entrega> BuscaEntregas(string pCriterioBusqueda) { return (from Entrega in LstEntregas() where Entrega.Concepto.Contains(pCriterioBusqueda) || Entrega.Estado.Contains(pCriterioBusqueda) select Entrega).ToList<E_Entrega>(); }
        public List<E_Entrega> BuscaEntregasDiseño(string pCriterioBusqueda) { return (from Entrega in LstEntregas() where (Entrega.Concepto.Contains("INTERFAZ") || Entrega.Concepto.Contains("CAMPAÑA")) && Entrega.Estado.Contains(pCriterioBusqueda) select Entrega).ToList<E_Entrega>(); }
        public List<E_Entrega> BuscaEntregasDesarrollo(string pCriterioBusqueda) { return (from Entrega in LstEntregas() where (Entrega.Concepto.Contains("APLICACION") || Entrega.Concepto.Contains("DOCUMENTACION")) && Entrega.Estado.Contains(pCriterioBusqueda) select Entrega).ToList<E_Entrega>(); }
        public List<E_Entrega> BuscaEntregasAplicaciones(string pCriterioBusqueda) { return (from Entrega in LstEntregas() where (Entrega.Concepto.Contains("APLICACION") && Entrega.Estado.Contains(pCriterioBusqueda)) select Entrega).ToList<E_Entrega>(); }
        public List<E_Entrega> BuscaEntregascampa(string pCriterioBusqueda) { return (from Entrega in LstEntregas() where (Entrega.Concepto.Contains(pCriterioBusqueda) && !Entrega.Estado.Contains("PENDIENTE")) select Entrega).ToList<E_Entrega>(); }
    }
}
