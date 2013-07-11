using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Dao
{
    public class clsCursoDAO
    {
        String con = clsConexion.GetConnection().ConnectionString;
        #region SINGLETON
        private static clsCursoDAO instance;

        public static clsCursoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new clsCursoDAO();
                return instance;
            }
        }
        #endregion
        public DataTable ListarCursosActivos()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(con);
            try
            {
                SqlCommand cmd = new SqlCommand("set isolation to dirty read", connection);
                cmd.CommandText = "SELECT IDCURSO,NOMBRE,PRECIO,FECHAINICIO,FECHAFIN,CAPACIDAD FROM CURSO WHERE ESTADO=1";
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

        public Boolean ActualizarCapacidadCurso(int IdCurso)
        {
            Boolean exito = false;
            SqlConnection connection = new SqlConnection(con);
            try
            {
                SqlCommand cmd = new SqlCommand("set isolation to dirty read", connection);
                cmd.CommandText = "  UPDATE CURSO SET CAPACIDAD=CAPACIDAD-1 WHERE IdCurso=" + IdCurso;
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

        public DataTable ListarCursosPorId(int id)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(con);
            try
            {
                SqlCommand cmd = new SqlCommand("set isolation to dirty read", connection);
                cmd.CommandText = "SELECT IDCURSO,NOMBRE,PRECIO,FECHAINICIO,FECHAFIN,CAPACIDAD "
                                + "FROM CURSO WHERE IDCURSO="+id;
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
