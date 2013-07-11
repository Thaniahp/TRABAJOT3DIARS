using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Dao
{
    public class clsEventosDAO
    {
        String con = clsConexion.GetConnection().ConnectionString;
        #region SINGLETON
        private static clsEventosDAO instance;

        public static clsEventosDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new clsEventosDAO();
                return instance;
            }
        }
        #endregion
        public DataTable ListarEventosActivos() {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(con);
            try
            {
                SqlCommand cmd = new SqlCommand("set isolation to dirty read", connection);
                cmd.CommandText = "SELECT IDEVENTO,NOMBRE,PRECIO,DIRECCION,FECHAINICIO,FECHAFIN,ORGANIZADOR,DESCRIPCION,CAPACIDAD FROM EVENTO WHERE ESTADO=1 AND CAPACIDAD>0";
                cmd.CommandType = CommandType.Text;
                connection.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception)
            {   
                throw;
            }
            return dt;
        }
        public Boolean ActualizarCapacidadEvento(int IdEvento) 
        {
            Boolean exito = false;
            SqlConnection connection = new SqlConnection(con);
            try
            {
                SqlCommand cmd = new SqlCommand("set isolation to dirty read", connection);
                cmd.CommandText = "  UPDATE EVENTO SET CAPACIDAD=CAPACIDAD-1 WHERE IdEvento=" + IdEvento;
                cmd.CommandType = CommandType.Text;
                connection.Open();
                cmd.ExecuteNonQuery();
                exito = true;
            }
            catch (Exception)
            {
                exito = false;
                throw;
            }
            finally
            {
                connection.Close();
            }
            return exito;
        }
        public DataTable ListarEventoPorId(int id)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(con);
            try
            {
                SqlCommand cmd = new SqlCommand("set isolation to dirty read", connection);
                cmd.CommandText = "SELECT IDEVENTO,NOMBRE,PRECIO,DIRECCION,FECHAINICIO,"
                                + "FECHAFIN,ORGANIZADOR,DESCRIPCION,CAPACIDAD FROM EVENTO "
                                + "WHERE IDEVENTO="+id;
                cmd.CommandType = CommandType.Text;
                connection.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
    }
}
