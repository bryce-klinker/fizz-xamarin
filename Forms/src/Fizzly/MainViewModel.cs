using System.Threading.Tasks;
using System.Windows.Input;
using Fizzly.Shared;
using Fizzly.Shared.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Fizzly
{
    public class MainViewModel : PropertyChangedBase
    {
        private readonly FizzBuzzService _service;

        public string Value { get; set; }
        public ICommand FizzBuzzCommand { get; }

        public MainViewModel(IHttpClient httpClient)
        {
            _service = new FizzBuzzService(httpClient);
            FizzBuzzCommand = new DelegateCommand(UpdateValue);
            Value = "";
        }

        private async void UpdateValue()
        {
            var fizzBuzz = await _service.GetLatest();
            Value = fizzBuzz.Evalate();
        }
    }

    public class FizzBuzzService
    {
        private readonly IHttpClient _httpClient;

        public FizzBuzzService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FizzBuzz> GetLatest()
        {
            var response = await _httpClient.GetAsync("http://localhost:9000");
            var json = await response.Content.ReadAsStringAsync();
            var jObject = JsonConvert.DeserializeObject<JObject>(json);
            return new FizzBuzz(jObject);
        }
    }
}
