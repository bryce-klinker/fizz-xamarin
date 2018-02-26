using Fizzly.Tests.Fakes.Http;
using Xunit;

namespace Fizzly.Tests
{
    public class MainViewModelTests
    {
        private readonly FakeHttpClient _httpClient;
        private readonly MainViewModel _viewModel;

        public MainViewModelTests()
        {
            _httpClient = new FakeHttpClient();
            _viewModel = new MainViewModel(_httpClient);
        }

        [Fact]
        public void ShouldShowNoValue()
        {
            Assert.Equal("", _viewModel.Value);
        }

        [Fact]
        public void ShouldShowFizz()
        {
            _httpClient.SetupJsonResponse("http://localhost:9000", new {Value = 6});
            
            _viewModel.FizzBuzzCommand.Execute(null);
            Assert.Equal("Fizz", _viewModel.Value);
        }
        
        [Fact]
        public void ShouldShowValue()
        {
            _httpClient.SetupJsonResponse("http://localhost:9000", new {Value = 2});
            
            _viewModel.FizzBuzzCommand.Execute(null);
            Assert.Equal("2", _viewModel.Value);
        }
    }
}
