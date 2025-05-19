using System.Globalization;

namespace MauiApp2Net9
{
    public class GridHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var width = (double)value;

            if (width > -1)
            {
                int.TryParse(parameter.ToString(), out int columns);

                var calculatedWidth = width;

                if (columns > 0)
                {
                    calculatedWidth = width / columns;
                }

                return (int)Math.Round(calculatedWidth);
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
