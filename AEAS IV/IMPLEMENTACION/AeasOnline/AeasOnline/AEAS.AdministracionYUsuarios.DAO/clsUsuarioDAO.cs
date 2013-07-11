using AEAS.AdministracionYUsuarios.ENTIDADES;
using AEAS.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.AdministracionYUsuarios.DAO
{
    public class clsUsuarioDAO
    {   //se declara una variable global con la cadena de conexionn.
        String con = clsConexion.GetConnection().ConnectionString;
        //aqui esta el patron singleton, funciona igual que en la capa de negocio
        #region singleton
        private static clsUsuarioDAO instance;
        public static clsUsuarioDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new clsUsuarioDAO();
                return instance;
            }
        }
        #endregion  
        
        public List<clsUsuario> LISTAR()
        {
            SqlConnection con = new SqlConnection();
            clsConexion Conexion = new clsConexion();
            String cadena = Conexion.OBTENERCADENA();
            con.ConnectionString = cadena;
            SqlCommand cmd = new SqlCommand("cls_Usuario_Listar_PA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            List<clsUsuario> coleccion = new List<clsUsuario>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                clsUsuario obj = new clsUsuario();
                obj.IdUsuario = (Int32)dr["IdUsuario"];
                obj.Usuario = dr["Usuario"].ToString();
                obj.Nombre = dr["Nombres"].ToString();
                obj.Apellidos = dr["Apellidos"].ToString();
                coleccion.Add(obj);
            }
            con.Close();
            return coleccion;
        }
        
        public Boolean RegistrarSocio(clsUsuario objUsuario)
        {
            Boolean exito = false;
            SqlConnection connection = new SqlConnection(con);
            try
            {
                SqlCommand cmd = new SqlCommand("set isolation to dirty read", connection);
                //aqui se genera una cadena que contendra la consulta a la Base de datos.
                String query =  " INSERT INTO Usuario"
                                  +" ([Usuario],[Pass],[Nombres],[Apellidos],[IdTipoUsuario],[Estado]"
                                  +" ,[FechaCreacion],[Dni],[FechaNacimiento],[Telefono]"
                                  +" ,[Celular],[Email])"
                                  +" VALUES("
                                  +" '"+objUsuario.Usuario+"'"
                                  +",'"+objUsuario.Pass+"'"
                                  +",'"+objUsuario.Nombre+"'"
                                  +",'"+objUsuario.Apellidos+"'"
                                  +", "+objUsuario.IdTipoUsuario+""
                                  +", "+Convert.ToInt16(objUsuario.Estado)+""
                                  +",'"+objUsuario.FechaCreacion.ToString("yyyy-MM-dd")+"'"
                                  +",'"+objUsuario.Dni+"'"
                                  +",'"+objUsuario.FechaNacimiento.ToString("yyyy-MM-dd")+"'"
                                  +",'"+objUsuario.Telefono+"'"
                                  +",'"+objUsuario.Celular+"'"
                                  +",'"+objUsuario.Email+"' )";
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                //se abre la conexion
                connection.Open();
                //se ejecuta la conexion
                cmd.ExecuteNonQuery();
                //si todo bien, se devuelve true.
                exito = true;
            }
            catch (Exception)
            {
                //se ocurre algun error, se devuelve false.
                exito = false;
                throw;
            }
            finally
            {//finalmente se cierra la conexion a la bd.
                connection.Close();
            }
            //se devuelvo el Booleano.
            return exito;
        }
    }
}
