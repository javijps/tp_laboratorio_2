using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace EntidadesAbstractas
{

    public abstract class Universitario : Persona 
    {

        //REVISAR SI ESTAN BIEN LAS IGUALDADES. FALTA CONTEMPLAR EL TIPO DE IGUALDAD.
        //CONSTRUCTOR POR DEFECTO?. 
        //TITULO SOBRECARGAS.DOC

        private int legajo;


        public int Legajo
        {
            get { return this.legajo; }
            set { this.legajo = value; }
        }



        #region "Constructores"

        /// <summary>
        /// 
        /// </summary>
        public Universitario() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this.Legajo = legajo;
        }

        #endregion

        #region "Métodos"

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()//chequear
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());
            sb.Append("LEGAJO NÚMERO: ");
            sb.Append(this.Legajo.ToString());
            sb.AppendLine();

            return sb.ToString();
        }

        #endregion

        #region "Sobrecarga de "//////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Legajo == pg2.Legajo || pg1.DNI == pg2.DNI ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

        #region "Sobrecarga de "//////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool rta = false;

            if (obj is Universitario)
            {
                rta = this == ((Universitario)obj);
            }
            return rta;
        }

        #endregion
    }
}

