using System;
using Xunit;

namespace Fizzly.Tests
{
    public class FizzBuzzTests
    {
        [Fact]
        public void ShouldReturnValueAsString() 
        {
            var fizzBuzz = new FizzBuzz();

            var value = fizzBuzz.Evaluate(2);
            Assert.Equal("2", value);
        }

        [Fact]
        public void ShouldReturnFizz() 
        {
            var fizzBuzz = new FizzBuzz();

            var value = fizzBuzz.Evaluate(3);
            Assert.Equal("Fizz", value);
        }
    }
}
