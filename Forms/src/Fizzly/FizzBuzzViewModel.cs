using System.Windows.Input;
using Fizzly.Shared;
using Fizzly.Shared.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Fizzly
{
    public class FizzBuzzViewModel : PropertyChangedBase
    {
        private readonly IHttpClient _httpClient;
        private readonly FizzBuzz _fizzBuzz;
        public string Value { get; set; }
        public ICommand FizzBuzzCommand { get; }

        public FizzBuzzViewModel(IHttpClient httpClient)
        {
            _fizzBuzz = new FizzBuzz();
            _httpClient = httpClient;
            FizzBuzzCommand = new DelegateCommand(UpdateValue);
            Value = "";
        }

        private async void UpdateValue()
        {
            var response = await _httpClient.GetAsync("http://localhost:9000");
            var json = await response.Content.ReadAsStringAsync();
            var jObject = JsonConvert.DeserializeObject<JObject>(json);
            Value = _fizzBuzz.Evalate(jObject.Value<int>("Value"));
        }
    }
}
