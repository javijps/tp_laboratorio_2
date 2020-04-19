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

        public double SetNumero//unico lugar donde se llama a validar numero
        {
            set { this.numero = value; }
        }

        #endregion

        #region Metodos

        public string BinarioDecimal(string numero)//binario a decimal. trabaja con enteros positivos
        {
            string num = "";
            return num;
        }

        public string DecimalBinario(string num)//decimal a binario trabaja con enteros positivos
        {
            string strBinario = " ";
            return strBinario;
        }

        public string DecimalBinario(double num)
        {
            string binario = "";
            return binario;
        }

        public double ValidarNumero(string strNumero)
        {
            double numero = 0;
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
