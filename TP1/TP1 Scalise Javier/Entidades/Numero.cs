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

        /// <summary>
        /// Crea una instancia de tipo Numero
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Crea una instancia del tipo numero e inicializa numero a traves del numero ingresado por parametro
        /// </summary>
        /// <param name="numero">numero del tipo double con el cual se inicializara</param>
        public Numero(double numero)
        {
            this.SetNumero = Convert.ToString(numero);
        }

        /// <summary>
        /// Crea una instancia del tipo numero e inicializa numero a traves del numero ingresado por parametro
        /// </summary>
        /// <param name="numero">numero del tipo string con el cual se inicializara</param>
        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad solo escritura del xxxx numero
        /// </summary>
        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Convierte numero binario a decimal, en caso de ser posible
        /// </summary>
        /// <param name="numero">Numero a ser convertido</param>
        /// <returns>Retorna "Valor Invalido" en caso de no haber podido realizar la conversion.Caso contrario
        /// retorna el numero convertido</returns>
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

        /// <summary>
        /// Convierte numero decimal a binario, en caso de ser posible
        /// </summary>
        /// <param name="numero">Numero a ser convertido</param>
        /// <returns>Retorna "Valor Invalido" en caso de no haber podido realizar la conversion.Caso contrario
        /// retorna el numero convertido</returns>
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

        /// <summary>
        /// Convierte numero decimal a binario, en caso de ser posible
        /// </summary>
        /// <param name="numero">Numero a ser convertido</param>
        /// <returns>Retorna "Valor Invalido" en caso de no haber podido realizar la conversion.Caso contrario
        /// retorna el numero convertido</returns>
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

        /// <summary>
        /// Comprueba que el valor recibido sea un numero
        /// </summary>
        /// <param name="strNumero">Valor a validar</param>
        /// <returns>En caso de no validar, retorna 0. Caso contrario, retorna el valor tipo double</returns>
        public double ValidarNumero(string strNumero)
        {
            double numero = 0;
            double.TryParse(strNumero, out numero);
            return numero;
        }

        #endregion

        #region Sobrecarga de Operadores

        /// <summary>
        /// Suma dos objetos de tipo Numero
        /// </summary>
        /// <param name="n1">Instancia de Clase Numero</param>
        /// <param name="n2">Instancia de Clase Numero</param>
        /// <returns>En caso de no poder realizar la operacion, retorna 0. Caso contrario retorna el resultado</returns>
        static public double operator +(Numero n1, Numero n2)
        {
            double resultado = 0;

            if (!object.Equals(n1, null) && !object.Equals(n2, null))
            {
                resultado = n1.numero + n2.numero;
            }
            return resultado;
        }

        /// <summary>
        /// Resta dos objetos de tipo Numero
        /// </summary>
        /// <param name="n1">Instancia de Clase Numero</param>
        /// <param name="n2">Instancia de Clase Numero</param>
        /// <returns>En caso de no poder realizar la operacion, retorna 0. Caso contrario retorna el resultado</returns>
        static public double operator -(Numero n1, Numero n2)
        {
            double resultado = 0;

            if (!object.Equals(n1, null) && !object.Equals(n2, null))
            {
                resultado = n1.numero - n2.numero;
            }
            return resultado;
        }

        /// <summary>
        /// Multiplica dos objetos de tipo Numero
        /// </summary>
        /// <param name="n1">Instancia de Clase Numero</param>
        /// <param name="n2">Instancia de Clase Numero</param>
        /// <returns>En caso de no poder realizar la operacion, retorna 0. Caso contrario retorna el resultado</returns>
        static public double operator *(Numero n1, Numero n2)
        {
            double resultado = 0;

            if (!object.Equals(n1, null) && !object.Equals(n2, null))
            {
                resultado = n1.numero * n2.numero;
            }
            return resultado;
        }

        /// <summary>
        /// Divide dos objetos de tipo Numero y valida que el divisor no sea 0
        /// </summary>
        /// <param name="n1">Instancia de Clase Numero</param>
        /// <param name="n2">Instancia de Clase Numero</param>
        /// <returns>En caso de no poder realizar la operacion, retorna 0. Caso contrario retorna el resultado</returns>

        static public double operator /(Numero n1, Numero n2)
        {
            double resultado = double.MinValue; ;

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