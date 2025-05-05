using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace JA.Classes
{
    public enum Country
    {
        [Description("Россия")]
        russia,

        [Description("Соединённые Штаты Америки")]
        usa,

        [Description("Германия")]
        germany,

        [Description("Франция")]
        france,

        [Description("Китай")]
        china,

        [Description("Япония")]
        japan,

        [Description("Великобритания")]
        UK,

        [Description("Канада")]
        canada,

        [Description("Бразилия")]
        brazil,

        [Description("Австралия")]
        australia,

        [Description("Буларусь")]
        belarus,

        [Description("Украина")]
        ukraine,
        
        [Description("Другая")]
        others
    }

    public static class CountryExtensions
    {
        public static string GetName(this Country country)
        {
            var field = country.GetType().GetField(country.ToString());
            var attribute = field.Attributes.ToString();
            return attribute ?? country.ToString();
        }
    }

}
