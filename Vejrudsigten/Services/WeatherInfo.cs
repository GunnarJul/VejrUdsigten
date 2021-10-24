using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Vejrudsigten.Services.Enum;

namespace Vejrudsigten.Services
{
    public class WeatherInfo
    {

        private readonly Dictionary<double, WeatherType> _tempType;
        private readonly Dictionary<double, TemperatureTendency> _tempChange ;

        private readonly Dictionary<string, NewWheatherType> _changedWheater;
        private readonly Dictionary<string, RepeatingWheatherType> _unChangedWheater;
        

        public WeatherInfo()
        {
            _tempType = new Dictionary<double, WeatherType>{  
                { -10, WeatherType.Arktiske },
                { 0, WeatherType.Vinterlige },
                { 20, WeatherType.IkkeBeskrevet },
                { 30, WeatherType.Sommerlige },
                { double.MaxValue ,  WeatherType.Tropiske },
            };
            _tempChange = new Dictionary<double, TemperatureTendency>{
                { -10.1,TemperatureTendency.VerySignificantDescreasing  },
                { -3.1, TemperatureTendency.SignificantDescreasing },
                { -1.1, TemperatureTendency.Descreasing  },
                 { 3, TemperatureTendency.Increasing  },
                 { 10,  TemperatureTendency.SignificantIncreasing},
                 { double.MaxValue ,  TemperatureTendency.VerySignificantIncreasing },
            };

            _changedWheater = new Dictionary<string, NewWheatherType>
            {
                { "Klart vejr",NewWheatherType.SunIsComming },
                { "Regn", NewWheatherType.RainIsComming},
                { "Sne",NewWheatherType.SnowIsComming},
                { "Skyet",NewWheatherType.CloudIsComming },
                { "Andet",NewWheatherType.DollWheatherIsComming},
            };

            _unChangedWheater = new Dictionary<string, RepeatingWheatherType>
            {
                { "Klart vejr",RepeatingWheatherType.SunIsStaying},
                { "Regn",RepeatingWheatherType.RainIsStaying },
                { "Sne", RepeatingWheatherType.SnowIsStaying  },
                { "Skyet",RepeatingWheatherType.CloudIsStaying  },
                { "Andet",RepeatingWheatherType.DollWheatherIsStaying},
            };

        }
        /// <summary>
        /// En af følgende vejrtyper:
        /// Klart vejr
        /// Regn
        /// Sne
        /// Skyet
        /// Andet
        /// </summary>
        public string Conditions { get; set; }

        /// <summary>
        /// Temperaturen i celcius
        /// </summary>
        public double Temperature { get; set; }

        public string DescribeTemperatureChange(WeatherInfo anotherWheater)
        {
            return $"{WheatherType(anotherWheater)} {TemperatureType.ToDescription() } {TemperatureChangeFind( anotherWheater).ToDescription() }".Trim();
        }
        public string WheatherType (WeatherInfo anotherWheater)
        {
            if (Conditions == anotherWheater.Conditions)
                return _unChangedWheater[Conditions].ToDescription();
            return _changedWheater[Conditions].ToDescription(); 
        }

        public WeatherType TemperatureType => TemperatureTypeFind; 
        private WeatherType TemperatureTypeFind { get
            {
                foreach (var key in _tempType.Keys.OrderBy (k => k))
                {
                    if (Temperature < key)
                        return _tempType[key] ;
                }
                return WeatherType.IkkeBeskrevet ;
            } }

        public TemperatureTendency TemperatureChange(WeatherInfo anotherDay) => TemperatureChangeFind(anotherDay);
        private TemperatureTendency TemperatureChangeFind(WeatherInfo anotherDay)
        {
            var temperatureDelta = Temperature - anotherDay.Temperature; 
            if (temperatureDelta <= 1 && temperatureDelta >= -1) return TemperatureTendency.NoChange;

            foreach ( var key in _tempChange.Keys.OrderBy (k => k))
            {
                if (temperatureDelta < 0 && key < 0 && key >= temperatureDelta)
                    return _tempChange[key];
                if (temperatureDelta > 0 && key > 0 &&  key >=  temperatureDelta)
                    return _tempChange[key];
            }
            return TemperatureTendency.NoChange;
        }
    }




}
