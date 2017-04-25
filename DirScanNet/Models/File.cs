using System.IO;

namespace DirScanNet.Models
{
    class File : FSItem
    {
        static public File GetFile(string path)
        {
            if (ItemsCache.ContainsKey(path)) return (File)ItemsCache[path];
            return new File(path);
        }

        File(string path) : base(path)
        {
            Weight = new FileInfo(path).Length;
        }

        public override string ToString() => $"File: {Name}";
    }
}