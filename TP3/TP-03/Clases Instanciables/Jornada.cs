using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List <Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region "Propiedades"

        public List<Alumno> Alumnos { get; set; }

        public Universidad.EClases Clase { get; set; }

        public Profesor Instructor { get; set; }

        #endregion

        #region "Constructores"

        public Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;//reemplazar con propiedades?
            this.instructor = instructor;//reemplazar con propiedades?
        }

        #endregion

        #region "Métodos"

        public bool Guardar(Jornada jornada)
        {
            return false;
        }

        public string Leer()
        {
            return "";
        }

        #endregion

        #region "Sobrecarga de /////"

        public static bool operator ==(Jornada j, Alumno a)
        {
            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            return new Jornada();
        }

        #endregion

        #region "Sobrecarga de /////"

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }
}
