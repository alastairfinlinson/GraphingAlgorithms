using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using GraphingAlgorithms.GraphObjects;

namespace GraphingAlgorithmsUI.Converters
{
    public class MarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new Thickness()
            {
                Top = (double)values[1],
                Left = (double)values[0],
                Right = 0,
                Bottom = 0
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
