using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentación
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void entra_Click(object sender, EventArgs e)
        {
            N_Usuario NU = new N_Usuario();
            E_Usuario EU = new E_Usuario();
            EU = NU.validaUsuario(Usuario.Text, Pass.Text);
            if (EU != null)
            {
                Session["SesionLogin"] = EU;
                Response.Redirect("Sistema.aspx");
            }
            else
            {
                LblMensaje.Text = "Dato de usuario o contraseña es incorrecto";
            }
        }
    }
}