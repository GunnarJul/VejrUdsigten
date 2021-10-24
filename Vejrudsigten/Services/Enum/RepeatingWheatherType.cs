using System.ComponentModel;

namespace Vejrudsigten.Services.Enum
{
    public enum RepeatingWheatherType
    {
        [Description("Mere Sol i vente.")]
        SunIsStaying = 1,

        [Description("Nu vælter det ned.")]
        RainIsStaying = 2,

        [Description("Mere regn i vente. Klimaændringerne er over os.")]
        SnowIsStaying = 3,

        [Description("Der trist vejr fortsætter.")]
        CloudIsStaying = 4,

        [Description("Kedeligt vejr igen i dag.")]
        DollWheatherIsStaying = 5

    }
}
