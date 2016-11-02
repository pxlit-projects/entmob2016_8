using System;
using Windows.UI.Xaml.Data;

namespace UWPMonitoring.App.Converters
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime date = ((DateTime)value);
            if (date == new DateTime())
            {
                return "This user doesn't have any sessions yet.";
            }
            else
            {
                return date.ToString("MMMM dd, yyyy");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
