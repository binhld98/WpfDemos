using System.Globalization;
using System.Windows.Data;

namespace SolutionExplorer.Converters
{
    internal class BooleanConverter<T> : IValueConverter
    {
        public T True { get; set; }

        public T False { get; set; }

        public BooleanConverter(T @true, T @false)
        {
            True = @true;
            False = @false;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool && ((bool)value) ? True : False;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is T && EqualityComparer<T>.Default.Equals((T)value, True);
        }
    }
}
