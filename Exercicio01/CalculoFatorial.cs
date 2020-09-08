using System.Linq;

namespace Exercicio01
{
    public class CalculoFatorial
    {
        public int Calcular(int numero)
        {
            return Enumerable.Range(1, numero).Aggregate(1, (p, item) => p * item);
        }
    }
}