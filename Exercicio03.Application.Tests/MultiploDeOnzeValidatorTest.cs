using System;
using System.Linq;
using Xunit;

namespace Exercicio03.Application.Tests
{
    public class MultiploDeOnzeValidatorTest
    {
        private IMultiploDeOnzeValidator validator;

        public MultiploDeOnzeValidatorTest()
        {
            this.validator = new MultiploDeOnzeValidator();
        }

        [Theory()]
        [InlineData(286, true)]
        [InlineData(1331, true)]
        [InlineData(14641, true)]
        [InlineData(24350, false)]
        [InlineData(94186565, true)]
        [InlineData(56568143, false)]
        public void Retornar_Verdadeiro_Quando_Numero_For_Multiplo_de_Onze(int numero, bool valido)
        {
            var resultado = this.validator.Validar(numero);
        
            Assert.Equal(valido, resultado);
        }
        
    }
}