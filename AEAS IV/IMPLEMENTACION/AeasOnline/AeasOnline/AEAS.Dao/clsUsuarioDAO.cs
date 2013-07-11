using AEAS.AdministracionYUsuarios.ENTIDADES;
//using AEAS.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Dao
{
    public class clsUsuarioDAO
    {
        String con = clsConexion.GetConnection().ConnectionString;

        #region SINGLETON
        private static clsUsuarioDAO instance;

        public static clsUsuarioDAO Instance {
            get {
                if (instance == null)
                    instance = new clsUsuarioDAO();
                return instance;
            }
        }
        #endregion

        public clsUsuario LogIn(clsUsuario objUsuario)
        {
            clsUsuario objUser = null; 
            SqlConnection connection = new SqlConnection(con);
            try
            {
                SqlCommand cmd = new SqlCommand("set isolation to dirty read", connection);
                cmd.CommandText = "SELECT IDUSUARIO,USUARIO,NOMBRES,APELLIDOS,IDTIPOUSUARIO FROM USUARIO WHERE USUARIO='" + objUsuario.Usuario +
                                "' AND PASS='" + objUsuario.Pass + "' AND ESTADO=1";
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    objUser = new clsUsuario();
                    objUser.IdUsuario = Convert.ToInt32(dr["IDUSUARIO"]);
                    objUser.Usuario = dr["USUARIO"].ToString();
                    objUser.Nombre = dr["NOMBRES"].ToString();
                    objUser.Apellidos = dr["APELLIDOS"].ToString();
                    objUser.IdTipoUsuario = Convert.ToInt32(dr["IDTIPOUSUARIO"]);
                }
            }
            catch (Exception)
            {
                objUser = null; 
                throw;
            }
            finally {
                connection.Close();
            }
            return objUser;
        }
    }
}
