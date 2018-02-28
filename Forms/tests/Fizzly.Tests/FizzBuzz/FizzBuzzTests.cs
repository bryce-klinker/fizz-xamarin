using Xunit;

namespace Fizzly.Tests.FizzBuzz
{
    public class FizzBuzzTests
    {
        [Fact]
        public void ShouldReturnFizz()
        {
            var fizzBuzz = new Fizzly.FizzBuzz.FizzBuzz(3);
            Assert.Equal("Fizz", fizzBuzz.Evalate());
        }

        [Fact]
        public void ShouldReturnFizzIfValueIsDivisibleByThree()
        {
            var fizzBuzz = new Fizzly.FizzBuzz.FizzBuzz(9);
            Assert.Equal("Fizz", fizzBuzz.Evalate());
        }

        [Fact]
        public void ShouldReturnValue()
        {
            var fizzBuzz = new Fizzly.FizzBuzz.FizzBuzz(1);
            Assert.Equal("1", fizzBuzz.Evalate());
        }

        [Fact]
        public void ShouldReturnBuzz()
        {
            var fizzBuzz = new Fizzly.FizzBuzz.FizzBuzz(5);
            Assert.Equal("Buzz", fizzBuzz.Evalate());
        }

        [Fact]
        public void ShouldReturnBuzzIfValueIsDivisibleByFive()
        {
            var fizzBuzz = new Fizzly.FizzBuzz.FizzBuzz(10);
            Assert.Equal("Buzz", fizzBuzz.Evalate());
        }

        [Fact]
        public void ShouldReturnFizzBuzz()
        {
            var fizzBuzz = new Fizzly.FizzBuzz.FizzBuzz(15);
            Assert.Equal("FizzBuzz", fizzBuzz.Evalate());
        }

        [Fact]
        public void ShouldReturnFizzBuzzIfDivisibleByThreeAndFive()
        {
            var fizzBuzz = new Fizzly.FizzBuzz.FizzBuzz(30);
            Assert.Equal("FizzBuzz", fizzBuzz.Evalate());
        }
    }
}
