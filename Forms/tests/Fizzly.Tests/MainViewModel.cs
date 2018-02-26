using Fizzly.Tests.Fakes.Http;
using Xunit;

namespace Fizzly.Tests
{
    public class MainViewModel
    {
        [Fact]
        public void ShouldShowNoValue()
        {
            var viewModel = new FizzBuzzViewModel(new FakeHttpClient());
            Assert.Equal("", viewModel.Value);
        }

        [Fact]
        public void ShouldShowFizz()
        {
            var client = new FakeHttpClient();
            client.SetupJsonResponse("http://localhost:9000", new {Value = 6});
            
            var viewModel = new FizzBuzzViewModel(client);
            viewModel.FizzBuzzCommand.Execute(null);
            Assert.Equal("Fizz", viewModel.Value);
        }

        [Fact]
        public void ShouldShowValue()
        {
            var client = new FakeHttpClient();
            client.SetupJsonResponse("http://localhost:9000", new {Value = 2});
            
            var viewModel = new FizzBuzzViewModel(client);
            viewModel.FizzBuzzCommand.Execute(null);
            Assert.Equal("2", viewModel.Value);
        }
    }
}
