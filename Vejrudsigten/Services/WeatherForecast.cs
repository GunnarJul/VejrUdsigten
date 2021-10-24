using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vejrudsigten.Services
{
    public static class WeatherForecast
    {
        public static async Task<string[]> GetForecastAsync(string key)
        {
            WeatherService service = new WeatherService();
            var todayInfo = await service.GetTodaysWeather(key, "Kolding");
            var yesterdayInfo = await service.GetYesterdaysWeather(key, "Kolding");
            string headLine = todayInfo.DescribeTemperatureChange(yesterdayInfo);
            var description = $"Vejret i Kolding er {todayInfo.Conditions} og der er {todayInfo.Temperature} grader. I går var det {yesterdayInfo.Conditions} og {yesterdayInfo.Temperature} grader";
            return  new string[2]{ headLine, description} ;
        }
      
    }
}
