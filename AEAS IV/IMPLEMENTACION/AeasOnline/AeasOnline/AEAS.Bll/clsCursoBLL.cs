using AEAS.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Bll
{
    public class clsCursoBLL
    {
        #region SINGLETON
        private static clsCursoBLL instance;

        public static clsCursoBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new clsCursoBLL();
                return instance;
            }
        }
        #endregion

        public DataTable ListarCursosActivos()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = clsCursoDAO.Instance.ListarCursosActivos();
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        public Boolean ActualizarCapacidadCurso(int IdCurso)
        {
            bool exito = false;
            try
            {
                exito = clsCursoDAO.Instance.ActualizarCapacidadCurso(IdCurso);
            }
            catch (Exception)
            {
                exito = false;
                throw;
            }
            return exito;
        }

        public DataTable ListarCursosPorId(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = clsCursoDAO.Instance.ListarCursosPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
    }
}
