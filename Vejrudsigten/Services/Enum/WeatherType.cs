using System.ComponentModel;

namespace Vejrudsigten.Services.Enum
{
    public enum WeatherType
    {
        [Description("Arktiske")]
        Arktiske = 0,

        [Description("Vinterlige")]
        Vinterlige = 1,

        [Description("")]
        IkkeBeskrevet = 2,

        [Description("Sommerlige")]
        Sommerlige = 3,

        [Description("Tropiske")]
        Tropiske = 4
    }
}
