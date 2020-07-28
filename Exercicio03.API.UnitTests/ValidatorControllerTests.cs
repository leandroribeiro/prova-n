using Exercicio03.API.Controllers;
using Exercicio03.API.Model;
using Exercicio03.Application;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Exercicio03.API.UnitTests
{
    public class ValidatorControllerTests
    {
        private readonly MultiploDeOnzeValidator _service;
        private readonly ValidadorController _controller;
        private readonly IDistributedCache _cache;
        
        public ValidatorControllerTests()
        {
            var opts = Options.Create(new MemoryDistributedCacheOptions());
            _cache = new MemoryDistributedCache(opts);
            
            _service = new MultiploDeOnzeValidator();
            _controller = new ValidadorController(_service, _cache);
        }

        [Theory]
        [InlineData("1", "10", "11")]
        public void Retornar_Sucesso_Quando_Passado_Array_De_Inteiros(params string[] numeros)
        {
            // Arrange
            var request = new MultiploDeOnzeRequest(){numbers = numeros};
            
            // Act
            var result = _controller.Post(request);
            
            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.StatusCode.Should().Be(200);
        }
    }
}