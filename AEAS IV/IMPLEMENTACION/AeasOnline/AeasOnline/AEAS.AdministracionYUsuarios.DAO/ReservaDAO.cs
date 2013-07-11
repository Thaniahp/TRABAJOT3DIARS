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
    public class ReservaDAO
    {
        public List<clsReserv> LISTAR(Int32 IdUsuario)
        {
            SqlConnection con = new SqlConnection();
            clsConexion Conexion = new clsConexion();
            String cadena = Conexion.OBTENERCADENA();
            con.ConnectionString = cadena;
            SqlCommand cmd = new SqlCommand("clsReserva_ListarPorUsuario_PA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
            con.Open();
            List<clsReserv> coleccion = new List<clsReserv>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                clsReserv obj = new clsReserv();
                obj.IdReserva = (Int32)dr["IdReserva"];
                obj.Fecha = (DateTime)dr["Fecha"];
                obj.Total = (Decimal)dr["Total"];
                coleccion.Add(obj);
            }
            con.Close();
            return coleccion;
        }
    }
}
