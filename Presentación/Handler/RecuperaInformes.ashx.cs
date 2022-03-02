using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Presentación.Handler
{
    /// <summary>
    /// Descripción breve de RecuperaArchivos
    /// </summary>
    public class RecuperaInformes : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var id = context.Request.QueryString["IDProyecto"];
            int IDProyecto;
            if (int.TryParse(id, out IDProyecto) == true)
            {
                SqlConnection Conexion = new SqlConnection("Data Source=LAPTOP-ISAAC\\SQLEXPRESS; Initial Catalog=Eureka; Integrated Security=true");
                Conexion.Open();

                DataTable DT = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM Proyectos WHERE IDProyecto=" + id, Conexion);
                DA.Fill(DT);
                if(DT != null)
                {
                    context.Response.ContentType = DT.Rows[0]["TipoInforme"].ToString();
                    Stream str = new MemoryStream((byte[])DT.Rows[0]["Informe"]);
                    byte[] buffer = new byte[4096];
                    int bytesnq = str.Read(buffer, 0, 4096);
                    while (bytesnq > 0)
                    {
                        context.Response.OutputStream.Write(buffer,0,bytesnq);
                        bytesnq = str.Read(buffer,0,4096);
                    }
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}