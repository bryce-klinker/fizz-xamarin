using System;
using System.Threading.Tasks;
using Fizzly.Models;
using Fizzly.Tests.Fakes;
using Xunit;

namespace Fizzly.Tests
{
    public class FizzBuzzTests
    {
        [Fact]
        public void ShouldReturnValueAsString() 
        {
            var value = new FizzBuzz(2).Evaluate();
            Assert.Equal("2", value);
        }

        [Fact]
        public void ShouldReturnFizz() 
        {
            var value = new FizzBuzz(3).Evaluate();
            Assert.Equal("Fizz", value);
        }

        [Fact]
        public void ShouldReturnBuzz() 
        {
            var value = new FizzBuzz(5).Evaluate();
            Assert.Equal("Buzz", value);
        }

        [Fact]
        public async Task ShouldReturnCurrentFizzBuzzValue()
        {
            var client = new FakeHttpClient();
            client.SetupGet("http://localhost:5000", new FizzBuzz(54));

            var model = await new FizzBuzz(client: client).GetCurrent();
            Assert.Equal(54, model.Value);
        }
    }
}
