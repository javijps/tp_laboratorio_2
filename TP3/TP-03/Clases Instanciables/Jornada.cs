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
        /*-CHEQUEAR LOGICA DE IGUALDAD y !=
         * guardar y leer
         *-DOC
         *-TITULO SOBRECARGAS
         */

        private List <Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

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
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        #endregion

        #region "Constructores"

        /// <summary>
        /// 
        /// </summary>
        public Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        #endregion

        #region "Métodos"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>

        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();

            return txt.Guardar(@"C:\archivos\JORNADA.txt", jornada.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto txt = new Texto();
            string texto;

            txt.Leer(@"C:\archivos\JORNADA.txt", out texto);

            return texto;

        }

        #endregion

        #region "Sobrecarga de /////"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j.alumnos)
            {
                if(item == a)//falta corregir el tipo de universitario en la igualdad
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j!=a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }

        #endregion

        #region "Sobrecarga de /////"

        /// <summary>
        /// 
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
    }
}
