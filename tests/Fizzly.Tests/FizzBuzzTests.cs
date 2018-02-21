using System;
using Xunit;

namespace Fizzly.Tests
{
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        public FizzBuzzTests()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [Fact]
        public void ShouldReturnValueAsString() 
        {
            var value = _fizzBuzz.Evaluate(2);
            Assert.Equal("2", value);
        }

        [Fact]
        public void ShouldReturnFizz() 
        {
            var value = _fizzBuzz.Evaluate(3);
            Assert.Equal("Fizz", value);
        }

        [Fact]
        public void ShouldReturnBuzz() 
        {
            var value = _fizzBuzz.Evaluate(5);
            Assert.Equal("Buzz", value);
        }
    }
}
