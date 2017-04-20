using System.Windows;

namespace DirScanNet.SettingsHelper
{
    public class MainWindowSettings
    {
        public WindowState WindowState { get; set; } = WindowState.Normal;
        public double Width { get; set; } = 840;
        public double Height { get; set; } = 500;
        public double Left { get; set; } = 250;
        public double Top { get; set; } = 110;
    }
}