using System.Windows.Input;
using Fizzly.Shared;
using Fizzly.Shared.Http;

namespace Fizzly
{
    public class MainViewModel : PropertyChangedBase
    {
        private readonly FizzBuzzService _service;

        public string Value { get; private set; } = "";
        public ICommand FizzBuzzCommand { get; }

        public MainViewModel()
            : this(new HttpClient())
        {
            
        }

        public MainViewModel(IHttpClient httpClient)
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
