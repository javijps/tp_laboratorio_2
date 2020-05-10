using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades
{
    public class Automovil: Vehiculo
    {
        private ETipo tipo;

        #region "Enumerados"

        public enum ETipo
        {
            Monovolumen, Sedan
        }

        #endregion

        #region "Propiedades"

        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        #endregion

        #region "Constructores"

        /// <summary>
        /// Constructor publico de la Clase Automovil. Inicializara todos sus atributos con los valores pasados por parametro.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
        : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color)
            :this(marca,chasis,color,ETipo.Monovolumen)
        {

        }

        #endregion

        #region "Métodos"

        /// <summary>
        /// Publica todos los datos de Automovil.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.Append("TAMAÑO: ");
            sb.AppendLine(this.Tamanio.ToString());
            sb.Append("TIPO : ");
            sb.AppendLine(this.tipo.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion

    }
}
