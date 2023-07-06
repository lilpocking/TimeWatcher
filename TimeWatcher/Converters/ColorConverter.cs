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
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() == typeof(System.Drawing.Color))
                return Internal.ColorConverter.DrawingColorToMediaColor((System.Drawing.Color)value);

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() == typeof(System.Windows.Media.Color))
                return Internal.ColorConverter.MediaColorToDrawingColor((System.Windows.Media.Color)value);

            return null;
        }
    }
}
