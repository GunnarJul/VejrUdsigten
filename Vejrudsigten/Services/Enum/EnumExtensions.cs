using System;
using System.ComponentModel;

namespace Vejrudsigten.Services.Enum
{
    public static class EnumExtensions
    {
        public static string ToDescription(this System.Enum en)  
        {
            return en.ToDescription(en.ToString());
        }

        public static string ToDescription(this System.Enum value, string defaultValue)  
        {
            var type = value.GetType();
            var memInfo = type.GetMember(value.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return defaultValue;
        }
      
    }


}
