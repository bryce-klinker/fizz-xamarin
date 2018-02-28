using System.Windows.Input;
using Fizzly.Dashboard.Models;
using Fizzly.Shared;
using Microcharts;

namespace Fizzly.Dashboard.ViewModels
{
    public class DashboardViewModel : PropertyChangedBase
    {
        private readonly IDashboardService _service;
        private readonly IGoldenHourChartFactory _goldenHourChartFactory;

        private Chart _goldenHourChart;
        public Chart GoldenHourChart 
        {
            get => _goldenHourChart;
            private set
            {
                _goldenHourChart = value;
                NotifyPropertyChanged(nameof(GoldenHourChart));
            }
        }

        private bool _isLoading;
        public bool IsLoading 
        {
            get => _isLoading;
            private set 
            {
                _isLoading = value;
                NotifyPropertyChanged(nameof(IsLoading));
            }
        }

        public ICommand RefreshCommand { get; }

        public DashboardViewModel()
            : this(new DashboardService(), new GoldenHourChartFactory())
        {

        }

        public DashboardViewModel(IDashboardService service, IGoldenHourChartFactory goldenHourChartFactory) 
        {
            _service = service;
            _goldenHourChartFactory = goldenHourChartFactory;
            RefreshCommand = new DelegateCommand(() => Refresh());
        }

        private async void Refresh() 
        {
            IsLoading = true;
            var model = await _service.GetLatest();
            GoldenHourChart = _goldenHourChartFactory.Create(model);
            IsLoading = false;
        }
    }
}
