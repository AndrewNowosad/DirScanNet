using DirScanNet.Views;
using System.Windows;

namespace DirScanNet
{
    public partial class App : Application
    {
        public App()
        {
            var mainWin = new MainWindow();
            mainWin.Show();
        }
    }
}