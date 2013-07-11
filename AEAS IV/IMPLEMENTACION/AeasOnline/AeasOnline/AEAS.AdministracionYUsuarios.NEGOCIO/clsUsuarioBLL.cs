using AEAS.AdministracionYUsuarios.DAO;
using AEAS.AdministracionYUsuarios.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.AdministracionYUsuarios.NEGOCIO
{
    public class clsUsuarioBLL
    {
        //se usa el patron de dise;o SINGLETON, es para no tener que instanciar a cada rato esta clase.
        //ejemplo de uso: clsUsuarioBLL.Instance.[la funcion que hayas creado]
        //                clsUsuarioBLL.Instance.RegistrarSocio(parametro);
        #region singleton
        private static clsUsuarioBLL instance;
        public static clsUsuarioBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new clsUsuarioBLL();
                return instance;
            }
        }
        #endregion  
        //metodo de la capa de negocio para registrar un usuario, el parametro que se le envia es el objeto usuario.
        public Boolean RegistrarSocio(clsUsuario objUsuario)
        {//se devolvera un verdadero o falso.
            bool ok = false;
            //examinamos que la data que se envia este llena
            if(objUsuario!=null)
            {//llamamos a la clase DAO para interactuar con la Base de datos.
                ok = clsUsuarioDAO.Instance.RegistrarSocio(objUsuario); 
            }
            return ok;
        }

    }
}
