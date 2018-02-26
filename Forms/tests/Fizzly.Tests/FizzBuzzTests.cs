using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Fizzly.Tests
{
    public class FizzBuzzTests
    {
        [Fact]
        public void ShouldReturnFizz()
        {
            var fizzBuzz = new FizzBuzz(JObject.FromObject(new { Value = 3 }));
            Assert.Equal("Fizz", fizzBuzz.Evalate());
        }

        [Fact]
        public void ShouldReturnValue()
        {
            var fizzBuzz = new FizzBuzz(JObject.FromObject(new { Value = 1 }));
            Assert.Equal("1", fizzBuzz.Evalate());
        }
    }
}
