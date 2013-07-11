
using AEAS.AdministracionYUsuarios.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AeasOnline
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clsUsuario objusuario= (clsUsuario) Session["Usuario"];
            if (objusuario== null)
            {
                divmenu.Visible = false;
                divtitulo.Visible = false;
                //Response.Redirect("/General/Default.aspx");
            }
            else {
                if (objusuario.IdTipoUsuario == 1)
                {
                    liadmin.Visible = true;
                    lblUser.Text = "Bienvenido Administrador" + objusuario.Nombre + " " + objusuario.Apellidos;
                }
                else {
                    liadmin.Visible = false;
                    lblUser.Text = "Bienvenido Sr." + objusuario.Nombre + " " + objusuario.Apellidos;
                }
                
                divtitulo.Visible = true;
                divmenu.Visible = true;
            }
            
        }

        protected void lbtn_CerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/General/Default.aspx");
        }
    }
}