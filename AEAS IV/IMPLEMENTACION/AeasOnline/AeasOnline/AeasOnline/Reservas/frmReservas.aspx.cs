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
    public partial class frmReservas : System.Web.UI.Page
    {
        AEAS.AdministracionYUsuarios.ENTIDADES.clsUsuario SessionUser = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                SessionUser = (AEAS.AdministracionYUsuarios.ENTIDADES.clsUsuario)Session["Usuario"];
                if (!Page.IsPostBack) {
                
                    
                    CargarEventosActivos();
                    CargarAmbientesActivos();
                    CargarCursosActivos();
                }
            }else {
                Response.Redirect("/General/Default.aspx");
            }
        }
        #region LoadGrids
        private void CargarEventosActivos()
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
                            Id= Convert.ToInt32(item["IdEvento"].ToString()),
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
                    EventosData.Value = sJSON.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarAmbientesActivos()
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
                    AmbientesData.Value = sJSON.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CargarCursosActivos()
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
                    CursosData.Value = sJSON.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        protected void lbtn_reservar_evento_Click(object sender, EventArgs e)
        {
            String a = ListaEventosReservados.Value;
            bool ok = false;
            clsReserva objReserva = null;
            if (!String.IsNullOrEmpty(a))
            {
                String[] Reservas = a.Split(' ');
                foreach (String r in Reservas)
                {
                    if (r != "") {
                        objReserva = new clsReserva();
                        string[] data = r.Split('/');
                        objReserva.Total = Convert.ToDecimal(data[1]);
                        objReserva.IdEvento = Convert.ToInt32(data[0]);
                        objReserva.IdUsuario = SessionUser.IdUsuario;
                        ok = clsReservaBLL.Instance.IngresarReserva(objReserva);
                        if (ok) {
                            ok = clsEventosBLL.Instance.ActualizarCapacidadEvento(Convert.ToInt32(data[0]));
                        }
                    }
                    
                }
                if (ok)
                {
                    lblMensajeEvento.Text = "Haz realizado tus reservas con exito";
                }
                else {
                    lblMensajeEvento.Text = "Ha ocurrido un error al realizar tu Reserva";
                }
            }
            
        }

        protected void lbtn_reservar_ambiente_Click(object sender, EventArgs e)
        {
            String a = ListaAmbientesReservados.Value;
            bool ok = false;
            clsReserva objReserva = null;
            if (!String.IsNullOrEmpty(a))
            {
                String[] Reservas = a.Split(' ');
                foreach (String r in Reservas)
                {
                    if (r != "")
                    {
                        objReserva = new clsReserva();
                        string[] data = r.Split('/');
                        objReserva.Total = Convert.ToDecimal(data[1]);
                        objReserva.IdAmbiente = Convert.ToInt32(data[0]);
                        objReserva.IdUsuario = SessionUser.IdUsuario;
                        ok = clsReservaBLL.Instance.IngresarReserva(objReserva);
                        if (ok)
                        {
                            ok = clsAmbienteBLL.Instance.ActualizarEstadoAmbiente(Convert.ToInt32(data[0]));
                        }
                    }

                }
                if (ok)
                {
                    lblMensajeAmbiente.Text = "Haz realizado tus reservas con exito";
                }
                else
                {
                    lblMensajeAmbiente.Text = "Ha ocurrido un error al realizar tu Reserva";
                }
            }
        }

        protected void lbtn_reservar_cursos_Click(object sender, EventArgs e)
        {
            String a = ListaCursosReservados.Value;
            bool ok = false;
            clsReserva objReserva = null;
            if (!String.IsNullOrEmpty(a))
            {
                String[] Reservas = a.Split(' ');
                foreach (String r in Reservas)
                {
                    if (r != "")
                    {
                        objReserva = new clsReserva();
                        string[] data = r.Split('/');
                        objReserva.Total = Convert.ToDecimal(data[1]);
                        objReserva.IdCurso = Convert.ToInt32(data[0]);
                        objReserva.IdUsuario = SessionUser.IdUsuario;
                        ok = clsReservaBLL.Instance.IngresarReserva(objReserva);
                        if (ok)
                        {
                            ok = clsCursoBLL.Instance.ActualizarCapacidadCurso(Convert.ToInt32(data[0]));
                        }
                    }

                }
                if (ok)
                {
                    lblMensajeCurso.Text = "Haz realizado tus reservas con exito";
                }
                else
                {
                    lblMensajeCurso.Text = "Ha ocurrido un error al realizar tu Reserva";
                }
            }
        }
    }
}