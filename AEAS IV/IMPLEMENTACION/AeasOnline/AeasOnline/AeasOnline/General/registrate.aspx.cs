using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using AEAS.AdministracionYUsuarios.DAO;

using AEAS.AdministracionYUsuarios.NEGOCIO;
using AEAS.AdministracionYUsuarios.ENTIDADES;
using System.Globalization;


namespace AeasOnline.General
{
    public partial class registrate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {//ocultamos el boton de inicio de sesion hasta que el usuario tenga un registro correcto.
            lbtnRedirect.Visible = false;
        }

        protected void lbtnRegistro_Click(object sender, EventArgs e)
        {// aqui se almacena la data del formulario en el objeto usuario.
            if (!String.IsNullOrEmpty(txtUsername.Text) && !String.IsNullOrEmpty(txtpass.Text)
                && !String.IsNullOrEmpty(txtnombre.Text) && !String.IsNullOrEmpty(txtapellido.Text)
                && !String.IsNullOrEmpty(txtdni.Text) && !String.IsNullOrEmpty(txttelefono.Text)
                && !String.IsNullOrEmpty(txtcel.Text) && !String.IsNullOrEmpty(txtemail.Text)
                && !String.IsNullOrEmpty(txtxfechaNacimiento.Text))
            {
                clsUsuario obj = new clsUsuario();
                obj.Usuario = txtUsername.Text;
                obj.Pass = txtpass.Text;
                obj.Nombre = txtnombre.Text;
                obj.Apellidos = txtapellido.Text;
                obj.IdTipoUsuario = 2;//es para socios, 1 es para admin
                obj.Estado = true;
                obj.FechaCreacion = DateTime.Now;//esto le da formato a la fecha para que sea admitida por la BD
                obj.Dni = txtdni.Text;
                obj.Telefono = txttelefono.Text;
                obj.Celular = txtcel.Text;
                obj.Email = txtemail.Text;
                obj.FechaNacimiento = DateTime.ParseExact(txtxfechaNacimiento.Text, "d", CultureInfo.InvariantCulture);

                if (clsUsuarioBLL.Instance.RegistrarSocio(obj))//aqui se llama a la capa de negocio y se envia el objeto usuario como parametro
                {//si la respuesta de la capa de negocio fue correcta, entonces mostramos el boton de inicio de sesion y le decimos al usuario que se ha registrado bien.
                    lbtnRedirect.Visible = true;
                    lblOk.Text = "Se ha registrado correctamente, ahora puede ";
                }
                else
                {// caso contrario se le notifica que ha ocurrido un error en la creacion de su cuenta.
                    lbtnRedirect.Visible = false;
                    lblError.Text = "Ha ocurrido un error";
                }
            }
            else 
            {
                lbtnRedirect.Visible = false;
                lblError.Text = "Debe llenar todos los campos del formulario";
            }
                
            
        }
        // este es el boton para que cuando se registre bien le permita ir al inicio de sesion.
        protected void lbtnRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

    }
}