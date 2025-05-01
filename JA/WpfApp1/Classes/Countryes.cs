using System.ComponentModel;
using System.Diagnostics.Metrics;

namespace JA.Classes
{
    public enum Country
    {
        [Description("Россия")]
        Russia,

        [Description("Соединённые Штаты Америки")]
        USA,

        [Description("Германия")]
        Germany,

        [Description("Франция")]
        France,

        [Description("Китай")]
        China,

        [Description("Япония")]
        Japan,

        [Description("Великобритания")]
        UK,

        [Description("Канада")]
        Canada,

        [Description("Бразилия")]
        Brazil,

        [Description("Австралия")]
        Australia,

        [Description("Буларусь")]
        Belarus,

        [Description("Украина")]
        Ukrain
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
