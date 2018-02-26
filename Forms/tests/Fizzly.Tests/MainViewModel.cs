using Fizzly.Tests.Fakes.Http;
using Xunit;

namespace Fizzly.Tests
{
    public class MainViewModel
    {
        [Fact]
        public void ShouldShowNoValue()
        {
            var viewModel = new FizzBuzzViewModel();
            Assert.Equal("", viewModel.Value);
        }

        [Fact]
        public void ShouldShowFizz()
        {
            var client = new FakeHttpClient();
            client.SetupJsonResponse("http://localhost:9000", new {Value = 6});
            
            var viewModel = new FizzBuzzViewModel();
            viewModel.FizzBuzzCommand.Execute(null);
            Assert.Equal("Fizz", viewModel.Value);
        }
    }
}
