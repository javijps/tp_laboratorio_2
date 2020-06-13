using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public NacionalidadInvalidaException()
            : this("La nacionalidad no se condice con el número de DNI")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        public NacionalidadInvalidaException(string mensaje)
            :base(mensaje)
        {

        }
    }
}
