﻿using System.Threading.Tasks;
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
        public void ShouldReturnValueIfNotFizzOrBuzz() 
        {
            var value = new FizzBuzz(14).Evaluate();
            Assert.Equal("14", value);
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
        public void ShouldReturnFizzWhenDivisibleByThree()
        {
            var value = new FizzBuzz(6).Evaluate();
            Assert.Equal("Fizz", value);
        }

        [Fact]
        public void ShouldReturnBuzzWhenDivisibleByFive()
        {
            var value = new FizzBuzz(10).Evaluate();
            Assert.Equal("Buzz", value);
        }

        [Fact]
        public void ShouldReturnFizzBuzz() 
        {
            var value = new FizzBuzz(15).Evaluate();
            Assert.Equal("FizzBuzz", value);
        }

        [Fact]
        public void ShouldReturnFizzBuzzWhenDivisibleByThreeAndFive() 
        {
            var value = new FizzBuzz(30).Evaluate();
            Assert.Equal("FizzBuzz", value);
        }

        [Fact]
        public async Task ShouldReturnCurrentFizzBuzzValue()
        {
            var client = new FakeHttpClient();
            client.SetupGet("", new FizzBuzz(54));

            var model = await new FizzBuzz(client: client).GetCurrent();
            Assert.Equal(54, model.Value);
        }
    }
}
