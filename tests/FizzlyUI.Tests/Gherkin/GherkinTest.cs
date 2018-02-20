using System;
namespace FizzlyUI.Tests.Gherkin
{
    public class GherkinTest
    {
        public GherkinTest()
        {
        }

        protected void Given(Action action) {
            action();
        }

        protected void Given<T>(Action<T> action, T value) {
            action(value);
        }

        protected void When(Action action) {
            action();
        }

        protected void When<T>(Action<T> action, T value) {
            action(value);
        }

        protected void Then(Action action) {
            action();
        }

        protected void Then<T>(Action<T> action, T value) {
            action(value);
        }
    }
}
