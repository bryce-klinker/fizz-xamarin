using Newtonsoft.Json.Linq;

namespace Fizzly
{
    public class FizzBuzz
    {
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";

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
            if (IsFizz() && IsBuzz())
                return $"{Fizz}{Buzz}";

            if (IsBuzz())
                return Buzz;

            return IsFizz() ? Fizz : Value.ToString();
        }

        private bool IsFizz()
        {
            return Value % 3 == 0;
        }

        private bool IsBuzz()
        {
            return Value % 5 == 0;
        }
    }
}
