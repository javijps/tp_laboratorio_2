using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace EntidadesAbstractas
{
    public abstract class Persona 
    {
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        #region "Enumerado"

        /// <summary>
        /// 
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion

        #region "Propiedades"

        /// <summary>
        /// 
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
        /// 
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
        /// 
        /// </summary>
        public int DNI
        {
            get { return this.dni; }

            set { this.dni = ValidarDni(this.Nacionalidad, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }

            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string StringToDNI
        {
            set { this.dni = ValidarDni(this.Nacionalidad,value); }
        }

        #endregion

        #region "Constructores"

        /// <summary>
        /// 
        /// </summary>
        public Persona() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region "Métodos"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

            Console.WriteLine("dato " + dato.ToString() + " nacionalidad " + nacionalidad.ToString());
            
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
        /// 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public string ValidarNombreApellido(string dato)
        {
            Regex r = new Regex("^[a-zA-Z]+$");

            if (r.IsMatch(dato))
            {
                return dato;
            }
            return "";
        }

        #endregion

        #region "Sobrecarga de " //renombrar

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
