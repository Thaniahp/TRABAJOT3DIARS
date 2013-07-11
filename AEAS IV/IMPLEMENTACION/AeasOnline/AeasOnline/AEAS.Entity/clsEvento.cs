using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Entity
{   
    [Serializable]
    public class clsEvento:clsBase
    {
        public Decimal Precio { get; set; }
        public String Direccion { get; set; }
        public String FechaInicio { get; set; }
        public String FechaFin { get; set; }
        public String  Organizador { get; set; }
        public String  Descripcion { get; set; }
        public Int32 Capacidad { get; set; }
    }
}
