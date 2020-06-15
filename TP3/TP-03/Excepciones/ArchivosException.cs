using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor por defecto de la clase ArchivosException
        /// </summary>
        public ArchivosException()
            :this("Archivo Exception")
        {

        }

        /// <summary>
        /// Constructor de instancia de la clase ArchivosException.
        /// </summary>
        /// <param name="mensaje"></param>
        public ArchivosException(string mensaje)
            : base(mensaje)
        {

        }

        /// <summary>
        /// Constructor de instancia de la clase ArchivosException.
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException)
            : base("Archivo Exception", innerException)
        {

        }
    }
}
