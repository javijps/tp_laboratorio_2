using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor por defecto de la clase AlumnoRepetidoException
        /// </summary>
        public AlumnoRepetidoException()
            : this("Alumno repetido")
        {

        }

        /// <summary>
        /// Constructor de instancia de la clase AlumnoRepetidoException.
        /// </summary>
        /// <param name="mensaje"></param>
        public AlumnoRepetidoException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
