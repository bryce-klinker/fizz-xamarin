using System;
using System.Threading.Tasks;
using Fizzly.Models;
using Fizzly.Shared;
using Newtonsoft.Json;

namespace Fizzly
{
    public class FizzBuzz
    {
        readonly IHttpClient _client;

        public int Value { get; }

        public FizzBuzz(int value = 0, IHttpClient client = null)
        {
            _client = client;
            Value = value;
        }

        public string Evaluate()
        {
            if (Value == 5)
                return "Buzz";
            
            return Value == 3 ? "Fizz" : "2";
        }

        public async Task<FizzBuzz> GetCurrent()
        {
            var response = await _client.GetAsync("http://localhost:5000");
            var json = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<FizzBuzzModel>(json);
            return new FizzBuzz(model.Value, _client);
        }
    }
}
