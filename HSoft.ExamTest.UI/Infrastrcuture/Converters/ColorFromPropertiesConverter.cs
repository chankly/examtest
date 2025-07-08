using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace HSoft.ExamTest.UI.Infrastrcuture.Converters
{
    public class ColorFromBoolPropertiesConverter : IMultiValueConverter
    {
        public object Convert(object[] inputs, Type targetType, object parameter, CultureInfo culture)
        {
            // Asumimos que 'value' es un array de objetos con los dos booleanos
            if (inputs is object[] values && values.Length == 2)
            {
                bool isValid = (bool)values[0];  // Ej: IsValid
                bool showCorrection = (bool)values[1]; // Ej: ShowCorrection

                if (showCorrection)
                {
                    return isValid ? Brushes.Green : Brushes.Red;
                }
            }
            return Brushes.Transparent;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
