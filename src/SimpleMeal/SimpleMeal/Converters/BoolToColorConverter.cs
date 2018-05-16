using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SimpleMeal.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Future addition - on color and off color as parameters
            if ((bool)value)
            {
                return Color.FromHex("#1CBA6E");
            }
            else
            {
                return Color.FromHex("#AAAAAA");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
