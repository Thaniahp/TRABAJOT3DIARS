using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using AEAS.AdministracionYUsuarios.ENTIDADES;
using AEAS.Dao;
using AEAS.Entity;

namespace AEAS.AdministracionYUsuarios.DAO
{
    public class clsPagoDAO
    {
        public Boolean REGPAGO(Int32 IdReserva)
        {
            SqlConnection con = new SqlConnection();
            clsConexion Conexion = new clsConexion();
            String cadena = Conexion.OBTENERCADENA();
            con.ConnectionString = cadena;
            SqlCommand cmd = new SqlCommand("clsPago_Registrar_PA", con);//invocando al procedimiento almacenado
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramCODIGO = new SqlParameter("IdPago", SqlDbType.Int, 8);
            paramCODIGO.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paramCODIGO);
            cmd.Parameters.AddWithValue("IdReserva", IdReserva);
            con.Open();
            cmd.ExecuteNonQuery();//devuelve la ejecucion del procedimiento almacenado
            con.Close();
            Int32 IdCurso = (Int32)paramCODIGO.Value;
            return true;
        }
    }
}
