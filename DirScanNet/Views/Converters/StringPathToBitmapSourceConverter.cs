using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace DirScanNet.Views.Converters
{
    [ValueConversion(typeof(string), typeof(BitmapSource))]
    public class StringPathToBitmapSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = (string)value;
            if (File.Exists(path)) return GetFileIcon(path);
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        object GetFileIcon(string path)
        {
            using (var sysicon = Icon.ExtractAssociatedIcon(path))
                return Imaging.CreateBitmapSourceFromHIcon(sysicon.Handle,
                            Int32Rect.Empty,
                            BitmapSizeOptions.FromEmptyOptions());
        }
    }
}