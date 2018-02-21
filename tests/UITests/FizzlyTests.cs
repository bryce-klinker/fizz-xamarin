using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Fizzly.UITests.Gherkin;
using Fizzly.UITests.WebService;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Fizzly.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class FizzlyTests : GherkinTestFixture
    {
		private readonly Platform _platform;
        private IApp _app;
        private WebServiceServer _server;

        public FizzlyTests(Platform platform)
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
        public async Task SeeFizz()
        {
            try
            {
                await Given(ANumberWebServiceThatReturnsValueInJSONObject, 6);
                When(ITapTheFizzBuzzButton);
                Then(ISee, "Fizz");
            }
            finally
            {
                _server?.Dispose(); 
            }
        }

        private async Task ANumberWebServiceThatReturnsValueInJSONObject(int value) {
            await _server.Start();
            await _server.SetValue(value);
        }

        private void ITapTheFizzBuzzButton() {
            _app.Tap(b => b.Button("FizzBuzz"));
        }

        private void ISee(string value) {
            Assert.That(_app.Query(e => e.Text(value)).Any(), Is.True);
        }
    }
}
