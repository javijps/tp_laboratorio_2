using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;



namespace EntidadesInstanciables
{
    [XmlInclude(typeof(Alumno))]
    public sealed class Alumno : Universitario 
    {

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region "Enumerado"

        /// <summary>
        /// 
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion

        #region "Propiedades"

        public Universidad.EClases ClaseQueToma
        {
            get { return this.claseQueToma; }
            set { this.claseQueToma = value; }
        }

        public EEstadoCuenta EstadoCuenta
        {
            get { return this.estadoCuenta; }
            set { this.estadoCuenta = value; }
        }

        #endregion

        #region "Constructores"

        /// <summary>
        /// 
        /// </summary>
        public Alumno()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("TOMA CLASE DE: ");
            sb.AppendLine(this.claseQueToma.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.Append("ESTADO DE CUENTA: ");
            sb.AppendLine(this.estadoCuenta.ToString());
            sb.Append(this.ParticiparEnClase());
            
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        #endregion

        #region "Sobrecarga de Operadores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (!(a != clase) && a.estadoCuenta != EEstadoCuenta.Deudor);//ESTA BIEN ?
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }

        #endregion

    }
}
