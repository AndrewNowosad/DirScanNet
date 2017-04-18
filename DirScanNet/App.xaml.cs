using DirScanNet.ViewModels;
using DirScanNet.Views;
using System.Windows;

namespace DirScanNet
{
    public partial class App : Application
    {
        public App()
        {
            var mainVM = new MainVM();
            var mainView = new MainWindow { DataContext = mainVM };
            mainView.Show();
        }
    }
}