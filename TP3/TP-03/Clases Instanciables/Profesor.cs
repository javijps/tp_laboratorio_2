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
        /*-REVISAR CONSTRUCTORES
         *-HACER ASIGNACION DE MATERIAS CON RANDOM, VER RELACION CON ENUMERADO
         *-RANDOMCLASES()
         *-ESTA BIEN EL FOREACH DE PARTICIPAR EN CLASE?
         *-ESTA BIEN EL CONTAINS DE == 
         *-TITULO SOBRECARGAS
         *-DOC
         */


        private Queue<Universidad.EClases> clasesDelDia;//FIFO. COLA
        private static Random random;

        #region "Constructores"

        /// <summary>
        /// 
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// 
        /// </summary>
        public Profesor()
            :base()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }


        #endregion

        #region "Métodos"

        /// <summary>
        /// 
        /// </summary>
        private void _randomClases()
        {
            Profesor.random.Next();// con el enumerado clases


            //asigna 2 clases al azar
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLASES DEL DIA: ");

            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();

        }

        #endregion

        #region "Sobrecarga de /////"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);//chequear
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion

        #region "Sobrecarga de /////"

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

    }
}
