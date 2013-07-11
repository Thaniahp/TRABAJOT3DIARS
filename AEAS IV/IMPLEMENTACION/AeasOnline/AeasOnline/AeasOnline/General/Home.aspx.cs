
using AEAS.AdministracionYUsuarios.ENTIDADES;
using AEAS.Bll;
using AEAS.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AeasOnline.General
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AEAS.AdministracionYUsuarios.ENTIDADES.clsUsuario objusuario = (AEAS.AdministracionYUsuarios.ENTIDADES.clsUsuario)Session["Usuario"];
            if (objusuario == null)
            {
                Response.Redirect("/General/Default.aspx");
            }
            else
            {
                LoadDataEvento();
                LoadDataCurso();
                LoadDataAmbiente();
            }
        }

        private void LoadDataEvento()
        {
            try
            {
                List<clsEvento> lst = new List<clsEvento>();
                DataTable dt = clsEventosBLL.Instance.ListarEventosActivos();
                if (dt != null)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        lst.Add(new clsEvento()
                        {
                            Id = Convert.ToInt32(item["IdEvento"].ToString()),
                            Nombre = item["Nombre"].ToString(),
                            Precio = Convert.ToDecimal(item["Precio"].ToString()),
                            Direccion = item["Direccion"].ToString(),
                            FechaInicio = item["FechaInicio"].ToString(),
                            FechaFin = item["FechaFin"].ToString(),
                            Organizador = item["Organizador"].ToString(),
                            Descripcion = item["Descripcion"].ToString()
                        });
                    }

                }
                else
                {
                    //Alert("An error ocurred while loading data");
                }

                if (lst != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string sJSON = serializer.Serialize(lst);
                    hfDataEvento.Value = sJSON.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void LoadDataAmbiente()
        {
            try
            {
                List<clsAmbiente> lst = new List<clsAmbiente>();
                DataTable dt = clsAmbienteBLL.Instance.ListarEventosActivos();
                if (dt != null)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        lst.Add(new clsAmbiente()
                        {
                            Id = Convert.ToInt32(item["IdAmbiente"].ToString()),
                            Nombre = item["Nombre"].ToString(),
                            Precio = Convert.ToDecimal(item["Precio"].ToString()),
                            Direccion = item["Direccion"].ToString(),
                            Telefono = item["Telefono"].ToString(),
                            Capacidad = Convert.ToInt32(item["Capacidad"].ToString())
                        });
                    }

                }
                else
                {
                    //Alert("An error ocurred while loading data");
                }

                if (lst != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string sJSON = serializer.Serialize(lst);
                    hfDataAmbiente.Value = sJSON.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void LoadDataCurso()
        {
            try
            {
                List<AEAS.Entity.clsCurso> lst = new List<AEAS.Entity.clsCurso>();
                DataTable dt = clsCursoBLL.Instance.ListarCursosActivos();
                if (dt != null)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        lst.Add(new AEAS.Entity.clsCurso()
                        {
                            Id = Convert.ToInt32(item["IdCurso"].ToString()),
                            Nombre = item["Nombre"].ToString(),
                            Precio = Convert.ToDecimal(item["Precio"].ToString()),
                            FechaInicio = item["FechaInicio"].ToString(),
                            FechaFin = item["FechaFin"].ToString(),
                            Capacidad = Convert.ToInt32(item["Capacidad"].ToString())

                        });
                    }

                }
                else
                {
                    //Alert("An error ocurred while loading data");
                }

                if (lst != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string sJSON = serializer.Serialize(lst);
                    hfDataCurso.Value = sJSON.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}