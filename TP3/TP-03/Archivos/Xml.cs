using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Xml<T> //: IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            //guarda con el tostring()
            return false;
        }

        public bool Leer(string archivo, T datos) //out
        {
            return false;
        }
    }
}
