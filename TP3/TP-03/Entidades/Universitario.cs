using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Universitario : Persona //REVISAR SI ESTAN BIEN LAS IGUALDADES. CONSTRUCTOR POR DEFECTO?. TITULO SOBRECARGAS.DOC
    {
        int legajo;

        #region "Constructores"
        
        /// <summary>
        /// 
        /// </summary>
        public Universitario()
            :base()
        {

        }

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
            this.legajo = legajo;
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
            sb.AppendLine(this.legajo.ToString());

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
            return (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI);//esta bien la logica? falta si son del mismo tipo equals?
            //opcion 2 if(pg1.legajo == pg2.legajo || pg1.DNI ==pg2.DNI)
            //return true
            //else false
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
        public override bool Equals(object obj)//REVISAR!!!!!!!!!!!!!
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

