using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Metodo de interfaz para guardado de datos de tipo T
        /// </summary>
        /// <param name="archivo">Cadena con la ruta del archivo</param>
        /// <param name="datos">Objeto de tipo T</param>
        /// <returns> true o false</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Metodo de interfaz para lectura de datos T
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true o false</returns>
        bool Leer(string archivo, out T datos);
    }
}
