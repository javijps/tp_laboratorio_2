using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        public delegate void DelegadoExcepcionDAO(string msg, Exception e);
        public static event DelegadoExcepcionDAO ExcepcionDAO;

        private static SqlCommand comando;
        private static SqlConnection conexion;

        #region Métodos

        /// <summary>
        /// Constructor de clase PaqueteDAO. Instaancia el atributo estatico conexion, con la cadena correspondiente.
        /// </summary>
        static PaqueteDAO()
        {
//            PaqueteDAO.conexion = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;");

            PaqueteDAO.conexion = new SqlConnection(@"Server=localhost\lnkl;Database=xxx;Trusted_Connection=True;");
        }

        /// <summary>
        /// Método que inserta un nuevo registro en la base de datos
        /// </summary>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;

            string sql = "INSERT INTO [correo-sp-2017].[dbo].[Paquetes] (direccionEntrega, trackingID, alumno) ";
            sql += "VALUES (@direccionEntrega, @trackingID, @alumno)";

            try
            {
                PaqueteDAO.comando = new SqlCommand();

                PaqueteDAO.comando.CommandType = CommandType.Text;

                PaqueteDAO.comando.Connection = PaqueteDAO.conexion;

                PaqueteDAO.comando.Parameters.AddWithValue("@direccionEntrega", p.DireccionEntrega);
                PaqueteDAO.comando.Parameters.AddWithValue("@trackingID", p.TrackingID);
                PaqueteDAO.comando.Parameters.AddWithValue("@alumno", "Scalise Javier");
                
                PaqueteDAO.comando.CommandText = sql;

                PaqueteDAO.conexion.Open();

                PaqueteDAO.comando.ExecuteNonQuery();

                
                retorno = true;

            }
            catch(Exception e)
            {
                PaqueteDAO.ExcepcionDAO.Invoke(e.Message, e);
            }
            finally
            {
                if(PaqueteDAO.conexion.State == ConnectionState.Open)
                {
                    PaqueteDAO.conexion.Close();
                }
            }

            return retorno;
        }

        #endregion
    }
}
