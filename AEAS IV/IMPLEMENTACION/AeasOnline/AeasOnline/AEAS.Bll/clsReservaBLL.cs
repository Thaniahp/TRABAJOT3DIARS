using AEAS.Dao;
using AEAS.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEAS.Bll
{
    public class clsReservaBLL
    {
        #region SINGLETON
        private static clsReservaBLL instance;

        public static clsReservaBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new clsReservaBLL();
                return instance;
            }
        }
        #endregion

        public Boolean IngresarReserva(clsReserva objReserva)
        {
            bool exito = false;
            try
            {
                exito = clsReservaDAO.Instance.IngresarReserva(objReserva);
            }
            catch (Exception)
            {
                exito = false;
                throw;
            }
            return exito;
        }

        public DataTable ListarEventosReservados(int IdUsuario) 
        {
            DataTable dt;
            try
            {
                dt = clsReservaDAO.Instance.ListarEventosReservados(IdUsuario);
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
        public DataTable ListarAmbientesReservados(int IdUsuario)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = clsReservaDAO.Instance.ListarAmbientesReservados(IdUsuario);
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
        public DataTable ListarCursosReservados(int IdUsuario)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = clsReservaDAO.Instance.ListarCursosReservados(IdUsuario);
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
    }
}
