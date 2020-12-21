using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WeatherCollector.Models;

namespace WeatherCollector.IO
{
    public class FileManagement
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        public string ApiKey { get; }
        public List<string> Cities { get; }
        
        public FileManagement(IConfiguration configuration)
        {
            _configuration = configuration;

            ApiKey = _configuration.GetValue<string>("OpenWeatherKey");
            Cities = _configuration.GetSection("Cities").Get<List<string>>();

            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api.openweathermap.org/")
            };
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        public async Task GetDataAsync()
        {
            foreach (var item in Cities)
            {
                string path = string.Format("data/2.5/weather?q={0}&appid={1}&units=metric", item, ApiKey);
                
                HttpResponseMessage response = await _client.GetAsync(path);

                var jsonData = await response.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(jsonData);
                var tempJson = parsedObject["main"].ToString();
                var content = JsonConvert.DeserializeObject<Temperature>(tempJson);
            }
        }
    }
}