using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region "Constructores"

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor()
            :base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            //asignar clases randomClases()

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {

        }



        #endregion

        #region "Métodos"

        private void _randomClases()
        {

        }

        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }

        protected override string ParticiparEnClase()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region "Sobrecarga de /////"

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
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
