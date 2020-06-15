using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace EntidadesAbstractas
{

    public abstract class Universitario : Persona 
    {

        private int legajo;

        #region "Propiedades"
        /// <summary>
        /// Propiedad publica de lectura y escritura del atributo legajo      
        /// </summary>
        public int Legajo
        {
            get { return this.legajo; }
            set { this.legajo = value; }
        }

        #endregion

        #region "Constructores"

        /// <summary>
        /// Constructor por defecto de la clase Universitario, requerido para serializacion xml.
        /// </summary>
        public Universitario() { }

        /// <summary>
        /// Constructor de instancia de la clase Universitario
        /// </summary>
        /// <param name="legajo">legajo del Universitario</param>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido  de la Persona</param>
        /// <param name="dni">dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad  de la Persona</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this.Legajo = legajo;
        }

        #endregion

        #region "Métodos"

        /// <summary>
        /// Método Abstracto y protegido.
        /// </summary>
        /// <returns>string</returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Método protegido y virtual que devuelve una cadena con todos los datos de Universitario.
        /// </summary>
        /// <returns>Cadena con todos los datos de Persona</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.Append("LEGAJO NÚMERO: ");
            sb.Append(this.Legajo.ToString());
            sb.AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del metodo Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public override bool Equals(object obj)
        {
            bool rta = false;

            if (obj is Universitario)
            {
                rta = this == ((Universitario)obj);
            }
            return rta;
        }


        #endregion

        #region "Sobrecarga de Operadores"

        /// <summary>
        /// Sobrecarga del operador ==
        /// </summary>
        /// <param name="pg1">Objeto del tipo Universitario</param>
        /// <param name="pg2">Objeto del tipo Universitario</param>
        /// <returns>True en caso de que los objetos sean del mismo tipo y tengan mismo dni o legajo, false en caso contrario</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.GetType() == pg2.GetType()) && (pg1.Legajo == pg2.Legajo || pg1.DNI == pg2.DNI);
        }

        /// <summary>
        /// Sobrecarga del operador !=
        /// </summary>
        /// <param name="pg1">Objeto del tipo Universitario</param>
        /// <param name="pg2">Objeto del tipo Universitario</param>
        /// <returns>True en caso de desigualdad, false en caso contrario</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

    }
}

