using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        #region Métodos

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool Insertar()
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        static PaqueteDAO()
        {
            //poner cadena correcta
            PaqueteDAO.conexion = new SqlConnection("");
        }

        #endregion
    }
}
