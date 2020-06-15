using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;
using System.IO;


namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Implementacion de metodo Guardar() de la interfaz IArchivo<T>. Serializa Xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si serializo exitosamente</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo,Encoding.Default))
                {
                    XmlSerializer ser = new XmlSerializer((typeof(T)));
                    ser.Serialize(writer, datos);
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }

        /// <summary>
        /// Implementacion de metodo Leer() de la interfaz IArchivo<T>. . Deserializa Xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si deserializo exitosamente</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer((typeof(T)));

                    datos = (T) ser.Deserialize(reader);
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
