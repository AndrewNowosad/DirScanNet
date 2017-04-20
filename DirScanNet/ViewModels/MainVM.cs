using DirScanNet.Models;
using DirScanNet.SettingsHelper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DirScanNet.ViewModels
{
    class MainVM : WindowVM
    {
        Folder currentFolder;
        public Folder CurrentFolder
        {
            get
            {
                return currentFolder;
            }
            set
            {
                Set(ref currentFolder, value);
                NotifyPropertyChanged(nameof(Items));
            }
        }

        public IEnumerable<FSItem> Items
        {
            get
            {
                return CurrentFolder?.ChildElements.OrderByDescending(item => item.Weight);
            }
        }

        DelegateCommand scanFolder;
        public ICommand ScanFolder
        {
            get
            {
                if (scanFolder == null)
                    scanFolder = new DelegateCommand(async o => await ScanAsync((string)o));
                return scanFolder;
            }
        }

        protected async Task ScanAsync(string path)
        {
            SaveSettings();
            CurrentFolder = await new FSScanner().GetFolderAsync(path);
        }

        public MainVM()
        {
            Title = "DirScanNet 1.0.0";
            LoadSettings();
        }

        void LoadSettings()
        {
            var settings = Settings.Instance.MainWindowSettings;
            WindowState = settings.WindowState;
            Width = settings.Width;
            Height = settings.Height;
            Left = settings.Left;
            Top = settings.Top;
        }

        void SaveSettings()
        {
            var settings = Settings.Instance.MainWindowSettings;
            settings.WindowState = WindowState;
            settings.Width = Width;
            settings.Height = Height;
            settings.Left = Left;
            settings.Top = Top;
            Settings.Save();
        }
    }
}