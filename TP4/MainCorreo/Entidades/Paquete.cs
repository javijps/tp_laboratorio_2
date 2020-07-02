using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Enumerado

        public enum EEstado
        {
            Ingresado,
            EnVijae,
            Entregado
        }

        #endregion

        #region Atributos

        //MODIFICAR CON LA FIRMA DEL METODO Q VA A INVOCAR
        public delegate void DelegadoEstado();
        public event DelegadoEstado InformaEstado;

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #endregion

        #region Propiedades

        //HACER LAS VALIDACIONES?
        /// <summary>
        /// 
        /// </summary>
        public string DireccionDeEntrega { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EEstado Estado { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        public string TrackingID { get; set; }

        #endregion

        #region Métodos
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionDeEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        /// <summary>
        /// 
        /// </summary>
        public void MockCicloDeVida()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            //HACER BIEN
            return String.Format("{0} para {1}",1,2);
        }


        #endregion

        #region Operadores
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            if (String.Compare(p1.TrackingID, p2.TrackingID) != 0)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
