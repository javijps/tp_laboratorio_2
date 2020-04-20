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
            this.numero = numero;
        }

        public Numero(string numero)
        {
            this.numero = Convert.ToDouble(numero);
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
            string resultado = "";
            Numero numeroIngresado = new Numero();
            numeroIngresado.SetNumero = numero;
            //aca se convierte el numero a decimal. y a string para poner en resultado
            return resultado;
        }

        public string DecimalBinario(string numero)//decimal a binario trabaja con enteros positivos
        {
            string resultado = "";
            Numero numeroIngresado = new Numero();
            numeroIngresado.SetNumero = numero;
            //aca algoritmo para convertir el numero a binario.
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

        static public double operator +(Numero n1,Numero n2)
        {
            double resultado = 0;

            return resultado;
        }

        static public double operator -(Numero n1, Numero n2)
        {
            double resultado = 0;

            return resultado;
        }

        static public double operator *(Numero n1, Numero n2)
        {
            double resultado = 0;

            return resultado;
        }

        static public double operator /(Numero n1, Numero n2)
        {
            double resultado = 0;

            return resultado;
        }

        #endregion

    }
}
