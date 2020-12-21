using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WeatherCollector.IO;

namespace WeatherCollector.Timers
{
    public class ScheduleTimer
    {
        public FileManagement FileManagement { get; }

        public ScheduleTimer(IConfiguration configuration)
        {
            FileManagement = new FileManagement(configuration);

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);

            var timer = new System.Threading.Timer(async (e) =>
            {
                await CallMethodAsync();   
            }, null, startTimeSpan, periodTimeSpan);
        }
        
        public async Task CallMethodAsync()
        {
            await FileManagement.GetDataAsync();
        }
    }
}