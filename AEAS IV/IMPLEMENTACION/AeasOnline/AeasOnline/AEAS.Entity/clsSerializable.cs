using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Entity
{
    [Serializable]
    public class clsSerializable
    {
        public String IdReserva { get; set; }
        public String FechaInicio { get; set; }
        public String FechaFin { get; set; }
        public String FechaReserva { get; set; }
        public String Total { get; set; }
        public String IdUsuario { get; set; }
        public String IdEvento { get; set; }
        public String IdCurso { get; set; }
        public String IdAmbiente { get; set; }
        public String NombreEvento { get; set; }
        public String NombreAmbiente { get; set; }
        public String NombreCurso { get; set; }
        public String Direccion { get; set; }
    }
}
