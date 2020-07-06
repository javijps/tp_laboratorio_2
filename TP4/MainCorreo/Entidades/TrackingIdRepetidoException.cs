using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        #region Constructores

        /// <summary>
        /// Constructor de instancia de la clase TrackingIdRepetidoException
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar en caso de lanzarse la excpecion</param>
        public TrackingIdRepetidoException(string mensaje)
            :base(mensaje)
        {

        }

        /// <summary>
        /// Constructor de instancia de la clase TrackingIdRepetidoException
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar en caso de lanzarse la excpecion</param>
        /// <param name="innerException">Excepcion interna</param>
        public TrackingIdRepetidoException(string mensaje, Exception innerException)
            : base(mensaje)
        {

        }

        #endregion
    }
}
