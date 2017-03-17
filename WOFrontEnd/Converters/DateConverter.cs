using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using WorkOutClass;

namespace WOFrontEnd.Converters
{
    class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var srcDate = (DateTime)value;
            return srcDate.ToString("d");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var strDate = value as string;
            try
            {
               DateTime newDate = DateTime.Parse(strDate);
                return newDate;
            }
            catch (ArgumentOutOfRangeException e)
            {
                return DateTime.Now;
            }
        }
    }
}
