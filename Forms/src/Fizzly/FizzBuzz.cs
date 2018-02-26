using Newtonsoft.Json.Linq;

namespace Fizzly
{
    public class FizzBuzz
    {
        private readonly JObject _jObject;
        public int Value => _jObject.Value<int>("Value");
        
        public FizzBuzz(JObject jObject)
        {
            _jObject = jObject;
        }
        public string Evalate()
        {
            return Value % 3 == 0 ? "Fizz" : Value.ToString();
        }
    }
}
