using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using AEAS.Dao;
using AEAS.AdministracionYUsuarios.ENTIDADES;

namespace AEAS.AdministracionYUsuarios.DAO
{
    public class clsParticipanteDAO
    {
        public Boolean REGISTRARPARTICIPANTE(clsUsuario entidad)
        {
            SqlConnection con = new SqlConnection();
            clsConexion Conexion = new clsConexion();
            String cadena = Conexion.OBTENERCADENA();
            con.ConnectionString = cadena;
            SqlCommand cmd = new SqlCommand("clsUsuario_Registrar_PA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramCODIGO = new SqlParameter("IdUsuario", SqlDbType.Int, 8);
            paramCODIGO.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramCODIGO);
            cmd.Parameters.AddWithValue("Usuario", entidad.Usuario);
            cmd.Parameters.AddWithValue("Pass", entidad.Pass);
            cmd.Parameters.AddWithValue("Nombre", entidad.Nombre);
            cmd.Parameters.AddWithValue("Apellidos", entidad.Apellidos);
            cmd.Parameters.AddWithValue("IdTipoUsuario", entidad.IdTipoUsuario);
            cmd.Parameters.AddWithValue("Estado", entidad.Estado);
            cmd.Parameters.AddWithValue("FechaCreacion", entidad.FechaCreacion);
            cmd.Parameters.AddWithValue("Dni", entidad.Dni);
            cmd.Parameters.AddWithValue("FechaNacimiento", entidad.FechaNacimiento);
            cmd.Parameters.AddWithValue("Telefono", entidad.Telefono);
            cmd.Parameters.AddWithValue("Celular", entidad.Celular);
            cmd.Parameters.AddWithValue("Email", entidad.Email);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            entidad.IdUsuario = (Int32)paramCODIGO.Value;
            return true;
        }
    }
}