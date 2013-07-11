using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.AdministracionYUsuarios.ENTIDADES
{
    public class clsCurso
    {
        public Int32 IdCurso { get; set; }
        public String Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Decimal Precio { get; set; }
        public Int32 Capacidad { get; set; }
        public Boolean Estado { get; set; }
    }
}
