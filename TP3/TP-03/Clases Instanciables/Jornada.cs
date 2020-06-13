using Archivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Jornada
    {
        /*-CHEQUEAR LOGICA DE IGUALDAD y !=
         *-DOC
         *-TITULO SOBRECARGAS
         *-CONSTRUCTORES
         * -TOSTRING
         * -PROPIEDADES EN CONSTRUCTORES?
         */



        private List <Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region "Propiedades"

        public List<Alumno> Alumnos 
        {
            get { return this.alumnos; }
            set { this.alumnos = value; } 
        }

        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }


        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        #endregion

        #region "Constructores"

        public Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.Clase = clase;//reemplazar con propiedades?
            this.Instructor = instructor;//reemplazar con propiedades?
        }

        #endregion

        #region "Métodos"

        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();

            return txt.Guardar("JORNADATEXTO.txt",jornada.ToString());
        }

        public static string Leer()
        {
            Texto txt = new Texto();
            string texto;

            txt.Leer("JORNADATEXTO.txt", out texto);

            return texto;

        }

        #endregion

        #region "Sobrecarga de /////"

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

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");
            sb.Append("CLASE DE:");
            sb.Append(this.clase.ToString());//CHEQUEAR SI NINGUNA DE LAS OTRAS CLASES LO MUESTRA
            sb.Append("POR NOMBRE COMPLETO:");

            foreach (Alumno item in this.alumnos)
            {
                sb.Append(item.ToString());// ESTA BIEN?
            }

            return sb.ToString();
        }

        #endregion
    }
}
