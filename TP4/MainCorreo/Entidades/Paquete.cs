using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Enumerado

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        #endregion

        #region Atributos

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #endregion

        #region Propiedades

        //HACER LAS VALIDACIONES?

        /// <summary>
        /// Propiedad publica de lectura y escritura del atributo DireccionEntrega
        /// </summary>
        public string DireccionEntrega 
        {
            get 
            { 
                return this.direccionEntrega; 
            }
            set 
            {
                if (value != null)
                {
                    this.direccionEntrega = value;
                }
            } 
        }

        /// <summary>
        /// Propiedad publica de lectura y escritura del atributo estado.
        /// </summary>
        public EEstado Estado 
        {
            get 
            {
                return this.estado; 
            }

            set 
            {
                this.estado = value;
            } 
        }

        /// <summary>
        /// Propiedad publica de lectura y escritura del atributo Tracking ID.
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }

            set
            {
                if (trackingID != null)
                {
                    this.trackingID = value;
                }
            }
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Constructor de instancia de la clase Paquete
        /// </summary>
        /// <param name="direccionEntrega">cadena que contiene la direccion de entrega del paquete</param>
        /// <param name="trackingID">numero de rastreo del paquete</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        /// <summary>
        /// Método que simula el ciclo de vida de un Paquete, informa el estado del mismo durante el proceso y
        /// guarda sus datos en la base de datos.
        /// </summary>
        public void MockCicloDeVida()
        {
            EventArgs e = default;

            while (this.estado <= EEstado.Entregado)
            {
                    //Demora de 4 segundos.
                    Thread.Sleep(4000);
                    //Pasar al siguiente estado.
                    this.estado++;
                    //Evento InformarEstado. 
                    this.InformaEstado.Invoke(this, e);
            }

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        /// <summary>
        /// Metodo a implementar de la interfaz IMostrar. 
        /// </summary>
        /// <param name="elemento">Objeto del tipo IMostrar<Paquete></param>
        /// <returns>Retorna una cadena con el tracking Id y direccion de entrega del paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;

            return String.Format("{0} para {1}",p.TrackingID, p.DireccionEntrega);
        }

        /// <summary>
        /// Sobrecarga del Método ToString, hace publica la informacion del paquete.
        /// </summary>
        /// <returns>Informacion del paquete</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(MostrarDatos(this));
            sb.AppendFormat(" ({0})", this.estado.ToString());

            return sb.ToString();
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Sobrecarga del Operador ==, Dos paquetes seran iguales si tienen el mismo tracking ID.
        /// </summary>
        /// <param name="p1">Objeto de la clase Paquete</param>
        /// <param name="p2">Objeto de la clase Paquete</param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (String.Compare(p1.TrackingID, p2.TrackingID) == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga del Operador !=, Dos paquetes seran distintos si no tienen el mismo tracking ID. 
        /// </summary>
        /// <param name="p1">Objeto de la clase Paquete</param>
        /// <param name="p2">Objeto de la clase Paquete</param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        #endregion
    }
}
