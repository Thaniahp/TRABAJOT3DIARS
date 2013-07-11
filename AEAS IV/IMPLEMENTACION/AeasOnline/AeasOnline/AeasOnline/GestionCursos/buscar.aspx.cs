using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AEAS.AdministracionYUsuarios.DAO;

namespace AeasOnline.GestionCursos
{
    public partial class buscar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clsCursoDAO dao = new clsCursoDAO();
            GridView1.DataSource = dao.OBTENERPORDESCRIPCION(TextBox1.Text);
            DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("registrar.aspx");
        }
    }
}