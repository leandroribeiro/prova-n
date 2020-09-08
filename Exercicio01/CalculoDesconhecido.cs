using System;

namespace Exercicio01
{
    public class CalculoDesconhecido
    {
        public int Calcular(int numero)
        {
            if (numero == 0)
                return 0;
            else
            {
                return numero * 2 - 1 + Calcular(numero - 1);
            }
        }
    }
}