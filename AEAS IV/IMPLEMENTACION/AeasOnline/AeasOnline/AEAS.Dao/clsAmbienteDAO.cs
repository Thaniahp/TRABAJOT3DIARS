using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Dao
{
    public class clsAmbienteDAO
    {
        String con = clsConexion.GetConnection().ConnectionString;
        #region SINGLETON
        private static clsAmbienteDAO instance;

        public static clsAmbienteDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new clsAmbienteDAO();
                return instance;
            }
        }
        #endregion

        public DataTable ListarAmbientesActivos()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(con);
            try
            {
                SqlCommand cmd = new SqlCommand("set isolation to dirty read", connection);
                cmd.CommandText = "SELECT IDAMBIENTE,NOMBRE,PRECIO,DIRECCION,TELEFONO,CAPACIDAD FROM AMBIENTE WHERE ESTADO=1";
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

        public Boolean ActualizarEstadoAmbiente(int IdAmbiente)
        {
            Boolean exito = false;
            SqlConnection connection = new SqlConnection(con);
            try
            {
                SqlCommand cmd = new SqlCommand("set isolation to dirty read", connection);
                cmd.CommandText = "  UPDATE AMBIENTE SET ESTADO=2 WHERE IDAMBIENTE=" + IdAmbiente;
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

        public DataTable ListarAmbientesPorId(int id)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(con);
            try
            {
                SqlCommand cmd = new SqlCommand("set isolation to dirty read", connection);
                cmd.CommandText = "SELECT IDAMBIENTE,NOMBRE,PRECIO,DIRECCION,TELEFONO,"
                                + "CAPACIDAD FROM AMBIENTE WHERE IDAMBIENTE="+id;
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
