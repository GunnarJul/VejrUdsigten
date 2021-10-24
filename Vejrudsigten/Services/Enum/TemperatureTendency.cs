using System.ComponentModel;

namespace Vejrudsigten.Services.Enum
{
    public enum TemperatureTendency
    {
        [Description("Krafigt faldende temperaturer.")]
        VerySignificantDescreasing = 0,

        [Description("Stærkt faldende temperaturer.")]
        SignificantDescreasing = 1,

        [Description("Faldende temperaturer.")]
        Descreasing = 2,

        [Description("")]
        NoChange = 3,

        [Description("Stigende temperaturer.")]
        Increasing = 4,

        [Description("Stærkt stigende temperaturer.")]
        SignificantIncreasing = 5,

        [Description("Kraftigt stigende temperaturer.")]
        VerySignificantIncreasing = 6

    }


}
