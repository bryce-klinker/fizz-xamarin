using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Fizzly.Shared;

namespace Fizzly.Droid
{
    [Activity(Label = "Fizzly", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private readonly FizzBuzz _fizzBuzz;
        private Button FizzBuzzButton => FindViewById<Button>(Resource.Id.FizzBuzz);
        private TextView FizzBuzzLabel => FindViewById<TextView>(Resource.Id.FizzBuzzValue);

        public MainActivity()
        {
            _fizzBuzz = new FizzBuzz(client: new HttpClient("http://10.0.0.2:5000"));
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            FizzBuzzButton.Click += onFizzBuzz;
        }

        private async void onFizzBuzz(object sender, EventArgs args)
        {
            FizzBuzzLabel.Text = (await _fizzBuzz.GetCurrent()).Evaluate();
        }
    }
}

