using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Constructor por defecto de la clase SinProfesorException
        /// </summary>
        public SinProfesorException()
            :this("No hay profesor para la clase")
        {

        }

        /// <summary>
        /// Constructor de instancia de la clase SinProfesorException.
        /// </summary>
        /// <param name="mensaje"></param>
        public SinProfesorException(string mensaje)
            :base(mensaje)
        {

        }
    }
}
