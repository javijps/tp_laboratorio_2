using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Xml<T> //: IArchivo<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            //guarda con el tostring()
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, T datos) //out
        {
            return false;
        }
    }
}
