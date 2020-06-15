using Excepciones;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        #region "Enumerados"

        /// <summary>
        /// Enumerado Nacionalidad
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion

        #region "Propiedades"

        /// <summary>
        /// Propiedad publica de lectura y escritura del atributo nombre
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }

            set
            {
                if (ValidarNombreApellido(value) != "")
                {
                    this.nombre = value;
                }
            }
        }

        /// <summary>
        /// Propiedad publica  de lectura y escritura del atributo apellido
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }

            set
            {
                if (ValidarNombreApellido(value) != "")
                {
                    this.apellido = value;
                }
            }
        }

        /// <summary>
        /// Propiedad publica  de lectura y escritura del atributo dni
        /// </summary>
        public int DNI
        {
            get { return this.dni; }

            set { this.dni = ValidarDni(this.Nacionalidad, value); }
        }

        /// <summary>
        /// Propiedad publica de lectura y escritura del atributo nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }

            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// Propiedad publica de escritura del atributo dni(string)
        /// </summary>
        public string StringToDNI
        { 
            set { this.dni = ValidarDni(this.Nacionalidad,value); }
        }

        #endregion

        #region "Constructores"

        /// <summary>
        /// Constructor por defecto de la clase Persona, requerido para serializacion xml.
        /// </summary>
        public Persona() { }

        /// <summary>
        /// Constructor de instancia de la clase Persona.
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido  de la Persona</param>
        /// <param name="nacionalidad">Nacionalidad  de la Persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de instancia de la clase Persona
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido  de la Persona</param>
        /// <param name="dni">dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad  de la Persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido  de la Persona</param>
        /// <param name="dni">dni de la persona(string)</param>
        /// <param name="nacionalidad">Nacionalidad  de la Persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region "Métodos"

        /// <summary>
        /// Metodo que valida el numero de documento en relacion a la nacionalidad de la persona.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>numero de dni</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {  
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    {

                        if(dato < 0 || dato > 89999999)
                        {
                            throw new NacionalidadInvalidaException();
                        }
                        break;
                    }
                case ENacionalidad.Extranjero:
                    {
                        if (dato < 90000000 || dato > 99999999)
                        {
                            throw new NacionalidadInvalidaException();
                        }
                        break;
                    }
            }
            return dato;
        }

        /// <summary>
        /// Valida que el formato del dni no contenga caracteres invalidos.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>numero de dni</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            
            int dni;

            if (dato.Length < 1 || dato.Length > 8)
            {
                throw new DniInvalidoException();
            }

            if (!Int32.TryParse(dato, out dni))
            {
                throw new DniInvalidoException();
            }

            return ValidarDni(nacionalidad, dni);
        }

        /// <summary>
        /// Valida que Apellido y Nombre sean cadenas compuestas solo por letras
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Nombre o Apellido</returns>
        public string ValidarNombreApellido(string dato)
        {
            Regex r = new Regex("^[a-zA-Z]+$");

            if (r.IsMatch(dato))
            {
                return dato;
            }
            return "";
        }

        /// <summary>
        /// Metodo que hace publico los atributos de Persona.
        /// </summary>
        /// <returns>Strign con todos los datos de Persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("NOMBRE COMPLETO: ");
            sb.Append(this.Apellido);
            sb.Append(", ");
            sb.AppendLine(this.Nombre);
            sb.Append("NACIONALIDAD: ");
            sb.AppendLine(this.Nacionalidad.ToString());
            sb.AppendLine();

            return sb.ToString();
        }

        #endregion
    }
}
