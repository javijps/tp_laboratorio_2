using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos

        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad publica del atributo paquetes.
        /// </summary>
        public List<Paquete> Paquetes { get; set; }

        #endregion

        #region Métodos

        /// <summary>
        /// Constructor por defecto de la clase Correo
        /// </summary>
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }

        /// <summary>
        /// Cierra todos los hilos activos de la lista correspondiente al atributo mockPaquetes.
        /// </summary>
        public void FinDeEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if(item.IsAlive)
                {
                    item.Abort();
                }
            }
        }

        /// <summary>
        /// Metodo que hace publica la informacion de .......
        /// </summary>
        /// <returns>Cadena que contiene la informacion</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            //COMO RESUELVO NO PODER USAR EL FOREACH?

            string cadena = String.Empty;

            //foreach (Paquete item in elemento)
            //{
            //    cadena += String.Format("");
            //}

            return cadena;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Sobrecarga del operador +. Agrega un paquete a la lista paquetes, si el mismo ya existe, Arroja excepcion TrackingIdException.
        /// Crea un hilo para el Metodo MockCicloDeVida, lo agrega a mockPaquetes y lo ejecuta.
        /// </summary>
        /// <param name="c">Objeto Correo</param>
        /// <param name="p">Objeto Paquete</param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.paquetes)
            {
                if (item != p)
                {
                    c.paquetes.Add(p);
                }
                else
                {
                    //reemplazar con la excepcion correspondiente
                    throw new Exception();
                }

                //PENDIENTE HILO Y MOCKCICLODEVIDAPAQUETE
            }



            return c;
        }

        #endregion
    }
}
