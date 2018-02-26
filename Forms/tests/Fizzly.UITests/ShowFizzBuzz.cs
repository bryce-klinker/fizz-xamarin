using System.Linq;
using System.Threading.Tasks;
using Fizzly.UITests.WebService;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Fizzly.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class ShowFizzBuzz
    {
        private readonly Platform _platform;
        private IApp _app;
        private WebServiceServer _server;

        public ShowFizzBuzz(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void Setup()
        {
            _server = new WebServiceServer();
            _app = AppInitializer.StartApp(_platform);
        }

        [Test]
        public async Task ShouldShowFizz()
        {
            await GivenANumberWebServiceThatReturnsValueInAJsonObject(6);
            WhenITapTheFizzBuzzButton();
            ThenISeeFizz();
        }

        [TearDown]
        public void TearDown()
        {
            _server?.Dispose();
        }

        private async Task GivenANumberWebServiceThatReturnsValueInAJsonObject(int value)
        {
            await _server.Start();
            await _server.SetValue(value);
        }

        private void ThenISeeFizz()
        {
            Assert.That(GetFizzBuzzLabel().Text, Contains.Substring("Fizz"));
        }

        private AppResult GetFizzBuzzLabel()
        {
            return _app.Query(t => t.Id("FizzBuzzLabel")).First();
        }

        private void WhenITapTheFizzBuzzButton()
        {
            _app.Tap(q => q.Button("FizzBuzzButton"));
        }
    }
}

