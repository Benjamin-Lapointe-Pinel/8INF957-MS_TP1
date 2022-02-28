using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TP1_app_BLP.ViewsModels.Converters
{
    // https://stackoverflow.com/a/41956317
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateOnly)value).ToDateTime(TimeOnly.MinValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateOnly.FromDateTime((DateTime)value);
        }
    }
}
