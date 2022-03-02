using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Presentación.Handler
{
    /// <summary>
    /// Descripción breve de RecuperaEntregas
    /// </summary>
    public class RecuperaEntregasA : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var id = context.Request.QueryString["IDEntrega"];
            int IDEntrega;
            if (int.TryParse(id, out IDEntrega) == true)
            {
                SqlConnection Conexion = new SqlConnection("Data Source=LAPTOP-ISAAC\\SQLEXPRESS; Initial Catalog=Eureka; Integrated Security=true");
                Conexion.Open();

                DataTable DT = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM Entregas WHERE IDEntrega=" + id, Conexion);
                DA.Fill(DT);
                if(DT != null)
                {
                    context.Response.ContentType = DT.Rows[0]["TipoEntrega"].ToString();
                    Stream str = new MemoryStream((byte[])DT.Rows[0]["Entrega"]);
                    byte[] buffer = new byte[4096];
                    int bytesnq = str.Read(buffer, 0, 4096);

                    if (DT.Rows[0]["TipoEntrega"].ToString() == "application/pdf")
                    {
                        while (bytesnq > 0)
                        {
                            context.Response.OutputStream.Write(buffer, 0, bytesnq);
                            bytesnq = str.Read(buffer, 0, 4096);
                        }
                    }
                    else
                    {
                        string path = AppDomain.CurrentDomain.BaseDirectory;
                        string folder = path + "/temp/";
                        string fullfilepath = folder + DT.Rows[0]["NombreEntrega"].ToString();

                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);
                        }
                        if (File.Exists(fullfilepath))
                        {
                            File.Delete(fullfilepath);
                        }

                        File.WriteAllBytes(fullfilepath, buffer);
                        Process.Start(fullfilepath);
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