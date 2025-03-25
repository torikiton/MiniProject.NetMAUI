using System.Globalization;

namespace MiniProject.Converters
{
    public class TermToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return Colors.White;

            string selectedTerm = value.ToString();
            string termParameter = parameter.ToString();

            return selectedTerm == termParameter ? Colors.LightGray : Colors.White;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}