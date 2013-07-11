using AEAS.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Dao
{
    public class clsReservaDAO
    {
        String con = clsConexion.GetConnection().ConnectionString;
        #region singleton
        private static clsReservaDAO instance;
        public static clsReservaDAO Instance {
            get {
                if (instance == null)
                    instance = new clsReservaDAO();
                return instance;
            }
        }
        #endregion  
        public Boolean IngresarReserva(clsReserva objReserva)
        {
            Boolean exito = false;
            SqlConnection connection = new SqlConnection(con);
            try
            {
                SqlCommand cmd = new SqlCommand("set isolation to dirty read", connection);
                cmd.CommandText = " INSERT INTO RESERVA(TOTAL,IDUSUARIO,ESTADO,IDEVENTO,IDCURSO,IDAMBIENTE)"
                                 + " VALUES(" + objReserva.Total + "," + objReserva.IdUsuario + ",1," + objReserva.IdEvento + "," + objReserva.IdCurso + "," + objReserva.IdAmbiente + ")";
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
            finally { 
                connection.Close();
            }
            return exito;
        }
        public DataTable ListarEventosReservados(int IdUsuario)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(con);
            try
            {
                SqlCommand cmd = new SqlCommand("set isolation to dirty read", connection);
                cmd.CommandText = "select R.IdReserva,R.Fecha,R.Total,R.IdUsuario,R.Estado,R.IdEvento, E.Nombre ,E.FechaInicio,E.FechaFin"
                                    +" from Reserva R JOIN Evento E ON(E.IdEvento=R.IdEvento) WHERE E.Estado=1 AND R.IdUsuario="+IdUsuario;
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
        public DataTable ListarAmbientesReservados(int IdUsuario)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(con);
            try
            {
                SqlCommand cmd = new SqlCommand("set isolation to dirty read", connection);
                cmd.CommandText = "select R.IdReserva,R.Fecha,R.Total,R.IdUsuario,R.Estado,R.IdAmbiente, A.Nombre ,A.Direccion"
                                + " from Reserva R JOIN Ambiente A ON(A.IdAmbiente=R.IdAmbiente) WHERE A.Estado=2 AND R.IdUsuario=" + IdUsuario;
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
        public DataTable ListarCursosReservados(int IdUsuario)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(con);
            try
            {
                SqlCommand cmd = new SqlCommand("set isolation to dirty read", connection);
                cmd.CommandText = "select R.IdReserva,R.Fecha,R.Total,R.IdUsuario,R.Estado,R.IdCurso, C.Nombre ,C.FechaInicio,C.FechaFin"
                                + " from Reserva R JOIN Curso C ON(C.IdCurso=R.IdCurso) WHERE C.Estado=1 AND R.IdUsuario=" + IdUsuario;
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
