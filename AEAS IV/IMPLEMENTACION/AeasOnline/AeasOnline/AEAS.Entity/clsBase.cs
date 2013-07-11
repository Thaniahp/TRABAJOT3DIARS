using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Entity
{
    public class clsBase// esta clase tiene datos generales que se usan en la herencia para las demas clases
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public String  Apellidos { get; set; }
        public int Estado { get; set; }
        public String FechaCreacion { get; set; }
        public String FechaModificacion { get; set; }
    }
}
