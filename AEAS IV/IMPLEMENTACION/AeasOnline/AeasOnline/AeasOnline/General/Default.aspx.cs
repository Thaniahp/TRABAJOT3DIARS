using AEAS.AdministracionYUsuarios.ENTIDADES;
using AEAS.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AeasOnline
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clsUsuario objusuario = (clsUsuario)Session["Usuario"];
            if (objusuario == null)
            {
                
            }
            else
            {
                Response.Redirect("/General/Home.aspx");
            }
        }

        protected void lbtn_Entrar_Click(object sender, EventArgs e)
        {
            clsUsuario objUser;
            try
            {
                clsUsuario obj = new clsUsuario();
                obj.Pass = txtPass.Text;
                obj.Usuario = txtUser.Text;
                objUser = clsUsuarioBLL.Instance.LogIn(obj);
                if (objUser!=null)
                {
                    Session.Add("Usuario",objUser);
                    Response.Redirect("~/General/Home.aspx");
                }
                else {
                    lblMensaje.Text = "Error en el inicio de sesion";
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}