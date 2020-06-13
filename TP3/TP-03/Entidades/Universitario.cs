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

        public Universitario()
            :base()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region "Métodos"

        protected abstract string ParticiparEnClase();

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

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI);//esta bien la logica? falta si son del mismo tipo equals?
            //opcion 2 if(pg1.legajo == pg2.legajo || pg1.DNI ==pg2.DNI)
            //return true
            //else false
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

        #region "Sobrecarga de "//////////

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

