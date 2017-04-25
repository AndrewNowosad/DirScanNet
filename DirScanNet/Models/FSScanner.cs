using System.Threading.Tasks;

namespace DirScanNet.Models
{
    class FSScanner
    {
        public Folder GetFolder(string path) => (Folder)Folder.GetFolder(path);

        public async Task<Folder> GetFolderAsync(string path)
        {
            return await Task.Run(() => GetFolder(path));
        }

        public ComputerRoot GetComputerRoot()
        {
            return (ComputerRoot)ComputerRoot.GetComputerRoot();
        }

        public async Task<ComputerRoot> GetComputerRootAsync()
        {
            return await Task.Run(() => GetComputerRoot());
        }
    }
}