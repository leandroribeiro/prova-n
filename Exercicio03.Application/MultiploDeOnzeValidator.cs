using System.ComponentModel;

namespace Exercicio03.Application
{
    public class MultiploDeOnzeValidator
    {
        public bool Validar(int numero)
        {
            var numeroString = numero.ToString();
            var substracao = numero;

            while (numeroString.Length > 2)
            {
                var tamanho = numeroString.Length;
                var algarismos = numeroString.Substring(0, tamanho - 1);
                var ultimoAlgarismo = numeroString.Substring(tamanho - 1, 1);

                var algarismosValor = int.Parse(algarismos);
                var ultimoAlgarimosValor = int.Parse(ultimoAlgarismo);

                substracao = algarismosValor - ultimoAlgarimosValor;
                numeroString = substracao.ToString();
            }

            return substracao % 11 == 0;
        }

        public bool Validar(string number)
        {
            if (int.TryParse(number, out var valorNumerico))
            {
                return this.Validar(valorNumerico);
            }

            throw new System.InvalidCastException();
        }
    }
}