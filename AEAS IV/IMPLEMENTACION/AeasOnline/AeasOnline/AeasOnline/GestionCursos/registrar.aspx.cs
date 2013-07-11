using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using AEAS.AdministracionYUsuarios.ENTIDADES;
using AEAS.AdministracionYUsuarios.DAO;

namespace AeasOnline.GestionCursos
{
    public partial class registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_registrar_Click(object sender, EventArgs e)
        {
            clsCurso obj = new clsCurso();
            obj.Nombre = TextBox1.Text;
            String IDia,IMes,IAño,FDia,FMes,FAño;

            IDia = DropDownList1.SelectedValue;
            IMes = DropDownList2.SelectedValue;
            IAño = DropDownList3.SelectedValue;

            obj.FechaInicio = Convert.ToDateTime(IDia + "-" + IMes + "-" + IAño);

            FDia = DropDownList4.SelectedValue;
            FMes = DropDownList5.SelectedValue;
            FAño = DropDownList6.SelectedValue;

            obj.FechaFin = Convert.ToDateTime(FDia + "-" + FMes + "-" + FAño);

            obj.Precio = Convert.ToDecimal(TextBox2.Text);
            obj.Capacidad = Convert.ToInt32(TextBox3.Text);
            obj.Estado = CheckBox1.Checked;
            
            clsCursoDAO dao = new clsCursoDAO();
            if (dao.REGISTRARCURSO(obj))
            {
                MessageBox.Show("La CATEGORIA " + obj.Nombre + " ha sido registrada corecctamente.");
                Response.Redirect("/GestionCursos/buscar.aspx");
            }
        }
    }
}