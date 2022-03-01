using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TP01_HeartDiseaseDiagnostic;

namespace TP1_app_BLP.ViewsModels.Converters
{
    public class ManConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Person.GenderEnum)value == Person.GenderEnum.Man;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Person.GenderEnum.Man : Person.GenderEnum.Woman;
        }
    }
}
