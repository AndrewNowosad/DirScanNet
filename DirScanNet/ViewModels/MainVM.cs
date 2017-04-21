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
        string currentPath;
        public string CurrentPath
        {
            get
            {
                return currentPath;
            }
            set
            {
                Set(ref currentPath, value);
            }
        }

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
                NotifyPropertyChanged(nameof(MaxWeight));
            }
        }

        public IEnumerable<FSItem> Items
        {
            get
            {
                return CurrentFolder?.ChildElements.OrderByDescending(item => item.Weight);
            }
        }

        public long MaxWeight => Items.First().Weight;

        bool isProcess;
        public bool IsProcess
        {
            get
            {
                return isProcess;
            }
            protected set
            {
                Set(ref isProcess, value);
            }
        }

        DelegateCommand scanFolder;
        public ICommand ScanFolder
        {
            get
            {
                if (scanFolder == null)
                    scanFolder = new DelegateCommand(async o => await ScanAsync());
                return scanFolder;
            }
        }

        DelegateCommand openFolder;
        public ICommand OpenFolder
        {
            get
            {
                if (openFolder == null)
                    openFolder = new DelegateCommand(o => Open((FSItem)o));
                return openFolder;
            }
        }

        protected async Task ScanAsync()
        {
            IsProcess = true;
            SaveSettings();
            CurrentFolder = await new FSScanner().GetFolderAsync(CurrentPath);
            IsProcess = false;
        }

        protected void Open(FSItem item)
        {
            var folder = item as Folder;
            if (folder == null) return;
            CurrentFolder = folder;
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
            CurrentPath = settings.CurrentPath;
        }

        void SaveSettings()
        {
            var settings = Settings.Instance.MainWindowSettings;
            settings.WindowState = WindowState;
            settings.Width = Width;
            settings.Height = Height;
            settings.Left = Left;
            settings.Top = Top;
            settings.CurrentPath = CurrentPath;
            Settings.Save();
        }
    }
}