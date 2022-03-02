using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

using Entidades;
using Negocios;

namespace Presentación
{
    public partial class Sistema : System.Web.UI.Page
    {
        E_Usuario Usuario = new E_Usuario();
        N_Usuario NU = new N_Usuario();
        E_Proyecto Proyecto = new E_Proyecto();
        N_Proyecto NP = new N_Proyecto();
        E_Entrega Entrega = new E_Entrega();
        N_Entrega NE = new N_Entrega();
        private void Page_Load(object sender, EventArgs e)
        {
            if (Session["SesionLogin"] != null)
            {
                E_Usuario C = (E_Usuario)Session["SesionLogin"];
                LblBienvenida.Text = "Bienvenido " + C.NombreUsuario;
                LblRol.Text = "Eres " + C.Rol.ToLower();
                LblNombre.Text = C.NombreUsuario;
                if (!IsPostBack)
                {
                    Inicializar();
                    Estadistica();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        #region Acciones estándar
        protected void Acciones()
        {
            E_Usuario C = (E_Usuario)Session["SesionLogin"];
            switch (C.Rol)
            {
                case "ADMIN":
                    BtnVerEntregas.Visible = true;
                    BtnGestionE.Visible = true;
                    BtnHacerAprobacion.Visible = true;
                    BtnHacerEntrega.Visible = false;
                    BtnHacerCorrecion.Visible = false;
                    BtnHacerInforme.Visible = false;
                    BtnReportarC.Visible = false;
                    BtnReportarE.Visible = false;
                    BtnRegProyecto.Visible = false;
                    BtnDesPublicidad.Visible = false;
                    BtnSoliPublicidad.Visible = false;
                    BtnHacerC.Visible = false;
                    BtnDesInterfaz.Visible = false;
                    BtnVerInformes.Visible = false;
                    BtnRegistro.Visible = false; break;
                case "DISEÑADOR":
                    BtnVerEntregas.Visible = false;
                    BtnGestionE.Visible = false;
                    BtnHacerAprobacion.Visible = false;
                    BtnHacerCorrecion.Visible = true;
                    BtnHacerEntrega.Visible = true;
                    BtnHacerInforme.Visible = false;
                    BtnReportarC.Visible = false;
                    BtnReportarE.Visible = false;
                    BtnRegProyecto.Visible = false;
                    BtnHacerC.Visible = false;
                    BtnDesPublicidad.Visible = false;
                    BtnSoliPublicidad.Visible = false;
                    BtnDesInterfaz.Visible = false;
                    BtnVerInformes.Visible = true;
                    BtnRegistro.Visible = true; break;
                case "TECNICO":
                    BtnVerEntregas.Visible = false;
                    BtnGestionE.Visible = false;
                    BtnHacerAprobacion.Visible = false;
                    BtnHacerCorrecion.Visible = false;
                    BtnHacerEntrega.Visible = false;
                    BtnHacerInforme.Visible = true;
                    BtnReportarC.Visible = true;
                    BtnReportarE.Visible = true;
                    BtnHacerC.Visible = true;
                    BtnRegProyecto.Visible = false;
                    BtnDesPublicidad.Visible = false;
                    BtnSoliPublicidad.Visible = false;
                    BtnDesInterfaz.Visible = false;
                    BtnVerInformes.Visible = false;
                    BtnRegistro.Visible = false; break;
                case "AGENTE DE VENTAS":
                    BtnVerEntregas.Visible = false;
                    BtnGestionE.Visible = false;
                    BtnHacerAprobacion.Visible = false;
                    BtnHacerCorrecion.Visible = false;
                    BtnHacerEntrega.Visible = false;
                    BtnHacerInforme.Visible = false;
                    BtnReportarC.Visible = false;
                    BtnRegProyecto.Visible = true;
                    BtnHacerC.Visible = false;
                    BtnDesPublicidad.Visible = true;
                    BtnSoliPublicidad.Visible = true;
                    BtnReportarE.Visible = false;
                    BtnDesInterfaz.Visible = false;
                    BtnVerInformes.Visible = false;
                    BtnRegistro.Visible = false; break;
                case "DESARROLLADOR":
                    BtnVerEntregas.Visible = false;
                    BtnGestionE.Visible = false;
                    BtnHacerAprobacion.Visible = false;
                    BtnHacerCorrecion.Visible = true;
                    BtnHacerEntrega.Visible = true;
                    BtnHacerInforme.Visible = false;
                    BtnHacerC.Visible = false;
                    BtnReportarC.Visible = false;
                    BtnRegProyecto.Visible = false;
                    BtnDesPublicidad.Visible = false;
                    BtnSoliPublicidad.Visible = false;
                    BtnDesInterfaz.Visible = true;
                    BtnVerInformes.Visible = true;
                    BtnReportarE.Visible = false;
                    BtnRegistro.Visible = true; break;
            }
        }
        
        void Inicializar()
        {
            ControlesOFF();
            Acciones();
            ControlesClear();
            ControlesOnOff(true);
        }

        protected void ControlesOFF()
        {
            PnlEstadistica.Visible = false;
            PnlUsuarios.Visible = false;
            PnlRegistros.Visible = false;
            PnlProyecto.Visible = false;
            PnlEntrega.Visible = false;
            IBM_EliminarU.Visible = false;
            IBM_InsertarU.Visible = false;
            IBM_ModificarU.Visible = false;
            PnlBotones.Visible = false;
            PnlBuscarEntregas.Visible = false;
            PnlSubirInforme.Visible = false;
            GrvEntregas.Visible = false;
            GrvProyectos.Visible = false;
            GrvUsuarios.Visible = false;
            BtnHacerAprobacion.Visible = false;
            PnlBtnEntregas.Visible = false;
            BtnIUsuarios.Visible = false;
            BtnProyectos.Visible = false;
            BtnEntregas.Visible = false;
            BtnPnlUsuario.Visible = false;
            PnlSubirEntrega.Visible = false;
            IBM_ModificarE.Visible = false;
            IBM_InsertarE.Visible = false;
            BtnAprobar.Visible = false;
            BtnErrores.Visible = false;
            IBM_InsertarP.Visible = false;
            IBM_ModificarP.Visible = false;
            BtnModificarU.Visible = false;
            PnlFormU.Visible = false;
            PnlFormP.Visible = false;
            PnlFormE.Visible = false;
            PnlVisualizarArchivo.Visible = false;
            BtnCapacitar.Visible = false;
            BtnACorregir.Visible = false;
            BtnZoom.Visible = false;
        }

        protected void ControlesClear()
        {
            NombreUsuario.Text = string.Empty;
            RolUsuario.Text = string.Empty;
            LoginUsuario.Text = string.Empty;
            ClaveUsuario.Text = string.Empty;
            ProyectoBusqueda.Text = string.Empty;
            NombreCliente.Text = string.Empty;
            NombreProyecto.Text = string.Empty;
            EstadoEntrega.Text = string.Empty;
            EstadoProyecto.Text = string.Empty;
            CorreoCliente.Text = string.Empty;
            ComentariosEntrega.Text = string.Empty;
            ConceptoEntrega.Text = string.Empty;
        }

        protected void ControlesOnOff(bool ONOFF)
        {
            NombreUsuario.Enabled = ONOFF;
            RolUsuario.Enabled = ONOFF;
            LoginUsuario.Enabled = ONOFF;
            ClaveUsuario.Enabled = ONOFF;
            ProyectoBusqueda.Enabled = ONOFF;
            NombreCliente.Enabled = ONOFF;
            NombreProyecto.Enabled = ONOFF;
            EstadoEntrega.Enabled = ONOFF;
            EstadoProyecto.Enabled = ONOFF;
            CorreoCliente.Enabled = ONOFF;
            ComentariosEntrega.Enabled = ONOFF;
            ConceptoEntrega.Enabled = ONOFF;
            NombreArchivo.Enabled = ONOFF;
            TipoArchivo.Enabled = ONOFF;
        }

        protected void Estadistica()
        {
            PnlEstadistica.Visible = true;
            E_Usuario C = (E_Usuario)Session["SesionLogin"];
            switch (C.Rol)
            {
                case "ADMIN":
                case "AGENTE DE VENTAS":
                case "TECNICO": LblAtr1.Text = "Proyectos registrados";
                                LblNum1.Text = Convert.ToString(NP.LstProyectos().Count);
                                LblAtr2.Text = "Proyectos concluidos";
                                LblNum2.Text = Convert.ToString(NP.BuscaProyectos("ENTREGADO").Count);
                                LblAtr3.Text = "Entregas realizadas";
                                LblNum3.Text = Convert.ToString(NE.LstEntregas().Count);
                                LblAtr4.Text = "Usuarios registrados";
                                LblNum4.Text = Convert.ToString(NU.LstUsuarios().Count); break;
                case "DESARROLLADOR":
                case "DISEÑADOR": LblAtr1.Text = "Proyectos asignados";
                                  LblNum1.Text = Convert.ToString(NP.LstProyectos().Count);
                                  LblAtr2.Text = "Entregas realizadas";
                                  LblNum2.Text = Convert.ToString(NE.BuscaEntregaU(C.IDUsuario).Count);
                                  LblAtr3.Text = "Entregas por corregir";
                                  LblNum3.Text = Convert.ToString(NE.BuscaEntregas("CORREGIR").Count);
                                  LblAtr4.Text = "Entregas aprobadas";
                                  LblNum4.Text = Convert.ToString(NE.BuscaEntregas("APROBADO").Count); break;
            }
        }
        #endregion

        #region Menu lateral
        protected void Perfil()
        {
            PnlUsuarios.Visible = true;
            PnlFormU.Visible = true;
            LblTUsuario.Text = "Mi Cuenta";
            E_Usuario C = (E_Usuario)Session["SesionLogin"];
            NombreUsuario.Text = C.NombreUsuario;
            RolUsuario.Text = C.Rol;
            LoginUsuario.Text = C.Login;
            ClaveUsuario.Text = C.Password;
            RolUsuario.Enabled = false;
            BtnModificarU.Visible = true;
        }

        protected void BtnRegistro_Click(object sender, EventArgs e)
        {
            Inicializar();
            PnlRegistros.Visible = true;
            E_Usuario C = (E_Usuario)Session["SesionLogin"];
            hfTipoArchivo.Value = "ENTREGA";
            LblTRegistros.Text = "Registros: Ver entregas realizadas";
            List<E_Entrega> LE = NE.BuscaEntregaU(C.IDUsuario);
            hfAccionV.Value = "VER";
            if (LE != null && LE.Count != 0)
            {
                LblTRegistros.Text = "Registros: Ver entregas realizadas";
                GrvEntregas.Visible = true;
                GridViewE.DataSource = LE;
                GridViewE.DataBind();
            }
            else
            {
                GrvEntregas.Visible = false;
                LblTRegistros.Text = "Registros: No has realizado ninguna entrega";
            }
        }

        protected void BtnEstadistica_Click(object sender, EventArgs e)
        {
            Inicializar();
            Estadistica();
        }

        protected void BtnPerfil2_Click(object sender, EventArgs e)
        {
            Inicializar();
            Perfil();
        }

        protected void BtnHacerCorrecion_Click(object sender, EventArgs e)
        {
            Inicializar();
            PnlRegistros.Visible = true;
            hfTipoArchivo.Value = "ENTREGA";
            hfAccionV.Value = "CORREGIR";
            E_Usuario C = (E_Usuario)Session["SesionLogin"];
            GrvEntregas.Visible = true;
            List<E_Entrega> LE = NE.BuscaEntregaDos(C.IDUsuario, "CORREGIR");
            if (LE != null && LE.Count != 0)
            {
                LblTRegistros.Text = "Registros: Ver entregas a corregir";
                GridViewE.DataSource = LE;
                GridViewE.DataBind();
            }
            else
            {
                GrvEntregas.Visible = false;
                LblTRegistros.Text = "Registros: No hay entregas a corregir";
            }
        }

        protected void BtnHacerEntrega_Click(object sender, EventArgs e)
        {
            Inicializar();
            PnlRegistros.Visible = true;
            E_Usuario C = (E_Usuario)Session["SesionLogin"];
            hfTipoArchivo.Value = "ENTREGA";
            hfAccionV.Value = "Subir";
            GrvEntregas.Visible = true;
            if (C.Rol.Contains("DESARROLLADOR"))
            {
                List<E_Entrega> LE = NE.BuscaEntregasDesarrollo("PENDIENTE");
                if (LE != null && LE.Count != 0)
                {
                    LblTRegistros.Text = "Registros: Ver entregas pendientes";
                    GridViewE.DataSource = LE;
                    GridViewE.DataBind();
                }
                else
                {
                    GrvEntregas.Visible = false;
                    LblTRegistros.Text = "Registros: No hay entregas pendientes";
                }
            }
            else
            {
                List<E_Entrega> LE = NE.BuscaEntregasDiseño("PENDIENTE");
                if (LE != null && LE.Count != 0)
                {
                    LblTRegistros.Text = "Registros: Ver entregas pendientes";
                    GridViewE.DataSource = LE;
                    GridViewE.DataBind();
                }
                else
                {
                    GrvEntregas.Visible = false;
                    LblTRegistros.Text = "Registros: No hay entregas pendientes";
                }
            }
        }

        protected void BtnHacerAprobacion_Click(object sender, EventArgs e)
        {
            Inicializar();
            PnlRegistros.Visible = true;
            GrvEntregas.Visible = true;
            hfAccionV.Value = "APROBAR";
            hfTipoArchivo.Value = "ENTREGA";
            List<E_Entrega> LE = NE.BuscaEntregasDesarrollo("ENTREGADO");
            if (LE != null && LE.Count != 0)
            {
                LblTRegistros.Text = "Aprobar aplicaciones";
                GridViewE.DataSource = LE;
                GridViewE.DataBind();
            }
            else
            {
                GrvEntregas.Visible = false;
                LblTRegistros.Text = "Aprobar aplicaciones: No hay aplicaciones en curso";
            }
        }

        protected void BtnGestionE_Click(object sender, EventArgs e)
        {
            Inicializar();
            LblTRegistros.Text = "Gestión Empleados";
            PnlRegistros.Visible = true;
            GrvUsuarios.Visible = true;
            BtnPnlUsuario.Visible = true;
            GridViewU.DataSource = NU.LstUsuarios();
            GridViewU.DataBind();
        }

        protected void BtnVerEntregas_Click(object sender, EventArgs e)
        {
            Inicializar();
            LblTEntrega.Text = "Buscar entregas por proyecto";
            hfAccionV.Value = "VER";
            hfTipoArchivo.Value = "ENTREGA";
            PnlRegistros.Visible = true;
            PnlBuscarEntregas.Visible = true;
        }
        #endregion

        #region Menú superior
        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Cookies.Add(new System.Web.HttpCookie("ASP.NET_SesionID", ""));
            Response.Redirect("Login.aspx");
        }

        protected void BtnPerfil1_Click(object sender, EventArgs e)
        {
            Inicializar();
            Perfil();
        }
        #endregion

        #region botones
        protected void BtnEntregasxProyecto_Click(object sender, EventArgs e)
        {
            int IDP = Convert.ToInt32(value: ProyectoBusqueda.Text);
            List<E_Entrega> LE = NE.BuscaEntregaP(IDP);
            if (LE != null && LE.Count != 0)
            {
                LblTRegistros.Text = "Buscar entregas por proyecto";
                hfTipoArchivo.Value = "ENTREGA";
                PnlBuscarEntregas.Visible = false;
                GrvEntregas.Visible = true;
                GridViewE.DataSource = LE;
                GridViewE.DataBind();
            }
            else
            {
                GrvEntregas.Visible = false;
                LblTRegistros.Text = "Buscar entregas por proyecto: No hay entregas del proyecto que buscas";
            }
        }

        protected void BtnPnlUsuario_Click(object sender, EventArgs e)
        {
            Inicializar();
            PnlUsuarios.Visible = true;
            PnlFormU.Visible = true;
            LblTUsuario.Text = "Registrar nuevo empleado";
            IBM_InsertarU.Visible = true;
        }

        protected void BtnAbrirEntrega_Click(object sender, EventArgs e)
        {
            
        }

        protected void BtnAprobar_Click(object sender, EventArgs e)
        {
            int IDEntrega = hfIDEntrega.Value == string.Empty ? 0 : Convert.ToInt32(hfIDEntrega.Value);
            E_Entrega E = NE.BuscarEntrega(IDEntrega);
            if(E != null)
            {

                E.Estado = "APROBADO";
                E.Comentarios = ComentariosEntrega.Text;
                LblTEntrega.Text = "Aprobar Entrega: " + NE.ModificaEntrega(E);
            }
            else
            {
                LblTEntrega.Text = "Aprobar Entrega: Error";
            }
        }

        protected void BtnACorregir_Click(object sender, EventArgs e)
        {
            int IDEntrega = hfIDEntrega.Value == string.Empty ? 0 : Convert.ToInt32(hfIDEntrega.Value);
            E_Entrega E = NE.BuscarEntrega(IDEntrega);
            if (E != null)
            {
                E.Estado = "CORREGIR";
                E.Comentarios = ComentariosEntrega.Text;
                LblTEntrega.Text = "Enviar a corregir Entrega: " + NE.ModificaEntrega(E);
            }
            else
            {
                LblTEntrega.Text = "Enviar a corregir Entrega: Error";
            }
        }

        #endregion

        #region botones IBM
        protected void IBM_InsertarU_Click(object sender, EventArgs e)
        {
            if (RolUsuario.Text.ToUpper().Contains("ADMIN") || RolUsuario.Text.ToUpper().Contains("AGENTE DE VENTAS") || RolUsuario.Text.ToUpper().Contains("DESARROLLADOR") || RolUsuario.Text.ToUpper().Contains("TECNICO") || RolUsuario.Text.ToUpper().Contains("DISEÑADOR"))
            {
                Usuario.NombreUsuario = NombreUsuario.Text;
                Usuario.Login = LoginUsuario.Text;
                Usuario.Rol = RolUsuario.Text.ToUpper();
                Usuario.Password = ClaveUsuario.Text;
                LblTUsuario.Text = "Registrar usuario: " + NU.InsertaUsuario(Usuario);
            }
            else
            {
                LblTUsuario.Text = "Registrar usuario: Ingresa un rol correcto";
            }
        }

        protected void IBM_EliminarU_Click(object sender, EventArgs e)
        {
            LblTUsuario.Text = "Eliminar usuario: " + NU.BorraUsuario(Convert.ToInt32(hfIDUsuario.Value));
        }

        protected void IBM_ModificarU_Click(object sender, EventArgs e)
        {
            Usuario.IDUsuario = Convert.ToInt32(hfIDUsuario.Value);
            Usuario.NombreUsuario = NombreUsuario.Text;
            Usuario.Login = LoginUsuario.Text;
            Usuario.Rol = RolUsuario.Text;
            Usuario.Password = ClaveUsuario.Text;
            LblTUsuario.Text = "Modificar usuario: " + NU.ModificaUsuario(Usuario);
        }
        protected void BtnModificarU_Click(object sender, EventArgs e)
        {
            E_Usuario C = (E_Usuario)Session["SesionLogin"];
            C.NombreUsuario = NombreUsuario.Text;
            C.Login = LoginUsuario.Text;
            C.Rol = RolUsuario.Text;
            C.Password = ClaveUsuario.Text;
            LblTUsuario.Text = "Mi cuenta: " + NU.ModificaUsuario(C);
        }

        #endregion

        #region GridView
        protected void GrvUsuario_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
            hfIDUsuario.Value = GridViewU.DataKeys[e.NewEditIndex].Value.ToString();
            PnlRegistros.Visible = false;
            PnlUsuarios.Visible = true;
            PnlFormU.Visible = true;
            IBM_ModificarU.Visible = true;
            ObjetoEntidad_WebFormU();
        }
        protected void GridViewU_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            hfIDUsuario.Value = GridViewU.DataKeys[e.RowIndex].Value.ToString();
            PnlRegistros.Visible = false;
            PnlUsuarios.Visible = true;
            IBM_EliminarU.Visible = true;
            PnlFormU.Visible = true;
            ControlesOnOff(false);
            ObjetoEntidad_WebFormU();
        }

        protected void GridViewP_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
            hfIDProyecto.Value = GridViewP.DataKeys[e.NewEditIndex].Value.ToString();
            PnlRegistros.Visible = false;
            PnlProyecto.Visible = true;
            PnlFormP.Visible = true;
            IBM_ModificarP.Visible = true;
            ObjetoEntidad_WebFormP(hfAccionV.Value);
        }

        protected void GridViewE_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
            hfIDEntrega.Value = GridViewE.DataKeys[e.NewEditIndex].Value.ToString();
            PnlRegistros.Visible = false;
            PnlEntrega.Visible = true;
            IBM_ModificarP.Visible = true;
            ObjetoEntidad_WebFormE(hfAccionV.Value);
        }
        #endregion

        #region Entidades Web EPU
        private void ObjetoEntidad_WebFormU()
        {
            int IDUsuario = hfIDUsuario.Value == string.Empty ? 0 : Convert.ToInt32(hfIDUsuario.Value);

            E_Usuario U = NU.BuscarUsuario(IDUsuario);
            if (U != null)
            {
                NombreUsuario.Text = U.NombreUsuario;
                LoginUsuario.Text = U.Login;
                RolUsuario.Text = U.Rol;
                ClaveUsuario.Text = U.Password;
            }
        }
        private void ObjetoEntidad_WebFormE(string Accion)
        {
            int IDEntrega = hfIDEntrega.Value == string.Empty ? 0 : Convert.ToInt32(hfIDEntrega.Value);
            E_Entrega E = NE.BuscarEntrega(IDEntrega);
            E_Usuario C = (E_Usuario)Session["SesionLogin"];
            if (C.Rol.Contains("ADMIN"))
            {
                if (Accion.Contains("VER"))
                {
                    if (E != null)
                    {
                        hfIDPEntrega.Value = E.IDProyecto.ToString();
                        hfIDVEntrega.Value = E.Version.ToString();
                        ConceptoEntrega.Text = E.Concepto;
                        EstadoEntrega.Text = E.Estado;
                        ComentariosEntrega.Text = E.Comentarios;
                        LblTEntrega.Text = "Ver Entregas";
                        PnlFormE.Visible = true;
                        ControlesOnOff(false);
                        if (E.NombreEntrega != null && E.NombreEntrega != string.Empty)
                        {
                            PnlVisualizarArchivo.Visible = true;
                            LblTVerArchivo.Text = "Ver archivo de Entrega";
                            NombreArchivo.Text = E.NombreEntrega;
                            TipoArchivo.Text = E.TipoEntrega;
                        }
                    }
                    else
                    {
                        PnlFormE.Visible = false;
                        LblTEntrega.Text = "Ver Entregas: No hay entregas a visualizar";
                    }
                }
                else
                {
                    if (E != null && E.Estado != "PENDIENTE")
                    {
                        hfIDPEntrega.Value = E.IDProyecto.ToString();
                        hfIDVEntrega.Value = E.Version.ToString();
                        ConceptoEntrega.Text = E.Concepto;
                        EstadoEntrega.Text = E.Estado;
                        ComentariosEntrega.Text = E.Comentarios;
                        LblTEntrega.Text = "Aprobar Entrega";
                        BtnAprobar.Visible = true;
                        BtnACorregir.Visible = true;
                        PnlSubirEntrega.Visible = false;
                        PnlFormE.Visible = true;
                        ControlesOnOff(false);
                        ComentariosEntrega.Enabled = true;
                        if (E.NombreEntrega != null && E.NombreEntrega != string.Empty)
                        {
                            PnlVisualizarArchivo.Visible = true;
                            LblTVerArchivo.Text = "Ver archivo de Entrega";
                            NombreArchivo.Text = E.NombreEntrega;
                            TipoArchivo.Text = E.TipoEntrega;
                        }
                    }
                    else
                    {

                        LblTEntrega.Text = "Aprobar Entrega: No se pueden aprobar las solicitudes pendientes de entrega";
                        PnlFormE.Visible = false;
                    }
                }
            }
            else
            {
                if (Accion.Contains("VER"))
                {
                    if (E != null)
                    {
                        hfIDPEntrega.Value = E.IDProyecto.ToString();
                        hfIDVEntrega.Value = E.Version.ToString();
                        ConceptoEntrega.Text = E.Concepto;
                        EstadoEntrega.Text = E.Estado;
                        ComentariosEntrega.Text = E.Comentarios;
                        LblTEntrega.Text = "Ver Entregas realizadas";
                        PnlFormE.Visible = true;
                        ControlesOnOff(false);
                        if (E.NombreEntrega != null && E.NombreEntrega != string.Empty)
                        {
                            PnlVisualizarArchivo.Visible = true;
                            LblTVerArchivo.Text = "Ver archivo de Entrega";
                            NombreArchivo.Text = E.NombreEntrega;
                            TipoArchivo.Text = E.TipoEntrega;
                        }
                    }
                    else
                    {
                        PnlFormE.Visible = false;
                        LblTEntrega.Text = "Ver Entregas realizadas: No hay entregas realizadas";
                    }
                }
                else
                {
                    if (E != null)
                    {
                        hfIDPEntrega.Value = E.IDProyecto.ToString();
                        hfIDVEntrega.Value = E.Version.ToString();
                        ConceptoEntrega.Text = E.Concepto;
                        EstadoEntrega.Text = E.Estado;
                        ComentariosEntrega.Text = E.Comentarios;
                        PnlEntrega.Visible = true;
                        LblTEntrega.Text = "Hacer Entrega";
                        PnlFormE.Visible = true;
                        ControlesOnOff(false);
                        if (E.NombreEntrega == null || E.NombreEntrega == string.Empty)
                        {
                            PnlSubirEntrega.Visible = true;
                        }
                    }
                    else
                    {
                        PnlFormE.Visible = false;
                        LblTEntrega.Text = "Hacer Entrega: No hay entregas para realizar";
                    }
                }
                if (Accion.Contains("APROBAR"))
                {
                    if (E != null && E.Estado != "PENDIENTE")
                    {
                        hfIDPEntrega.Value = E.IDProyecto.ToString();
                        hfIDVEntrega.Value = E.Version.ToString();
                        ConceptoEntrega.Text = E.Concepto;
                        EstadoEntrega.Text = E.Estado;
                        ComentariosEntrega.Text = E.Comentarios;
                        LblTEntrega.Text = "Revisar Entrega";
                        BtnAprobar.Visible = true;
                        BtnACorregir.Visible = true;
                        PnlSubirEntrega.Visible = false;
                        PnlFormE.Visible = true;
                        ControlesOnOff(false);
                        ComentariosEntrega.Enabled = true;
                        if (E.NombreEntrega != null && E.NombreEntrega != string.Empty)
                        {
                            PnlVisualizarArchivo.Visible = true;
                            LblTVerArchivo.Text = "Ver archivo de Entrega";
                            NombreArchivo.Text = E.NombreEntrega;
                            TipoArchivo.Text = E.TipoEntrega;
                        }
                    }
                    else
                    {

                        LblTEntrega.Text = "Revisar Entrega: No se pueden ver las solicitudes pendientes de entrega";
                        PnlFormE.Visible = false;
                    }
                }
                if (Accion.Contains("CORREGIR"))
                {
                    if (E != null && E.Estado != "PENDIENTE")
                    {
                        hfIDPEntrega.Value = E.IDProyecto.ToString();
                        hfIDVEntrega.Value = E.Version.ToString();
                        ConceptoEntrega.Text = E.Concepto;
                        EstadoEntrega.Text = E.Estado;
                        ComentariosEntrega.Text = E.Comentarios;
                        LblTEntrega.Text = "Corregir entrega";
                        PnlFormE.Visible = true;
                        IBM_ModificarE.Enabled = true;
                        ControlesOnOff(false);
                        PnlSubirEntrega.Visible = true;
                        if (E.NombreEntrega != null && E.NombreEntrega != string.Empty)
                        {
                            PnlVisualizarArchivo.Visible = true;
                            LblTVerArchivo.Text = "Ver archivo de Entrega";
                            NombreArchivo.Text = E.NombreEntrega;
                            TipoArchivo.Text = E.TipoEntrega;
                        }
                    }
                    else
                    {
                        PnlFormE.Visible = false;
                        LblTEntrega.Text = "Corregir entrega: No hay entregas para corregir errores";
                    }
                }
                if (Accion.Contains("ERRORES"))
                {
                    if (E != null && E.Estado != "PENDIENTE")
                    {
                        hfIDPEntrega.Value = E.IDProyecto.ToString();
                        hfIDVEntrega.Value = E.Version.ToString();
                        ConceptoEntrega.Text = E.Concepto;
                        EstadoEntrega.Text = E.Estado;
                        ComentariosEntrega.Text = E.Comentarios;
                        LblTEntrega.Text = "Registrar errores en entrega";
                        PnlFormE.Visible = true;
                        BtnErrores.Visible = true;
                        ControlesOnOff(false);
                        ComentariosEntrega.Enabled = true;
                        if (E.NombreEntrega != null && E.NombreEntrega != string.Empty)
                        {
                            PnlVisualizarArchivo.Visible = true;
                            LblTVerArchivo.Text = "Ver archivo de Entrega";
                            NombreArchivo.Text = E.NombreEntrega;
                            TipoArchivo.Text = E.TipoEntrega;
                        }
                    }
                    else
                    {
                        PnlFormE.Visible = false;
                        LblTEntrega.Text = "Registrar errores en entrega: No hay entregas para reportar errores";
                    }
                }
                if (Accion.Contains("CAPACITAR"))
                {
                    if (E != null && E.Estado != "PENDIENTE")
                    {
                        hfIDPEntrega.Value = E.IDProyecto.ToString();
                        hfIDVEntrega.Value = E.Version.ToString();
                        ConceptoEntrega.Text = E.Concepto;
                        EstadoEntrega.Text = E.Estado;
                        ComentariosEntrega.Text = E.Comentarios;
                        LblTEntrega.Text = "Registrar capacitación al cliente";
                        PnlFormE.Visible = true;
                        BtnCapacitar.Visible = true;
                        ControlesOnOff(false);
                        if (E.NombreEntrega != null && E.NombreEntrega != string.Empty)
                        {
                            PnlVisualizarArchivo.Visible = true;
                            LblTVerArchivo.Text = "Ver archivo de Entrega";
                            NombreArchivo.Text = E.NombreEntrega;
                            TipoArchivo.Text = E.TipoEntrega;
                        }
                    }
                    else
                    {
                        PnlFormE.Visible = false;
                        LblTEntrega.Text = "Registrar capacitación al cliente: No hay entregas para capacitar";
                    }
                }
                if (Accion.Contains("ZOOM"))
                {
                    if (E != null && E.Estado != "PENDIENTE")
                    {
                        hfIDPEntrega.Value = E.IDProyecto.ToString();
                        hfIDVEntrega.Value = E.Version.ToString();
                        ConceptoEntrega.Text = E.Concepto;
                        EstadoEntrega.Text = E.Estado;
                        ComentariosEntrega.Text = E.Comentarios;
                        LblTEntrega.Text = "Iniciar capacitación al cliente";
                        PnlFormE.Visible = true;
                        BtnZoom.Visible = true;
                        ControlesOnOff(false);
                        if (E.NombreEntrega != null && E.NombreEntrega != string.Empty)
                        {
                            PnlVisualizarArchivo.Visible = true;
                            LblTVerArchivo.Text = "Ver archivo de Entrega";
                            NombreArchivo.Text = E.NombreEntrega;
                            TipoArchivo.Text = E.TipoEntrega;
                        }
                    }
                    else
                    {
                        PnlFormE.Visible = false;
                        LblTEntrega.Text = "Iniciar capacitación al cliente: No hay entregas para capacitar";
                    }
                }
            }
        }

        private void ObjetoEntidad_WebFormP(string Accion)
        {
            int IDProyecto = hfIDProyecto.Value == string.Empty ? 0 : Convert.ToInt32(hfIDProyecto.Value);
            E_Proyecto P = NP.BuscarProyecto(IDProyecto);
            E_Usuario C = (E_Usuario)Session["SesionLogin"];
            if (C.Rol.Contains("AGENTE DE VENTAS"))
            {
                if (Accion.Contains("VER"))
                {
                    if (P != null)
                    {
                        NombreCliente.Text = P.NombreCliente;
                        CorreoCliente.Text = P.CorreoCliente;
                        NombreProyecto.Text = P.NombreProyecto;
                        EstadoProyecto.Text = P.EstadoProyecto;
                        LblTProyecto.Text = "Ver Proyectos";
                        PnlFormE.Visible = true;
                        ControlesOnOff(false);
                        if (P.NombreInforme != null && P.NombreInforme != string.Empty)
                        {
                            PnlVisualizarArchivo.Visible = true;
                            LblTVerArchivo.Text = "Ver Informe del Proyecto";
                            NombreArchivo.Text = P.NombreInforme;
                            TipoArchivo.Text = P.TipoInforme;
                        }
                    }
                    else
                    {
                        PnlFormE.Visible = false;
                        LblTProyecto.Text = "Ver Proyectos: No hay proyectos a visualizar";
                    }
                }
                else
                {
                    if (P != null)
                    {
                        NombreCliente.Text = P.NombreCliente;
                        CorreoCliente.Text = P.CorreoCliente;
                        NombreProyecto.Text = P.NombreProyecto;
                        EstadoProyecto.Text = P.EstadoProyecto;
                        LblTProyecto.Text = "Editar Proyectos";
                        PnlFormE.Visible = true;
                        IBM_ModificarP.Visible = true;
                        if (P.NombreInforme != null && P.NombreInforme != string.Empty)
                        {
                            PnlVisualizarArchivo.Visible = true;
                            LblTVerArchivo.Text = "Ver Informe del Proyecto";
                            NombreArchivo.Text = P.NombreInforme;
                            TipoArchivo.Text = P.TipoInforme;
                        }
                    }
                    else
                    {
                        PnlFormE.Visible = false;
                        LblTProyecto.Text = "Editar Proyectos: No hay proyectos a editar";
                    }
                }
            }
            else
            {
                if (Accion.Contains("VER"))
                {
                    if (P != null)
                    {
                        NombreCliente.Text = P.NombreCliente;
                        CorreoCliente.Text = P.CorreoCliente;
                        NombreProyecto.Text = P.NombreProyecto;
                        EstadoProyecto.Text = P.EstadoProyecto;
                        LblTProyecto.Text = "Ver Proyectos";
                        PnlFormE.Visible = true;
                        ControlesOnOff(false);
                        IBM_ModificarP.Visible = false;
                        if (P.NombreInforme != null && P.NombreInforme != string.Empty)
                        {
                            PnlVisualizarArchivo.Visible = true;
                            LblTVerArchivo.Text = "Ver Informe del Proyecto";
                            NombreArchivo.Text = P.NombreInforme;
                            TipoArchivo.Text = P.TipoInforme;
                        }
                    }
                    else
                    {
                        PnlFormE.Visible = false;
                        LblTProyecto.Text = "Ver Proyectos: No hay proyectos a visualizar";
                    }
                }
                else
                {
                    if (P != null)
                    {
                        NombreCliente.Text = P.NombreCliente;
                        CorreoCliente.Text = P.CorreoCliente;
                        NombreProyecto.Text = P.NombreProyecto;
                        EstadoProyecto.Text = P.EstadoProyecto;
                        IBM_ModificarP.Visible = false;
                        LblTProyecto.Text = "Subir Informe de Proyecto";
                        PnlFormE.Visible = true;
                        ControlesOnOff(false);
                        if (P.NombreInforme == null || P.NombreInforme == string.Empty)
                        {
                            PnlSubirInforme.Visible = true;
                        }
                    }
                    else
                    {
                        PnlFormE.Visible = false;
                        LblTProyecto.Text = "Subir Informe de Proyecto: No hay proyectos para subir Informe";
                    }
                }
            }
        }



        #endregion

        protected void BtnHacerInforme_Click(object sender, EventArgs e)
        {
            Inicializar();
            PnlRegistros.Visible = true;
            GrvProyectos.Visible = true;
            hfAccionV.Value = "SUBIR";
            hfTipoArchivo.Value = "INFORME";
            List<E_Proyecto> LP = NP.BuscaProyectos("PENDIENTE");
            if (LP != null && LP.Count != 0)
            {
                LblTRegistros.Text = "Ver proyectos sin informe";
                GridViewP.DataSource = LP;
                GridViewP.DataBind();
            }
            else
            {
                GrvProyectos.Visible = false;
                LblTRegistros.Text = "Ver proyectos sin informe: No hay informes pendientes de subir";
            }
        }

        protected void BtnReportarE_Click(object sender, EventArgs e)
        {
            Inicializar();
            PnlRegistros.Visible = true;
            GrvEntregas.Visible = true;
            hfAccionV.Value = "ERRORES";
            hfTipoArchivo.Value = "ENTREGA";
            List<E_Entrega> LE = NE.BuscaEntregas("APLICACION");
            if (LE != null && LE.Count != 0)
            {
                LblTRegistros.Text = "Ver Aplicaciones aprobadas";
                GridViewE.DataSource = LE;
                GridViewE.DataBind();
            }
            else
            {
                GrvEntregas.Visible = false;
                LblTRegistros.Text = "Ver Aplicaciones aprobadas: No hay aplicaciones en funcionamiento";
            }
        }

        protected void BtnReportarC_Click(object sender, EventArgs e)
        {
            Inicializar();
            PnlRegistros.Visible = true;
            GrvEntregas.Visible = true;
            hfAccionV.Value = "CAPACITAR";
            hfTipoArchivo.Value = "ENTREGA";
            List<E_Entrega> LE = NE.BuscaEntregasDesarrollo("APROBADO");
            if (LE != null && LE.Count != 0)
            {
                LblTRegistros.Text = "Ver Aplicaciones aprobadas";
                GridViewE.DataSource = LE;
                GridViewE.DataBind();
            }
            else
            {
                GrvEntregas.Visible = false;
                LblTRegistros.Text = "Ver Aplicaciones aprobadas: No hay aplicaciones en funcionamiento";
            }
        }

        protected void BtnHacerC_Click(object sender, EventArgs e)
        {
            Inicializar();
            PnlRegistros.Visible = true;
            GrvEntregas.Visible = true;
            hfAccionV.Value = "ZOOM";
            hfTipoArchivo.Value = "ENTREGA";
            List<E_Entrega> LE = NE.BuscaEntregasDesarrollo("APROBADO");
            if (LE != null && LE.Count != 0)
            {
                LblTRegistros.Text = "Ver Aplicaciones aprobadas";
                GridViewE.DataSource = LE;
                GridViewE.DataBind();
            }
            else
            {
                GrvEntregas.Visible = false;
                LblTRegistros.Text = "Ver Aplicaciones aprobadas: No hay aplicaciones en funcionamiento";
            }
        }

        protected void BtnZoom_Click(object sender, EventArgs e)
        {
            int IDEntrega = hfIDEntrega.Value == string.Empty ? 0 : Convert.ToInt32(hfIDEntrega.Value);
            E_Entrega E = NE.BuscarEntrega(IDEntrega);
            E_Proyecto P = NP.BuscarProyecto(E.IDProyecto);
            if (P != null)
            {
                try
                {
                    MailMessage correo = new MailMessage();

                    correo.From = new MailAddress("sistema.eureka.contacto@gmail.com", "Sistema Eureka", System.Text.Encoding.UTF8);
                    correo.To.Add(P.CorreoCliente);
                    correo.Subject = "Capacitación Eureka: " + P.NombreProyecto;
                    correo.Body = "Hola " + P.NombreCliente  + Environment.NewLine + 
                                  ", En breve iniciará nuestra sesión de capacitación para tu proyecto " + P.NombreProyecto + ", puedes ingresar a la sala ingresando los siguientes datos:" + Environment.NewLine +
                                  "Join Zoom Meeting:" + Environment.NewLine +
                                  "https://zoom.us/j/96476703087?pwd=ZSs1Z3lCVUs1OVZPSjhUdGFxczJxUT09" + Environment.NewLine +
                                  "Meeting ID: 964 7670 3087" + Environment.NewLine +
                                  "Passcode: Wx2SVT" + Environment.NewLine +
                                  "¡Te esperamos!.";
                    correo.IsBodyHtml = true;
                    correo.Priority = MailPriority.Normal;

                    SmtpClient smtp = new SmtpClient();
                    smtp.UseDefaultCredentials = false;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential("sistema.eureka.contacto@gmail.com", "Aragon33!");
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                    smtp.Send(correo);

                    Response.Redirect("https://localhost:44352/Zoom/index.html");
                }
                catch(Exception ex)
                {
                    LblTEntrega.Text = "Error al notificar: " + ex.Message;
                }
            }
        }

        protected void BtnErrores_Click(object sender, EventArgs e)
        {
            int IDEntrega = hfIDEntrega.Value == string.Empty ? 0 : Convert.ToInt32(hfIDEntrega.Value);
            E_Entrega E = NE.BuscarEntrega(IDEntrega);
            if (E != null)
            {

                E.Estado = "CORREGIR";
                E.Comentarios = ComentariosEntrega.Text;
                LblTEntrega.Text = "Reportar Aplicacion: " + NE.ModificaEntrega(E);
            }
            else
            {
                LblTEntrega.Text = "Reportar Aplicacion: Error";
            }
        }

        protected void BtnSoliPublicidad_Click(object sender, EventArgs e)
        {
            Inicializar();
            PnlEntrega.Visible = true;
            PnlFormE.Visible = true;
            ConceptoEntrega.Text = "CAMPAÑA";
            ConceptoEntrega.Enabled = false;
            EstadoEntrega.Text = "PENDIENTE";
            EstadoEntrega.Enabled = false;
            LblTEntrega.Text = "Solicitar diseño de publicidad";
            IBM_InsertarE.Visible = true;
        }

        protected void BtnVerInformes_Click(object sender, EventArgs e)
        {
            Inicializar();
            PnlRegistros.Visible = true;
            GrvProyectos.Visible = true;
            hfAccionV.Value = "VER";
            hfTipoArchivo.Value = "INFORME";
            List<E_Proyecto> LP = NP.BuscaProyectos("EN_PRODUCCION");
            if (LP != null && LP.Count != 0)
            {
                LblTRegistros.Text = "Ver proyectos con informes";
                GridViewP.DataSource = LP;
                GridViewP.DataBind();
            }
            else
            {
                GrvProyectos.Visible = false;
                LblTRegistros.Text = "Ver proyectos con informes: No hay reportes a mostrar";
            }
        }

        protected void BtnDesInterfaz_Click(object sender, EventArgs e)
        {
            Inicializar();
            PnlRegistros.Visible = true;
            GrvEntregas.Visible = true;
            hfAccionV.Value = "APROBAR";
            hfTipoArchivo.Value = "ENTREGA";
            List<E_Entrega> LE = NE.BuscaEntregascampa("INTERFAZ");
            if (LE != null && LE.Count != 0)
            {
                LblTRegistros.Text = "Ver diseños de aplicaciones realizadas";
                GridViewE.DataSource = LE;
                GridViewE.DataBind();
            }
            else
            {
                GrvEntregas.Visible = false;
                LblTRegistros.Text = "Ver diseños de aplicaciones realizadas: No hay diseños realizados";
            }
        }

        protected void BtnDesPublicidad_Click(object sender, EventArgs e)
        {
            Inicializar();
            PnlRegistros.Visible = true;
            GrvEntregas.Visible = true;
            hfAccionV.Value = "APROBAR";
            hfTipoArchivo.Value = "ENTREGA";
            List<E_Entrega> LE = NE.BuscaEntregascampa("CAMPAÑA");
            if (LE != null && LE.Count != 0)
            {
                LblTRegistros.Text = "Ver diseños de campañas realizadas";
                GridViewE.DataSource = LE;
                GridViewE.DataBind();
            }
            else
            {
                GrvEntregas.Visible = false;
                LblTRegistros.Text = "Ver diseños de campañas realizadas: No hay diseños realizados";
            }
        }

        protected void BtnRegProyecto_Click(object sender, EventArgs e)
        {
            Inicializar();
            PnlProyecto.Visible = true;
            PnlFormP.Visible = true;
            LblTProyecto.Text = "Registrar proyecto";
            IBM_InsertarP.Visible = true;
            EstadoProyecto.Text = "PENDIENTE";
            EstadoProyecto.Enabled = false;
        }

        protected void IBM_InsertarE_Click(object sender, EventArgs e)
        {
            Entrega.IDEntrega = 6;
            Entrega.IDProyecto = 2;
            Entrega.Version = 1;
            Entrega.Concepto = ConceptoEntrega.Text;
            Entrega.Estado = EstadoEntrega.Text;
            Entrega.TipoEntrega = string.Empty;
            Entrega.NombreEntrega = string.Empty;
            Entrega.Entrega = new byte[4096];
            Entrega.Comentarios = ComentariosEntrega.Text;
            Entrega.IDUsuario = 1;
            LblTEntrega.Text = "Solicitar diseño de publicidad: " + NE.InsertaEntrega(Entrega);
        }

        protected void BtnCapacitar_Click(object sender, EventArgs e)
        {
            int IDEntrega = hfIDEntrega.Value == string.Empty ? 0 : Convert.ToInt32(hfIDEntrega.Value);
            E_Entrega E = NE.BuscarEntrega(IDEntrega);
            E_Proyecto P = NP.BuscarProyecto(E.IDProyecto);
            if (E != null && P != null)
            {

                E.Estado = "FINALIZADO";
                P.EstadoProyecto = "ENTREGADO";
                LblTEntrega.Text = "Reportar Capacitación: " + NE.ModificaEntrega(E);
                LblTEntrega.Text = "Reportar Capacitación: " + NP.ModificaProyecto(P);
            }
            else
            {
                LblTEntrega.Text = "Reportar Capacitación: Error";
            }
        }

        #region Entregas
        protected SqlConnection AbreBD()
        {
            SqlConnection Conexion = new SqlConnection("Data Source=LAPTOP-ISAAC\\SQLEXPRESS; Initial Catalog=Eureka; Integrated Security=true");
            Conexion.Open();

            return Conexion;
        }

        protected void BtnSubirEntrega_Click(object sender, EventArgs e)
        {
            if (FUEntrega.HasFile)
            {
                HttpPostedFile hpfEntrega = FUEntrega.PostedFile;
                E_Usuario C = (E_Usuario)Session["SesionLogin"];
                int IDEntrega = hfIDEntrega.Value == string.Empty ? 0 : Convert.ToInt32(hfIDEntrega.Value);
                E_Entrega E = NE.BuscarEntrega(IDEntrega);
                int Version = E.Version;
                if (E.Estado.Contains("CORREGIR"))
                {
                    Version += 1;
                }
                string NombreEntrega = Path.GetFileName(hpfEntrega.FileName);
                string TipoEntrega = FUEntrega.PostedFile.ContentType;
                int TamanoEntrega = FUEntrega.PostedFile.ContentLength;
                Byte[] byteArchivo = new byte[TamanoEntrega];
                hpfEntrega.InputStream.Read(byteArchivo, 0, TamanoEntrega);

                Entrega.IDEntrega = Convert.ToInt32(hfIDEntrega.Value);
                Entrega.IDProyecto = Convert.ToInt32(hfIDPEntrega.Value);
                Entrega.Version = Version;
                Entrega.Concepto = ConceptoEntrega.Text;
                Entrega.NombreEntrega = NombreEntrega;
                Entrega.TipoEntrega = TipoEntrega;
                Entrega.Entrega = byteArchivo;
                Entrega.Estado = "ENTREGADO";
                Entrega.Comentarios = string.Empty;
                Entrega.IDUsuario = C.IDUsuario;
                LblTEntrega.Text = "Hacer Entrega: " + NE.ModificaEntrega(Entrega);
            }
            else
            {
                LblTEntrega.Text = "Hacer Entrega: Se debe elegir un archivo.";
            }
        }

        protected void BtnAbrirArchivo_Click(object sender, EventArgs e)
        {
            if(hfTipoArchivo.Value.Contains("ENTREGA"))
            {
                Response.Redirect("https://localhost:44352/Handler/RecuperaEntregasA.ashx?IDEntrega=" + hfIDEntrega.Value);
            }
            else
            {
                Response.Redirect("https://localhost:44352/Handler/RecuperaInformes.ashx?IDProyecto=" + hfIDProyecto.Value);
            }
        }

        protected void BtnSubirInforme_Click(object sender, EventArgs e)
        {
            if (FUInforme.HasFile)
            {
                HttpPostedFile hpfInforme = FUInforme.PostedFile;
                E_Usuario C = (E_Usuario)Session["SesionLogin"];

                string NombreInforme = Path.GetFileName(hpfInforme.FileName);
                string TipoInforme = FUInforme.PostedFile.ContentType;
                int TamanoInforme = FUInforme.PostedFile.ContentLength;
                Byte[] byteInforme = new byte[TamanoInforme];
                hpfInforme.InputStream.Read(byteInforme, 0, TamanoInforme);

                Proyecto.IDProyecto = Convert.ToInt32(hfIDProyecto.Value);
                Proyecto.NombreCliente = NombreCliente.Text;
                Proyecto.CorreoCliente = CorreoCliente.Text;
                Proyecto.NombreProyecto = NombreProyecto.Text;
                Proyecto.NombreInforme = NombreInforme;
                Proyecto.TipoInforme = TipoInforme;
                Proyecto.Informe = byteInforme;
                Proyecto.EstadoProyecto = "EN_PRODUCCION";
                LblTEntrega.Text = "Subir Informe de Proyecto: " + NP.ModificaProyecto(Proyecto);
                if (LblTEntrega.Text.Contains("Subir Informe de Proyecto: Exito: el proyecto se registró correctamente"))
                {
                    //Notifica al Diseñador - Interfaz
                    Entrega.IDEntrega = 5;
                    Entrega.IDProyecto = Convert.ToInt32(hfIDProyecto.Value);
                    Entrega.Version = 1;
                    Entrega.Concepto = "INTERFAZ";
                    Entrega.Estado = "PENDIENTE";
                    Entrega.TipoEntrega = string.Empty;
                    Entrega.NombreEntrega = string.Empty;
                    Entrega.Entrega = new byte[4096];
                    Entrega.Comentarios = string.Empty;
                    Entrega.IDUsuario = 1;
                    LblTEntrega.Text = "Subir Informe de Proyecto: " + NE.InsertaEntrega(Entrega);
                    //Notifica al Desarrollador - Aplicació
                    Entrega.IDEntrega = 5;
                    Entrega.IDProyecto = Convert.ToInt32(hfIDProyecto.Value);
                    Entrega.Version = 1;
                    Entrega.Concepto = "APLICACION";
                    Entrega.Estado = "PENDIENTE";
                    Entrega.TipoEntrega = string.Empty;
                    Entrega.NombreEntrega = string.Empty;
                    Entrega.Entrega = new byte[4096];
                    Entrega.Comentarios = string.Empty;
                    Entrega.IDUsuario = 1;
                    LblTEntrega.Text = "Subir Informe de Proyecto: " + NE.InsertaEntrega(Entrega);
                    //Notifica al Desarrollador - Documentación
                    Entrega.IDEntrega = 5;
                    Entrega.IDProyecto = Convert.ToInt32(hfIDProyecto.Value);
                    Entrega.Version = 1;
                    Entrega.Concepto = "DOCUMENTACION";
                    Entrega.Estado = "PENDIENTE";
                    Entrega.TipoEntrega = string.Empty;
                    Entrega.NombreEntrega = string.Empty;
                    Entrega.Entrega = new byte[4096];
                    Entrega.Comentarios = string.Empty;
                    Entrega.IDUsuario = 1;
                    LblTEntrega.Text = "Subir Informe de Proyecto: " + NE.InsertaEntrega(Entrega);
                }
            }
            else
            {
                LblTEntrega.Text = "Subir Informe de Proyecto: Se debe elegir un archivo.";
            }
        }
        #endregion

        protected void IBM_InsertarP_Click(object sender, EventArgs e)
        {
            Proyecto.NombreCliente = NombreCliente.Text;
            Proyecto.CorreoCliente = CorreoCliente.Text;
            Proyecto.NombreProyecto = NombreProyecto.Text;
            Proyecto.EstadoProyecto = EstadoProyecto.Text;
            LblTProyecto.Text = "Registrar proyecto: " + NP.InsertaProyecto(Proyecto);
        }
    }
} 