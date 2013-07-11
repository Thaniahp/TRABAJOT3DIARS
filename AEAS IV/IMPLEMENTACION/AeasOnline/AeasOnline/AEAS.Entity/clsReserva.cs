using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Entity
{   [Serializable]
    public class clsReserva:clsBase
    {   
        public String Fecha { get; set; }
        public Decimal Total { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 IdCurso { get; set; }
        public Int32 IdEvento { get; set; }
        public Int32 IdAmbiente { get; set; }
    }
}
