using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region "Constructores"

        /// <summary>
        /// Constructor de Clase de la Clase Profesor. Inicializa el atributo random.
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Constructor por defecto de la clase Profesor, requerido para serializacion xml.
        /// </summary>
        public Profesor() { }

        /// <summary>
        /// Constructor de instancia de la clase Profesor
        /// </summary>
        /// <param name="id">legajo del Universitario</param>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido  de la Persona</param>
        /// <param name="dni">dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad  de la Persona</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }


        #endregion

        #region "Métodos"

        /// <summary>
        /// Metodo privado que asgina de forma aleatoria dos clases al atributo clasesDelDia
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((EntidadesInstanciables.Universidad.EClases)Profesor.random.Next(0, 3));
            }
        }

        /// <summary>
        /// Metodo protegido que muestra los datos de profesor
        /// </summary>
        /// <returns>Una cadena con los datos de profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            sb.AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// Metodo que sobreescribe ParticiparEnClase()
        /// </summary>
        /// <returns>Cadena con las clases que dicta el alumno</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");

            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();

        }

        /// <summary>
        /// Metodo que hace publico los datos de profesor
        /// </summary>
        /// <returns>retorna una cadena con todos los datos de profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region "Sobrecarga de Operadores"

        /// <summary>
        /// Sobrecarga del operador ==.Un profesor y una clase seran iguales si el profesor da esa clase
        /// </summary>
        /// <param name="i">Objeto del tipo profesor</param>
        /// <param name="clase">Objeto del tipo Universidad.Eclases</param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            if (!(i is null))
            {
                foreach (Universidad.EClases item in i.clasesDelDia)
                {
                    if (clase == item)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga del operador !=.Un profesor y una clase seran distintos si el profesor no da esa clase
        /// </summary>
        /// <param name="i">Objeto del tipo profesor</param>
        /// <param name="clase">Objeto del tipo Universidad.Eclases</param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
