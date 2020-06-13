using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region "Propiedades"

        public List<Alumno> Alumnos { get; set; }

        public List<Jornada> Jornada { get; set; }

        public List<Profesor> Profesores { get; set; }

        public Jornada this[int i]
        {
            get { /* return the specified index here */ return new Jornada(); }
            set { /* set the specified index to value here */ ; }
        }

        #endregion

        #region "Constructores"

        public Universidad()
        {
            
        }

        #endregion

        #region "Métodos"

        public bool Guardar(Universidad uni)
        {
            return false;
        }

        public Universidad Leer()
        {
            return new Universidad();
        }

        private string MostrarDatos(Universidad uni)
        {
            return "";
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
            return false;
        }

        public static bool operator !=(Universidad u, Alumno a)
        {
            return false;
        }

        public static bool operator ==(Universidad u, Profesor i)
        {
            return false;
        }

        public static bool operator !=(Universidad u, Profesor i)
        {
            return false;
        }

        public static bool operator ==(Universidad u, Universidad.EClases clase)
        {
            return false;
        }

        public static bool operator !=(Universidad u, Universidad.EClases clase)
        {
            return false;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            return u;
        }

        public static Universidad operator +(Universidad u, Universidad.EClases clase)
        {
            return u;
        }


        #endregion

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
