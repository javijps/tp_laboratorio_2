﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;


namespace Archivos //CHEQUEAR EN AMBOS SI EL ARCHIVO EXISTE
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
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
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
