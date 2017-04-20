using System;
using System.Globalization;
using System.Windows.Data;

namespace DirScanNet.Views.Converters
{
    [ValueConversion(typeof(long), typeof(string))]
    public class FileLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double fileLength = (long)value;
            if (fileLength < 1024) return $"{fileLength:0} Б";
            fileLength /= 1024;
            if (fileLength < 1024) return $"{fileLength:0.0} кБ";
            fileLength /= 1024;
            if (fileLength < 1024) return $"{fileLength:0.0} МБ";
            fileLength /= 1024;
            if (fileLength < 1024) return $"{fileLength:0.0} ГБ";
            fileLength /= 1024;
            return $"{fileLength:0.0} ТБ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}