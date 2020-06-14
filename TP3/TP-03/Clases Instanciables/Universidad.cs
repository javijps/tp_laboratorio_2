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
        /// 
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
        /// 
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Jornada> Jornada
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Profesor> Profesores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        /// <summary>
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.Guardar(@"C:\archivos\ArchivoUniversidad.xml", uni);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            Universidad u = null;

            xml.Leer(@"C:\archivos\ArchivoUniversidad.xml", out u);

            return u;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uni"></param>
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

        public override string ToString()//revisar
        {
            return MostrarDatos(this);
        }

        #endregion

        #region "Sobrecarga de Operadores"

        public static bool operator ==(Universidad u, Alumno a)
        {
            if (!(a is null))
            {
                return u.Alumnos.Contains(a);
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad u, Profesor i)
        {
            if (!(i is null))
            {
                return u.Profesores.Contains(i);
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad u, Profesor i)
        {
            return !(u == i);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
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
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
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
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
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
