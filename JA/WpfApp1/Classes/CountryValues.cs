using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace JA.Classes
{
    public static class CountryValues
    {
        public static IEnumerable<Country> Values =>
            Enum.GetValues(typeof(Country)).Cast<Country>();

        public static string GetDescription(Country value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(
                field,
                typeof(DescriptionAttribute));
            return attribute?.Description ?? value.ToString();
        }
    }
}