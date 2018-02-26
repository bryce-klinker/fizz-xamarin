using System.Windows.Input;
using Fizzly.Shared;
using Fizzly.Shared.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Fizzly
{
    public class FizzBuzzViewModel : PropertyChangedBase
    {
        public string Value { get; set; }
        public ICommand UpdateCommand { get; }

        public FizzBuzzViewModel()
        {
            UpdateCommand = new DelegateCommand(UpdateValue);
            Value = "";
        }

        private void UpdateValue()
        {
            Value = "Fizz";
        }
    }
}
