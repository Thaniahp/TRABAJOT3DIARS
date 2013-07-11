using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Entity
{
    public class clsHorario:clsBase
    {
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public String Dia { get; set; }
        public Int32 TipoHorario { get; set; }
    }
}
