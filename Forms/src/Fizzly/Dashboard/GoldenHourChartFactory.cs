using System;
using Fizzly.Dashboard.Models;
using Fizzly.Shared.Styles;
using Microcharts;
using SkiaSharp;

namespace Fizzly.Dashboard
{
    public interface IGoldenHourChartFactory
    {
        Chart Create(DashboardModel model);
    }

    public class GoldenHourChartFactory : IGoldenHourChartFactory
    {
        public Chart Create(DashboardModel model) 
        {

            return new RadialGaugeChart
            {
                Entries = new []
                {
                    new Entry(0) { Color = SKColor.Parse(Colors.Primary) },
                    new Entry(25) { Color = SKColor.Parse(Colors.Primary) },
                    new Entry(50) { Color = SKColor.Parse(Colors.Primary) }
                },
                BackgroundColor = SKColor.Parse("#222222"),
                StartAngle = (float)(-Math.PI * 0.8)
            };
        }
    }
}
