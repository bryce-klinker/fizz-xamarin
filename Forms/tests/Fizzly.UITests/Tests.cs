using NUnit.Framework;
using Xamarin.UITest;

namespace Fizzly.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        private IApp _app;
        private readonly Platform _platform;

        public Tests(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _app = AppInitializer.StartApp(_platform);
        }

        [Test]
        public void AppLaunches()
        {
            _app.Screenshot("First screen.");
        }
    }
}

