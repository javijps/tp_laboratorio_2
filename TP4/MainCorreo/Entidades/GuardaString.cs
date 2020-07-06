using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {

        #region Métodos

        /// <summary>
        /// Método de Extension para la clase string. Guarda el texto en un archivo txt en el escritorio de la máquina.
        /// </summary>
        /// <param name="texto">objeto string</param>
        /// <param name="archivo">nombre del archivo que sera guardado</param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nombreArchivo = String.Format(@"\{0}.txt",archivo);

            bool retorno = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(rutaEscritorio + nombreArchivo,true))
                {
                    sw.WriteLine(texto,archivo);

                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            return retorno;
        }

        #endregion
    }
}
