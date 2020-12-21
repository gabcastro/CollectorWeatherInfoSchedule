using System;
using System.Collections.Generic;

namespace WeatherCollector.ViewModels.WeatherInfoViewModels
{
    public class ListWeatherInfoViewModel
    {
        public string City { get; set; }
        public List<(double, DateTime)> Temperature { get; set; }
    }
}