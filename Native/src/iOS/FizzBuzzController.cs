using System;

using UIKit;

namespace Fizzly.iOS
{
    public partial class FizzBuzzController : UIViewController
    {
        private readonly FizzBuzz _fizzBuzz;

        public FizzBuzzController(IntPtr handle) : base(handle)
        {
            _fizzBuzz = new FizzBuzz();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        async partial void OnFizzBuzz(UIButton sender)
        {
            var fizzBuzz = await _fizzBuzz.GetCurrent();
            FizzBuzzLabel.Text = fizzBuzz.Evaluate();
        }
    }
}
