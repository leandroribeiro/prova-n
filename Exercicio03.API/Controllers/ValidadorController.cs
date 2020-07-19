using System.Collections.Generic;
using Exercicio03.API.Model;
using Exercicio03.Application;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio03.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidadorController
    {
        private readonly IMultiploDeOnzeValidator _multiploDeOnze;

        public ValidadorController(IMultiploDeOnzeValidator multiploDeOnze)
        {
            _multiploDeOnze = multiploDeOnze;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<MultiploDeOnzeResponse>), 200)]
        public IActionResult Post([FromBody] MultiploDeOnzeRequest model)
        {
            var result = new List<MultiploDeOnzeResponse>();

            foreach (var number in model.numbers)
            {
                result.Add(new MultiploDeOnzeResponse(number)
                {
                    isMultiple = _multiploDeOnze.Validar(number)
                });
            }


            return new OkObjectResult(result);
        }
    }
}