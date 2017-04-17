using System.IO;

namespace DirScanNet.Models
{
    class File : FSItem
    {
        public File(string path) : base(path)
        {
            Weight = new FileInfo(path).Length;
        }
    }
}