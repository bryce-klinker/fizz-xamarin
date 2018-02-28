using System;
using System.Threading.Tasks;
using Fizzly.Dashboard.Models;
using Fizzly.Shared.Http;

namespace Fizzly.Dashboard
{
    public interface IDashboardService 
    {
        Task<DashboardModel> GetLatest();
    }

    public class DashboardService : IDashboardService
    {
        public async Task<DashboardModel> GetLatest() 
        {
            await Task.Delay(2000);
            return new DashboardModel
            {

            };
        }
    }
}
