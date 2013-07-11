using AEAS.AdministracionYUsuarios.ENTIDADES;
using AEAS.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Bll
{
    public class clsUsuarioBLL
    {
        #region SINGLETON
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
        public clsUsuario LogIn(clsUsuario objUsuario)
        {
            clsUsuario objUser = new clsUsuario();
            try
            {
                objUser = clsUsuarioDAO.Instance.LogIn(objUsuario);
            }
            catch (Exception)
            {   
                throw;
            }
            return objUser;
        }
    }
}
