using System.Linq;
using FizzlyUI.Tests.Gherkin;
using FizzlyUI.Tests.WebService;
using NUnit.Framework;
using Xamarin.UITest;

namespace FizzlyUI.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class FizzlyTests : GherkinTest
    {
        private IApp app;
        private Platform platform;
        private WebServiceServer _server;

        public FizzlyTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void Setup()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            Given(ANumberWebServiceThatReturnsValueInJSONObject, 6);
            When(ITapTheFizzBuzzButton);
            Then(ISee, "Fizz");
        }

        [TearDown]
        public void Teardown() {
            _server.Dispose();
        }

        private void ANumberWebServiceThatReturnsValueInJSONObject(int value) {
            _server.Start();
            _server.SetValue(value);
        }

        private void ITapTheFizzBuzzButton() {
            app.Tap(q => q.Button().Id("Update"));
        }

        private void ISee(string value) {
            var label = app.Query(q => q.Text(value));
            Assert.That(label.Any(), Is.True);
        }
    }
}
