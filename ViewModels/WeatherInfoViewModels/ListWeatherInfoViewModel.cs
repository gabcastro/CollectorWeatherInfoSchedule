using System.Collections.Generic;

namespace WeatherCollector.ViewModels.WeatherInfoViewModels
{
    public class ListWeatherInfoViewModel
    {
        public string City { get; set; }
        public List<string> Temperature { get; set; }
        
        public ListWeatherInfoViewModel()
        {
            Temperature = new List<string>();
        }
    }
}