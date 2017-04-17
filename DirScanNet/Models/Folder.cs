using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirScanNet.Models
{
    class Folder : FSItem
    {
        List<FSItem> childElements;
        public IReadOnlyList<FSItem> ChildElements => childElements;

        public Folder(string path) : base(path)
        {
            RescanPath();
        }

        void RescanPath()
        {
            childElements = new List<FSItem>();
            foreach (var dir in Directory.EnumerateDirectories(FullPhysicalPath))
                childElements.Add(new Folder(dir));
            foreach (var file in Directory.EnumerateFiles(FullPhysicalPath))
                childElements.Add(new File(file));
            Weight = childElements.Sum(item => item.Weight);
        }
    }
}