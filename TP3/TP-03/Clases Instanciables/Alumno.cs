using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;



namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region "Enumerados"

        /// <summary>
        /// Enumerado de Estado de Cuenta del alumno
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion

        #region "Propiedades"

        /// <summary>
        /// Propiedad publica de lectura y escritura del atributo claseQueToma      
        /// </summary>
        public Universidad.EClases ClaseQueToma
        {
            get { return this.claseQueToma; }
            set { this.claseQueToma = value; }
        }

        /// <summary>
        /// Propiedad publica de lectura y escritura del atributo estadoDeCuenta      
        /// </summary>
        public EEstadoCuenta EstadoCuenta
        {
            get { return this.estadoCuenta; }
            set { this.estadoCuenta = value; }
        }

        #endregion

        #region "Constructores"

        /// <summary>
        /// Constructor por defecto de la clase Alumno, requerido para serializacion xml.
        /// </summary>
        public Alumno()
        { }

        /// <summary>
        /// Constructor de instancia de la clase Alumno
        /// </summary>
        /// <param name="id">legajo del Universitario</param>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido  de la Persona</param>
        /// <param name="dni">dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad  de la Persona</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de instancia de la clase Alumno
        /// </summary>
        /// <param name="id">legajo del Universitario</param>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido  de la Persona</param>
        /// <param name="dni">dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad  de la Persona</param>
        /// <param name="claseQueToma">Clase que toma el alumno</param>
        /// <param name="estadoCuenta">Estado de Cuenta del alumno</param>
        public Alumno(int id,
                      string nombre,
                      string apellido,
                      string dni,
                      ENacionalidad nacionalidad,
                      Universidad.EClases claseQueToma,
                      EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region "Métodos"

        /// <summary>
        /// Metodo que sobreescribe ParticiparEnClase()
        /// </summary>
        /// <returns>Cadena con la clase que toma el alumno</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("TOMA CLASE DE: ");
            sb.AppendLine(this.claseQueToma.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Metodo que muestra todos los datos del alumno
        /// </summary>
        /// <returns>Cadena que contiene los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.Append("ESTADO DE CUENTA: ");
            sb.AppendLine(this.estadoCuenta.ToString());
            sb.Append(this.ParticiparEnClase());
            
            return sb.ToString();
        }

        /// <summary>
        /// Método que hace publicos todos los datos del alumno
        /// </summary>
        /// <returns>Cadena que contiene los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        #endregion

        #region "Sobrecarga de Operadores"

        /// <summary>
        /// Sobrecarga del operador ==. Un alumno sera igual a una clase si la toma y si su estado de cuenta es diferente a deudor
        /// </summary>
        /// <param name="a">Objeto del tipo alumno</param>
        /// <param name="clase">Universidad.Eclases</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (!(a != clase) && a.estadoCuenta != EEstadoCuenta.Deudor);//ESTA BIEN ?
        }

        /// <summary>
        /// Sobrecarga del operador !=. Un alumno sera distinto a una clase si no la toma
        /// </summary>
        /// <param name="a">Objeto del tipo alumno</param>
        /// <param name="clase">Universidad.Eclases</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }

        #endregion

    }
}
