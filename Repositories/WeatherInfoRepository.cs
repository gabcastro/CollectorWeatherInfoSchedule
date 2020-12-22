using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using WeatherCollector.ViewModels.WeatherInfoViewModels;

namespace WeatherCollector.Repositories
{
    public class WeatherInfoRepository
    {
        private readonly IConfiguration _configuration;
        public string FileDir { get; }
        public ListWeatherInfoViewModel ListWeatherViewModel { get; }

        public WeatherInfoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            FileDir = _configuration.GetValue<string>("WinFileDir");

            ListWeatherViewModel = new ListWeatherInfoViewModel();
        }

        public ListWeatherInfoViewModel GetInfoCity(string city, string start_date, string end_date)
        {
            try
            {
                ListWeatherViewModel.City = city;
                using StreamReader sr = new StreamReader(FileDir);
                while (sr.Peek() >= 0)
                {
                    string str;
                    string[] strArry;
                    str = sr.ReadLine();

                    strArry = str.Split(';');

                    if (strArry[1].Equals(city) && Convert.ToDateTime(strArry[3]) >= Convert.ToDateTime(start_date) && Convert.ToDateTime(strArry[3]) <= Convert.ToDateTime(end_date))
                    {
                        var element = string.Format("{0} - {1}", strArry[2], strArry[3]);
                        ListWeatherViewModel.Temperature.Add(element);
                    }
                }

                return ListWeatherViewModel;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                
                throw e;
            }
        }
    }
}