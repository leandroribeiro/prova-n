using System.Linq;
using Xunit;

namespace Exercicio01.Test
{
    public class ProvaTest
    {
        private CalculoDesconhecido _calculoDesconhecido;
        private CalculoFatorial _calculoFatorial;
        private CalculoAoQuadrado _calculoAoQuadrado;
        private CalculoSomatorio _calculoSomatorio;

        public ProvaTest()
        {
            _calculoAoQuadrado = new CalculoAoQuadrado();
            _calculoSomatorio = new CalculoSomatorio();
            _calculoDesconhecido = new CalculoDesconhecido();
            _calculoFatorial = new CalculoFatorial();
        }

        [Theory()]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void Retornar_Fatorial_Quando_Numero_Inteiro_Positivo(int numero)
        {
            var resultado = _calculoDesconhecido.Calcular(numero);

            var esperado = _calculoFatorial.Calcular(numero);
            
            Assert.Equal(esperado, resultado);
        }
        
        [Theory()]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void Retornar_AoQuadrado_Quando_Numero_Inteiro_Positivo(int numero)
        {
            var resultado = _calculoDesconhecido.Calcular(numero);

            var esperado = _calculoAoQuadrado.Calcular(numero);
            
            Assert.Equal(esperado, resultado);
        }
        
        [Theory()]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void Retornar_Somatorio_Quando_Numero_Inteiro_Positivo(int numero)
        {
            var resultado = _calculoDesconhecido.Calcular(numero);

            var esperado = _calculoSomatorio.Calcular(numero);
            
            Assert.Equal(esperado, resultado);
        }
        
        [Theory()]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void Retornar_Somatorio_Numeros_Pares_Quando_Numero_Inteiro_Positivo(int numero)
        {
            var resultado = _calculoDesconhecido.Calcular(numero);

            var esperado = Enumerable.Range(0, numero).Where(x=>x%2 == 0).Sum();
            
            Assert.Equal(esperado, resultado);
        }
        
        [Theory()]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void Retornar_Dois_Elevado_Ao_Numero_Quando_Numero_Inteiro_Positivo(int numero)
        {
            var resultado = _calculoDesconhecido.Calcular(numero);

            var esperado = Enumerable.Range(0, numero).Where(x=>x%2 == 0).Sum();
            
            Assert.Equal(esperado, resultado);
        }
        
    }
}
