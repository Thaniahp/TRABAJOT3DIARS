using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Entity
{
    public class clsCurso:clsBase
    {
        public String FechaInicio { get; set; }
        public String FechaFin { get; set; }
        public Decimal Precio { get; set; }
        public Int32 Capacidad { get; set; }
    }
}
