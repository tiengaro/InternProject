using System;
using System.Globalization;
using Xamarin.Forms;

namespace InternProject.Converters
{
    public class DateTimeToDateTimeOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var dto = (DateTimeOffset) value;
                return dto.DateTime;
            }
            catch (Exception)
            {
                return DateTimeOffset.MinValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var date = (DateTime) value;
                return new DateTimeOffset(date);
            }
            catch (Exception)
            {
                return DateTimeOffset.MinValue;
            }
        }
    }
}