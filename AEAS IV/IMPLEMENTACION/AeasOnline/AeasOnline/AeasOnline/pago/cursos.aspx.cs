using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Windows.Forms;

using AEAS.AdministracionYUsuarios.DAO;
using AEAS.AdministracionYUsuarios.ENTIDADES;

namespace AeasOnline.pago
{
    public partial class cursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String C = Request.QueryString.Get("IdUsuario");
            Int32 IdUsuario = Convert.ToInt32(C);
            
            ReservaDAO dao = new ReservaDAO();
            GridView1.DataSource = dao.LISTAR(IdUsuario);
            DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "pagar")
            {
                Int32 index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                String i = Server.HtmlDecode(row.Cells[0].Text);

                if (MessageBox.Show("Realmente deseas cancelar la deuda?", "Confirmar eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Int32 IdReserva = Convert.ToInt32(i);

                    clsPago obj = new clsPago();
                    clsPagoDAO g = new clsPagoDAO();
                    if (g.REGPAGO(IdReserva))
                    {
                        Response.Redirect("pago.aspx");
                    }
                }
            }
        }
    }
}