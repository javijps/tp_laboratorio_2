﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor por defecto de la clase NacionalidadInvalidaException
        /// </summary>
        public NacionalidadInvalidaException()
            : this("La nacionalidad no se condice con el número de DNI")
        {

        }

        /// <summary>
        /// Constructor de instancia de la clase NacionalidadInvalidaException.
        /// </summary>
        /// <param name="mensaje"></param>
        public NacionalidadInvalidaException(string mensaje)
            :base(mensaje)
        {

        }
    }
}
