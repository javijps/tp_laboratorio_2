using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Constructor

        public Numero()
        {
            this.SetNumero = 0;
        }

        public Numero(double numero)
        {
            this.SetNumero = Convert.ToString(numero);
        }

        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

        #endregion

        #region Propiedades

        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }

        #endregion

        #region Metodos

        public string BinarioDecimal(string numero)
        {
            int resto;
            int base1 = 1;
            int numeroDecimal = 0;
            string resultado = " ";
            int numeroIngresado;
            int.TryParse(numero, out numeroIngresado);
            
            if (numeroIngresado > 0)
            {
                while (numeroIngresado > 0)
                {
                    resto = numeroIngresado % 10;
                    numeroIngresado = numeroIngresado / 10;
                    numeroDecimal += resto * base1;
                    base1 = base1 * 2;
                }
                resultado = Convert.ToString(numeroDecimal);
                return resultado;
            }
            resultado = "Valor Invalido";
            return resultado;
        }

        public string DecimalBinario(string numero)
        {
            string resultado = "Valor Invalido";
            int numeroIngresado;
         
            int.TryParse(numero, out numeroIngresado);
            
            if (numeroIngresado > 0)
            {
                resultado = DecimalBinario(Convert.ToDouble(numeroIngresado));
            }
            return resultado;
        }

        public string DecimalBinario(double numero)
        {
            string resultado = " ";
            int numeroIngresadoInt = Convert.ToInt32(numero);
            int resto;

            if (numeroIngresadoInt > 0)
            {
                while (numeroIngresadoInt > 1)
                {
                    resto = numeroIngresadoInt % 2;
                    resultado = Convert.ToString(resto) + resultado;
                    numeroIngresadoInt /= 2;
                }
                resultado = Convert.ToString(numeroIngresadoInt) + resultado;
                return resultado;
            }
            resultado = "Valor Invalido";
            return resultado;
        }

        public double ValidarNumero(string strNumero)
        {
            double numero = 0;
            double.TryParse(strNumero, out numero);
            return numero;
        }

        #endregion

        #region Sobrecarga de Operadores

        static public double operator +(Numero n1, Numero n2)
        {
            double resultado = 0;

            if (!object.Equals(n1, null) && !object.Equals(n2, null))
            {
                resultado = n1.numero + n2.numero;
            }
            return resultado;
        }

        static public double operator -(Numero n1, Numero n2)
        {
            double resultado = 0;

            if (!object.Equals(n1, null) && !object.Equals(n2, null))
            {
                resultado = n1.numero - n2.numero;
            }
            return resultado;
        }

        static public double operator *(Numero n1, Numero n2)
        {
            double resultado = 0;

            if (!object.Equals(n1, null) && !object.Equals(n2, null))
            {
                resultado = n1.numero * n2.numero;
            }
            return resultado;
        }

        static public double operator /(Numero n1, Numero n2)
        {
            double resultado = 0;

            if (!object.Equals(n1, null) && !object.Equals(n2, null))
            {
                if (n2.numero != 0)
                {
                    resultado = n1.numero / n2.numero;
                }
            }
            return resultado;
        }
        #endregion
    }
}