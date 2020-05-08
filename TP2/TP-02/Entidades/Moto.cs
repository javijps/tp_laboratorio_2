using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto: Vehiculo
    {
        #region Constructores

        public Moto(EMarca marca, string chasis, ConsoleColor color)
            :base(chasis,marca,color)
        {

        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        #endregion

        #region Métodos

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");//revisar si queda bien

            return sb.ToString();
        }

        #endregion
    }
}
