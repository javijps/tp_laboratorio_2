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
        public List<Paquete> Paquetes 
        {
            get
            {
                return this.paquetes;
            }

            set
            {
                if (value != null)
                {
                    this.paquetes = value;
                }
            }
        }

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
            if (!(this.mockPaquetes is null))
            {
                foreach (Thread item in this.mockPaquetes)
                {
                    if (item.IsAlive)
                    {
                        item.Abort();
                    }
                }
            }
        }



        /// <summary>
        /// Metodo que hace publica la informacion de todos los paquetes existentes en la lista paquetes.
        /// </summary>
        /// <returns>Cadena que contiene la informacion</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            string cadena = String.Empty;

            if (elemento != null)
            {
                foreach (Paquete item in ((Correo)elemento).paquetes)
                {
                    cadena += String.Format("{0} para {1} {2}\n", item.TrackingID, item.DireccionEntrega, item.Estado.ToString());
                }
            }
            return cadena;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Sobrecarga del operador +. Agrega un paquete a la lista paquetes, si el mismo ya existe, arroja excepcion TrackingIdException.
        /// En caso de haber agregado el paquete a la lista, crea un hilo para el Metodo MockCicloDeVida, lo agrega a mockPaquetes y lo ejecuta.
        /// </summary>
        /// <param name="c">Objeto Correo</param>
        /// <param name="p">Objeto Paquete</param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            Thread thread = new Thread(new ThreadStart(p.MockCicloDeVida));


            if (c != null && p != null && c.paquetes != null)
            {
                foreach (Paquete item in c.paquetes)
                {
                    if (item == p)
                    {
                        throw new TrackingIdRepetidoException("Paquete existente!!");
                    }
                }

                try
                {
                    c.paquetes.Add(p);

                    c.mockPaquetes.Add(thread);

                    thread.Start();
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
            return c;
        }

        #endregion
    }
}
