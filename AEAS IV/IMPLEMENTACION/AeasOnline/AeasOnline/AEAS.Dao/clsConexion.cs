using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Dao
{
    public class clsConexion
    {
        public static SqlConnection GetConnection() {
            string connectionString = ConfigurationManager.ConnectionStrings["AEAS"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
        public String OBTENERCADENA()
        {
            String CADENA = "Data Source=IDEA-PC;Initial Catalog=AEAS;Integrated Security=True";
            return CADENA;
        }
    }
}
