using System.Linq;

namespace Exercicio01
{
    public class CalculoSomatorio
    {
        public int Calcular(int numero)
        {
            return Enumerable.Range(0, numero).Sum();
        }
    }
}