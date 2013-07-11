using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AEAS.AdministracionYUsuarios.DAO;

namespace AeasOnline.pago
{
    public partial class pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clsUsuarioDAO dao = new clsUsuarioDAO();
            GridView1.DataSource = dao.LISTAR();
            DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Cursos")
            {
                Int32 index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                String i = Server.HtmlDecode(row.Cells[0].Text);

                Response.Redirect("cursos.aspx?IdUsuario=" + i);
            }
        }
    }
}