using Fizzly.Dashboard.ViewModels;
using Xamarin.Forms;

namespace Fizzly.Dashboard.Views
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is DashboardViewModel)
                (BindingContext as DashboardViewModel).RefreshCommand.Execute(null);
        }
    }
}
