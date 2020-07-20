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
                //agregar alguna validacion?
                if (!String.IsNullOrEmpty(value))
                {
                    this.direccionEntrega = value;
                }
                else
                {
                    throw new Exception("Direccion invalida");
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
                //agregar alguna validacion?
                if (!(String.IsNullOrEmpty(value)) &&  value.Length == 10)
                {
                    this.trackingID = value;
                }
                else
                {
                    throw new Exception("Tracking ID invalido");
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
            this.TrackingID = trackingID;
        }

        /// <summary>
        /// Método que simula el ciclo de vida de un Paquete, informa el estado del mismo durante el proceso y
        /// guarda sus datos en la base de datos.
        /// </summary>
        public void MockCicloDeVida()
        {
            EventArgs e = default;

            try
            {
                while (this.estado < EEstado.Entregado)
                {
                    //Demora de 4 segundos.
                    Thread.Sleep(4000);
                    //Pasar al siguiente estado.
                    this.estado++;
                    //Evento InformarEstado. 
                    this.InformaEstado.Invoke(this, e);
                }

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
            string datosPaquete = String.Empty;

            if (elemento != null)
            {
                Paquete p = (Paquete)elemento;

                datosPaquete = String.Format("{0} para {1}", p.TrackingID, p.DireccionEntrega);
            }
            return datosPaquete;
        }

        /// <summary>
        /// Sobrecarga del Método ToString, hace publica la informacion del paquete.
        /// </summary>
        /// <returns>Informacion del paquete</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(MostrarDatos(this));
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
            if (!(p1 is null) &&  !(p2 is null))
            {
                if (String.Compare(p1.TrackingID, p2.TrackingID) == 0)
                {
                    return true;
                }
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
