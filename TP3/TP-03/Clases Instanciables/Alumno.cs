using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario //titulo de sobrecarga, DOC, REVISAR LOGICA DE == Y != Y SI MUESTRA DATOS OK
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region "Constructores"

        public Alumno()
            : base()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
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
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }


        #endregion

        #region "Métodos"

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("TOMA CLASE DE: ");
            sb.AppendLine(this.claseQueToma.ToString());

            return sb.ToString();
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.Append("ESTADO DE CUENTA: ");
            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }

        #endregion

        #region "Sobrecarga de /////"

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (!(a != clase) && a.estadoCuenta != EEstadoCuenta.Deudor);//ESTA BIEN ?
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }

        #endregion

        #region "Sobrecarga de /////"

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region "Enumerado"

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion
    }
}
