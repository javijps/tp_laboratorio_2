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
                        resultado = 1 + 1;//numero1 + numero2
                        return resultado;
                    }
                case "-":
                    {
                        resultado = 1 - 1;//numero1 - numero2
                        return resultado;
                    }
                case "*":
                    {
                        resultado = 1 * 1;//numero1 * numero 2
                        return resultado;
                    }
                case "/":
                    {
                        if(1!=0)// en 1 va numero2!=0 xq no se puede dividir por 0
                        {
                            resultado = 1 / 1;//numero1 / numero2
                        }
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
