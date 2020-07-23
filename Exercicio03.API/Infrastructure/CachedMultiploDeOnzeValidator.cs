using System.Text;
using Exercicio03.Application;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Exercicio03.API.Infrastructure
{
    public class CachedMultiploDeOnzeValidator : IMultiploDeOnzeValidator
    {
        private readonly IMultiploDeOnzeValidator _multiploDeOnze;
        private readonly IDistributedCache _cache;

        public CachedMultiploDeOnzeValidator(IMultiploDeOnzeValidator multiploDeOnze, IDistributedCache cache)
        {
            _multiploDeOnze = multiploDeOnze;
            _cache = cache;
        }
        public bool Validar(int numero)
        {
            var cachedData = _cache.Get(numero.ToString());
                
            if (cachedData != null)
            {
                var binaryData = Encoding.UTF8.GetString(cachedData);
                var resultItem = JsonConvert.DeserializeObject<bool>(binaryData);
                    
                return resultItem;
            }
            else
            {
                var isMultiple = _multiploDeOnze.Validar(numero);

                var serializeData = JsonConvert.SerializeObject(isMultiple);
                var binaryData = Encoding.UTF8.GetBytes(serializeData);

                _cache.SetAsync(numero.ToString(), binaryData);

                return isMultiple;
            }
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