using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace JA.Classes
{
    public class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return string.Empty;

            var field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();

            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(
                field,
                typeof(DescriptionAttribute));

            return attribute?.Description ?? value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}