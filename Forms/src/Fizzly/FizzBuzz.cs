using Newtonsoft.Json.Linq;

namespace Fizzly
{
    public class FizzBuzz
    {
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";
        
        public int Value { get; }

        public FizzBuzz(int value)
        {
            Value = value;
        }

        public FizzBuzz(JToken jObject)
            : this(jObject.Value<int>("Value"))
        {
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
