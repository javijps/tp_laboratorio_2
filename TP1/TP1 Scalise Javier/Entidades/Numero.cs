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
            this.numero = 0;
            new Numero();
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

        public string BinarioDecimal(string numero)//binario a decimal. trabaja con enteros positivos
        {
            int resto;
            int base1 = 1;
            int numeroDecimal = 0;
            string resultado = "Valor Invalido";
            int numeroBinario = Convert.ToInt32(numero);

            if (numeroBinario > 0)
            {
                while (numeroBinario > 0)
                {
                    resto = numeroBinario % 10;
                    numeroBinario = numeroBinario / 10;
                    numeroDecimal += resto * base1;
                    base1 = base1 * 2;
                }
                resultado = Convert.ToString(numeroDecimal);
            }
            return resultado;
        }

        public string DecimalBinario(string numero)//decimal a binario trabaja con enteros positivos
        {
            int numeroIngresadoInt = Convert.ToInt32(numero);
            int resto;
            string resultado = "";

            while (numeroIngresadoInt > 1)
            {
                resto = numeroIngresadoInt % 2;
                resultado = Convert.ToString(resto) + resultado;
                numeroIngresadoInt /= 2;
            }
            resultado = Convert.ToString(numeroIngresadoInt) + resultado;
            return resultado;
        }

        public string DecimalBinario(double numero)
        {
            string resultado = "";
            Numero numeroIngresado = new Numero();
            numeroIngresado.SetNumero = Convert.ToString(numero);
            return resultado = DecimalBinario(numeroIngresado.numero);
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