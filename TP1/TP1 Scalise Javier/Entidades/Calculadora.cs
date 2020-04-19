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
            //switch para cada caso de operacion
            double resultado = numero1 + numero2;
            return resultado;
        }

        private static string ValidarOperador(string operador)
        {
            return "+";
        }
    }
}
