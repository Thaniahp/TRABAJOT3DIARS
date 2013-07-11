
using AEAS.AdministracionYUsuarios.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AeasOnline.General
{
    public partial class contactanos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clsUsuario objusuario = (clsUsuario)Session["Usuario"];
            if (objusuario == null)
            {
                Response.Redirect("/General/Default.aspx");
            }
            else
            {
               
            }
        }
    }
}