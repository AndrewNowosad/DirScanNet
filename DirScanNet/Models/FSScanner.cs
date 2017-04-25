using System.Threading.Tasks;

namespace DirScanNet.Models
{
    class FSScanner
    {
        public Folder GetFolder(string path) => Folder.GetFolder(path);

        public async Task<Folder> GetFolderAsync(string path)
        {
            return await Task.Run(() => GetFolder(path));
        }

        public Folder GetParent(FSItem fsItem) =>  fsItem.GetParent();

        public async Task<Folder> GetParentAsync(FSItem fsItem)
        {
            return await Task.Run(() => GetParent(fsItem));
        }

        public ComputerRoot GetComputerRoot() => ComputerRoot.GetComputerRoot();

        public async Task<ComputerRoot> GetComputerRootAsync()
        {
            return await Task.Run(() => GetComputerRoot());
        }
    }
}