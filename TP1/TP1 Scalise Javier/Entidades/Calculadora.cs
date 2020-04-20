using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

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
