using System;
namespace Fizzly.Models
{
    public class FizzBuzzValue
    {
        public int Value { get; }

        public FizzBuzzValue(int value)
        {
            Value = value;
        }

        public static FizzBuzzValue FromString(string value) {
            return new FizzBuzzValue(Convert.ToInt32(value));
        }
    }
}
