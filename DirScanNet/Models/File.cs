using System.IO;

namespace DirScanNet.Models
{
    class File : FSItem
    {
        static public FSItem GetFile(string path)
        {
            if (ItemsCache.ContainsKey(path)) return ItemsCache[path];
            return new File(path);
        }

        File(string path) : base(path)
        {
            Weight = new FileInfo(path).Length;
        }

        public override string ToString() => $"File: {Name}";
    }
}