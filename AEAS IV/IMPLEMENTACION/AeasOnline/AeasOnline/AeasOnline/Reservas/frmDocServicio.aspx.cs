using AEAS.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AeasOnline.Reservas
{
    public partial class frmDocServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if(!String.IsNullOrEmpty(Request.QueryString["t"])){
                    if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        CargarPagina(Request.QueryString["t"], Convert.ToInt32(Request.QueryString["id"]));
                    }
                    else { Response.Redirect("../General/Home.aspx"); }
                }
                else { Response.Redirect("../General/Home.aspx"); }
            }
        }
        private void CargarPagina(String tipo, Int32 id) {
            DataTable dt = new DataTable();
            switch (tipo)
            {
                case "e":
                    dt = clsEventosBLL.Instance.ListarEventoPorId(id);
                    GenerarServicioEvento(dt);
                    break;
                case "c":
                    dt = clsCursoBLL.Instance.ListarCursosPorId(id);
                    GenerarServicioCurso(dt);
                    break;
                case "a":
                    dt = clsAmbienteBLL.Instance.ListarEventosPorId(id);
                    GenerarServicioAmbiente(dt);
                    break;
                default:
                    break;
            }
        }

        private void GenerarServicioEvento(DataTable dt)
        {
           String html= string.Empty;
           html = "<b>Nombre del evento : <h3 class='h3data'>"+dt.Rows[0]["NOMBRE"].ToString()+"</h3></b>"
                + "<b>Descripci&oacute;n : <h3 class='h3data'>" + dt.Rows[0]["DESCRIPCION"].ToString() + "</h3></b>"
                + "<b>Direcci&oacute;n : <h3 class='h3data'>" + dt.Rows[0]["DIRECCION"].ToString() + "</h3></b>"
                + "<b>Precio : <h3 class='h3data'>" + dt.Rows[0]["PRECIO"].ToString() + "</h3></b>"
                + "<b>Fecha de inicio : <h3 class='h3data'>" + dt.Rows[0]["FECHAINICIO"].ToString() + "</h3></b>"
                + "<b>Fecha fin : <h3 class='h3data'>" + dt.Rows[0]["FECHAFIN"].ToString() + "</h3></b>"
                + "<b>Organizador : <h3 class='h3data'>" + dt.Rows[0]["ORGANIZADOR"].ToString() + "</h3></b>"
                + "<b>Aun quedan : <h3 class='h3data'>" + dt.Rows[0]["CAPACIDAD"].ToString() + " vacantes</h3> </b>"
                ;
           divservicio.InnerHtml = html;
        }

        private void GenerarServicioCurso(DataTable dt) {
            String html = string.Empty;
            html = "<b>Nombre del Curso : <h3 class='h3data'>" + dt.Rows[0]["NOMBRE"].ToString() + "</h3></b>"
                 + "<b>Precio : <h3 class='h3data'>" + dt.Rows[0]["PRECIO"].ToString() + "</h3></b>"
                 + "<b>Fecha de inicio : <h3 class='h3data'>" + dt.Rows[0]["FECHAINICIO"].ToString() + "</h3></b>"
                 + "<b>Fecha fin : <h3 class='h3data'>" + dt.Rows[0]["FECHAFIN"].ToString() + "</h3></b>"
                 + "<b>Aun quedan : <h3 class='h3data'>" + dt.Rows[0]["CAPACIDAD"].ToString() + " vacantes</h3> </b>"
                 ;
            divservicio.InnerHtml = html;
        }

        private void GenerarServicioAmbiente(DataTable dt)
        {
            String html = string.Empty;
            html = "<b>Nombre del ambiente : <h3 class='h3data'>" + dt.Rows[0]["NOMBRE"].ToString() + "</h3></b>"
                 + "<b>Direcci&oacute;n : <h3 class='h3data'>" + dt.Rows[0]["DIRECCION"].ToString() + "</h3></b>"
                 + "<b>Precio : <h3 class='h3data'>" + dt.Rows[0]["PRECIO"].ToString() + "</h3></b>"
                 + "<b>Telefono : <h3 class='h3data'>" + dt.Rows[0]["TELEFONO"].ToString() + "</h3></b>"
                 + "<b>Aun quedan : <h3 class='h3data'>" + dt.Rows[0]["CAPACIDAD"].ToString() + " vacantes</h3> </b>"
                 ;
            divservicio.InnerHtml = html;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add(this.txtemail.Text);
            mmsg.Subject = "Servicio";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            mmsg.Body = "<html><body><h1>AEAS</h1>" + divservicio.InnerHtml + "</body></html>";
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("zhany91@gmail.com");
            /*-------------------------CLIENTE DE CORREO----------------------*/
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials = new System.Net.NetworkCredential("zhany91@gmail.com", "z_224322_z");
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com"; 
            /*-------------------------ENVIO DE CORREO----------------------*/
            try
            {   
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }
    }
}