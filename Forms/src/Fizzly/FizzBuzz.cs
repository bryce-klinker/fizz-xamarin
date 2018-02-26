using Newtonsoft.Json.Linq;

namespace Fizzly
{
    public class FizzBuzz
    {
        private readonly JObject _jObject;
        public int Value => _jObject.Value<int>("Value");

        public FizzBuzz(int value)
            : this(JObject.FromObject(new { Value = value }))
        {
            
        }

        public FizzBuzz(JObject jObject)
        {
            _jObject = jObject;
        }
        public string Evalate()
        {
            if (Value % 3 == 0 && Value % 5 == 0)
                return "FizzBuzz";

            if (Value % 5 == 0)
                return "Buzz";

            return Value % 3 == 0 ? "Fizz" : Value.ToString();
        }
    }
}
