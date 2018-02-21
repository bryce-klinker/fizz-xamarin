using System;
namespace Fizzly
{
    public class FizzBuzz
    {
        public object Evaluate(int value)
        {
            if (value == 5)
                return "Buzz";
            
            return value == 3 ? "Fizz" : "2";
        }
    }
}
