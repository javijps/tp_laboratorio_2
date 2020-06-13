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
        /// 
        /// </summary>
        public ArchivosException()
            :this("Archivo Exception")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        public ArchivosException(string mensaje)
            : base(mensaje)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException)
            : base("Archivo Exception", innerException)
        {

        }
    }
}
