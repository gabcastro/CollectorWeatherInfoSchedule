using System;

namespace WeatherCollector.Timers
{
    public class ScheduleTimer
    {
        public ScheduleTimer()
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(1);

            var timer = new System.Threading.Timer((e) =>
            {
                Your_method();   
            }, null, startTimeSpan, periodTimeSpan);
        }
        
        public void Your_method()
        {
            Console.WriteLine("teste timer");
        }
    }
}