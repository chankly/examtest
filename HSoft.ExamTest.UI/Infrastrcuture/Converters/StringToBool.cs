using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HSoft.ExamTest.UI.Infrastrcuture.Converters
{
    public class StringToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Convierte null o string vacío a false
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return Visibility.Collapsed;

            return Visibility.Visible; // Cualquier otro string devuelve true
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Opcional: convertir bool a string (si necesitas two-way binding)
            throw new NotImplementedException();
        }
    }
}
