using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SolutionExplorer.Converters
{
    internal class TreeViewItemIndentConverter : IMultiValueConverter
    {
        public readonly int IndentSize = 16;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is not TreeViewItem item)
                return 0d;

            int level = 0;
            DependencyObject parent = item;
            while ((parent = VisualTreeHelper.GetParent(parent)) != null)
            {
                if (parent is TreeViewItem)
                    level++;
            }

            return (double)(level * IndentSize);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
