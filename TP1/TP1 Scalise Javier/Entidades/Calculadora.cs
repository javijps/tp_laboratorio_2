using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza operaciones entre dos Numero a traves de la sobrecarga de "+", "-", "*", "/".
        /// </summary>
        /// <param name="numero1">Primer Numero</param>
        /// <param name="numero2">Segundo Numero</param>
        /// <param name="operador">operador</param>
        /// <returns>Retorna 0 en caso de no ingresar en ningun caso del switch o el resultado de la operacion</returns>
        public double Operar(Numero numero1,Numero numero2,string operador)
        {
            double resultado = 0;
            string auxOperador = ValidarOperador(operador);

            switch(auxOperador)
            {
                case "+":
                    {
                        resultado = numero1 + numero2;
                        return resultado;
                    }
                case "-":
                    {
                        resultado = numero1 - numero2;
                        return resultado;
                    }
                case "*":
                    {
                        resultado = numero1 * numero2;
                        return resultado;
                    }
                case "/":
                    {
                        resultado = numero1 / numero2;
                        return resultado;
                    }
            }
            return resultado;
        }

        /// <summary>
        /// Valida que el operador sea "-","*","/"
        /// </summary>
        /// <param name="operador"> operador a validar</param>
        /// <returns> Devuelve + en caso que el operador no sea "-", "+" o "/"</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            return "+";
        }
    }
}
