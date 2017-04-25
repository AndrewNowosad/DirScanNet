using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirScanNet.Models
{
    class ComputerRoot : Folder
    {
        static public ComputerRoot GetComputerRoot()
        {
            if (ItemsCache.ContainsKey(ComputerRootAlias))
                return (ComputerRoot)ItemsCache[ComputerRootAlias];
            return new ComputerRoot();
        }

        ComputerRoot() : base(ComputerRootAlias) { }

        protected override void RescanPath()
        {
            childElements = new List<FSItem>();
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