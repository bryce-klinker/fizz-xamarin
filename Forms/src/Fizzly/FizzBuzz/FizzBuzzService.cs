using System.Threading.Tasks;
using Fizzly.Shared.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Fizzly.FizzBuzz
{
    public class FizzBuzzService
    {
        private readonly IHttpClient _httpClient;

        public FizzBuzzService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FizzBuzz> GetLatest()
        {
            var response = await _httpClient.GetAsync("http://localhost:5000");
            var json = await response.Content.ReadAsStringAsync();
            var jObject = JsonConvert.DeserializeObject<JObject>(json);
            return new FizzBuzz(jObject);
        }
    }
}