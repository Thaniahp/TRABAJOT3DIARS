using AEAS.Bll;
using AEAS.Entity;
using AEAS.AdministracionYUsuarios.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AeasOnline.Reservas
{
    public partial class MisReservas : System.Web.UI.Page
    {
        AEAS.AdministracionYUsuarios.ENTIDADES.clsUsuario SessionUser = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                SessionUser = (AEAS.AdministracionYUsuarios.ENTIDADES.clsUsuario)Session["Usuario"];
                if (!Page.IsPostBack)
                {
                    CargarEventosReservados();
                    CargarAmbientesReservados();
                    CargarCursosReservados();
                }
            }
            else
            {
                Response.Redirect("/General/Default.aspx");
            }
        }

        #region LoadGrids
        public void CargarEventosReservados() 
        {
            try
            {
                List<clsSerializable> lst = new List<clsSerializable>();
                DataTable dt = clsReservaBLL.Instance.ListarEventosReservados(SessionUser.IdUsuario);
                if (dt != null)
                {//R.IdReserva,R.Fecha,R.Total,R.IdUsuario,R.Estado,R.IdEvento, E.Nombre ,E.FechaInicio,E.FechaFin
                    foreach (DataRow item in dt.Rows)
                    {
                        lst.Add(new clsSerializable()
                        {
                            IdReserva = item["IdReserva"].ToString(),
                            NombreEvento = item["Nombre"].ToString(),
                            FechaReserva = item["Fecha"].ToString(),
                            Total = item["Total"].ToString(),
                            FechaInicio = item["FechaInicio"].ToString(),
                            FechaFin = item["FechaFin"].ToString(),
                            IdUsuario = item["IdUsuario"].ToString(),
                            IdEvento = item["IdEvento"].ToString()
                        });
                    }

                }
                else
                {
                }

                if (lst != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string sJSON = serializer.Serialize(lst);
                    MisEventosData.Value = sJSON.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void CargarAmbientesReservados()
        {
            try
            {
                List<clsSerializable> lst = new List<clsSerializable>();
                DataTable dt = clsReservaBLL.Instance.ListarAmbientesReservados(SessionUser.IdUsuario);
                if (dt != null)
                {//
                    foreach (DataRow item in dt.Rows)
                    {
                        lst.Add(new clsSerializable()
                        {
                            IdReserva = item["IdReserva"].ToString(),
                            NombreAmbiente = item["Nombre"].ToString(),
                            Direccion = item["Direccion"].ToString(),
                            FechaReserva = item["Fecha"].ToString(),
                            Total = item["Total"].ToString(),
                            IdUsuario = item["IdUsuario"].ToString(),
                            IdAmbiente = item["IdAmbiente"].ToString()
                        });
                    }

                }
                else
                {
                }

                if (lst != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string sJSON = serializer.Serialize(lst);
                    MisAmbientesData.Value = sJSON.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void CargarCursosReservados()
        {
            try
            {
                List<clsSerializable> lst = new List<clsSerializable>();
                DataTable dt = clsReservaBLL.Instance.ListarCursosReservados(SessionUser.IdUsuario);
                if (dt != null)
                {//,R.Total,R.IdUsuario,R.Estado,R.IdCurso, 
                    foreach (DataRow item in dt.Rows)
                    {
                        lst.Add(new clsSerializable()
                        {
                            IdReserva = item["IdReserva"].ToString(),
                            NombreCurso = item["Nombre"].ToString(),
                            FechaReserva = item["Fecha"].ToString(),
                            Total = item["Total"].ToString(),
                            FechaInicio = item["FechaInicio"].ToString(),
                            FechaFin = item["FechaFin"].ToString(),
                            IdUsuario = item["IdUsuario"].ToString(),
                            IdCurso = item["IdCurso"].ToString()
                        });
                    }

                }
                else
                {
                }

                if (lst != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    string sJSON = serializer.Serialize(lst);
                    MisCursosData.Value = sJSON.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}