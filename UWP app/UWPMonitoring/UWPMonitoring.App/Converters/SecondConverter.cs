using System;
using Windows.UI.Xaml.Data;

namespace UWPMonitoring.App.Converters
{
    public class SecondConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int uren = (int)value / 3600;
            int restVanUren = (int)value % 3600;
            int minuten = restVanUren / 60;
            int seconden = restVanUren % 60;

            return String.Format("{0} Uren, {1} Minuten en {2} Seconden", uren, minuten, seconden);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
