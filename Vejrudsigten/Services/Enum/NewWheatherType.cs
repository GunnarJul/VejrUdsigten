using System.ComponentModel;

namespace Vejrudsigten.Services.Enum
{
    public enum NewWheatherType
    {
        [Description("Sol på vej.")]
        SunIsComming = 1,

        [Description("Nu vælter det ned.")]
        RainIsComming = 2,

        [Description("Sne flokkene kommer vrimlende.")]
        SnowIsComming = 3,

        [Description("Overskyet og trist vejr.")]
        CloudIsComming = 4,

        [Description("Kedeligt vejr.")]
        DollWheatherIsComming = 5
    }
}
