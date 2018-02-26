﻿using Xunit;

namespace Fizzly.Tests
{
    public class FizzBuzzTests
    {
        [Fact]
        public void ShouldReturnFizz()
        {
            var fizzBuzz = new FizzBuzz(3);
            Assert.Equal("Fizz", fizzBuzz.Evalate());
        }

        [Fact]
        public void ShouldReturnFizzIfValueIsDivisibleByThree()
        {
            var fizzBuzz = new FizzBuzz(9);
            Assert.Equal("Fizz", fizzBuzz.Evalate());
        }

        [Fact]
        public void ShouldReturnValue()
        {
            var fizzBuzz = new FizzBuzz(1);
            Assert.Equal("1", fizzBuzz.Evalate());
        }

        [Fact]
        public void ShouldReturnBuzz()
        {
            var fizzBuzz = new FizzBuzz(5);
            Assert.Equal("Buzz", fizzBuzz.Evalate());
        }

        [Fact]
        public void ShouldReturnBuzzIfValueIsDivisibleByFive()
        {
            var fizzBuzz = new FizzBuzz(10);
            Assert.Equal("Buzz", fizzBuzz.Evalate());
        }

        [Fact]
        public void ShouldReturnFizzBuzz()
        {
            var fizzBuzz = new FizzBuzz(15);
            Assert.Equal("FizzBuzz", fizzBuzz.Evalate());
        }

        [Fact]
        public void ShouldReturnFizzBuzzIfDivisibleByThreeAndFive()
        {
            var fizzBuzz = new FizzBuzz(30);
            Assert.Equal("FizzBuzz", fizzBuzz.Evalate());
        }
    }
}
