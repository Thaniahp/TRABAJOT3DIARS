using AEAS.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Bll
{
    public class clsAmbienteBLL
    {
        #region SINGLETON
        private static clsAmbienteBLL instance;

        public static clsAmbienteBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new clsAmbienteBLL();
                return instance;
            }
        }
        #endregion

        public DataTable ListarEventosActivos()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = clsAmbienteDAO.Instance.ListarAmbientesActivos();
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        public Boolean ActualizarEstadoAmbiente(int IdAmbiente)
        {
            bool exito = false;
            try
            {
                exito = clsAmbienteDAO.Instance.ActualizarEstadoAmbiente(IdAmbiente);
            }
            catch (Exception)
            {
                exito = false;
                throw;
            }
            return exito;
        }

        public DataTable ListarEventosPorId(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = clsAmbienteDAO.Instance.ListarAmbientesPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
    }
}
