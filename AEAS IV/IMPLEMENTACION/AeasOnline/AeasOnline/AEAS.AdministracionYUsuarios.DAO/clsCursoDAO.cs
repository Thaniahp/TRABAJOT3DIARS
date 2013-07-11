using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using AEAS.AdministracionYUsuarios.ENTIDADES;
using AEAS.Dao;

namespace AEAS.AdministracionYUsuarios.DAO
{
    public class clsCursoDAO
    {
        public Boolean REGISTRARCURSO(clsCurso entidad)
        {
            SqlConnection con = new SqlConnection();
            clsConexion Conexion = new clsConexion();
            String cadena = Conexion.OBTENERCADENA();
            con.ConnectionString = cadena;
            SqlCommand cmd = new SqlCommand("clsCurso_Registrar_PA", con);//invocando al procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramCODIGO = new SqlParameter("IdCurso", SqlDbType.Int, 8);
            paramCODIGO.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramCODIGO);
            cmd.Parameters.AddWithValue("Nombre", entidad.Nombre);
            cmd.Parameters.AddWithValue("FechaInicio", entidad.FechaInicio);
            cmd.Parameters.AddWithValue("FechaFin", entidad.FechaFin);
            cmd.Parameters.AddWithValue("Precio", entidad.Precio);
            cmd.Parameters.AddWithValue("Capacidad", entidad.Capacidad);
            cmd.Parameters.AddWithValue("Estado", entidad.Estado);
            con.Open();
            cmd.ExecuteNonQuery();//devuelve la ejecucion del procedimiento almacenado
            con.Close();
            entidad.IdCurso = (Int32)paramCODIGO.Value;
            return true;
        }

        public clsCurso OBTENERPORID(Int32 IdCurso)
        {
            SqlConnection con = new SqlConnection();
            clsConexion Conexion = new clsConexion();
            String cadena = Conexion.OBTENERCADENA();
            con.ConnectionString = cadena;
            SqlCommand cmd = new SqlCommand("clsCurso_ObtenerPorId_PA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("IdCurso", IdCurso);
            con.Open();
            clsCurso obj = new clsCurso();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                obj.IdCurso = (Int32)dr["IdCurso"];
                obj.Nombre = dr["Nombre"].ToString();
                obj.FechaInicio = (DateTime)dr["FechaInicio"];
                obj.FechaFin = (DateTime)dr["FechaFin"];
                obj.Precio = (Decimal)dr["Precio"];
                obj.Capacidad = (Int32)dr["Capacidad"];
                obj.Estado = (Boolean)dr["Estado"];
            }
            con.Close();
            return obj;
        }

        public Boolean ACTUALIZARNOMBRE(clsCurso entidad)
        {
            SqlConnection con = new SqlConnection(); ;
            clsConexion Conexion = new clsConexion();
            String cadena = Conexion.OBTENERCADENA();
            con.ConnectionString = cadena;
            SqlCommand cmd = new SqlCommand("clsCurso_ActualizarNombre_PA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("IdCurso", entidad.IdCurso);
            cmd.Parameters.AddWithValue("Nombre", entidad.Nombre);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public Boolean ELIMINARCURSO(clsCurso entidad)
        {
            SqlConnection con = new SqlConnection();
            clsConexion Conexion = new clsConexion();
            String cadena = Conexion.OBTENERCADENA();
            con.ConnectionString = cadena;
            SqlCommand cmd = new SqlCommand("clsCurso_Eliminar_PA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("IdCurso", entidad.IdCurso);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public List<clsCurso> OBTENERPORDESCRIPCION(String Descripcion)
        {
            SqlConnection con = new SqlConnection();
            clsConexion Conexion = new clsConexion();
            String cadena = Conexion.OBTENERCADENA();
            con.ConnectionString = cadena;
            SqlCommand cmd = new SqlCommand("clsCurso_ObtenerPorDescripcion_PA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Nombre", Descripcion);
            con.Open();
            List<clsCurso> coleccion = new List<clsCurso>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                clsCurso obj = new clsCurso();
                obj.IdCurso = (Int32)dr["IdCurso"];
                obj.Nombre = dr["Nombre"].ToString();
                obj.FechaInicio = (DateTime)dr["FechaInicio"];
                obj.FechaFin=(DateTime)dr["FechaFin"];
                obj.Precio=(Decimal)dr["Precio"];
                obj.Capacidad = (Int32)dr["Capacidad"];
                obj.Estado = (Boolean)dr["Estado"];
                coleccion.Add(obj);
            }
            con.Close();
            return coleccion;
        }
    }
}