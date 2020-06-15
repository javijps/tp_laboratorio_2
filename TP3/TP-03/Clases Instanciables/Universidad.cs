using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region Enumerado

        /// <summary>
        /// Enumerado Eclases
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #endregion

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
        /// Propiedad publica de lectura y escritura del atributo jornada
        /// </summary>
        public List<Jornada> Jornada
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        /// <summary>
        /// Propiedad publica de lectura y escritura del atributo profesores
        /// </summary>
        public List<Profesor> Profesores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        /// <summary>
        /// Propiedad de lectura escritura para al acceso de una jornada por medio de un indexador.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }

        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto del la clase Universidad. Iniciliza las listas de todos sus atributos.
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornada = new List<Jornada>();
            this.Profesores = new List<Profesor>();
        }

        #endregion

        #region "Métodos"

        /// <summary>
        /// Metodo estatico de clase que serializa la informacion de Universidad en formato xml
        /// </summary>
        /// <param name="uni">Objeto del tipo universidad</param>
        /// <returns>true en caso de guardar exitosamente,caso contrario lanzara la excepcion correspondiente</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.Guardar(@"C:\archivos\ArchivoUniversidad.xml", uni);
        }

        /// <summary>
        /// Metodo estatico de clase que desserializa la informacion de Universidad en formato xml
        /// </summary>
        /// <returns>Objeto universidad donde se deserializo la informacion</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            Universidad u = null;

            xml.Leer(@"C:\archivos\ArchivoUniversidad.xml", out u);

            return u;
        }

        /// <summary>
        /// Metodo que muestra los datos de universidad
        /// </summary>
        /// <param name="uni">Objeto del tipo Universidad</param>
        /// <returns></returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");

            foreach (Jornada item in this.Jornada)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Metodo que hace publica la informacion de universidad
        /// </summary>
        /// <returns>cadena que contiene la informacion de universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region "Sobrecarga de Operadores"

        /// <summary>
        /// Sobrecarga del operador ==. Un alumno y una universidad seran iguales, si el alumno esta inscripto
        /// </summary>
        /// <param name="u">Objeto del tipo Universidad</param>
        /// <param name="a">Objeto del tipo alumno</param>
        /// <returns>true en caso de igualdad, false en caso contrario</returns>
        public static bool operator ==(Universidad u, Alumno a)
        {
            if (!(a is null))
            {
                return u.Alumnos.Contains(a);
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga del operador !=. Un alumno y una universidad seran distintos, si el alumno no esta inscripto
        /// </summary>
        /// <param name="u">Objeto del tipo Universidad</param>
        /// <param name="a">Objeto del tipo alumno</param>
        /// <returns>true en caso de igualdad, false en caso contrario</returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        /// <summary>
        /// Sobrecarga del operador ==. Un profesor y una universidad seran iguales, si el profesor dicta clases en ella.
        /// </summary>
        /// <param name="u">Objeto del tipo Universidad</param>
        /// <param name="p">Objeto del tipo Profesor</param>
        /// <returns>true en caso de igualdad, false en caso contrario</returns>
        public static bool operator ==(Universidad u, Profesor i)
        {
            if (!(i is null))
            {
                return u.Profesores.Contains(i);
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga del operador !=. Un profesor y una universidad seran distintos, si el profesor no dicta clases en ella.
        /// </summary>
        /// <param name="u">Objeto del tipo Universidad</param>
        /// <param name="p">Objeto del tipo Profesor</param>
        /// <returns>true en caso de igualdad, false en caso contrario</returns>
        public static bool operator !=(Universidad u, Profesor i)
        {
            return !(u == i);
        }

        /// <summary>
        /// Sobrecarga del operador ==. Una clase y una universidad seran iguales, si algun profesor dicta la clase. 
        /// </summary>
        /// <param name="u">Objeto del tipo Universidad</param>
        /// <param name="clase">Objeto del tipo Universidad.EClases</param>
        /// <returns>El primer profesor capaz de dictar dicha clase, caso contrario arrojara SinProfesorException</returns>
        public static Profesor operator ==(Universidad u, Universidad.EClases clase)
        {
            foreach (Profesor item in u.Profesores)
            {
                if (item == clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Sobrecarga del operador !=. Una clase y una universidad seran distintos, si algun profesor no dicta la clase. 
        /// </summary>
        /// <param name="u">Objeto del tipo Universidad</param>
        /// <param name="clase">Objeto del tipo Universidad.EClases</param>
        /// <returns>El primer profesor incapaz de dictar dicha clase</returns>

        public static Profesor operator !=(Universidad u, Universidad.EClases clase)
        {
            Profesor p = null;//NO ME CIERRA EL N

            foreach (Profesor item in u.Profesores)
            {
                if (item != clase)
                {
                    p = item;
                    break;
                }
            }
            return p;
        }

        /// <summary>
        /// Sobrecarga del operador +. Se agregara un alumno a la universidad, si el mismo no esta inscripto
        /// </summary>
        /// <param name="u">Objeto del tipo Universidad</param>
        /// <param name="a">Objeto del tipo Alumno</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (!(a is null))
            {
                if (u == a)
                {
                    throw new AlumnoRepetidoException();
                }
                u.alumnos.Add(a);
            }
            return u;
        }

        /// <summary>
        /// Sobrecarga del operador +. Se agregara un profesor a la universidad, si el mismo no se encuentra previamente
        /// </summary>
        /// <param name="u">Objeto del tipo Universidad</param>
        /// <param name="a">Objeto del tipo Alumno</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (!(i is null) && u != i)
            {
                u.profesores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// Sobrecarga del operador +. Se creara un objeto del tipo Jornada, se le asignara un profesor capaz de dar la clase y los 
        /// inscriptos en la misma
        /// </summary>
        /// <param name="u">Objeto del tipo Universidad</param>
        /// <param name="clase">Objeto del tipo Universidad.EClases</param>
        /// <returns>retorna u</returns>
        public static Universidad operator +(Universidad u, Universidad.EClases clase)
        {
            Profesor p = u == clase;

            Jornada j = new Jornada(clase, p);

            foreach (Alumno item in u.Alumnos)
            {
                if (item == clase)
                {
                    j += item;
                }
            }
            u.Jornada.Add(j);

            return u;
        }


        #endregion

    }
}
