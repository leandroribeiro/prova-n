using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Exercicio03.API.Model;
using Exercicio03.API.Validations;
using Exercicio03.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Exercicio03.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidadorController
    {
        private readonly IMultiploDeOnzeValidator _multiploDeOnze;
        private readonly IDistributedCache _cache;

        public ValidadorController(IMultiploDeOnzeValidator multiploDeOnze, IDistributedCache cache)
        {
            _multiploDeOnze = multiploDeOnze;
            _cache = cache;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<MultiploDeOnzeResponse>), 200)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody] MultiploDeOnzeRequest model)
        {
            var validator = new MultiploDeOnzeRequestValidator();
            var validationResult = validator.Validate(model);
	
            if (!validationResult.IsValid)
            {
                //TODO
                return new BadRequestObjectResult(validationResult.Errors.First().ErrorMessage);
            }
            
            var result = model.numbers
                .Select(number => new MultiploDeOnzeResponse(number) {isMultiple = _multiploDeOnze.Validar(number)})
                .ToList();

            return new OkObjectResult(result);
        }

    }
}