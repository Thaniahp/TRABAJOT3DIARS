using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Entity
{
    public class clsUsuario: clsBase
    {
        public String Usuario { get; set; }
        public String Pass { get; set; }
        public String Dni { get; set; }
        public String FechaNacimiento { get; set; }
        public Int32 IdTipoUsuario { get; set; }
        public String Telefono { get; set; }
        public String Celular { get; set; }
        public String Email { get; set; }
    }
}
