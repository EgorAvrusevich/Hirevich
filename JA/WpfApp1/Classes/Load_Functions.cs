using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace JA.Classes
{
    class Load_Functions
    {
        public static BitmapImage LoadImageFromFile(string filePath)
        {
            // Создание BitmapImage
            var bitmap = new BitmapImage();

            // Инициализация с настройками для оптимальной загрузки
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(filePath);
            bitmap.CacheOption = BitmapCacheOption.OnLoad; // Загрузка сразу в память
            bitmap.EndInit();
            bitmap.Freeze(); // Для безопасного использования в других потоках

            return bitmap;
        }

        public static byte[]? ConvertImageToBytes(BitmapImage image)
        {
            if (image.UriSource != null && image.UriSource.IsFile)
            {
                return File.ReadAllBytes(image.UriSource.LocalPath);
            }
            else if (image.StreamSource != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(image));
                    encoder.Save(memoryStream);
                    return memoryStream.ToArray();
                }
            }
            return null;
        }

        public static BitmapImage ConvertBytesToImage(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
                return null;

            var bitmapImage = new BitmapImage();

            using (var memoryStream = new MemoryStream(imageBytes))
            {
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.EndInit();
            }

            // Для корректного использования в разных потоках
            bitmapImage.Freeze();

            return bitmapImage;
        }
    }
    public class GreaterThanZeroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
