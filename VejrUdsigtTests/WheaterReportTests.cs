using System;
using Vejrudsigten.Services;
using Vejrudsigten.Services.Enum;
using Xunit;

namespace VejrUdsigtTests
{
    public class WheaterReportTests
    {
        [Theory]
        [InlineData(-12, (int)WeatherType.Arktiske)]
        [InlineData(-11, (int)WeatherType.Arktiske)]
        [InlineData(-10, (int)WeatherType.Vinterlige )]
        [InlineData(-1, (int)WeatherType.Vinterlige)]
        [InlineData(0, (int)WeatherType.IkkeBeskrevet )]
        [InlineData(20, (int)WeatherType.Sommerlige) ]
        [InlineData(29, (int)WeatherType.Sommerlige)]
        [InlineData(30, (int)WeatherType.Tropiske )]
        [InlineData(31, (int)WeatherType.Tropiske)]
        public void Dagens_temperatur_beskriver_klima_type(double temperature, int wheaterType)
        {
            //arrange
            var  weatherInfo = new WeatherInfo { Conditions = "", Temperature = temperature };
            var expected = (WeatherType)wheaterType;
            
            // act
            var type = weatherInfo.TemperatureType;

            //assert
            Assert.Equal(expected, type);
        }

        [Theory]
        [InlineData(0, -11, (int)TemperatureTendency.VerySignificantDescreasing)]
        [InlineData(0, -12, (int)TemperatureTendency.VerySignificantDescreasing)]
        [InlineData(0, -10, (int)TemperatureTendency.SignificantDescreasing)]
        [InlineData(0, -4, (int)TemperatureTendency.SignificantDescreasing)]
        [InlineData(0, -3, (int)TemperatureTendency.Descreasing)]
        [InlineData(0, -1.1, (int)TemperatureTendency.Descreasing)]
        [InlineData(0, -1, (int)TemperatureTendency.NoChange)]
        [InlineData(0, 1, (int)TemperatureTendency.NoChange)]
        [InlineData(0, 2, (int)TemperatureTendency.Increasing)]
        [InlineData(0, 3, (int)TemperatureTendency.Increasing)]
        [InlineData(0, 4, (int)TemperatureTendency.SignificantIncreasing)]
        [InlineData(0, 10, (int)TemperatureTendency.SignificantIncreasing)]
        [InlineData(0, 11, (int)TemperatureTendency.VerySignificantIncreasing)]
        [InlineData(0, 12, (int)TemperatureTendency.VerySignificantIncreasing)]
        public void Temperaturens_udvikling_beskrives_korrekt(double yesterdayTempeture , double todayTempeture, int tempetureTendency)
        {
            //arrange
            var weatherInfoYesterday = new WeatherInfo { Conditions = "", Temperature = yesterdayTempeture };
            var weatherInfoToday = new WeatherInfo { Conditions = "", Temperature = todayTempeture };
            var expected = (TemperatureTendency)tempetureTendency;

            // act
            var result = weatherInfoToday.TemperatureChange(weatherInfoYesterday);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Klart vejr", (int) RepeatingWheatherType.SunIsStaying )]
        [InlineData("Skyet", (int)RepeatingWheatherType.CloudIsStaying)]
        [InlineData("Regn", (int)RepeatingWheatherType.RainIsStaying)]
        [InlineData("Sne", (int)RepeatingWheatherType.SnowIsStaying)]
        [InlineData("Andet", (int)RepeatingWheatherType.DollWheatherIsStaying )]
        public void Vejret_er_det_samme_som_i_går_beskrivelse_korrekt(string wheatherType, int repeatWheater)
        {
            //arrange
            var weatherInfoYesterday = new WeatherInfo { Conditions = wheatherType, Temperature = 0};
            var weatherInfoToday = new WeatherInfo { Conditions = wheatherType, Temperature = 0 };
            var extpected = (RepeatingWheatherType)repeatWheater;
            
            //act
            var result = weatherInfoToday.DescribeTemperatureChange(weatherInfoYesterday);
            //assert
            Assert.Equal(extpected.ToDescription(), result);
        }


        [Theory]
        [InlineData("Klart vejr", "Skyet", (int)NewWheatherType.SunIsComming)]
        [InlineData("Klart vejr", "Regn", (int)NewWheatherType.SunIsComming)]
        [InlineData("Klart vejr", "Sne", (int)NewWheatherType.SunIsComming)]
        [InlineData("Klart vejr", "Andet", (int)NewWheatherType.SunIsComming)]

        [InlineData("Skyet", "Klart vejr", (int)NewWheatherType.CloudIsComming )]
        [InlineData("Skyet", "Regn", (int)NewWheatherType.CloudIsComming)]
        [InlineData("Skyet", "Sne", (int)NewWheatherType.CloudIsComming)]
        [InlineData("Skyet", "Andet", (int)NewWheatherType.CloudIsComming)]

        [InlineData("Regn", "Klart vejr", (int)NewWheatherType.RainIsComming )]
        [InlineData("Regn", "Skyet", (int)NewWheatherType.RainIsComming)]
        [InlineData("Regn", "Sne", (int)NewWheatherType.RainIsComming)]
        [InlineData("Regn", "Andet", (int)NewWheatherType.RainIsComming)]

        [InlineData("Sne", "Klart vejr", (int)NewWheatherType.SnowIsComming )]
        [InlineData("Sne", "Skyet", (int)NewWheatherType.SnowIsComming)]
        [InlineData("Sne", "Regn", (int)NewWheatherType.SnowIsComming)]
        [InlineData("Sne", "Andet", (int)NewWheatherType.SnowIsComming)]

        [InlineData("Andet", "Klart vejr", (int)NewWheatherType.DollWheatherIsComming )]
        [InlineData("Andet", "Skyet", (int)NewWheatherType.DollWheatherIsComming)]
        [InlineData("Andet", "Regn", (int)NewWheatherType.DollWheatherIsComming)]
        [InlineData("Andet", "Sne", (int)NewWheatherType.DollWheatherIsComming)]

        public void Vejret_er_ændret_beskrivelse_korrekt(string wheatherTypeToDay, string wheatherTypeYesterday, int repeatWheater)
        {
            //arrange
            var weatherInfoYesterday = new WeatherInfo { Conditions = wheatherTypeYesterday, Temperature = 0 };
            var weatherInfoToday = new WeatherInfo { Conditions = wheatherTypeToDay, Temperature = 0 };
            var extpected = (NewWheatherType)repeatWheater;

            //act
            var result = weatherInfoToday.DescribeTemperatureChange(weatherInfoYesterday);
            //assert
            Assert.Equal(extpected.ToDescription(), result);
        }


    }
}
