using System.Windows;

namespace SolutionExplorer.Converters
{
    internal sealed class BooleanToVisibilityConverter : BooleanConverter<Visibility>
    {
        public BooleanToVisibilityConverter() : base(Visibility.Visible, Visibility.Hidden)
        {

        }
    }
}
