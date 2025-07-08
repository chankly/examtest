using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace HSoft.ExamTest.UI.Infrastrcuture.Converters
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return null;

            string imageName = value?.ToString();
            var imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", imageName);

            if (!System.IO.File.Exists(imagePath))
            {
                return null;
            }
            return new BitmapImage(new Uri(imagePath, UriKind.Absolute));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
