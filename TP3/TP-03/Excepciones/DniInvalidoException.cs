using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor por defecto de la clase DniInvalidoException
        /// </summary>
        public DniInvalidoException()
            : this("DNI inválido.")
        {

        }

        /// <summary>
        /// Constructor de instancia de la clase DniInvalidoException.
        /// </summary>
        /// <param name="mensaje"></param>
        public DniInvalidoException(string mensaje)
            :base(mensaje)
        {

        }

        /// <summary>
        /// Constructor de instancia de la clase DniInvalidoException.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="innerException"></param>
        public DniInvalidoException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {

        }

        /// <summary>
        /// Constructor de instancia de la clase DniInvalidoException.
        /// </summary>
        /// <param name="innerException"></param>
        public DniInvalidoException(Exception innerException)
            : base("DNI inválido.", innerException)
        {

        }


    }
}
