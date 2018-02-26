// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Fizzly.iOS
{
    [Register ("ViewController")]
    partial class FizzBuzzController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FizzBuzzLabel { get; set; }

        [Action ("onFizzBuzz:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void OnFizzBuzz (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (Button != null) {
                Button.Dispose ();
                Button = null;
            }

            if (FizzBuzzLabel != null) {
                FizzBuzzLabel.Dispose ();
                FizzBuzzLabel = null;
            }
        }
    }
}