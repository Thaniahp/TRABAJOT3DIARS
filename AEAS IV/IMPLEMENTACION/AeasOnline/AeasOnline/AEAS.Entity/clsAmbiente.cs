using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Entity
{
    public class clsAmbiente : clsBase
    {
        public String Direccion { get; set; }
        public Decimal Precio { get; set; }
        public String Telefono { get; set; }
        public Int32 Capacidad { get; set; }
    }
}