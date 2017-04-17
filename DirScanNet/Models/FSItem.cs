using System.IO;

namespace DirScanNet.Models
{
    abstract class FSItem
    {
        public string Name { get; protected set; }
        public string FullPhysicalPath { get; protected set; }
        public long Weight { get; protected set; }

        public FSItem(string path)
        {
            FullPhysicalPath = path;
            Name = Path.GetFileName(path);
        }
    }
}