using System.Windows.Input;
using Fizzly.Dashboard.Models;
using Fizzly.Shared;

namespace Fizzly.Dashboard.ViewModels
{
    public class DashboardViewModel : PropertyChangedBase
    {
        private readonly IDashboardService _service;

        public DashboardModel Dashboard { get; private set; }

        public ICommand RefreshCommand { get; }

        public DashboardViewModel()
            : this(new DashboardService())
        {

        }

        public DashboardViewModel(IDashboardService service) 
        {
            _service = service;
            RefreshCommand = new DelegateCommand(() => Refresh());
        }

        private async void Refresh() 
        {
            var model = await _service.GetLatest();
            Dashboard = model;
            NotifyPropertyChanged(nameof(Dashboard));
        }
    }
}
