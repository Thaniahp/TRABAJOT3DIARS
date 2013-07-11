using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.AdministracionYUsuarios.ENTIDADES
{
    public class clsUsuario
    {
        public Int32 IdUsuario { get; set; }
        public String Usuario { get; set; }
        public String Pass { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public Int32 IdTipoUsuario { get; set; }
        public Boolean Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public String Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String Telefono { get; set; }
        public String Celular { get; set; }
        public String Email { get; set; }
    }
}
