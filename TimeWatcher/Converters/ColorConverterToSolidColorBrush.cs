using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TimeWatcher.Converters
{
    [ValueConversion(typeof(System.Drawing.Color), typeof(System.Windows.Media.Color))]
    public class ColorConverterToSolidColorBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() == typeof(System.Drawing.Color))
                return new System.Windows.Media.SolidColorBrush(Internal.ColorConverter.DrawingColorToMediaColor((System.Drawing.Color)value));

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() == typeof(System.Windows.Media.SolidColorBrush))
            {
                System.Windows.Media.SolidColorBrush brush = (System.Windows.Media.SolidColorBrush)value;
                return Internal.ColorConverter.MediaColorToDrawingColor(brush.Color);
            }

            return null;
        }
    }
}
