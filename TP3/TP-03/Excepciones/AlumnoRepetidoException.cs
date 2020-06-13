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
        /// 
        /// </summary>
        public AlumnoRepetidoException()
            : this("Alumno repetido")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        public AlumnoRepetidoException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
