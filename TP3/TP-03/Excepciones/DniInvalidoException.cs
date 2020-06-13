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
        /// 
        /// </summary>
        public DniInvalidoException()
            : this("DNI inválido.")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        public DniInvalidoException(string mensaje)
            :base(mensaje)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="innerException"></param>
        public DniInvalidoException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="innerException"></param>
        public DniInvalidoException(Exception innerException)
            : base("DNI inválido.", innerException)
        {

        }


    }
}
