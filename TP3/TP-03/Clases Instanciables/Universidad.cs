using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Universidad
    {
        /*
         * REVISAR INDEXADOR PROP JORNADA
         * CONSTRUCTORES
         * propiedades?
         * Muestra los datos ok?
         * REVISAR U != CLASE
         * CAMBIAR LEER
         */


        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

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
            get { return this.jornada[i]; }//ESTA BIEN?
            set { this.jornada[i] = value; }
        }

        #endregion

        #region "Constructores"
        /// <summary>
        /// 
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        #endregion

        #region "Métodos"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {//XML
         //tiene que guardar todos los datos de la universidad, las 3 listas y todos los datos de cada elemento de cada lista

            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.Guardar("ArchivoUniversidad.xml", uni);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()// CAMBIAR AL HACER LEER DE XML
        {
            Xml<Universidad> xml = new Xml<Universidad>();

            Universidad u = new Universidad();               //--------CAMBIAR----------------//

            xml.Leer("ArchivoUniversidad.xml", u);

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

            foreach (Jornada item in this.Jornada)
            {
                sb.Append(item.ToString());
            }

            foreach (Alumno item in this.Alumnos)
            {
                sb.Append(item.ToString());
            }

            foreach (Profesor item in this.Profesores)
            {
                sb.Append(item.ToString());
            }

            return sb.ToString();
        }
        #endregion

        #region "Sobrecarga de ///////"

        public override string ToString()//revisar
        {
            return MostrarDatos(this);
        }

        #endregion

        #region "Sobrecarga de ///////"

        public static bool operator ==(Universidad u, Alumno a)
        {
            return u.alumnos.Contains(a);//esta bien?
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
            return u.profesores.Contains(i);//esta bien?
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
            Profesor p = null;//NO ME CIERRA EL NULL

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
            if (u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
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
            if (u != i)
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
    }
}
