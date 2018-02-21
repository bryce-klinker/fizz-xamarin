using System;
using System.Threading.Tasks;
using Fizzly.Models;
using Fizzly.Tests.Fakes;
using Xunit;

namespace Fizzly.Tests
{
    public class FizzBuzzTests
    {
        private FakeHttpClient _client;
        private FizzBuzz _fizzBuzz;

        public FizzBuzzTests()
        {
            _client = new FakeHttpClient();
            _fizzBuzz = new FizzBuzz(client: _client);
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

        [Fact]
        public async Task ShouldReturnCurrentFizzBuzzValue()
        {
            _client.SetupGet("http://localhost:5000", new FizzBuzz(54));

            var model = await _fizzBuzz.GetCurrent();
            Assert.Equal(54, model.Value);
        }
    }
}
