using Archivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesInstanciables;

namespace EntidadesInstanciables
{
    public class Jornada
    {

        private List <Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region "Propiedades"
        
        /// <summary>
        /// Propiedad publica de lectura y escritura del atributo alumnos
        /// </summary>
        public List<Alumno> Alumnos 
        {
            get { return this.alumnos; }
            set { this.alumnos = value; } 
        }

        /// <summary>
        /// Propiedad publica de lectura y escritura del atributo clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        /// <summary>
        /// Propiedad publica de lectura y escritura del atributo instructor
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        #endregion

        #region "Constructores"

        /// <summary>
        /// Constructor por defecto del la clase Jornada. Inicializa la Lista<Alumno>
        /// </summary>
        public Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de instancia de la clase Jornada
        /// </summary>
        /// <param name="clase">clase de la jornada</param>
        /// <param name="instructor">profesor que imparte la clase</param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        #endregion

        #region "Métodos"

        /// <summary>
        /// Metodo estatico de clase que guarda la informacion de Jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>

        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();

            return txt.Guardar(@"JORNADA.txt", jornada.ToString());
        }

        /// <summary>
        /// Metodo estatico de clase que lee la informacion de un archivo de texto
        /// </summary>
        /// <returns>retorna una cadena con el texto leido del archivo</returns>
        public static string Leer()
        {
            Texto txt = new Texto();
            string texto;

            txt.Leer(@"JORNADA.txt", out texto);

            return texto;

        }


        /// <summary>
        /// Metodo que hace publica la informacion de Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLASE DE ");
            sb.Append(this.clase.ToString());
            sb.Append(" POR ");
            sb.Append(this.instructor.ToString());
            sb.AppendLine("ALUMNOS: ");

            foreach (Alumno item in this.alumnos)
            {
                sb.Append(item.ToString());
            }

            sb.AppendLine("<----------------------------------------------------->");
            sb.AppendLine();

            return sb.ToString();
        }


        #endregion

        #region "Sobrecarga de Operadores"

        /// <summary>
        /// Sobrecarga del operador ==. Una Jornada y un alumno seran iguales si el alumno participa de la clase.
        /// </summary>
        /// <param name="j">Objeto del tipo jornada</param>
        /// <param name="a">objeto del tipo alumno</param>
        /// <returns>true en caso de igualdad, false en caso contrario</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j.alumnos)
            {
                if(item == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga del operador !=. Una Jornada y un alumno seran distintos si el alumno no participa de la clase.
        /// </summary>
        /// <param name="j">Objeto del tipo jornada</param>
        /// <param name="a">objeto del tipo alumno</param>
        /// <returns>true en caso de desigualdad, false en caso contrario</returns>

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Sobrecarga del operador +. Un alumno se agregara a la lista alumnos de la jornada, si no existe en la misma
        /// </summary>
        /// <param name="j">Objeto del tipo jornada</param>
        /// <param name="a">objeto del tipo alumno</param>
        /// <returns>retorna j</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j!=a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }

        #endregion
    }
}
