using System.Windows.Input;
using Fizzly.Shared;
using Fizzly.Shared.Http;

namespace Fizzly.FizzBuzz.ViewModels
{
    public class FizzBuzzViewModel : PropertyChangedBase
    {
        private readonly FizzBuzzService _service;

        public string Value { get; private set; } = "";
        public ICommand FizzBuzzCommand { get; }

        public FizzBuzzViewModel()
            : this(new HttpClient())
        {
            
        }

        public FizzBuzzViewModel(IHttpClient httpClient)
        {
            _service = new FizzBuzzService(httpClient);
            FizzBuzzCommand = new DelegateCommand(UpdateValue);
        }

        private async void UpdateValue()
        {
            var fizzBuzz = await _service.GetLatest();
            Value = fizzBuzz.Evalate();
            NotifyPropertyChanged(nameof(Value));
        }
    }
}
