using System;
using System.Threading.Tasks;

namespace Fizzly.UITests.Gherkin
{
    public class GherkinTestFixture
    {
        public void Given(Action action) {
            action();
        }

        public void Given<T>(Action<T> action, T value)
        {
            action(value);
        }

        public async Task Given<T>(Func<T, Task> action, T value) {
            await action(value);
        }

        public void When(Action action) {
            action();
        }

        public void Then<T>(Action<T> action, T value) {
            action(value);
        }
    }
}
