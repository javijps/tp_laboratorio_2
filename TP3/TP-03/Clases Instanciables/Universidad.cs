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
        /*
         * REVISAR U != CLASE
         * GUARDAR Y LEER
         * chequear los null
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
        {//XML
         //tiene que guardar todos los datos de la universidad, las 3 listas y todos los datos de cada elemento de cada lista

            Xml<Universidad> xml = new Xml<Universidad>();

            return xml.Guardar(@"C:\archivos\ArchivoUniversidad.xml", uni);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()// CAMBIAR AL HACER LEER DE XML
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
            return u.alumnos.Contains(a);
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
            return u.profesores.Contains(i);
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
            if (u == a)
            {
                throw new AlumnoRepetidoException();
            }
            u.alumnos.Add(a);

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



        public static bool GuardarT(Universidad u)
        {
            Texto txt = new Texto();

            return txt.Guardar(@"C:\archivos\UNI.txt", u.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string LeerT()
        {
            Texto txt = new Texto();
            string texto;

            txt.Leer(@"C:\archivos\UNI.txt", out texto);

            return texto;

        }
    }
}
