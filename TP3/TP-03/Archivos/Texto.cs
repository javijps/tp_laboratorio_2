using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Implementacion de metodo Guardar() de la interfaz IArchivo<T>. Guarda archivos de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si logro guardar exitosamente</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo,false))
                {
                    sw.Write(datos.ToString());
                }

            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return true;
        }

        /// <summary>
        /// Implementacion de metodo Guardar() de la interfaz IArchivo<T>. Lee archivos de texto.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si logro leer exitosamente</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }
    }
}
