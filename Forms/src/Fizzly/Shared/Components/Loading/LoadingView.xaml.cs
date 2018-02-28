using System;
using System.Collections.Generic;
using Fizzly.Shared.Styles;
using Xamarin.Forms;

namespace Fizzly.Shared.Components.Loading
{
    public partial class LoadingView : ContentView
    {
        public LoadingView()
        {
            InitializeComponent();
            Indicator.Color = Colors.PrimaryColor;
        }
    }
}
