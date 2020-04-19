using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Numero
    {
        private double numero;

        #region Constructor

        public Numero()
        {
            this.numero = 0;
            new Numero();
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            this.numero = Convert.ToDouble(numero);
        }

        public double ValidarNumero(string strNumero)
        {
            return 0;
        }

        #endregion

        #region Propiedades

        public double SetNumero
        {
            set { this.numero = value; }
        }

        #endregion

    }
}
