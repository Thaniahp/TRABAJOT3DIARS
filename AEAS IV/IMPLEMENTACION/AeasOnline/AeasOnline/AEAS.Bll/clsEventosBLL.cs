using AEAS.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Bll
{
    public class clsEventosBLL
    {
        #region SINGLETON
        private static clsEventosBLL instance;

        public static clsEventosBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new clsEventosBLL();
                return instance;
            }
        }
        #endregion

        public DataTable ListarEventosActivos() {
            DataTable dt= new DataTable();
            try
            {
                dt=clsEventosDAO.Instance.ListarEventosActivos();
            }
            catch (Exception)
            {   
                throw;
            }
            return dt;
        }
        public Boolean ActualizarCapacidadEvento(int IdEvento) {
            bool exito = false;
            try
            {
                exito = clsEventosDAO.Instance.ActualizarCapacidadEvento(IdEvento);
            }
            catch (Exception)
            {
                exito = false;
                throw;
            }
            return exito;
        }
        public DataTable ListarEventoPorId(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = clsEventosDAO.Instance.ListarEventoPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
    }
}
