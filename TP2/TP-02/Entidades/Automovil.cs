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

        #region Constructores

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

        public Automovil(EMarca marca, string chasis, ConsoleColor color,ETipo tipo)
                : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        #endregion

        #region Propiedades

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

        #region Métodos

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.Append("TAMAÑO: ");
            sb.AppendLine(this.Tamanio.ToString());
            sb.Append("TIPO : ");
            sb.AppendLine(this.tipo.ToString());
            sb.AppendLine("---------------------");//revisar si se ve bien

            return sb.ToString();
        }

        #endregion

        #region Enumerados

        public enum ETipo
        {
            Monovolumen, Sedan
        }

        #endregion
    }
}
