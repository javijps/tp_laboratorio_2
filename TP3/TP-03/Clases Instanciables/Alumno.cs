using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region "Constructores"

        public Alumno()
            :base()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, 
                      string nombre, 
                      string apellido, 
                      string dni, 
                      ENacionalidad nacionalidad, 
                      Universidad.EClases claseQueToma,
                      EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }


        #endregion

        #region "Métodos"

        protected override string ParticiparEnClase()
        {
            return "";
        }

        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }

        #endregion

        #region "Sobrecarga de /////"

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return false;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return false;
        }

        #endregion

        #region "Sobrecarga de /////"

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion












        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
    }
}
