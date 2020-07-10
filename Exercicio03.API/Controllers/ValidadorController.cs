using System;
using System.Collections.Generic;
using System.Linq;
using Exercicio03.API.Model;
using Exercicio03.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio03.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidadorController
    {
        private MultiploDeOnzeValidator _multiploDeOnze;

        public ValidadorController()
        {
            _multiploDeOnze = new MultiploDeOnzeValidator();
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