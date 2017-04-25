using System.IO;
using System.Linq;

namespace DirScanNet.Models
{
    class ComputerRoot : Folder
    {
        static public FSItem GetComputerRoot()
        {
            if (ItemsCache.ContainsKey(ComputerRootAlias))
                return ItemsCache[ComputerRootAlias];
            return new ComputerRoot();
        }

        ComputerRoot() : base(ComputerRootAlias) { }

        protected override void RescanPath()
        {
            var drives = DriveInfo.GetDrives()
                                  .Select(d => d.RootDirectory.FullName);
            foreach (var drive in drives)
                childElements.Add(GetFolder(drive));
        }

        public override string ToString()
        {
            return ComputerRootAlias;
        }
    }
}