using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public IReadOnlyList<Folder> GetRootFolders()
        {
            return DriveInfo.GetDrives()
                            .Select(d => GetFolder(d.RootDirectory.FullName))
                            .ToList();
        }

        public async Task<IReadOnlyList<Folder>> GetRootFoldersAsync()
        {
            return await Task.Run(() => GetRootFolders());
        }
    }
}