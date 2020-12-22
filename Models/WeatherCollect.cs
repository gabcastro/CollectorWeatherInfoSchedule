using System;

namespace WeatherCollector.Models
{
    public class WeatherCollect
    {
        public int Id { get; set; }
        public string City { get; set; }
        public double Temperature { get; set; }
        public DateTime DateTime { get; set; }

        public override string ToString() => $"{Id};{City};{Temperature};{DateTime:dd/MM/yyyy}";
    }
}