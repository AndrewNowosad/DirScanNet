using DirScanNet.Models;
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
            CurrentFolder = await new FSScanner().GetFolderAsync(path);
        }
    }
}