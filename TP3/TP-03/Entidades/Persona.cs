using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {

        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        #region "Propiedades"

        public string Nombre
        {
            get { return this.nombre; }

            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this.nombre = value;
                }
            }
        }

        public string Apellido 
        {
            get { return this.apellido; }

            set 
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this.apellido = value;
                }
            }
        }

        public int DNI
        {
            get { return this.dni; }

            set { this.dni = ValidarDni(this.Nacionalidad, value); }
        }
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }

            set { this.nacionalidad = value; }
        }
        public string StringToDNI 
        {
            set { this.dni = ValidarDni(this.Nacionalidad, value); } 
        }

        #endregion

        #region "Constructores"
        public Persona()
        {
            //para que el constructor por defecto?
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region "Métodos"

        private int ValidarDni(ENacionalidad nacionalidad,int dato)
        {
            switch(nacionalidad)
            {
                case ENacionalidad.Argentino:
                    {
                        if(dato < 1 || dato > 89999999)
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

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;

            if(dato.Length < 1 || dato.Length >9)
            {
                throw new DniInvalidoException();
            }

            if(!Int32.TryParse(dato,out dni))
            {
                throw new DniInvalidoException();
            }

            return ValidarDni(nacionalidad,dni);
        }

        public string ValidarNombreApellido(string dato)
        {
            Regex r = new Regex("^[a-zA-Z]+$");

            if(r.IsMatch(dato))
            {
                return dato;
            }
            return null;
        }

        #endregion

        #region "Sobrecarga de " //renombrar

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("NOMBRE COMPLETO: ");
            sb.Append(this.Apellido);
            sb.Append(", ");
            sb.AppendLine(this.Nombre);
            sb.Append("NACIONALIDAD: ");
            sb.AppendLine(this.Nacionalidad.ToString());

            return sb.ToString();
        }

        #endregion



        #region "Enumerado"

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion
    }
}
